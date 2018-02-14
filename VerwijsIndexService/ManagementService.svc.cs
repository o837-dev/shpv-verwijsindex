using Denion.WebService.Database;
using System.ServiceModel;
using System;

namespace Denion.WebService.VerwijsIndex
{
    [LogBehavior]
    [ServiceBehavior(Name = "Management", Namespace = "https://verwijsindex.shpv.nl/service/")]
    public class ManagementService : IManagement
    {
        StatusResponse IManagement.ServiceStatus()
        {
            return Service.ServiceStatus();
        }

        public int QueueLength()
        {
            Timing t = new Timing("ManagementService", null, null);
            System.Threading.Thread.Sleep(2000);
            t.Finish();
            return DatabaseQueue.Length;
        }

        public int ReInit()
        {
            DatabaseFunctions.InitializeConstants();
            return 0;
        }
    }
}
