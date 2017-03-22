using System.Web.Services;
using System.Web.Services.Protocols;

/// <summary>
/// Summary description for CobisProxyRecuperarInfoPJ
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class CobisProxy_RecuperarInfoPJService : System.Web.Services.WebService
{

    public Bizagi.Proxy.Layer.Cobis.RecuperarInfoPJ.Cliente_RecuperarInfoPJ.ConsumerHeader header;


    [TraceExtensionAttribute(Filename = "C:/LogWSFacadeService/")]
    [WebMethod]
    [SoapHeader("header")]
    public Bizagi.Proxy.Layer.Cobis.RecuperarInfoPJ.Cliente_RecuperarInfoPJ.ServicioResponse recuperarInfoBasicaPersonaJuridicaRequest(Bizagi.Proxy.Layer.Cobis.RecuperarInfoPJ.Cliente_RecuperarInfoPJ.ServiceRequest DatosCliente)
    {
        return Bizagi.Proxy.Layer.Service.Manager.CobisManager.recuperarInfoBasicaPersonaJuridicaRequest(header, DatosCliente);
    }
}
