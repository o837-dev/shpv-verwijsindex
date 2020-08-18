using Denion.WebService.VerwijsIndex.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace Denion.WebService.VerwijsIndex
{
    [ServiceBehavior(Name = "Bridge", Namespace = "https://verwijsindex.shpv.nl/service/")]
    public class BridgeService : IVerwijsIndex
    {
        PaymentStartResponse IVerwijsIndex.PaymentStart(PaymentStartRequest request)
        {
            Denion.WebService.Database.Database.Log("[PaymentStart] Provider: " + Settings.Default.ProviderId + "; Received: " + request.VehicleId);
            VerwijsIndexClient clnt = null;
            PaymentStartResponse psr = null;
            try
            {
                clnt = new VerwijsIndexClient();
                psr = clnt.PaymentStart(request);
            }
            catch (Exception ex)
            {
                Denion.WebService.Database.Database.Log("[PaymentStart] Provider: " + Settings.Default.ProviderId + " [Exception]; " + ex.Message + "; " + ex.StackTrace);
            }
            finally
            {
                if (clnt != null) clnt.Close();
            }

            return psr;
        }

        PaymentEndResponse IVerwijsIndex.PaymentEnd(PaymentEndRequest request)
        {
            Denion.WebService.Database.Database.Log("[PaymentEnd] Provider: " + Settings.Default.ProviderId + "; Received: " + request.VehicleId);
            VerwijsIndexClient clnt = null ;
            PaymentEndResponse per = null;
            try
            {
                clnt = new VerwijsIndexClient();
                per = clnt.PaymentEnd(request);
            }
            catch (Exception ex)
            {
                Denion.WebService.Database.Database.Log("[PaymentEnd] Provider: " + Settings.Default.ProviderId + " [Exception]; " + ex.Message + "; " + ex.StackTrace);
            }
            finally
            {
                if (clnt != null) clnt.Close();
            }

            return per;
        }

        PaymentCheckResponse IVerwijsIndex.PaymentCheck(PaymentCheckRequest request)
        {
            Denion.WebService.Database.Database.Log("[PaymentCheck] Provider: " + Settings.Default.ProviderId + "; Received: " + request.VehicleId);
            VerwijsIndexClient clnt = null;
            PaymentCheckResponse pcr = null;
            try
            {
                clnt = new VerwijsIndexClient();
                pcr = clnt.PaymentCheck(request);
            }
            catch (Exception ex)
            {
                Denion.WebService.Database.Database.Log("[PaymentCheck] Provider: " + Settings.Default.ProviderId + " [Exception]; " + ex.Message + "; " + ex.StackTrace);
            }
            finally
            {
                if (clnt != null) clnt.Close();
            }

            return pcr;
        }

        StatusResponse IVerwijsIndex.ServiceStatus()
        {
            return Service.ServiceStatus();
        }
    }
}

