using Bizagi.Proxy.Layer.Service.Manager;
using Bizagi.Proxy.Layer.Service.Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Bizagi.Proxy.Layer.Service
{
    /// <summary>
    /// Summary description for CobisProxy_AsignarEstacionTramite
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CobisProxy_AsignarEstacionTramite : System.Web.Services.WebService
    {



        [TraceExtensionAttribute]
        [WebMethod]
        public Bizagi.Proxy.Layer.Cobis.AsignarEstacionTramite.Credito_AsignarEstacionTramite.asignarEstacionTramite_Output
            AsignarEstacionTramite(Bizagi.Proxy.Layer.Cobis.AsignarEstacionTramite.Credito_AsignarEstacionTramite.asignarEstacionTramite_Input input)
        {

            ICredito credito = new CobisManager();
            return credito.asignarEstacionTramite(input);
        }
    }
}

