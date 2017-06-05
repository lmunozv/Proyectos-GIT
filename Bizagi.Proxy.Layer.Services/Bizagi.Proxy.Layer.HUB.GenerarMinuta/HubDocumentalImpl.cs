using Bizagi.Proxy.Layer.Util;
using Bizagi.Proxy.Utils.Serializar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;

namespace Bizagi.Proxy.Layer.HUB.GenerarMinuta
{
    public class HubDocumentalImpl
    {
        public static Clinte_HubDocumental.migrarSolicitudReparto_Output GenerarMinuta(Clinte_HubDocumental.migrarSolicitudReparto_Input input)
        {
            try
            {
                ProxyUtils.ByPassCertificate();
               Clinte_HubDocumental.Credito_MigrarSolicitudRepartoPortTypeClient ClientWs =
                 new Clinte_HubDocumental.Credito_MigrarSolicitudRepartoPortTypeClient();
                ClientWs.ClientCredentials.UserName.UserName = ProxyUtils.GetServiceUser("UsrServices");
                ClientWs.ClientCredentials.UserName.Password = ProxyUtils.GetServicePwd("PwdServices");
                using (OperationContextScope scope = new OperationContextScope(ClientWs.InnerChannel))
                {
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] =
                        ProxyUtils.GetHttpRequestMessageProperty();
                    var SomeResponse = ClientWs.migrarSolicitudReparto(input);
                    return SomeResponse;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}