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
    /// <summary>
    /// Summary description for CobisProxy_RecuperarInfoPNService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]   
    public class CobisProxy_RecuperarInfoPNService : System.Web.Services.WebService
    {
        [TraceExtensionAttribute]
        [WebMethod]
        public Cobis.RecuperarInfoPN.ClientePersonaNaturalCliente.recuperarinformacion_output
            RecuperarInfoBasicaPersonaNatural(Cobis.RecuperarInfoPN.ClientePersonaNaturalCliente.recuperarinformacion_input input)
        {
            ICliente cliente = new CobisManager();
            return cliente.RecuperarInfoBasicaPersonaNatural(input);
        }        
    }
}
