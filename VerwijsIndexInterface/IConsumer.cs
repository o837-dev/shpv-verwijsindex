using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Denion.WebService.VerwijsIndex
{
    [ServiceContract(Name = "Consumer", Namespace = "https://verwijsindex.shpv.nl/service/")]
    public interface IConsumer
    {
        [OperationContract]
        CancelAuthorisationResponse CancelAuthorisation(CancelAuthorisationRequest CancelAuthorisationRequest);

        [OperationContract]
        ActivateAuthorisationResponse ActivateAuthorisation(ActivateAuthorisationRequest ActivateAuthorisationRequest);

    }
}
