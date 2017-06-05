using Bizagi.Proxy.Layer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Bizagi.Proxy.Layer.Cobis.RecuperarDetalleTramite
{
    public class Cobis_RecuperarDetalleTramiteImpl2
    {
        public Cliente_DetalleTramite.recuperarDetalleTramite_Output
            RecuperarDetalleTramite(Cliente_DetalleTramite.recuperarDetalleTramite_Input input)
        {
            try
            {
                ProxyUtils.ByPassCertificate();
                Cliente_DetalleTramite.Credito_RecuperarDetalleTramitePortTypeClient cliente = 
                    new Cliente_DetalleTramite.Credito_RecuperarDetalleTramitePortTypeClient();
                cliente.ClientCredentials.UserName.UserName = ProxyUtils.GetServiceUser("UsrServices");
                cliente.ClientCredentials.UserName.Password = ProxyUtils.GetServicePwd("PwdServices");
                using (OperationContextScope scope = new OperationContextScope(cliente.InnerChannel))
                {
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] =
                        ProxyUtils.GetHttpRequestMessageProperty();                    
                    return cliente.recuperarDetalleTramite(input);                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
