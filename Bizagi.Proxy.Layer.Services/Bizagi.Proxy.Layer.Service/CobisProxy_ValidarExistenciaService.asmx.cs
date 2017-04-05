using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace Bizagi.Proxy.Layer.Service
{
    /// <summary>
    /// Servicio que permite validar la existencia de un cliente
    /// en el core de COBIS pasando por el ESB.
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line 
    // [System.Web.Script.Services.ScriptService]
    public class CobisProxy_ValidarExistenciaService : System.Web.Services.WebService
    {
        public Bizagi.Proxy.Layer.Cobis.ValidarExistenciaCliente.Cliente_ValidarExistencia.ConsumerHeader header;
        [TraceExtensionAttribute]
        [WebMethod]
        [SoapHeader("header")]
        public Bizagi.Proxy.Layer.Cobis.ValidarExistenciaCliente.Cliente_ValidarExistencia.ServicioResponse validarExistenciarRequest(Bizagi.Proxy.Layer.Cobis.ValidarExistenciaCliente.Cliente_ValidarExistencia.ServiceRequest DatosCliente)
        {
            return Bizagi.Proxy.Layer.Service.Manager.CobisManager.validarExistenciaRequest(header, DatosCliente);
        }
    }
}
