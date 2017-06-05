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
        [TraceExtensionAttribute]
        [WebMethod]
        public Cobis.ValidarExistenciaCliente.Cliente_ValidarExistencia_WCF.validarexistencia_Output
           ValidarExistenciaCliente(Cobis.ValidarExistenciaCliente.Cliente_ValidarExistencia_WCF.validarexistencia_Input input)
        {
            ICliente cliente = new CobisManager();
            return cliente.ValidarExistenciaCliente(input);
        }
    }
}
