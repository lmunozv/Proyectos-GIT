using Bizagi.Proxy.Layer.Util;
using System;
using System.Collections.Generic;
using System.Text;

    public static class CobisManager
    {
        public static ServicioResponse validarExistencia(ConsumerHeader head, ServiceRequest body)
        {
            ProxyUtils.ByPassCertificate();
            Cobis_ValidarExistenciaImpl ser = new Cobis_ValidarExistenciaImpl();
            ser.consumerHeader = head;
        ser.Url = "https://172.16.123.110:7094/esb/services/soap";
            ser.Credentials = ProxyUtils.getServiceCredentials();
            ser.PreAuthenticate = true;
            return ser.ValidarExistencia(body);
        }


    public static ServiceResponse recuperarInfoBasicaPersonaJuridica(ConsumerHeader head, ServiceRequest1 body)
        {
            ProxyUtils.ByPassCertificate();
            Cobis_RecuperarInfoBasicaPersonaJuriImpl ser = new Cobis_RecuperarInfoBasicaPersonaJuriImpl();
            ser.consumerHeader = head;
        ser.Url = "https://172.16.123.110:7094/esb/services/soap";

        ser.Credentials = ProxyUtils.getServiceCredentials();
            ser.PreAuthenticate = true;
            return ser.RecuperarInformacionBasicaPersonaJuridica(body);
        }

    }
