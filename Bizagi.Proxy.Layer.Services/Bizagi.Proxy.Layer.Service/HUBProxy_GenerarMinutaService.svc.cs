using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Bizagi.Proxy.Layer.HUB.GenerarMinuta.Cliente_HubDocumental;
using Bizagi.Proxy.Layer.Service.Manager;
using System.ServiceModel.Activation;

namespace Bizagi.Proxy.Layer.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HUBProxy_GenerarMinutaService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select HUBProxy_GenerarMinutaService.svc or HUBProxy_GenerarMinutaService.svc.cs at the Solution Explorer and start debugging.
    public class HUBProxy_GenerarMinutaService : IHUBProxy_GenerarMinutaService
    {
        
        public int GenerarMinuta(solicitudType solicitud)
        {
            return HUBManager.GenerarMinuta(solicitud);
        }
    }
}
