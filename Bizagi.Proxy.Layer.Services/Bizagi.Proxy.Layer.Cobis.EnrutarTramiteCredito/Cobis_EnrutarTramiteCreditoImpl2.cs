using System;
using System.Net;
using System.Text;
using Bizagi.Proxy.Layer.Util;
using System.ServiceModel;
using System.ServiceModel.Channels;

/// <summary>
/// Summary description for Class1
/// </summary>
/// 
namespace Bizagi.Proxy.Layer.Cobis.EnrutarTramiteCredito
{
    public partial class Cobis_EnrutarTramiteCreditoImpl2
    {
        public Bizagi.Proxy.Layer.Cobis.EnrutarTramiteCredito.Cobis_EnrutarTramite.enrutarTramiteCredito_Output EnrutarTramiteCredito(Cobis_EnrutarTramite.enrutarTramiteCredito_Input input)
        {
            try
            {
                ProxyUtils.ByPassCertificate();
                Cobis_EnrutarTramite.Credito_EnrutarTramiteCreditoPortTypeClient cliente = new Cobis_EnrutarTramite.Credito_EnrutarTramiteCreditoPortTypeClient();
                cliente.ClientCredentials.UserName.UserName = ProxyUtils.GetServiceUser("UsrServices");
                cliente.ClientCredentials.UserName.Password = ProxyUtils.GetServicePwd("PwdServices");
                using (OperationContextScope scope = new OperationContextScope(cliente.InnerChannel))
                {
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] =
                        ProxyUtils.GetHttpRequestMessageProperty();
                    Bizagi.Proxy.Layer.Cobis.EnrutarTramiteCredito.Cobis_EnrutarTramite.EnrutarTramiteCreditoRsType EnrutarTramiteCreditoRs = new Cobis_EnrutarTramite.EnrutarTramiteCreditoRsType();
                    var SomeResposne = cliente.enrutarTramiteCredito(input);
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