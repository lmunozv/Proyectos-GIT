using Bizagi.Proxy.Layer.HUB.CorreosSeguros.Cliente_CorreoSeguro;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;

public partial class CorreoSeguroImpl : PKI_CorreoSeguroService
{
    protected override WebRequest GetWebRequest(Uri uri)
    {
        HttpWebRequest request;
        request = (HttpWebRequest)base.GetWebRequest(uri);      
        request.ContentType= ConfigurationManager.AppSettings["ContentTypeRQ"];        
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
    

    protected override WebResponse GetWebResponse(WebRequest request)
    {
        request.ContentType = ConfigurationManager.AppSettings["ContentTypeRQ"];
        WebResponse response = base.GetWebResponse(request);
        response.Headers[HttpResponseHeader.ContentType] = ConfigurationManager.AppSettings["ContentTypeRS"];
        return response;
    }
}

