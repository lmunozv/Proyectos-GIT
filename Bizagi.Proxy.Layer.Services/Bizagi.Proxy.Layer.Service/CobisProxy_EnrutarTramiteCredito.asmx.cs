using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace Bizagi.Proxy.Layer.Service
{
   

    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
   

    public class CobisProxy_EnrutarTramiteCredito : System.Web.Services.WebService
    {
        //public Bizagi.Proxy.Layer.Cobis.EnrutarTramiteCredito.Credito_EnrutarTramiteCredito.ConsumerHeader header;
        //[TraceExtensionAttribute]
        //[WebMethod]
        //[SoapHeader("header")]
        //public Bizagi.Proxy.Layer.Cobis.EnrutarTramiteCredito.Credito_EnrutarTramiteCredito.EnrutarTramiteCreditoRsType enrutarTramiteRequest(Bizagi.Proxy.Layer.Cobis.EnrutarTramiteCredito.Credito_EnrutarTramiteCredito.EnrutarTramiteCreditoRqType DatosTramite)
        //{
        //    return Bizagi.Proxy.Layer.Service.Manager.CobisManager.EnrutarTramiteCredito(header, DatosTramite);
        //}


        public void enrutarTramiteRequest(Cobis.EnrutarTramiteCredito.Cobis_EnrutarTramite.enrutarTramiteCredito_Input input)
        {
            Bizagi.Proxy.Layer.Service.Manager.CobisManager.EnrutarTramiteCredito(input);
        }
    }
}
