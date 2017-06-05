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
    /// Summary description for CobisProxy_RecuperarInfoPJService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CobisProxy_RecuperarInfoPJService : System.Web.Services.WebService
    {
        public Bizagi.Proxy.Layer.Cobis.RecuperarInfoPJ.Cliente_RecuperarInfoPJ.ConsumerHeader header;
        [TraceExtensionAttribute]
        [WebMethod]
        [SoapHeader("header")]
        public Bizagi.Proxy.Layer.Cobis.RecuperarInfoPJ.Cliente_RecuperarInfoPJ.ServicioResponse recuperarInfoBasicaPersonaJuridicaRequest(Bizagi.Proxy.Layer.Cobis.RecuperarInfoPJ.Cliente_RecuperarInfoPJ.ServiceRequest DatosCliente)
        {
            ICliente cliente = new CobisManager();
            return cliente.recuperarInfoBasicaPersonaJuridicaRequest(header, DatosCliente);
        }
    }
}
