using Bizagi.Proxy.Layer.Cobis.RecuperarTramites.Cliente_RecuperarTramites;
using Bizagi.Proxy.Layer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;


public class Cobis_RecuperarTramistesImpl : Credito_RecuperarTramiteSolicitudesService
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

