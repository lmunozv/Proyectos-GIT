using Bizagi.Proxy.Layer.Service.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace Bizagi.Proxy.Layer.Service
{
    /// <summary>
    /// Servicio que consulta los tramite de un consumidor financiero
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]    
    public class CobisProxy_RecuperarTramites : System.Web.Services.WebService
    {        
        [TraceExtensionAttribute(Filename = "C:/LogWSFacadeService/")]
        [WebMethod]        
        public Cobis.RecuperarTramites.Cliente_RecuperarTramites.TramiteType2[] RecuperarTramites(Bizagi.Proxy.Layer.Cobis.RecuperarTramites.Cliente_RecuperarTramites.ConsumerHeader header, Bizagi.Proxy.Layer.Cobis.RecuperarTramites.Cliente_RecuperarTramites.ConsultarTramitesCreditoPorIdentificacionRq body)
        {
           return   CobisManager.RecuperarTramites(header, body);
        }
    }
}
