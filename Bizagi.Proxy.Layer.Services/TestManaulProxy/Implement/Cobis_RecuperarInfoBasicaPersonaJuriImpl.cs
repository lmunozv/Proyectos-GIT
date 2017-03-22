using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;


/// <summary>
/// Summary description for Class1
/// </summary>
/// 
public partial class Cobis_RecuperarInfoBasicaPersonaJuriImpl : Cliente_RecuperarInformacionBasicaPersonaJuridica_Service
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
