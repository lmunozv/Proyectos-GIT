using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Bizagi.Proxy.Layer.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHUBProxy_GenerarMinutaService" in both code and config file together.
    [ServiceContract]
    public interface IHUBProxy_GenerarMinutaService
    {
        [OperationContract]
       int GenerarMinuta(solicitudType solicitud);
       
    }
}
