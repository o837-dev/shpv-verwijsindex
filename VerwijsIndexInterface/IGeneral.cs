using System;
using System.Runtime.Serialization;

namespace Denion.WebService.VerwijsIndex
{
    [DataContract(Namespace = "https://verwijsindex.shpv.nl/messages/")]
    public class StatusResponse
    {
        [DataMember(Order = 0, IsRequired = false)]
        public string Message { get; set; }

        [DataMember(Order = 1, IsRequired = false)]
        public DateTime CheckTime { get; set; }
    }
}
