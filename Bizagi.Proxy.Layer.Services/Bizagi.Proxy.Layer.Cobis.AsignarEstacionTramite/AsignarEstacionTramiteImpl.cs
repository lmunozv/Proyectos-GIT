using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml;
using Bizagi.Proxy.Layer.Util;
using Bizagi.Proxy.Layer.Cobis.AsignarEstacionTramite.Credito_AsignarEstacionTramite;


namespace Bizagi.Proxy.Layer.Cobis.ConsultarCargaTrabajo
{
    public class AsignarEstacionTramiteImpl
    {
        public asignarEstacionTramite_Output asignarEstacionTramite(asignarEstacionTramite_Input input)
        {
            try
            {
                ProxyUtils.ByPassCertificate();
                Credito_AsignarEstacionTramitePortTypeClient ClientWs =
                 new Credito_AsignarEstacionTramitePortTypeClient();
                ClientWs.ClientCredentials.UserName.UserName = ProxyUtils.GetServiceUser("UsrServices");
                ClientWs.ClientCredentials.UserName.Password = ProxyUtils.GetServicePwd("PwdServices");
                using (OperationContextScope scope = new OperationContextScope(ClientWs.InnerChannel))
                {
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] =
                        ProxyUtils.GetHttpRequestMessageProperty();
                    var SomeResposne = ClientWs.asignarEstacionTramite(input);
                    return SomeResposne;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }   
}
