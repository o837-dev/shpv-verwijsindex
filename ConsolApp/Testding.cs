using Denion.WebService.VerwijsIndex;
using System;
using System.Diagnostics;
using System.ServiceModel;

namespace ConsolApp
{
    class Testding
    {
        public Testding()
        {

            VerwijsIndexClient clnt = null;
            try
            {
                //clnt = Service.PaymentClient("https://parkeergebouwenamsterdam.nl/service/v1/service.php");
                //clnt = new VerwijsIndexClient("dev");
                clnt = Service.PaymentClient("http://acc.cp3.glimworm.net/approval.php");
                PaymentCheckRequest req2 = new PaymentCheckRequest();

                req2.AreaManagerId = "02065";
                req2.AreaId = "Centrum";
                req2.VehicleId = "AB12D";
                req2.VehicleIdType = "LICENSE_PLATE";
                req2.CheckDateTime = DateTime.Now;

                PaymentCheckResponse relayRes = clnt.PaymentCheck(req2);
                Debug.WriteLine(relayRes.Granted);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                if (clnt != null && clnt.State != CommunicationState.Closing && clnt.State != CommunicationState.Closed)
                    clnt.Close();
            }

        }
    }
}
