using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml;
using Bizagi.Proxy.Layer.Cobis.ConsultarCargaTrabajo.Credito_ConsultarCargaTrabajo;
using Bizagi.Proxy.Layer.Util;

namespace Bizagi.Proxy.Layer.Cobis.ConsultarCargaTrabajo
{
    public class ConsultarCargaTrabajoImpl
    {
        public etapaEstacionType[] consultarCargaTrabajo(consultarCargaTrabajoPorEtapa_Input input)
        {
            try
            {
                ProxyUtils.ByPassCertificate();
                Credito_ConsultarCargaTrabajoPortTypeClient ClientWs =
                 new Credito_ConsultarCargaTrabajoPortTypeClient();
                ClientWs.ClientCredentials.UserName.UserName = ProxyUtils.GetServiceUser("UsrServices");
                ClientWs.ClientCredentials.UserName.Password = ProxyUtils.GetServicePwd("PwdServices");
                using (OperationContextScope scope = new OperationContextScope(ClientWs.InnerChannel))
                {
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] =
                        ProxyUtils.GetHttpRequestMessageProperty();
                    var SomeResposne = ClientWs.consultarCargaTrabajoPorEtapa(input);
                    return SomeResposne.ConsultarCargaTrabajoPorEtapaRs;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }   
}
