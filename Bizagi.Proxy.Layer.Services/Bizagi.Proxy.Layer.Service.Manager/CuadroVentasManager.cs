using Bizagi.Proxy.Layer.CuadroVentas.CrearSolicitud.CrearSolicitud;
using Bizagi.Proxy.Layer.Util;
using System;
using System.Collections.Generic;
using System.Net;
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
            ser.Url = ProxyUtils.GetServiceEndpoint("URLCrearSolicitud");
            NetworkCredential credential = ProxyUtils.getReceivedCredentials();
            //si no vienen credenciales basic, no se crea estructura de seguridad. 
            //sino, se genera excepción cuando hayan peticiones sin autenticación.
            if (credential != null)
            {
                ser.Credentials = credential;
                ser.PreAuthenticate = true;
            }
            return ser.CrearSolicitud(body);
        }
    }
}
