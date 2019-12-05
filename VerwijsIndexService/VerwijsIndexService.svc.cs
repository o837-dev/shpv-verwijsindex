using System;
using System.ServiceModel;
using Denion.WebService.Database;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using System.Configuration;
using System.Text.RegularExpressions;
using System.ServiceModel.Channels;

namespace Denion.WebService.VerwijsIndex
{
    [LogBehavior]
    [ServiceBehavior(Name = "VerwijsIndex", Namespace = "https://verwijsindex.shpv.nl/service/")]
    public class VerwijsIndexService : IVerwijsIndex
    {
        public VerwijsIndexService()
        {
            if (Thread.CurrentThread.Name == null)
            {
                Thread.CurrentThread.Name = "VerwijsIndexService";
            }
        }

        #region IVerwijsIndex interface implementatie

        /// <summary>
        /// Webservice ingang, voertuig rijd garage in
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PaymentStartResponse IVerwijsIndex.PaymentStart(PaymentStartRequest request) {
            Timing t = new Timing("PaymentStart", Service.IncomingAddress(), Service.OperationContextAddress());
            PaymentStartResponse res = new PaymentStartResponse();
            
            Err err = request.IsValid();
            if (err != null) {
                res.Remark = err.Remark;
                res.RemarkId = err.RemarkId;
            } else {
                PaymentStartWorker psw = new PaymentStartWorker(request);
                Thread newThread = new Thread(new ThreadStart(psw.Settle));
                newThread.Name = "PaymentStart+" + request.VehicleId;
                newThread.Start();

                if (newThread.Join(DatabaseFunctions.GetProperty("StartRequestTimeout", 2000))) {
                    res = psw.Result as PaymentStartResponse;
                } else {
                    psw.Abort();
                    if (psw.Result != null) {
                        res = psw.Result as PaymentStartResponse;
                    } else {
                        res.Remark = "PaymentServiceProvider does not respond";
                        res.RemarkId = "15";
                    }
                }

                if (string.IsNullOrEmpty(res.Remark)) {
                    if(string.IsNullOrEmpty(res.PaymentAuthorisationId)) {
                        res.Remark = "No PaymentServiceProvider for this VehicleId";
                        res.RemarkId = "10";

                        if(psw.AuthorisationRecordId != null)
                            DatabaseFunctions.UnregisterRequest(psw.AuthorisationRecordId);
                    }
                }
            }
            t.Finish();
            return res;
        }

        /// <summary>
        /// Webservice ingang, voertuig verlaat garage
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PaymentEndResponse IVerwijsIndex.PaymentEnd(PaymentEndRequest request)
        {
            Timing t = new Timing("PaymentEnd", Service.IncomingAddress(), Service.OperationContextAddress());
            PaymentEndResponse res = Stop(request);
            t.Finish();
            return res;
        }

        /// <summary>
        /// Webservice ingang, controleren of voertuig toegang heeft
        /// </summary>
        /// <param name="PaymentCheckRequest"></param>
        /// <returns></returns>
        PaymentCheckResponse IVerwijsIndex.PaymentCheck(PaymentCheckRequest request)
        {
            Timing t = new Timing("PaymentCheck", Service.IncomingAddress(), Service.OperationContextAddress());
            PaymentCheckResponse res = new PaymentCheckResponse();

            Err err = request.IsValid();
            if (err != null)
            {
                res.Remark = err.Remark;
                res.RemarkId = err.RemarkId;
            }
            else
            {
                PaymentCheckWorker pcw = new PaymentCheckWorker(request);
                Thread newThread = new Thread(new ThreadStart(pcw.Settle));
                newThread.Name = "PaymentCheck+" + request.VehicleId;
                newThread.Start();

                if (newThread.Join(DatabaseFunctions.GetProperty("StartRequestTimeout", 2000)))
                {
                    res = pcw.Result as PaymentCheckResponse;
                }
                else
                {
                    pcw.Abort();
                    if (pcw.Result != null)
                    {
                        res = pcw.Result as PaymentCheckResponse;
                    }
                    else
                    {
                        res.Remark = "PaymentServiceProvider does not respond";
                        res.RemarkId = "15";
                    }
                }

                if (string.IsNullOrEmpty(res.Remark))
                {
                    if (!res.Granted.HasValue)
                    {
                        res.Remark = "No PaymentServiceProvider for this VehicleId";
                        res.RemarkId = "10";
                    }
                }
            }
            t.Finish();
            return res;
        }

        StatusResponse IVerwijsIndex.ServiceStatus()
        {
            return Service.ServiceStatus();
        }
        #endregion

        /// <summary>
        /// implementatie, voertuig verlaat garage
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private static PaymentEndResponse Stop(PaymentEndRequest request)
        {
            PaymentEndResponse res = new PaymentEndResponse();

            Err err = request.IsValid();
            if (err != null) {
                res.Remark = err.Remark;
                res.RemarkId = err.RemarkId;
            } else {
                SqlCommand com = new SqlCommand();
                com.CommandText = @"Select p.id as [PROVIDERID], p.DESCRIPTION, p.URL, c.NPRREGISTRATION, a.STARTDATE, a.AREAID, a.AREAMANAGERID, p.PROTOCOLL, a.SETTLED
                    from Authorisation a join Provider p on a.PROVIDERID=p.ID join Contract c on  a.AREAMANAGERID= c.AREAMANAGERID and c.PROVIDERID2 = p.PID
                    where a.AUTHORISATIONID=@AUTHORISATIONID";

                com.Parameters.Add("@AUTHORISATIONID", System.Data.SqlDbType.NVarChar, 50).Value = request.PaymentAuthorisationId;
                if (!string.IsNullOrEmpty(request.VehicleIdType)) {
                    com.CommandText += " AND (a.VEHICLEIDTYPE=@VEHICLEIDTYPE OR a.VEHICLEIDTYPE IS NULL)";
                    com.Parameters.Add("@VEHICLEIDTYPE", System.Data.SqlDbType.NVarChar, 50).Value = request.VehicleIdType;
                }

                DataTable dt = Database.Database.ExecuteQuery(com);
                if (dt != null) {
                    foreach (DataRow dr in dt.Rows) {
                        Provider p = new Provider(dr);

                        if((Boolean)dr["SETTLED"] == true) {
                            res.Remark = "Authorisation already settled";
                            res.RemarkId = "110";
                        } else { 

                            new Thread(() => {
                                Thread.CurrentThread.IsBackground = true;

                                request.ProviderId = (string)dr["PROVIDERID"];

                                //Bericht naar provider
                                WorkerFunctions.PaymentEndWrapper(p, request);
                            }).Start();

                            if (request.PaymentAuthorisationId != null) {
                                object PSRightID = DBNull.Value;
                                Database.Database.Log("Payment end reg? " + p.NPRRegistration);

                                //Registratie in NPR
                                if (p.NPRRegistration) {
                                    RDWRight r = WebService.Functions.RDWEnrollRight((string)dr["PROVIDERID"], (string)dr["AreaManagerId"], (string)dr["AreaId"], "BETAALDP", request.VehicleId, (DateTime)dr["STARTDATE"], request.EndDateTime, request.CountryCode, Convert.ToDecimal(request.Amount), Convert.ToDecimal(request.VAT), "" + request.PaymentAuthorisationId);
                                    if (r.PSRightId != null)
                                        PSRightID = r.PSRightId;
                                    if (!string.IsNullOrEmpty(r.Remark))
                                    {
                                        res.RemarkId = "120";
                                        res.Remark = "Problem with NPR registration; " + r.Remark;
                                    }
                                }
                                AuthorisationSettled(request.PaymentAuthorisationId.ToString(), PSRightID);
                                res.PaymentAuthorisationId = request.PaymentAuthorisationId;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    res.Remark = "No matching authorisation could be found";
                    res.RemarkId = "95";
                }


            }
            return res;
        }

        /// <summary>
        /// Update Autorisation request in the database, mark the record as settled
        /// </summary>
        /// <param name="PaymentAuthorisationId">Provider authorisation ID</param>
        private static void AuthorisationSettled(string PaymentAuthorisationId, object PSRightId)
        {
            SqlCommand com = new SqlCommand();
            com.CommandText = "Update Authorisation set SETTLED=@SETTLED, PSRIGHTID=@PSRIGHTID, LINKID=@LINKID where AUTHORISATIONID=@AUTHORISATIONID";
            com.Parameters.Add("@SETTLED", SqlDbType.Bit).Value = true;
            com.Parameters.Add("@AUTHORISATIONID", SqlDbType.VarChar, 50).Value = PaymentAuthorisationId;
            com.Parameters.Add("@PSRIGHTID", SqlDbType.NVarChar, 50).Value = PSRightId;
            com.Parameters.Add("@LINKID", SqlDbType.Int).Value = DBNull.Value;

            Database.Database.ExecuteQuery(com);
        }

        /// <summary>
        /// Class om het inrijd verzoek via een thread af te handelen
        /// </summary>
        class PaymentStartWorker : Worker {
            /// <summary>
            /// Verzoek bericht
            /// </summary>
            private PaymentStartRequest _request;

            /// <summary>
            /// Antwoord bericht
            /// </summary>
            private PaymentStartResponse _response;

            /// <summary>
            /// Constructor, stores the request and prepares the Result
            /// </summary>
            /// <param name="request"></param>
            public PaymentStartWorker(PaymentStartRequest request)
            {
                this._request = request;
                this._response = new PaymentStartResponse();
            }

            public override object Request
            {
                get
                {
                    return _request;
                }

                set
                {
                    _request = value as PaymentStartRequest;
                }
            }

            /// <summary>
            /// Result of the webservice call
            /// </summary>
            public override object Result {
                get { return _response; }
            }

            /// <summary>
            /// Het ingediende verzoek afmelden, op bais van eigen logica, om de administratie op orde te houden
            /// </summary>
            public override void UnSettle() {
                //Database.Database.Log("UnSettle: '" + _request.VehicleId + "' for " + _request.AreaId);

                PaymentEndRequest abortReq = new PaymentEndRequest();

                abortReq.ProviderId = _response.ProviderId;
                abortReq.PaymentAuthorisationId = _response.PaymentAuthorisationId;
                abortReq.VehicleId = _request.VehicleId;
                abortReq.CountryCode = _request.CountryCode;
                abortReq.EndDateTime = _request.StartDateTime;
                abortReq.Amount = _request.Amount;
                abortReq.VAT = _request.VAT;

                VerwijsIndexService.Stop(abortReq);
            }

            /// <summary>
            /// Main function
            /// </summary>
            public override void Settle() {
                try {
                    _requestid = DatabaseFunctions.RegisterRequest(_request.AccessId, _request.VehicleId, _request.CountryCode, _request.AreaManagerId, _request.StartDateTime, _request.AreaId, _request.VehicleIdType, "");

                    Providers providers = DatabaseFunctions.ListOfProvider(_request.AreaManagerId, _request.StartDateTime);
                    if (providers.Count > 0) {
                        foreach (Provider p in providers) {
                            if (_aborted) break;
                            

                            Link link = DatabaseFunctions.GetLink(p.id, _request.VehicleId, _request.StartDateTime, _request.EndDateTime, _request.Amount, _request.AreaId, true, _request.VehicleIdType);
                            //if (linkid != null)
                            //    Database.Database.Log("[PaymentStart] LinkID: " + linkid.ToString());

                            if (p.sendlinkrequest == Provider.SendLinkRequest.NO)
                            {
                                // geen autorisatieverzoeken voor voertuigen waarvoor geen koppeling bestaat
                                if (link == null)
                                    continue;
                            }
                            else if (p.sendlinkrequest == Provider.SendLinkRequest.IMPLICIT)
                            {
                                // autorisatieverzoek sturen en als daar een positief antwoord op komt een koppeling registreren met de einddatumtijd van de autorisatie als einddatumtijd van de koppeling
                            }

                            //Database.Database.Log("[PaymentStart] Checking: " + p.description);
                            Database.Database.Log("[Provider]: " + p.id);
                            PaymentStartResponse relayRes = WorkerFunctions.PaymentStartWrapper(p, _request);

                            if (relayRes != null) {
                                _response = relayRes;

                                if(relayRes.PaymentAuthorisationId != null) { 
                                    _settled = true;

                                    if (link != null)
                                    {
                                        if (p.sendlinkrequest != Provider.SendLinkRequest.NO)
                                        {
                                            // don't update records of a static provider
                                            DatabaseFunctions.UpdateLink(_request.CountryCode, _response.AuthorisationMaxAmount, _request.StartDateTime, _response.AuthorisationValidUntil, _response.Token, link.ID, null, _response.TokenType);
                                        }
                                    }
                                    else
                                    {
                                        link = DatabaseFunctions.CreateLink(_request.VehicleId, _request.CountryCode, _response.ProviderId, _response.AuthorisationMaxAmount, _request.StartDateTime, _response.AuthorisationValidUntil, _response.Token, _request.AreaId, _request.VehicleIdType, _response.TokenType);
                                    }

                                    DatabaseFunctions.UpdateAuthorisation(_response.ProviderId, _response.PaymentAuthorisationId, _response.Remark, _requestid, link, null);

                                    break;
                                }
                            }
                        }

                        if (_aborted) {
                            UnSettle();
                        }
                    }
                    else
                    {
                        //Database.Database.Log(string.Format("No contract found; area: {0}; startdate: {1}", _request.AreaManagerId, _request.StartDateTime));
                        DatabaseFunctions.UnregisterRequest(_requestid);
                        _response.RemarkId = "115";
                        _response.Remark = "No available contract";
                    }
                }
                catch (Exception ex)
                {
                    Database.Database.Log(string.Format("VERW; EXCEP:{0}; STACK: {1}", ex.Message, ex.StackTrace));

                    _response.Remark = "VerwijsIndex; Internal error";
                    _response.RemarkId = "40";
                }
            }

        }

        class PaymentCheckWorker : Worker
        {
            /// <summary>
            /// Verzoek bericht
            /// </summary>
            private PaymentCheckRequest _request;

            /// <summary>
            /// Antwoord bericht
            /// </summary>
            public override object Request
            {
                get
                {
                    return _request;
                }

                set
                {
                    _request = value as PaymentCheckRequest;
                }
            }

            /// <summary>
            /// Antwoord bericht
            /// </summary>
            private PaymentCheckResponse _response;

            /// <summary>
            /// Antwoord bericht
            /// </summary>
            public override object Result
            {
                get
                {
                    return _response;
                }
            }

            public PaymentCheckWorker(PaymentCheckRequest pcr) {
                _request = pcr;
                _response = new PaymentCheckResponse();
            }

            public override void Settle() {
                try
                {
                    Providers providers = null;
                    if (!string.IsNullOrEmpty(_request.Provider))
                        providers = DatabaseFunctions.GetProvider(_request.AreaManagerId, _request.Provider, _request.CheckDateTime);
                    else
                        providers = DatabaseFunctions.ListOfProvider(_request.AreaManagerId, _request.CheckDateTime);

                    if (providers != null && providers.Count > 0) {

                        foreach (Provider p in providers) {
                            if (_aborted) break;

                            Link link = DatabaseFunctions.GetLink(p.id, _request.VehicleId, _request.CheckDateTime, null, null, _request.AreaId, true, _request.VehicleIdType);
                            if (p.sendlinkrequest == Provider.SendLinkRequest.NO)
                            {
                                // 29-08-2017 logica gelijk getrokken met PaymentStart!
                                // geen autorisatieverzoeken voor voertuigen waarvoor geen koppeling bestaat
                                if (link == null) {
                                    //Database.Database.Log("No link for Vehicle: " + _request.VehicleId);
                                    continue;
                                }
                                // logica gelijk getrokken met PaymentStart!
                            }
                            else if (p.sendlinkrequest == Provider.SendLinkRequest.IMPLICIT) {
                                // autorisatieverzoek sturen en als daar een positief antwoord op komt een koppeling registreren met de einddatumtijd van de autorisatie als einddatumtijd van de koppeling
                            }

                            PaymentCheckResponse relayRes = WorkerFunctions.PaymentCheckWrapper(p, _request);

                            if (relayRes != null)
                            {
                                Database.Database.Log(string.Format("PaymentCheckWorker relayRes: Provider[{5}], AreaId[{0}], granted[{1}], ProviderId[{2}], RemarkId[{3}], Remark[{4}]", relayRes.AreaId, relayRes.Granted, relayRes.ProviderId, relayRes.RemarkId, relayRes.Remark, p.id));
                                _response = relayRes;
                                if (relayRes.Granted.HasValue && relayRes.Granted.Value)
                                {
                                    break;
                                }

                            }
                        }
                    }
                    else
                    {
                        _response.RemarkId = "115";
                        _response.Remark = "No available contract";
                    }
                }
                catch (Exception ex)
                {
                    Database.Database.Log(string.Format("VERW; EXCEP:{0}; STACK: {1}", ex.Message, ex.StackTrace));

                    _response.Remark = "VerwijsIndex; Internal error";
                    _response.RemarkId = "40";
                }
            }

            public override void UnSettle()
            {
                // do nothing
            }
        }
    }

    class WorkerFunctions
    {
        internal static PaymentStartResponse PaymentStartWrapper(Provider p, PaymentStartRequest request)
        {
            PaymentStartResponse relayRes = null;
            if (p.Protocoll == Provider.ProtocollType.NprPlus)
            {
                relayRes = ActivateEnroll(p, request);
            }
            else
            {
                relayRes = PaymentStart(p, request);
            }
            return relayRes;
        }

        internal static PaymentEndResponse PaymentEndWrapper(Provider p, PaymentEndRequest request)
        {
            PaymentEndResponse relayRes = null;
            if (p.Protocoll == Provider.ProtocollType.NprPlus)
            {
                relayRes = RevokedByThirdParty(p, request);
            }
            else
            {
                relayRes = PaymentEnd(p, request);
            }
            return relayRes;
        }

        internal static PaymentCheckResponse PaymentCheckWrapper(Provider p, PaymentCheckRequest request)
        {
            PaymentCheckResponse relayRes = null;

            Database.Database.Log("protocoll " + p.Protocoll);

            if (p.Protocoll == Provider.ProtocollType.Unknown)
            {
                Database.Database.Log(string.Format("Unknown protocollType, on provider '{0}'", p.id));
            }
            else if (p.Protocoll == Provider.ProtocollType.NprPlus)
            {
                //Database.Database.Log(string.Format("No PaymentCheck for '{3}', received from: {2}/{0}, destination: {1}", request.AreaId, p.url, request.AreaManagerId, p.id));


                relayRes = CheckPSRight(p, request);

                //relayRes = new PaymentCheckResponse()
                //{
                //    AreaId = request.AreaId,
                //    Granted = true,
                //    ProviderId = p.id,
                //};
            }
            else
            {
                relayRes = WorkerFunctions.PaymentCheck(p, request);
            }
            return relayRes;
        }


        internal static PaymentStartResponse PaymentStart(Provider p, PaymentStartRequest request)
        {
            PaymentStartResponse response = null;
            VerwijsIndexClient clnt = null;

            try
            {
                Timing t = new Timing("VerwijsIndexService", "PaymentStart", p.url);
                clnt = Service.PaymentClient(p);

                response = clnt.PaymentStart(request);
                t.Finish();
            }
            catch (Exception ex)
            {
                Database.Database.Log(string.Format("Exception on PaymentStart from ({2}); {0}; {1}", ex.Message, ex.StackTrace, p.url));
                //response.Remark = "Exception on PaymentStart";
                //response.RemarkId = "500x";
            }
            finally
            {
                if (clnt != null && clnt.State != CommunicationState.Closing && clnt.State != CommunicationState.Closed)
                    clnt.Close();
            }

            return response;

        }

        internal static PaymentCheckResponse PaymentCheck(Provider p, PaymentCheckRequest request)
        {
            PaymentCheckResponse response = null;
            VerwijsIndexClient clnt = null;

            try
            {
                Timing t = new Timing("VerwijsIndexService", "PaymentCheck", p.url);
                clnt = Service.PaymentClient(p);

                response = clnt.PaymentCheck(request);
                t.Finish();
            }
            catch (Exception ex)
            {
                Database.Database.Log(string.Format("Exception on PaymentCheck from ({2}); {0}; {1}", ex.Message, ex.StackTrace, p.url));
                //response.Remark = "Exception on PaymentCheck";
                //response.RemarkId = "500x";
            }
            finally
            {
                if (clnt != null && clnt.State != CommunicationState.Closing && clnt.State != CommunicationState.Closed)
                    clnt.Close();
            }

            return response;
        }

        internal static PaymentEndResponse PaymentEnd(Provider p, PaymentEndRequest request)
        {
            PaymentEndResponse response = null;
            VerwijsIndexClient clnt = null;

            try
            {
                Timing t = new Timing("VerwijsIndexService", "PaymentEnd", p.url);
                clnt = Service.PaymentClient(p);

                //Set Pin if there is a certeificate
                if (clnt.ClientCredentials.ClientCertificate.Certificate != null) { 
                    System.Security.Cryptography.X509Certificates.X509Certificate2 cert = clnt.ClientCredentials.ClientCertificate.Certificate;
                    string pin = Regex.Match(cert.Subject, @"O\s?=(.*),\s").Groups[1].ToString();
                    request.PIN = pin;
                    using (new OperationContextScope(clnt.InnerChannel)) {
                        // Add a SOAP Header to an outgoing request
                        MessageHeader aMessageHeader = MessageHeader.CreateHeader("PIN", "http://rdw.nl/rpv/1.0", pin);
                        OperationContext.Current.OutgoingMessageHeaders.Add(aMessageHeader);
                        response = clnt.PaymentEnd(request);
                    }
                } else { 
                    response = clnt.PaymentEnd(request);
                }
                t.Finish();
            }
            catch (Exception ex)
            {
                Database.Database.Log(string.Format("Exception on PaymentEnd from ({2}); {0}; {1}", ex.Message, ex.StackTrace, p.url));
                //response.Remark = "Exception on PaymentEnd";
                //response.RemarkId = "500x";
            }
            finally
            {
                if (clnt != null && clnt.State != CommunicationState.Closing && clnt.State != CommunicationState.Closed)
                    clnt.Close();
            }

            return response;
        }

        internal static PaymentStartResponse ActivateEnroll(Provider p, PaymentStartRequest request)
        {
            PaymentStartResponse response = null;
            RegistrationPlusClient clnt = null;

            try
            {
                //prepare request
                ActivateEnrollRequestRequestData req = new ActivateEnrollRequestRequestData
                {
                    AccessId = request.AccessId,
                    Amount = request.Amount,
                    AreaId = request.AreaId,
                    AreaManagerId = request.AreaManagerId,
                    CountryCode = request.CountryCode,
                    EndDateTime = request.EndDateTime,
                    StartDateTime = request.StartDateTime,
                    Token = request.Token,
                    TokenType = request.TokenType,
                    VAT = request.VAT,
                    VehicleId = request.VehicleId,
                    VehicleIdType = request.VehicleIdType,
                };
                ActivateEnrollRequestResponseData res = null;
                ActivateEnrollRequestResponseError err = null;


                // make the call
                Timing t = new Timing("VerwijsIndexService", "ActivateEnroll", p.url);
                clnt = Service.NPRPlusClient(p);
                res = clnt.ActivateEnroll("", req, out err);
                t.Finish();

                // fill the response
                response = new PaymentStartResponse {
                    AuthorisationMaxAmount = res.AuthorisationMaxAmount,
                    AuthorisationValidUntil = res.AuthorisationValidUntil,
                    PaymentAuthorisationId = res.PaymentAuthorisationId,
                    ProviderId = res.ProviderId,
                    Remark = res.Remark,
                    RemarkId = res.RemarkId,
                    Token = res.Token,
                    TokenType = res.TokenType,
                };
            } catch (Exception ex) {
                Database.Database.Log(string.Format("Exception on ActivateEnroll from ({2}); {0}; {1}", ex.Message, ex.StackTrace, p.url));
                //response.Remark = "Exception on ActivateEnroll";
                //response.RemarkId = "500x";
            } finally {
                if (clnt != null && clnt.State != CommunicationState.Closing && clnt.State != CommunicationState.Closed)
                    clnt.Close();
            }

            return response;
        }

        internal static PaymentCheckResponse CheckPSRight(Provider p, PaymentCheckRequest request) {
            PaymentCheckResponse response = null;
            RegistrationPlusClient clnt = null;

            try {
                //prepare request
                PSRightCheckRequestData req = new PSRightCheckRequestData {
                    AreaManagerId = request.AreaManagerId,
                    AreaId = request.AreaId,
                    UsageId = "parkeren",
                    VehicleId = request.VehicleId,
                    CheckTime = request.CheckDateTime,
                    ExtraInfoIndicator = IndicatorYNType.N
                };
                PSRightCheckResponseData res = null;
                PSRightCheckResponseError err = null;

                Database.Database.Log("sending NPR+ to PARKPRO " + ConfigurationManager.AppSettings["ServiceId"]);


                // make the call
                Timing t = new Timing("VerwijsIndexService", "CheckPSRight", p.url);
                clnt = Service.NPRPlusClient(p);
                res = clnt.CheckPSRight("", req, out err);
                t.Finish();

                // fill the response
                response = new PaymentCheckResponse {
                    Granted = res.CheckAnswer == IndicatorYNType.y || res.CheckAnswer == IndicatorYNType.Y
                };
            } catch (Exception ex) {
                Database.Database.Log(string.Format("Exception on CheckPSRight from ({2}); {0}; {1}", ex.Message, ex.StackTrace, p.url));
                //response.Remark = "Exception on ActivateEnroll";
                //response.RemarkId = "500x";
            } finally {
                if (clnt != null && clnt.State != CommunicationState.Closing && clnt.State != CommunicationState.Closed)
                    clnt.Close();
            }

            return response;
        }

        internal static PaymentEndResponse RevokedByThirdParty(Provider p, PaymentEndRequest request)
        {
            PaymentEndResponse response = null;
            RegistrationPlusClient clnt = null;

            try
            {
                //prepare request
                RevokedByThirdPartyRequestRequestData req = new RevokedByThirdPartyRequestRequestData {
                    Amount = request.Amount,
                    CountryCode = request.CountryCode,
                    EndDateTime = request.EndDateTime,
                    PaymentAuthorisationId = ulong.Parse(request.PaymentAuthorisationId),
                    ProviderId = request.ProviderId,
                    VAT = request.VAT,
                    VehicleId = request.VehicleId,
                    VehicleIdType = request.VehicleIdType,
                };
                RevokedByThirdPartyRequestResponseData res = null;
                RevokedByThirdPartyRequestResponseError err = null;

                // make the call
                Timing t = new Timing("VerwijsIndexService", "RevokedByThirdParty", p.url);
                clnt = Service.NPRPlusClient(p);
                res = clnt.RevokedByThirdParty("", req, out err);
                t.Finish();

                // fill the response
                response = new PaymentEndResponse
                {
                    PaymentAuthorisationId = res.PaymentAuthorisationId.ToString(),
                    Remark = res.Remark,
                    RemarkId = res.RemarkId,
                };
            }
            catch (Exception ex)
            {
                Database.Database.Log(string.Format("Exception on RevokedByThirdParty from ({2}); {0}; {1}", ex.Message, ex.StackTrace, p.url));
                //response.Remark = "Exception on RevokedByThirdParty";
                //response.RemarkId = "500x";
            }
            finally
            {
                if (clnt != null && clnt.State != CommunicationState.Closing && clnt.State != CommunicationState.Closed)
                    clnt.Close();
            }

            return response;
        }
    }
}
