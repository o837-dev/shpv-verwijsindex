using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Denion.WebService.VerwijsIndex;
using ManualProviderService.Properties;
using System.ServiceModel.Activation;
using System.Configuration;
using Denion.WebService.Database;
using System.Threading;
using System.Web;
using System.Xml;

namespace ManualProviderService
{
    [LogBehavior]
    [ServiceBehavior(Name = "ManualProvider", Namespace = "https://verwijsindex.shpv.nl/service/")]
    [AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Required)]
    public class ManualProviderService : IVerwijsIndex, IProvider
    {
        #region IVerwijsIndex implementation
        PaymentStartResponse IVerwijsIndex.PaymentStart(PaymentStartRequest req)
        {
            Database.ProviderLog(ConfigurationManager.AppSettings["ProviderId"], "PaymentStart", req.VehicleId, req.VehicleIdType, req.CountryCode, req.AreaManagerId, req.AreaId);
            Dictionary<UniqueId, PaymentStartRequest> reqlist = null;
            Dictionary<UniqueId, PaymentStartResponse> reslist = null;

            if (System.Web.HttpContext.Current == null)
            {
                reqlist = new Dictionary<UniqueId, PaymentStartRequest>();
                reslist = new Dictionary<UniqueId, PaymentStartResponse>();
            }
            else
            {
                reqlist = (Dictionary<UniqueId, PaymentStartRequest>)System.Web.HttpContext.Current.Application["reqlist"];
                reslist = (Dictionary<UniqueId, PaymentStartResponse>)System.Web.HttpContext.Current.Application["reslist"];
            }

            UniqueId uuid = null;
            OperationContext context = OperationContext.Current;
            if (context != null)
            {
                uuid = context.IncomingMessageHeaders.MessageId;
            }
            else
                uuid = new UniqueId();

            reqlist.Add(uuid, req);

            bool wait = true;
            DateTime waitmax = DateTime.Now.AddSeconds(20);
            while (wait)
            {
                Thread.Sleep(100);
                wait = (!reslist.ContainsKey(uuid) && (DateTime.Now <= waitmax));
            }

            PaymentStartResponse res = null;
            if (reslist.ContainsKey(uuid))
            {
                res = reslist[uuid];
                reslist.Remove(uuid);
            }
            else
            {
                res = new PaymentStartResponse();
            }
            reqlist.Remove(uuid);

            return res;
        }

        PaymentEndResponse IVerwijsIndex.PaymentEnd(PaymentEndRequest req)
        {
            Database.ProviderLog(ConfigurationManager.AppSettings["ProviderId"], "PaymentEnd", req.VehicleId, req.VehicleIdType, req.CountryCode, null, null);
            PaymentEndResponse response = new PaymentEndResponse();
            response.PaymentAuthorisationId = req.PaymentAuthorisationId;
            response.Remark = "ManualProvider; No PaymentStop";
            response.RemarkId = "85";

            return response;

        }

        PaymentCheckResponse IVerwijsIndex.PaymentCheck(PaymentCheckRequest req)
        {
            //Database.Log("Provider: " + ConfigurationManager.AppSettings["ProviderId"] + "; Received PaymentCheck: " + req.VehicleId);
            Database.ProviderLog(ConfigurationManager.AppSettings["ProviderId"], "PaymentCheck", req.VehicleId, req.VehicleIdType, req.CountryCode, req.AreaManagerId, req.AreaId);
            PaymentCheckResponse pcr = new PaymentCheckResponse();
            pcr.Remark = "not checked";
            pcr.RemarkId = "0";
            pcr.Granted = true;
            Thread.Sleep(10);
            return pcr;
        }

        StatusResponse IVerwijsIndex.ServiceStatus()
        {
            return Service.ServiceStatus();
        }
        #endregion

        #region IProvider implementation
        //public LinkResponse Request(LinkRequest req)
        //{
        //    Database.Log("Provider: " + ConfigurationManager.AppSettings["ProviderId"] + "; Received linkRequest: " + req.VehicleId);

        //    Dictionary<UniqueId, LinkRequest> reqlist = null;
        //    Dictionary<UniqueId, LinkResponse> reslist = null;

        //    if (System.Web.HttpContext.Current == null)
        //    {
        //        reqlist = new Dictionary<UniqueId, LinkRequest>();
        //        reslist = new Dictionary<UniqueId, LinkResponse>();
        //    }
        //    else
        //    {
        //        reqlist = (Dictionary<UniqueId, LinkRequest>)System.Web.HttpContext.Current.Application["llreqlist"];
        //        reslist = (Dictionary<UniqueId, LinkResponse>)System.Web.HttpContext.Current.Application["llreslist"];
        //    }

        //    UniqueId uuid = null;
        //    OperationContext context = OperationContext.Current;
        //    if (context != null)
        //    {
        //        uuid = context.IncomingMessageHeaders.MessageId;
        //    }
        //    else
        //        uuid = new UniqueId();

        //    reqlist.Add(uuid, req);

        //    bool wait = true;
        //    DateTime waitmax = DateTime.Now.AddSeconds(20);
        //    while (wait)
        //    {
        //        Thread.Sleep(100);
        //        wait = (!reslist.ContainsKey(uuid) && (DateTime.Now <= waitmax));
        //    }
        //    LinkResponse res = null;
        //    if (reslist.ContainsKey(uuid))
        //    {
        //        res = reslist[uuid];
        //        reslist.Remove(uuid);
        //    }
        //    else
        //    {
        //        res = new LinkResponse();
        //    }
        //    reqlist.Remove(uuid);

        //    return res;
        //}

        public LinkRegistrationResponse Registration(LinkRegistrationRequest req)
        {
            throw new NotImplementedException();
        }

        public LinkRegistrationBatchResponse BatchRegistration(LinkRegistrationBatchRequest req)
        {
            throw new NotImplementedException();
        }

        public CancelAuthorisationResponse CancelAuthorisation(CancelAuthorisationRequest req)
        {
            throw new NotImplementedException();
        }

        StatusResponse IProvider.ServiceStatus()
        {
            return Service.ServiceStatus();
        }

        //public StatusResponse ServiceStatus()
        //{
        //    return Service.ServiceStatus();
        //}

        public LinkTerminationAcknowledged Terminated(LinkTerminationNotification ltn)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
