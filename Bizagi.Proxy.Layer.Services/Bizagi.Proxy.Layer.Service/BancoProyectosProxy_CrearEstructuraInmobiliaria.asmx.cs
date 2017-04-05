using Bizagi.Proxy.Layer.BancoProyectos;
using Bizagi.Proxy.Layer.BancoProyectos.CrearEstructuraInmob.CrearEstructuraInmob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace Bizagi.Proxy.Layer.Service
{
    /// <summary>
    /// Summary description for BancoProyectosProxy_CrearEstructuraInmobiliaria
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BancoProyectosProxy_CrearEstructuraInmobiliaria : System.Web.Services.WebService
    {

        public ConsumerHeader head;

        [TraceExtensionAttribute]
        [WebMethod]
        [SoapHeader("head")]
        public ServicioResponse crearEstructuraInmobiliariaRequest(ServiceRequest DatosProyecto)
        {
            return BancoProyectosManager.crearEstructuraInmobiliaria(head, DatosProyecto);
        }
    }
}
