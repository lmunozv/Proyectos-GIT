using Bizagi.Proxy.Layer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Bizagi.Proxy.Layer.Cobis.RecuperarInfoPN
{
    public class Cobis_RecuperarInfoPNImpl2
    {
        public ClientePersonaNaturalCliente.recuperarinformacion_output
            RecuperarInfoBasicaPersonaNatural(ClientePersonaNaturalCliente.recuperarinformacion_input input)
        {
            try
            {
                ProxyUtils.ByPassCertificate();
                ClientePersonaNaturalCliente.ClientePersonaNatural_RecuperarInformacionPortTypeClient cliente =
                    new ClientePersonaNaturalCliente.ClientePersonaNatural_RecuperarInformacionPortTypeClient();
                cliente.ClientCredentials.UserName.UserName = ProxyUtils.GetServiceUser("UsrServices");
                cliente.ClientCredentials.UserName.Password = ProxyUtils.GetServicePwd("PwdServices");
                using (OperationContextScope scope = new OperationContextScope(cliente.InnerChannel))
                {
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] =
                        ProxyUtils.GetHttpRequestMessageProperty();
                    var res = cliente.recuperarInformacion(input);
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
