using Denion.WebService.VerwijsIndex;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Threading;
using System.Xml;

namespace ConsumerService
{
    [LogBehavior]
    [ServiceBehavior(Name = "Consumer", Namespace = "https://verwijsindex.shpv.nl/service/")]
    [AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Required)]
    public class ConsumerService : IConsumer
    {
        public ActivateAuthorisationResponse ActivateAuthorisation(ActivateAuthorisationRequest req)
        {
            Dictionary<UniqueId, ActivateAuthorisationRequest> aareqlist = null;
            Dictionary<UniqueId, ActivateAuthorisationResponse> aareslist = null;

            if (System.Web.HttpContext.Current == null)
            {
                aareqlist = new Dictionary<UniqueId, ActivateAuthorisationRequest>();
                aareslist = new Dictionary<UniqueId, ActivateAuthorisationResponse>();
            }
            else
            {
                aareqlist = (Dictionary<UniqueId, ActivateAuthorisationRequest>)System.Web.HttpContext.Current.Application["aareqlist"];
                aareslist = (Dictionary<UniqueId, ActivateAuthorisationResponse>)System.Web.HttpContext.Current.Application["aareslist"];
            }

            UniqueId uuid = null;
            OperationContext context = OperationContext.Current;
            if (context != null)
            {
                uuid = context.IncomingMessageHeaders.MessageId;
            }
            else
                uuid = new UniqueId();

            aareqlist.Add(uuid, req);

            bool wait = true;
            DateTime waitmax = DateTime.Now.AddSeconds(20);
            while (wait)
            {
                Thread.Sleep(100);
                wait = (!aareslist.ContainsKey(uuid) && (DateTime.Now <= waitmax));
            }
            //reqlist.Clear();
            ActivateAuthorisationResponse res = null;
            if (aareslist.ContainsKey(uuid))
            {
                res = aareslist[uuid];
                aareslist.Remove(uuid);
            }
            else
            {
                res = new ActivateAuthorisationResponse();
            }
            aareqlist.Remove(uuid);

            return res;
        }

        public CancelAuthorisationResponse CancelAuthorisation(CancelAuthorisationRequest req)
        {
            Dictionary<UniqueId, CancelAuthorisationRequest> reqlist = null;
            Dictionary<UniqueId, CancelAuthorisationResponse> reslist = null;

            if (System.Web.HttpContext.Current == null)
            {
                reqlist = new Dictionary<UniqueId, CancelAuthorisationRequest>();
                reslist = new Dictionary<UniqueId, CancelAuthorisationResponse>();
            }
            else
            {
                reqlist = (Dictionary<UniqueId, CancelAuthorisationRequest>)System.Web.HttpContext.Current.Application["reqlist"];
                reslist = (Dictionary<UniqueId, CancelAuthorisationResponse>)System.Web.HttpContext.Current.Application["reslist"];
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
            //reqlist.Clear();
            CancelAuthorisationResponse res = null;
            if (reslist.ContainsKey(uuid))
            {
                res = reslist[uuid];
                reslist.Remove(uuid);
            }
            else
            {
                res = new CancelAuthorisationResponse();
            }
            reqlist.Remove(uuid);
            
            return res;
        }
    }
}
