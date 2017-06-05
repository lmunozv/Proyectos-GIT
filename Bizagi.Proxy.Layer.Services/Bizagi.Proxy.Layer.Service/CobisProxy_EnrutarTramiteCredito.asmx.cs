using Bizagi.Proxy.Layer.Service.Manager;
using Bizagi.Proxy.Layer.Service.Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace Bizagi.Proxy.Layer.Service
{
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class CobisProxy_EnrutarTramiteCredito : System.Web.Services.WebService
    {    
        [TraceExtensionAttribute]
        [WebMethod]
        public Bizagi.Proxy.Layer.Cobis.EnrutarTramiteCredito.Cobis_EnrutarTramite.enrutarTramiteCredito_Output enrutarTramiteRequest(Cobis.EnrutarTramiteCredito.Cobis_EnrutarTramite.enrutarTramiteCredito_Input input)
        {
            ITramites cliente = new CobisManager();
            return cliente.EnrutarTramiteCredito(input);
        }
    }
}
