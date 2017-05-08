using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for ProxyUtils
/// </summary>
/// 
namespace Bizagi.Proxy.Layer.Util
{
    public class ProxyUtils
    {

        /**
        * funcion para obtener las credenciales basic enviadas en la cabecera del mensaje.
        * 
        */
        public static NetworkCredential getReceivedCredentials()
        {
            return new NetworkCredential(ProxyUtils.GetServiceUser("UsrServices"), ProxyUtils.GetServicePwd("PwdServices"));
            //HttpContext httpContext = HttpContext.Current;
            //string authHeader = httpContext.Request.Headers["Authorization"];
            //if (authHeader != null && authHeader.StartsWith("Basic"))
            //{
            //    string encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
            //    Encoding encoding = Encoding.GetEncoding("iso-8859-1");
            //    string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));
            //    int seperatorIndex = usernamePassword.IndexOf(':');
            //    var username = usernamePassword.Substring(0, seperatorIndex);
            //    var password = usernamePassword.Substring(seperatorIndex + 1);
            //    return new NetworkCredential(username, password);
            //}
            //else
            //{
            //    return null;
            //}
        }


        /**
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

        /**
        * Permite consultar el usuario de servicios en el bus. 
        * 
        */
        public static string GetServiceUser(string usrService)
        {
            return System.Configuration.ConfigurationManager.AppSettings[usrService];
        }

        /**
         * Permite consultar el usuario de servicios en el bus. 
         * 
         */
        public static string GetServicePwd(string pwdService)
        {
            return System.Configuration.ConfigurationManager.AppSettings[pwdService];
        }


        public static string GetBase64String(string text)
        {
            byte[] encodedByte = System.Text.ASCIIEncoding.ASCII.GetBytes(text);
            string base64Encoded = Convert.ToBase64String(encodedByte);
            return base64Encoded;
        }

        public static string GetAddress()
        {
            return ConfigurationManager.AppSettings["URLCorreoSeguro"];
        }

        public static CustomBinding CreateCustomBinding()
        {
            ProxyUtils.ByPassCertificate();
            WSMessageEncoding msgEncoding;
            msgEncoding = WSMessageEncoding.Mtom;
            BasicHttpSecurityMode sec = BasicHttpSecurityMode.TransportWithMessageCredential;            
            BasicHttpBinding basicBinding = new BasicHttpBinding(sec)
            {
                Security =
                {
                    Message =
                    {
                        ClientCredentialType = BasicHttpMessageCredentialType.UserName
                    }
                },
                MessageEncoding = msgEncoding,
            };
            var elements = basicBinding.CreateBindingElements();           
            if (msgEncoding == WSMessageEncoding.Text)
            {
                TextMessageEncodingBindingElement te = elements.Find<TextMessageEncodingBindingElement>();
                te.MessageVersion = MessageVersion.Soap12;
            }
            else
            {
                MtomMessageEncodingBindingElement te = elements.Find<MtomMessageEncodingBindingElement>();
                te.MessageVersion = MessageVersion.Soap12;
            }            
            CustomBinding customBinding = new CustomBinding(elements);           
            return customBinding;
        }

        public static HttpRequestMessageProperty GetHttpRequestMessageProperty()
        {
            HttpRequestMessageProperty httpRequestMessageProperty = new HttpRequestMessageProperty();
            httpRequestMessageProperty.Headers[HttpRequestHeader.Authorization] = "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(ProxyUtils.GetServiceUser("UsrServices") + ":" + ProxyUtils.GetServicePwd("PwdServices")));
            return httpRequestMessageProperty;
        }
    }
}