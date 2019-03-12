using Denion.WebService.VerwijsIndex;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConsolApp
{
    class NPRPlusTest
    {
        public NPRPlusTest()
        {

            //Providers providers = DatabaseFunctions.ListOfProvider("HTH", DateTime.Now);

            VerwijsIndexClient vwxclnt = null;
            ProviderClient psclnt = null;
            RegistrationClient nprclnt = null;
            try
            {
                vwxclnt = Service.PaymentClient("https://verwijsindex.azurewebsites.net/Service/VerwijsIndexService.svc");
                nprclnt = Service.NPRLikeClient("https://verwijsindex.azurewebsites.net/Service/registration.svc");
                psclnt = Service.LinkClient("https://verwijsindex.azurewebsites.net/Service/ProviderService.svc");

                RequestStatus(psclnt);
                RequestStatus(vwxclnt);
                

                PaymentStartRequest psreq = new PaymentStartRequest
                {
                    AccessId = "aid",
                    Amount = 0,
                    AreaId = "CENTRUM",
                    AreaManagerId = "HTH",
                    CountryCode = "NL",
                    EndDateTime = null,
                    StartDateTime = DateTime.Now,
                    Token = null,
                    TokenType = null,
                    VAT = null,
                    VehicleId = "TEST01",
                    VehicleIdType = "LICENSE_PLATE"
                };

                PSRightEnrollRequestData pereq = new PSRightEnrollRequestData
                {
                    AreaManagerId = "HTH",
                    AreaId = "CENTRUM",
                    SellingPointId = "123",

                    VehicleId = "TEST02",
                    VehicleIdType = "LICENSE_PLATE",
                    //CountryCodeVehicle = UneceLandCodesType.NL,
                    //CountryCodeVehicleSpecified = true,
                    
                    UsageId = "PARKEREN",
                    //LocationPSRight = new PSRightEnrollRequestDataLocationPSRight { Latitude = 53.540601m, Longitude = 6.577557m },
                    StartTimePSright = DateTime.Now,
                    //EndTimePSright
                    ProviderId = "HarmPS",
                    
                };

                /*
                Err e1 =  new PSRightEnrollRequest("", new PSRightEnrollRequestData { VehicleId="aa", AreaManagerId = "dsa" }).IsValid();
                Err e2 = new PSRightEnrollRequest("", new PSRightEnrollRequestData { VehicleId="aa", AreaId = "das", AreaManagerId = "dsa" }).IsValid();
                Err e3 = new PSRightEnrollRequest("", new PSRightEnrollRequestData { VehicleId="aa", SellingPointId = "das" }).IsValid();
                Err e4 = new PSRightEnrollRequest("", new PSRightEnrollRequestData { VehicleId="aa", AreaId = "das", AreaManagerId = "dsa", SellingPointId = "das" }).IsValid();
                Err e5 = new PSRightEnrollRequest("", new PSRightEnrollRequestData { VehicleId="aa", LocationPSRight = new PSRightEnrollRequestDataLocationPSRight { Latitude = 1m, Longitude = 2m } }).IsValid();
                Err e6 = new PSRightEnrollRequest("", new PSRightEnrollRequestData { VehicleId="aa", AreaId = "das", LocationPSRight = new PSRightEnrollRequestDataLocationPSRight { Latitude = 1m, Longitude = 2m } }).IsValid();

                PSRightEnrollRequest req = new PSRightEnrollRequest("", pereq);
                Err test = req.IsValid();*/

                //METHOD  1a, garage VWX protocol, provider NPR+
                //PaymentStartResponse res = PaymentStart(vwxclnt, psreq);
                //PaymentEndResponse res2 = PaymentEnd(vwxclnt, psreq, res);

                //METHOD  1b, garage VWX protocol, provider NPR+
                //PaymentStartResponse res = PaymentStart(vwxclnt, psreq);
                //RevokePSRight(nprclnt, res.PaymentAuthorisationId);

                //method 2a, provider nprplus, garage nprplus
                PSRightEnrollResponseData res = EnrollPSRight(nprclnt, pereq);
                
                PSRightRevokeResponseData res2 = RevokePSRight(nprclnt, long.Parse(res.PSRightId));
                Debug.Write(res2.AmountPSRightCalculated);
                //method 2b, provider nprplus, garage vwx
                //PSRightEnrollResponseData res = EnrollPSRight(nprclnt, pereq);
                //PaymentEnd(vwxclnt, pereq, res);
                
                //RevokePSRight(nprclnt, "f2ad69d2-a31a-45ec-a15c-cf39819252ed");
                //StatusRequest(nprclnt);
                //RetrieveAreasByLocation(nprclnt);

            } catch (Exception ex) {
                Debug.WriteLine(ex);
            } finally {
                if (vwxclnt != null && vwxclnt.State != CommunicationState.Closing && vwxclnt.State != CommunicationState.Closed)
                    vwxclnt.Close();
                if (nprclnt != null && nprclnt.State != CommunicationState.Closing && nprclnt.State != CommunicationState.Closed)
                    nprclnt.Close();
            }
        }

        private void PaymentEnd(VerwijsIndexClient vwxclnt, PSRightEnrollRequestData startreq, PSRightEnrollResponseData startres)
        {
            PaymentEndRequest req = new PaymentEndRequest
            {
                Amount = 12.34,
                CountryCode = startreq.CountryCodeVehicle.ToString(),
                EndDateTime = DateTime.Now,
                PaymentAuthorisationId = startres.PSRightId,
                ProviderId = "HarmPS",
                VAT = 2.56,
                VehicleId = startreq.VehicleId,
                VehicleIdType = null

            };
            PaymentEndResponse res = vwxclnt.PaymentEnd(req);

            if (req != null) Debug.WriteLine("req: " + Functions.ToLongString(req));
            if (res != null) Debug.WriteLine("res: " + Functions.ToLongString(res));
        }

        private void directtest(PaymentStartRequest request)
        {
            RegistrationPlusClient clnt = Service.NPRPlusClient("https://verwijsindex.azurewebsites.net/NPRPlusProvider/NprPlusProviderService.svc");

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

            res = clnt.ActivateEnroll("", req, out err);

            if (req != null) Debug.WriteLine("req: " + Functions.ToLongString(req));
            if (res != null) Debug.WriteLine("res: " + Functions.ToLongString(res));
            if (err != null) Debug.WriteLine("err: " + Functions.ToLongString(err));

        }

        private PaymentStartResponse PaymentStart(VerwijsIndexClient clnt, PaymentStartRequest req)
        {
            PaymentStartResponse res = clnt.PaymentStart(req);

            if (req != null) Debug.WriteLine("req: " + Functions.ToLongString(req));
            if (res != null) Debug.WriteLine("res: " + Functions.ToLongString(res));

            return res;
        }
        private PaymentEndResponse PaymentEnd(VerwijsIndexClient clnt, PaymentStartRequest startreq, PaymentStartResponse startres)
        {
            PaymentEndRequest req = new PaymentEndRequest
            {
                Amount = 12.34,
                CountryCode = startreq.CountryCode,
                EndDateTime = DateTime.Now,
                PaymentAuthorisationId = startres.PaymentAuthorisationId,
                ProviderId = startres.ProviderId,
                VAT = 2.56,
                VehicleId = startreq.VehicleId,
                VehicleIdType = startreq.VehicleIdType
                
            };
            PaymentEndResponse res = clnt.PaymentEnd(req);

            if (req != null) Debug.WriteLine("req: " + Functions.ToLongString(req));
            if (res != null) Debug.WriteLine("res: " + Functions.ToLongString(res));

            return res;   
        }

        public PSRightEnrollResponseData EnrollPSRight(RegistrationClient clnt, PSRightEnrollRequestData req)
        {
            PSRightEnrollResponseData res = null;
            PSRightEnrollResponseError err = null;
            
            res = clnt.EnrollPSRight("", req, out err);

            if (req != null) Debug.WriteLine("req: " + Functions.ToLongString(req));
            if (res != null) Debug.WriteLine("res: " + Functions.ToLongString(res));
            if (err != null) Debug.WriteLine("err: " + Functions.ToLongString(err));

            return res;
        }

        public PSRightRevokeResponseData RevokePSRight(RegistrationClient clnt, long PSRightId)
        {
            PSRightRevokeRequestData req = new PSRightRevokeRequestData();
            PSRightRevokeResponseData res = null;
            PSRightRevokeResponseError err = null;

            req.PSRightId = PSRightId.ToString();
            req.EndTimePSRight = DateTime.Now;

            try
            {
                res = clnt.RevokePSRight("", req, out err);

                if (req != null) Debug.WriteLine("req: " + Functions.ToLongString(req));
                if (res != null) Debug.WriteLine("res: " + Functions.ToLongString(res));
                if (err != null) Debug.WriteLine("err: " + Functions.ToLongString(err));
            }
            catch (Exception Ex)
            {
                Debug.WriteLine("Ex: " + Functions.ToLongString(Ex));
            }

            return res;
        }

        public void RequestStatus(VerwijsIndexClient clnt)
        {
            StatusResponse res = null;

            res = clnt.ServiceStatus();

            if (res != null) Debug.WriteLine("res: " + Functions.ToLongString(res));
        }

        public void RequestStatus(ProviderClient clnt)
        {
            StatusResponse res = null;

            res = clnt.ServiceStatus();
            
            if (res != null) Debug.WriteLine("res: " + Functions.ToLongString(res));
        }

        public void StatusRequest(RegistrationClient clnt)
        {
            StatusRequestRequestData req = new StatusRequestRequestData();
            StatusRequestResponseData res = null;
            StatusRequestResponseError err = null;

            req.StatusReference = "ref";
            req.StatusTime= DateTime.Now;

            res = clnt.StatusRequest("", req, out err);

            if (req != null) Debug.WriteLine("req: " + Functions.ToLongString(req));
            if (res != null) Debug.WriteLine("res: " + Functions.ToLongString(res));
            if (err != null) Debug.WriteLine("err: " + Functions.ToLongString(err));
        }

        public void RetrieveAreasByLocation(RegistrationClient clnt)
        {
            RetrieveAreasByLocationRequestData req = new RetrieveAreasByLocationRequestData();
            RetrieveAreasByLocationResponseData res = null;
            RetrieveAreasByLocationResponseError err = null;

            req.AreaManagerId = "02065";
            req.AreaId = "Haven";

            res = clnt.RetrieveAreasByLocation("", req, out err);

            if (req != null) Debug.WriteLine("req: " + Functions.ToLongString(req));
            if (res != null) Debug.WriteLine("res: " + Functions.ToLongString(res));
            if (err != null) Debug.WriteLine("err: " + Functions.ToLongString(err));
        }
    }
}
