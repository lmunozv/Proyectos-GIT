using System.Net;

/// <summary>
/// Summary description for ProxyUtils
/// </summary>
/// 
namespace Bizagi.Proxy.Layer.Util
{
    public class ProxyUtils
    {


        public static NetworkCredential getServiceCredentials()
        {
            return new NetworkCredential("Curso1", "Fondo2009", "fna");
        }


        /*
         * Esto es para que no genere inconvenientes de certificados autofirmados, por ej. un ambiente local.
         * en ambientes del fna se han instalado los certificados requeridos. 
         * 
         */
        public static void ByPassCertificate()
        {
            if (System.Configuration.ConfigurationManager.AppSettings["ByPassCertificate"].Equals("true"))
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        }

        /**
      * Permite consultar el endopoint de los servicios en el bus. 
      * 
      */
        public static string GetServiceEndpoint(string urlPropertyName)
        {
            return System.Configuration.ConfigurationManager.AppSettings[urlPropertyName];
        }

    }
}