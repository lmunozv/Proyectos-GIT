using Bizagi.Proxy.Layer.Service.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Bizagi.Proxy.Layer.Service
{
    /// <summary>
    /// Summary description for HUB_GenerarMinuta
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class HUB_GenerarMinuta : System.Web.Services.WebService
    {
        [WebMethod]
        public HUB.GenerarMinuta.Clinte_HubDocumental.migrarSolicitudReparto_Output
            GenerarMinuta(HUB.GenerarMinuta.Clinte_HubDocumental.migrarSolicitudReparto_Input input)
        {
            return HUBManager.GenerarMinuta(input);
        }
    }
}
