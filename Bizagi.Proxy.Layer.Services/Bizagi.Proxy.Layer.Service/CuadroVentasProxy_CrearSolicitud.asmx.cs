using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Bizagi.Proxy.Layer.CuadroVentas;
using Bizagi.Proxy.Layer.CuadroVentas.CrearSolicitud.CrearSolicitud;
using System.Web.Services.Protocols;

namespace Bizagi.Proxy.Layer.Service
{
    /// <summary>
    /// Summary description for CuadroVentasProxy_CrearSolicitud
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CuadroVentasProxy_CrearSolicitud : System.Web.Services.WebService
    {
         public ConsumerHeader header;

    [TraceExtensionAttribute(Filename = "C:/LogWSFacadeService/")]
    [WebMethod]
    [SoapHeader("header")]
    public ServicioResponse crearSolicitudRequest(ServiceRequest DatosSolicitud)
    {
        return CuadroVentasManager.crearSolicitud(header, DatosSolicitud);
    }
    }
}
