using Bizagi.Proxy.Layer.Cobis.EnrutarTramiteCredito;
using Bizagi.Proxy.Layer.Cobis.RecuperarDetalleTramite;
using Bizagi.Proxy.Layer.Cobis.RecuperarInfoPN;
using Bizagi.Proxy.Layer.Cobis.RecuperarTramites;
using Bizagi.Proxy.Layer.Cobis.ValidarExistenciaCliente;
using Bizagi.Proxy.Layer.Service.Manager.Interfaces;
using Bizagi.Proxy.Layer.Util;
using System.Net;

namespace Bizagi.Proxy.Layer.Service.Manager
{
    public class CobisManager : ICliente, ITramites
    {
        #region Cliente
        public Cobis.ValidarExistenciaCliente.Cliente_ValidarExistencia_WCF.validarexistencia_Output
           ValidarExistenciaCliente(Cobis.ValidarExistenciaCliente.Cliente_ValidarExistencia_WCF.validarexistencia_Input input)
        {
            Cobis_ValidarExistenciaImpl2 cliente = new Cobis_ValidarExistenciaImpl2();
            return cliente.ValidarExistencia(input);
        }

        public Cobis.RecuperarInfoPJ.Cliente_RecuperarInfoPJ.ServicioResponse recuperarInfoBasicaPersonaJuridicaRequest(Cobis.RecuperarInfoPJ.Cliente_RecuperarInfoPJ.ConsumerHeader head, Cobis.RecuperarInfoPJ.Cliente_RecuperarInfoPJ.ServiceRequest body)
        {
            ProxyUtils.ByPassCertificate();
            Cobis_RecuperarInfoPersonaJuriImpl ser = new Cobis_RecuperarInfoPersonaJuriImpl();
            ser.consumerHeader = head;
            ser.Url = ProxyUtils.GetServiceEndpoint("URLRecuperarInfoPJ");
            NetworkCredential credential = ProxyUtils.getReceivedCredentials();
            //si no vienen credenciales basic, no se crea estructura de seguridad. 
            //sino, se genera excepción cuando hayan peticiones sin autenticación.
            if (credential != null)
            {
                ser.Credentials = credential;
                ser.PreAuthenticate = true;
            }
            return ser.RecuperarInformacionPersonaJuridica(body);
        }

        public Cobis.RecuperarInfoPN.ClientePersonaNaturalCliente.recuperarInfoBasica_Output
           RecuperarInfoBasicaPersonaNatural(Cobis.RecuperarInfoPN.ClientePersonaNaturalCliente.recuperarInfoBasica_Input input)
        {
            Cobis_RecuperarInfoPNImpl2 cliente = new Cobis_RecuperarInfoPNImpl2();
            return cliente.RecuperarInfoBasicaPersonaNatural(input);
        }
        #endregion

        #region Tramites
        public Cobis.RecuperarTramites.Cliente_RecuperarTramite.consultarTramitesCreditoPorIdentificacion_Output
            RecuperarTramites(Cobis.RecuperarTramites.Cliente_RecuperarTramite.consultarTramitesCreditoPorIdentificacion_Input input)
        {
            Cobis_RecuperarTramistesImpl2 cliente = new Cobis_RecuperarTramistesImpl2();
            return cliente.RecuperarTramites(input);
        }    

        public Cobis.RecuperarDetalleTramite.Cliente_DetalleTramite.recuperarDetalleTramite_Output
           RecuperarDetalleTramite(Cobis.RecuperarDetalleTramite.Cliente_DetalleTramite.recuperarDetalleTramite_Input input)
        {
            Cobis_RecuperarDetalleTramiteImpl2 cliente = new Cobis_RecuperarDetalleTramiteImpl2();
            return cliente.RecuperarDetalleTramite(input);
        }

        public Bizagi.Proxy.Layer.Cobis.EnrutarTramiteCredito.Cobis_EnrutarTramite.enrutarTramiteCredito_Output 
            EnrutarTramiteCredito(Cobis.EnrutarTramiteCredito.Cobis_EnrutarTramite.enrutarTramiteCredito_Input input)
        {
            ProxyUtils.ByPassCertificate();
            Cobis_EnrutarTramiteCreditoImpl2 ser = new Cobis_EnrutarTramiteCreditoImpl2();
            return ser.EnrutarTramiteCredito(input);
        }      
        #endregion
    }
}