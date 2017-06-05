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
    /// Servicio que consulta los tramite de un consumidor financiero
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]    
    public class CobisProxy_RecuperarTramites : System.Web.Services.WebService
    {        
        [TraceExtensionAttribute]
        [WebMethod]
        public Cobis.RecuperarTramites.Cliente_RecuperarTramite.consultarTramitesCreditoPorIdentificacion_Output RecuperarTramites
            (Cobis.RecuperarTramites.Cliente_RecuperarTramite.consultarTramitesCreditoPorIdentificacion_Input body)
        {
            ITramites cliente = new CobisManager();
            return cliente.RecuperarTramites(body);
        }
    }
}
