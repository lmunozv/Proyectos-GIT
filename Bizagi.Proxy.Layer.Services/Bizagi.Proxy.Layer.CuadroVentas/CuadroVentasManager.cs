using Bizagi.Proxy.Layer.Util;
using System;
using System.Collections.Generic;
using System.Text;


namespace Bizagi.Proxy.Layer.CuadroVentas
{
    public static class CuadroVentasManager
    {
        public static ServicioResponse crearSolicitud(ConsumerHeader head, ServiceRequest body)
        {
            ProxyUtils.ByPassCertificate();
            CuadroVentas_CrearSolicitudImpl ser = new CuadroVentas_CrearSolicitudImpl();
            ser.consumerHeader = head;
            ser.Url = ProxyUtils.GetServiceEndpoint("ESBSOAPEndpoint");
            ser.Credentials = ProxyUtils.getServiceCredentials();
            ser.PreAuthenticate = true;
            return ser.CrearSolicitud(body);
        }
    }
}
