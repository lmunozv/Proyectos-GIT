using Bizagi.Proxy.Layer.BusinessObjects.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Bizagi.Proxy.Layer.Facade
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServicioGestionSeguros" in both code and config file together.
    [ServiceContract]
    public interface IServicioGestionSeguros
    {
        [OperationContract]
        AjustePNCSegurosResponse AjustarPNCSeguros(AjustePNCSegurosRequest request);
    }
}
