using Bizagi.Proxy.Layer.Cobis.RecuperarDetalleTramite.Cliente_RecuperarDetalleTramite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace Bizagi.Proxy.Layer.Service
{
    /// <summary>
    /// Summary description for CobisProxy_RecuperarDetalleTramiteService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CobisProxy_RecuperarDetalleTramiteService : System.Web.Services.WebService
    {
        //public Cobis.RecuperarDetalleTramite.Cliente_RecuperarDetalleTramite.ConsumerHeader header;
        [TraceExtensionAttribute]
        [WebMethod]
        //[SoapHeader("header")]        
        public RecuperarDetalleTramiteRsType RecuperarDetalleTramite(Cobis.RecuperarDetalleTramite.Cliente_RecuperarDetalleTramite.ConsumerHeader header,
        RecuperarDetalleTramiteRqType DatosTramite)
        {
            return Bizagi.Proxy.Layer.Service.Manager.CobisManager.RecuperarDetalleTramite(header, DatosTramite);
        }
    }
}
