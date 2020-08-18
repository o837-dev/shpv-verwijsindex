using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Denion.WebService.Database;
using System.Data;

namespace Denion.WebService.VerwijsIndex
{
    [LogBehavior]
    [ServiceBehavior(Name = "Provider", Namespace = "https://verwijsindex.shpv.nl/service/")]
    public class ProviderService : IProvider
    {
        #region IProvider interface implementatie
        //LinkResponse IProvider.Request(LinkRequest req)
        //{
        //    throw new Exception("This service does not support this function.");
        //}

        LinkRegistrationResponse IProvider.Registration(LinkRegistrationRequest req)
        {
            Timing t = new Timing("Registration", Service.IncomingAddress(), Service.OperationContextAddress());
            LinkRegistrationResponse res = null;
            res = HandleRegistration(req);
            t.Finish();
            return res;
        }

        LinkRegistrationBatchResponse IProvider.BatchRegistration(LinkRegistrationBatchRequest req)
        {
            Timing t = new Timing("BatchRegistration", Service.IncomingAddress(), Service.OperationContextAddress());
            LinkRegistrationBatchResponse res = new LinkRegistrationBatchResponse();
            res.Batch = new LinkRegistrationResponse[req.Batch.Length];
            for (int i = 0; i < req.Batch.Length; i++)
            {
                res.Batch[i] = HandleRegistration(req.Batch[i]);
            }
            t.Finish();
            return res;
        }

        ActivateAuthorisationResponse IProvider.ActivateAuthorisation(ActivateAuthorisationRequest req) {
            Timing t1 = new Timing("ActivateAuthorisation", Service.IncomingAddress(), Service.OperationContextAddress());
            ActivateAuthorisationResponse res = new ActivateAuthorisationResponse();
            res.Granted = false;
            Err err = req.IsValid();
            if (err != null) {
                res.RemarkId = err.RemarkId;
                res.Remark = err.Remark;
            } else {
                Providers validContracts = DatabaseFunctions.ListOfProvider(req.AreaManagerId, req.StartDateTime);

                if (!validContracts.Exists(provider => provider.id == req.ProviderId)) {
                    res.RemarkId = "115";
                    res.Remark = "No contract available";
                    return res;
                }


                ulong? paymentAuthorisationId = req.PaymentAuthorisationId;
                //If PSRightId not send by provider than generate one 
                if (paymentAuthorisationId == null) {
                    req.PaymentAuthorisationId = Functions.GenerateUniqueId();
                }  else {
                    //Provider filled psRightId so check if not already exists
                    if (!DatabaseFunctions.checkForUniqueness(paymentAuthorisationId.ToString()))  {
                        res.RemarkId = "156";
                        res.Remark = "PaymentAuthorisationId already exists in our system";
                        return res;
                    }
                }


                // select parkingfacility from DB
                Providers parkingFacility = DatabaseFunctions.ListOfParkingFacilities(req.AreaManagerId, req.AreaId, req.StartDateTime);
                if (parkingFacility.Count > 0) {
                    foreach (Provider p in parkingFacility) {
                        ConsumerClient clnt = null;
                        try {
                            Timing t = new Timing("RegistrationService", "ActivateAuthorisation", p.url);
                            clnt = Service.Consumer(p.url);

                            object _requestid = DatabaseFunctions.RegisterRequest(null, req.VehicleId, req.CountryCode, req.AreaManagerId, req.StartDateTime, req.AreaId, null, req.PaymentAuthorisationId.ToString());

                            ActivateAuthorisationResponse relayRes = clnt.ActivateAuthorisation(req);
                            t.Finish();

                            if (relayRes != null)
                            {
                                res = relayRes;
                                if(!string.IsNullOrEmpty(relayRes.PaymentAuthorisationId)) {
                                    DateTime startDateTimeAdjusted = DateTime.Now;
                                    if(relayRes.StartDateTimeAdjusted.HasValue) {
                                        startDateTimeAdjusted = relayRes.StartDateTimeAdjusted.Value;
                                    } else if(req.StartDateTime != null) {
                                        startDateTimeAdjusted = req.StartDateTime;
                                    }

                                    DateTime endDateTime = DateTime.Now;
                                    if(relayRes.EndDateTime.HasValue) {
                                        //Als garage antwoordt
                                        endDateTime = relayRes.EndDateTime.Value;
                                    } else if(req.EndDateTime.HasValue) {
                                        //Garage heeft niets gestuurd dus kijken we of provider een eindtijd heeft gestuurd
                                        endDateTime = req.EndDateTime.Value;
                                    }

                                    //Remak id = 0, dan weglaten
                                    if(relayRes.RemarkId == "0") {
                                        relayRes.RemarkId = null;
                                    }
                            

                                    Link link = DatabaseFunctions.CreateLink(req.VehicleId, req.CountryCode, req.ProviderId, null, startDateTimeAdjusted, endDateTime, null, req.AreaId, req.VehicleIdType, null);

                                    DatabaseFunctions.UpdateAuthorisation(req.ProviderId, req.PaymentAuthorisationId.ToString(), null, _requestid, link, startDateTimeAdjusted);

                                    clnt.Close();
                                    break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Database.Database.Log(string.Format("Exception on ActivateAuthorisation from ({2}); {0}; {1}", ex.Message, ex.StackTrace, p.url));
                        }
                        finally
                        {
                            if (clnt != null && clnt.State != CommunicationState.Closing && clnt.State != CommunicationState.Closed)
                                clnt.Close();
                        }
                    }

                    if(res.RemarkId == null && res.PaymentAuthorisationId == null)
                    {
                        res.RemarkId = "15";
                        res.Remark = "ParkingFacility does not respond";
                    }

                }
                else
                {
                    //_responsebase._responsebase.Log(string.Format("No contract found; area: {0}; startdate: {1}", gi.AreaManagerId, _request.StartDateTime));
                    //res.RemarkId = "115";
                    //_response.Remark = "No available contract";
                }
            }
            t1.Finish();
            return res;
        }

        CancelAuthorisationResponse IProvider.CancelAuthorisation(CancelAuthorisationRequest req)
        {
            Timing t1 = new Timing("CancelAuthorisation", Service.IncomingAddress(), Service.OperationContextAddress());
            CancelAuthorisationResponse res = new CancelAuthorisationResponse();
            Err err = req.IsValid();
            if (err != null)
            {
                res.RemarkId = err.RemarkId;
                res.Remark = err.Remark;
            }
            else
            {
                DataTable dt = DatabaseFunctions.GetConsumer(req);
                if (dt != null && dt.Rows.Count > 0)
                {
                    bool settled = false;
                    bool contractAvailable = true;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ConsumerClient clnt = null;
                        string URL = string.Empty;
                        try
                        {
                            DataRow dr = dt.Rows[i];
                            settled = (bool)dr["SETTLED"];
                            
                            if (!settled)
                            {
                                DateTime contractStart = dr["ContractStartDate"] as DateTime? ?? DateTime.MinValue;
                                DateTime contractEnd = dr["ContractEndDate"] as DateTime? ?? DateTime.MaxValue;
                                DateTime start = DateTime.Now;
                                URL = dr["URL"] as string ?? null;
                                
                                Timing t = new Timing("ProviderService", "CancelAuthorisation", URL);
                                clnt = Service.Consumer(URL);

                                req.AreaId = dr["AreaId"] as string;
                                req.AreaManagerId = dr["AreaManagerId"] as string;
                                req.CountryCode = dr["CountryCode"] as string;
                                req.ProviderId = dr["ProviderId"] as string;
                                req.VehicleId = Cryptography.Rijndael.Decrypt(dr["VehicleId"] as string);
                                req.VehicleIdType = dr["VehicleIdType"] as string;

                                CancelAuthorisationResponse relayRes = clnt.CancelAuthorisation(req);
                                t.Finish();

                                if (relayRes != null)
                                {
                                    res = relayRes;
                                    if (res.PaymentAuthorisationId != null)
                                    {
                                        bool nprRegistration = RevokePSRightWorker.getNprRegistration(req.ProviderId, req.AreaManagerId);
                                        Database.Database.Log("providerId:" + req.ProviderId + ", AreaManagerId " + req.AreaManagerId);

                                        object PSRightID = DBNull.Value;
                                        Database.Database.Log("NPR Registration? " + nprRegistration);
                                        if (nprRegistration)
                                        {
                                            DateTime endTime = req.CancelDateTime.Value;
                                            //Garage wijzigd eindtijd?
                                            if (res.EndTimeAdjusted != null)
                                            {
                                                endTime = res.EndTimeAdjusted.Value;
                                            }
                                            DateTime startTime = (DateTime)dr["STARTDATE"];

                                            if (endTime == null || endTime <= startTime)
                                            {
                                                endTime = startTime;
                                            }

                                            res.Amount = res.Amount == null ? 0 : res.Amount;
                                            RDWRight r = WebService.Functions.RDWEnrollRight((string)dr["PROVIDERID"], (string)dr["AreaManagerId"], (string)dr["AreaId"], "BETAALDP", req.VehicleId, startTime, endTime, req.CountryCode, Convert.ToDecimal(res.Amount), Convert.ToDecimal(res.VAT), "" + res.PaymentAuthorisationId.Value);
                                            if (r.PSRightId != null)
                                                PSRightID = r.PSRightId;
                                            if (!string.IsNullOrEmpty(r.Remark))
                                            {
                                                res.RemarkId = "120";
                                                res.Remark = "Problem with NPR registration; " + r.Remark;
                                            }
                                        }
                                        RevokePSRightWorker.AuthorisationSettled(res.PaymentAuthorisationId.Value, PSRightID);

                                        clnt.Close();
                                        break;
                                    }
                                } else
                                {
                                    //Should not be filled at this point
                                    if (res.RemarkId == null && res.PaymentAuthorisationId == null)
                                    {
                                        res.RemarkId = "15";
                                        res.Remark = "ParkingFacility does not respond";
                                    }
                                }

                                if (relayRes != null)
                                {
                                    res = relayRes;
                                    break;
                                }
                            }
                            else
                            {
                                res.RemarkId = "110";
                                res.Remark = "Authorisation already settled";
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            Database.Database.Log(string.Format("Exception on CancelAuthorisation from ({2}); {0}; {1}", ex.Message, ex.StackTrace, URL));
                            res.RemarkId = "40";
                            res.Remark = "VerwijsIndex; Internal error";
                        }
                        finally
                        {
                            if (clnt != null && clnt.State != CommunicationState.Closing && clnt.State != CommunicationState.Closed)
                                clnt.Close();
                        }
                    }

                    if (!contractAvailable)
                    {
                        res.RemarkId = "115";
                        res.Remark = "No available contract";
                    }
                }
                else
                {
                    res.RemarkId = "95";
                    res.Remark = "No matching authorisation could be found";
                }
            }
            t1.Finish();
            return res;
        }

        StatusResponse IProvider.ServiceStatus()
        {
            return Service.ServiceStatus();
        }

        public LinkTerminationAcknowledged Terminated(LinkTerminationNotification ltn)
        {
            throw new Exception("This service does not support this function.");
        }
        #endregion

        private LinkRegistrationResponse HandleRegistration(LinkRegistrationRequest req) {
            LinkRegistrationResponse res = new LinkRegistrationResponse();
            Err err = req.IsValid();
            if (err != null) {
                res.RemarkId = err.RemarkId;
                res.Remark = err.Remark;
            } else {
                try {
                    res = DatabaseFunctions.VerifyLink(req);
                } catch (Exception ex) {
                    res.RemarkId = "125";
                    res.Remark = ex.Message;
                }
            }
            return res;
        }
    }
}
