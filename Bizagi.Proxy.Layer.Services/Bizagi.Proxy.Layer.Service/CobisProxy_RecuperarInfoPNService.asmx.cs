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
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CobisProxy_RecuperarInfoPNService : System.Web.Services.WebService
    {
        public Bizagi.Proxy.Layer.Cobis.RecuperarInfoPN.Cliente_RecuperarInfoPN.ConsumerHeader header;
        [TraceExtensionAttribute(Filename = "C:/LogWSFacadeService/")]
        [WebMethod]
        [SoapHeader("header")]
        public Bizagi.Proxy.Layer.Cobis.RecuperarInfoPN.Cliente_RecuperarInfoPN.ServiceResponse RecuperarInfoBasicaPersonaNatural(Bizagi.Proxy.Layer.Cobis.RecuperarInfoPN.Cliente_RecuperarInfoPN.ServiceRequest DatosCliente)
        {
            return Bizagi.Proxy.Layer.Service.Manager.CobisManager.RecuperarInfoBasicaPersonaNatural(header, DatosCliente);
        }
    }
}
