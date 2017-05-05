using Bizagi.Proxy.Layer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;

namespace Bizagi.Proxy.Layer.HUB.FirmarDocumentos
{
    public class FirmaDocumentosImpl2
    {
        public FirmaDocuementoClient.FirmarDocumentoRsType FirmarDocumento(FirmaDocuementoClient.firmarDocumento_Input input)
        {
            try
            {
                ProxyUtils.ByPassCertificate();
                FirmaDocuementoClient.PKI_FirmaDocumentoPortTypeClient ClientWs =
                 new FirmaDocuementoClient.PKI_FirmaDocumentoPortTypeClient();
                ClientWs.ClientCredentials.UserName.UserName = ProxyUtils.GetServiceUser("UsrServices");
                ClientWs.ClientCredentials.UserName.Password = ProxyUtils.GetServicePwd("PwdServices");
                using (OperationContextScope scope = new OperationContextScope(ClientWs.InnerChannel))
                {
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] =
                        ProxyUtils.GetHttpRequestMessageProperty();
                    var SomeResposne = ClientWs.firmarDocumento(input);
                    return SomeResposne.FirmarDocumentoRs;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
