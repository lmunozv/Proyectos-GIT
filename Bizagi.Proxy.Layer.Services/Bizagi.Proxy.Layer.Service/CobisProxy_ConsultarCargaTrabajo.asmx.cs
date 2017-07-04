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
    /// Summary description for CobisProxy_ConsultarCargaTrabajo
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CobisProxy_ConsultarCargaTrabajo : System.Web.Services.WebService
    {

       
            [TraceExtensionAttribute]
            [WebMethod]
            public Bizagi.Proxy.Layer.Cobis.ConsultarCargaTrabajo.Credito_ConsultarCargaTrabajo.etapaEstacionType[]
                ConsultarCargatrabajo(Bizagi.Proxy.Layer.Cobis.ConsultarCargaTrabajo.Credito_ConsultarCargaTrabajo.consultarCargaTrabajoPorEtapa_Input input)
            {
                
                ICliente cliente = new CobisManager();
                return cliente.consultarCargaTrabajo(input);
                
            }
        }
}
