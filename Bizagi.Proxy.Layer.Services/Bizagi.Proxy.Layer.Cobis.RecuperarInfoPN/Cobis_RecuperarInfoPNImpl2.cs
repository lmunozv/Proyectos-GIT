using Bizagi.Proxy.Layer.Util;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Bizagi.Proxy.Layer.Cobis.RecuperarInfoPN
{
    public class Cobis_RecuperarInfoPNImpl2
    {
        public ClientePersonaNaturalCliente.recuperarInfoBasica_Output
            RecuperarInfoBasicaPersonaNatural(ClientePersonaNaturalCliente.recuperarInfoBasica_Input input)
        {
            try
            {
                ProxyUtils.ByPassCertificate();
                ClientePersonaNaturalCliente.Common_MessageSetPortTypeClient cliente =
                    new ClientePersonaNaturalCliente.Common_MessageSetPortTypeClient();
                cliente.ClientCredentials.UserName.UserName = ProxyUtils.GetServiceUser("UsrServices");
                cliente.ClientCredentials.UserName.Password = ProxyUtils.GetServicePwd("PwdServices");
                using (OperationContextScope scope = new OperationContextScope(cliente.InnerChannel))
                {
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] =
                        ProxyUtils.GetHttpRequestMessageProperty();
                    var res = cliente.recuperarInfoBasica(input);
                    return res;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
