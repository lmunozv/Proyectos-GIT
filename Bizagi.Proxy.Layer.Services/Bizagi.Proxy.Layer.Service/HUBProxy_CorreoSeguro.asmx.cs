using Bizagi.Proxy.Layer.Service.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Bizagi.Proxy.Layer.Service
{
    /// <summary>
    /// Summary description for HUBProxy_CorreoSeguro
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class HUBProxy_CorreoSeguro : System.Web.Services.WebService
    {
        [TraceExtensionAttribute]
        [WebMethod]
        public HUB.CorreosSeguros.CorreoSeguroClient.EnviarCorreoSeguroRsType EnviarCorreoSeguro(HUB.CorreosSeguros.CorreoSeguroClient.enviarCorreoSeguro_Input input)
        {
            return HUBManager.EnviarCorreoSeguro2(input);
        }        
    }
}
