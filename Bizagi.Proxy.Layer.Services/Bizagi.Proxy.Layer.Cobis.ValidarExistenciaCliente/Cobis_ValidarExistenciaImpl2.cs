using Bizagi.Proxy.Layer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Bizagi.Proxy.Layer.Cobis.ValidarExistenciaCliente
{
    public class Cobis_ValidarExistenciaImpl2
    {
        public Cliente_ValidarExistencia_WCF.validarexistencia_Output
            ValidarExistencia(Cliente_ValidarExistencia_WCF.validarexistencia_Input input)
        {
            try
            {
                ProxyUtils.ByPassCertificate();
                Cliente_ValidarExistencia_WCF.Cliente_validarexistenciaPortTypeClient cliente =
                    new Cliente_ValidarExistencia_WCF.Cliente_validarexistenciaPortTypeClient();
                cliente.ClientCredentials.UserName.UserName = ProxyUtils.GetServiceUser("UsrServices");
                cliente.ClientCredentials.UserName.Password = ProxyUtils.GetServicePwd("PwdServices");
                using (OperationContextScope scope = new OperationContextScope(cliente.InnerChannel))
                {
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] =
                        ProxyUtils.GetHttpRequestMessageProperty();
                    return cliente.ValidarExistencia(input);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
