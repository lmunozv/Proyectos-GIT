using Bizagi.Proxy.Layer.HUB.CorreosSeguros.Encoder;
using Bizagi.Proxy.Layer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml;

namespace Bizagi.Proxy.Layer.HUB.CorreosSeguros
{
    public class CorreoSeguroImpl2
    {
        public CorreoSeguroClient.EnviarCorreoSeguroRsType EnviarCorreoSeguro(CorreoSeguroClient.enviarCorreoSeguro_Input input)
        {
            ProxyUtils.ByPassCertificate();
            CorreoSeguroClient.PKI_CorreoSeguroPortTypeClient ClientWs =
             new CorreoSeguroClient.PKI_CorreoSeguroPortTypeClient();
            ClientWs.ClientCredentials.UserName.UserName = ProxyUtils.GetServiceUser("UsrServices");
            ClientWs.ClientCredentials.UserName.Password = ProxyUtils.GetServicePwd("PwdServices");
            using (OperationContextScope scope = new OperationContextScope(ClientWs.InnerChannel))
            {
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] =
                    ProxyUtils.GetHttpRequestMessageProperty();             
                var SomeResposne = ClientWs.enviarCorreoSeguro(input);
                return SomeResposne.EnviarCorreoSeguroRs;
            }
        }
    }

   
}
