using Bizagi.Proxy.Layer.HUB.CorreosSeguros.Encoder;
using Bizagi.Proxy.Layer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;

namespace Bizagi.Proxy.Layer.HUB.CorreosSeguros
{
    public class CorreoSeguroImpl2
    {
        public CorreoSeguroClient.EnviarCorreoSeguroRsType EnviarCorreoSeguro(CorreoSeguroClient.headerRq head, CorreoSeguroClient.EnviarCorreoSeguroRqType body)
        {
            EndpointAddress address = new EndpointAddress(ProxyUtils.GetAddress());
            ICollection<BindingElement> bindingElements = new List<BindingElement>();
            HttpTransportBindingElement httpBindingElement = new HttpTransportBindingElement();
            CustomTextMessageBindingElement textBindingElement = new CustomTextMessageBindingElement("utf-8", "text/plain");
            bindingElements.Add(textBindingElement);
            bindingElements.Add(httpBindingElement);
            CustomBinding binding = new CustomBinding(bindingElements);


            /*************************************/


            // WebMessageFormat

            /*************************************/


            //CorreoSeguroClient.PKI_CorreoSeguroPortTypeClient ClientWs =
            //   new CorreoSeguroClient.PKI_CorreoSeguroPortTypeClient(binding, address);
            CorreoSeguroClient.PKI_CorreoSeguroPortTypeClient ClientWs =
             new CorreoSeguroClient.PKI_CorreoSeguroPortTypeClient();
            ClientWs.ClientCredentials.UserName.UserName = ProxyUtils.GetServiceUser("UsrServices");
            ClientWs.ClientCredentials.UserName.Password = ProxyUtils.GetServicePwd("PwdServices");
            using (OperationContextScope scope = new OperationContextScope(ClientWs.InnerChannel))
            {
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] =
                    ProxyUtils.GetHttpRequestMessageProperty();

                var SomeResposne = ClientWs.enviarCorreoSeguro(head, body);
                return SomeResposne;
            }


            
            
        }
    }
}
