using Bizagi.Proxy.Layer.Cobis.RecuperarInfoPJ.Cliente_RecuperarInfoPJ;
using System;
using System.Net;
using System.Text;

/// <summary>
/// Summary description for Class1
/// </summary>
/// 
public partial class Cobis_RecuperarInfoPersonaJuriImpl : Cliente_RecuperarInformacionPersonaJuridica_Service
{


    protected override WebRequest GetWebRequest(Uri uri)
        {
            HttpWebRequest request;
            request = (HttpWebRequest)base.GetWebRequest(uri);

            if (PreAuthenticate)
            {
                NetworkCredential networkCredentials =
                Credentials.GetCredential(uri, "Basic");

                if (networkCredentials != null)
                {
                    byte[] credentialBuffer = new UTF8Encoding().GetBytes(
                    networkCredentials.UserName + ":" +
                    networkCredentials.Password);
                    request.Headers["Authorization"] =
                    "Basic " + Convert.ToBase64String(credentialBuffer);
                }
                else
                {
                    throw new ApplicationException("No network credentials");
                }
            }
            return request;
        }

}
