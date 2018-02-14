using Denion.WebService.VerwijsIndex;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ParkProConsumerService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IConsumer
    {
        public ActivateAuthorisationResponse ActivateAuthorisation(ActivateAuthorisationRequest request)
        {
            ActivateAuthorisationResponse result = new ActivateAuthorisationResponse();

            result.Remark = "";
            result.RemarkId = "";

            RDW.RegistrationClient client = new RDW.RegistrationClient();

            RDW.RetrieveRightInfoRequestData req = new RDW.RetrieveRightInfoRequestData();
            RDW.RetrieveRightInfoResponseData res = null;
            RDW.RetrieveRightInfoResponseError err = null;

            if (request.EndDateTime > DateTime.MinValue && request.EndDateTime < DateTime.MaxValue)
            {
                req.IndicatorTime = request.EndDateTime;
                req.IndicatorTimeSpecified = true;
            }
            req.VehicleId = request.VehicleId;

            try
            {
                res = client.RetrieveRightInfo("PIN", req, out err);
            }
            catch (Exception ex)
            {
                result.RemarkId = "-1";
                result.Remark = ex.Message;
            }

            if (err != null)
            {
                result.RemarkId = err.ErrorCode;
                result.Remark = err.ErrorDesc;
            }
            else
            {
                for (int i = 0; i < res.PSRightInfoList.Length; i++)
                {
                    RDW.PSRightInfoData rid = res.PSRightInfoList[i];

                    if (rid.AmountPSRight.HasValue)
                        result.Amount = Convert.ToDouble(rid.AmountPSRight.Value);

                    if (rid.EndTimePSRightSpecified)
                        result.EndDateTime = rid.EndTimePSRight;

                    result.Granted = true;
                    result.PaymentAuthorisationId = rid.PSRightId;
                    result.ProviderId = "PARKPRO";
                    //result.Remark
                    //result.RemarkId
                    result.StartDateTimeAdjusted = rid.StartTimePSRight;
                    if (rid.VATPSRight.HasValue)
                        result.VAT = Convert.ToDouble(rid.VATPSRight);
                }
            }
            return result;
        }

        public CancelAuthorisationResponse CancelAuthorisation(CancelAuthorisationRequest req)
        {
            CancelAuthorisationResponse res = new CancelAuthorisationResponse();
            res.Remark = "";
            res.RemarkId = "";
            
            res.PaymentAuthorisationId = req.PaymentAuthorisationId;
            res.ProviderId = req.ProviderId;
            
            return res;
        }
    }
}
