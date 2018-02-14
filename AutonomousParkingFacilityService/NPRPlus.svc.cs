using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Denion.WebService.VerwijsIndex;

namespace AutonomousParkingFacilityService
{
    public class NPRPlus : Denion.WebService.VerwijsIndex.INprPlus
    {
        public ActivateEnrollRequestResponse ActivateEnroll(ActivateEnrollRequestRequest request)
        {
            throw new NotImplementedException();
        }

        public RevokedByThirdPartyRequestResponse RevokedByThirdParty(RevokedByThirdPartyRequestRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
