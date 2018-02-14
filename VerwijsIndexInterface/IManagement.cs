using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Denion.WebService.VerwijsIndex
{
    [ServiceContract(Name = "Management", Namespace = "https://verwijsindex.shpv.nl/service/")]
    public interface IManagement
    {
        [OperationContract]
        int QueueLength();

        [OperationContract]
        int ReInit();
        
        [OperationContract]
        StatusResponse ServiceStatus();
    }
}
