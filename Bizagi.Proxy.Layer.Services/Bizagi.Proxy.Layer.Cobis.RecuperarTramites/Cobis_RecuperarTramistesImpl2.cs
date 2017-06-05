using Bizagi.Proxy.Layer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Bizagi.Proxy.Layer.Cobis.RecuperarTramites
{
    public class Cobis_RecuperarTramistesImpl2
    {
        public Cliente_RecuperarTramite.consultarTramitesCreditoPorIdentificacion_Output 
            RecuperarTramites(Cliente_RecuperarTramite.consultarTramitesCreditoPorIdentificacion_Input input)
        {            
            try
            {
                ProxyUtils.ByPassCertificate();
                Cliente_RecuperarTramite.Credito_RecuperarTramiteSolicitudesPortTypeClient cliente = new Cliente_RecuperarTramite.Credito_RecuperarTramiteSolicitudesPortTypeClient();
                cliente.ClientCredentials.UserName.UserName = ProxyUtils.GetServiceUser("UsrServices");
                cliente.ClientCredentials.UserName.Password = ProxyUtils.GetServicePwd("PwdServices");
                using (OperationContextScope scope = new OperationContextScope(cliente.InnerChannel))
                {
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] =
                        ProxyUtils.GetHttpRequestMessageProperty();
                    Cliente_RecuperarTramite.TramiteType2[] tramite;
                   return cliente.consultarTramitesCreditoPorIdentificacion(input);                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
    }
}
