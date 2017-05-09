using Bizagi.Proxy.Layer.Cobis.EnrutarTramiteCredito;
using Bizagi.Proxy.Layer.Util;
using System.Net;

namespace Bizagi.Proxy.Layer.Service.Manager
{
    public static class CobisManager
    {
        public static Layer.Cobis.ValidarExistenciaCliente.Cliente_ValidarExistencia.ServicioResponse validarExistenciaRequest(
            Layer.Cobis.ValidarExistenciaCliente.Cliente_ValidarExistencia.ConsumerHeader head, Layer.Cobis.ValidarExistenciaCliente.Cliente_ValidarExistencia.ServiceRequest body)

        {
            ProxyUtils.ByPassCertificate();
            Cobis_ValidarExistenciaImpl ser = new Cobis_ValidarExistenciaImpl();
            ser.consumerHeader = head;
            ser.Url = ProxyUtils.GetServiceEndpoint("URLValidarExistencia");
            NetworkCredential credential = ProxyUtils.getReceivedCredentials();
            //si no vienen credenciales basic, no se crea estructura de seguridad. 
            //sino, se genera excepción cuando hayan peticiones sin autenticación.
            if (credential != null)
            {
                ser.Credentials = credential;
                ser.PreAuthenticate = true;
            }
            return ser.ValidarExistencia(body);
        }


        public static Cobis.RecuperarInfoPJ.Cliente_RecuperarInfoPJ.ServicioResponse recuperarInfoBasicaPersonaJuridicaRequest(Cobis.RecuperarInfoPJ.Cliente_RecuperarInfoPJ.ConsumerHeader head, Cobis.RecuperarInfoPJ.Cliente_RecuperarInfoPJ.ServiceRequest body)
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

        #region Legalización
        public static Cobis.RecuperarInfoPN.Cliente_RecuperarInfoPN.ServiceResponse RecuperarInfoBasicaPersonaNatural(Cobis.RecuperarInfoPN.Cliente_RecuperarInfoPN.ConsumerHeader head, Cobis.RecuperarInfoPN.Cliente_RecuperarInfoPN.ServiceRequest body)
        {
            ProxyUtils.ByPassCertificate();
            Cobis_RecuperarInfoPNImpl ser = new Cobis_RecuperarInfoPNImpl();
            ser.consumerHeader = head;
            ser.Url = ProxyUtils.GetServiceEndpoint("URLRecuperarInfoPN");
            NetworkCredential credential = ProxyUtils.getReceivedCredentials();
            //si no vienen credenciales basic, no se crea estructura de seguridad. 
            //sino, se genera excepción cuando hayan peticiones sin autenticación.
            if (credential != null)
            {
                ser.Credentials = credential;
                ser.PreAuthenticate = true;
            }
            return ser.recuperarInformacion(body);
        }

        public static Cobis.RecuperarDetalleTramite.Cliente_RecuperarDetalleTramite.RecuperarDetalleTramiteRsType RecuperarDetalleTramite(Cobis.RecuperarDetalleTramite.Cliente_RecuperarDetalleTramite.ConsumerHeader head, 
            Cobis.RecuperarDetalleTramite.Cliente_RecuperarDetalleTramite.RecuperarDetalleTramiteRqType body)
        {
            ProxyUtils.ByPassCertificate();
            Cobis_RecuperarDetalleTramiteImpl ser = new Cobis_RecuperarDetalleTramiteImpl();
            ser.headerRq = head;
            ser.Url = ProxyUtils.GetServiceEndpoint("URLRecuperarDetalleTramite");
            NetworkCredential credential = ProxyUtils.getReceivedCredentials();
            //si no vienen credenciales basic, no se crea estructura de seguridad. 
            //sino, se genera excepción cuando hayan peticiones sin autenticación.
            if (credential != null)
            {
                ser.Credentials = credential;
                ser.PreAuthenticate = true;
            }
            return ser.recuperarDetalleTramite(body);
        }

        public static Cobis.RecuperarTramites.Cliente_RecuperarTramites.TramiteType2[] RecuperarTramites(Bizagi.Proxy.Layer.Cobis.RecuperarTramites.Cliente_RecuperarTramites.ConsumerHeader header, Bizagi.Proxy.Layer.Cobis.RecuperarTramites.Cliente_RecuperarTramites.ConsultarTramitesCreditoPorIdentificacionRq body)
        {
            ProxyUtils.ByPassCertificate();
            Cobis_RecuperarTramistesImpl ser = new Cobis_RecuperarTramistesImpl();
            ser.headerRq = header;
            ser.Url = ProxyUtils.GetServiceEndpoint("URLRecuperarTramite");
            NetworkCredential credential = ProxyUtils.getReceivedCredentials();
            //si no vienen credenciales basic, no se crea estructura de seguridad. 
            //sino, se genera excepción cuando hayan peticiones sin autenticación.
            if (credential != null)
            {
                ser.Credentials = credential;
                ser.PreAuthenticate = true;
            }
            return ser.consultarTramitesCreditoPorIdentificacion(body);

        }

        public static Bizagi.Proxy.Layer.Cobis.EnrutarTramiteCredito.Cobis_EnrutarTramite.enrutarTramiteCredito_Output EnrutarTramiteCredito(Cobis.EnrutarTramiteCredito.Cobis_EnrutarTramite.enrutarTramiteCredito_Input input)
        {
            ProxyUtils.ByPassCertificate();
            Cobis_EnrutarTramiteCreditoImpl2 ser = new Cobis_EnrutarTramiteCreditoImpl2();
            return ser.EnrutarTramiteCredito(input);
        }


        //public static Cobis.EnrutarTramiteCredito.Credito_EnrutarTramiteCredito.EnrutarTramiteCreditoRsType EnrutarTramiteCredito(Cobis.EnrutarTramiteCredito.Credito_EnrutarTramiteCredito.ConsumerHeader head,
        //    Cobis.EnrutarTramiteCredito.Credito_EnrutarTramiteCredito.EnrutarTramiteCreditoRqType body)
        //{
        //    ProxyUtils.ByPassCertificate();
        //    Cobis_EnrutarTramiteCreditoImpl ser = new Cobis_EnrutarTramiteCreditoImpl();
        //    ser.headerRq = head;
        //    ser.Url = ProxyUtils.GetServiceEndpoint("URLEnrutarTramiteCredito");
        //    NetworkCredential credential = ProxyUtils.getReceivedCredentials();
        //    //si no vienen credenciales basic, no se crea estructura de seguridad. 
        //    //sino, se genera excepción cuando hayan peticiones sin autenticación.
        //    if (credential != null)
        //    {
        //        ser.Credentials = credential;
        //        ser.PreAuthenticate = true;
        //    }
        //    Cobis.EnrutarTramiteCredito.Credito_EnrutarTramiteCredito.EnrutarTramiteCreditoRsType a = ser.enrutarTramiteCredito(body);
        //    Cobis.EnrutarTramiteCredito.Credito_EnrutarTramiteCredito.ConsumerHeaderResponse_v10 headerRs = ser.headerRs;
        //    return a;
        //}
        #endregion
    }
}