using Bizagi.Proxy.Layer.Util;
using System;
using System.Collections.Generic;
using System.Text;
using Bizagi.Proxy.Layer.BancoProyectos;
using System.Net;

namespace Bizagi.Proxy.Layer.BancoProyectos
{
    public static class BancoProyectosManager
    {
        public static Bizagi.Proxy.Layer.BancoProyectos.CrearProyectoInmob.CrearProyectoInmob.ServicioResponse crearProyectoInmobiliario(
            Bizagi.Proxy.Layer.BancoProyectos.CrearProyectoInmob.CrearProyectoInmob.ConsumerHeader head,
            Bizagi.Proxy.Layer.BancoProyectos.CrearProyectoInmob.CrearProyectoInmob.ServiceRequest body)
        {
            ProxyUtils.ByPassCertificate();
            BancoProyectos_CrearProyectoInmoImpl ser = new BancoProyectos_CrearProyectoInmoImpl();
            ser.consumerHeader = head;
            ser.Url = ProxyUtils.GetServiceEndpoint("URLCrearProyecto");
            NetworkCredential credential = ProxyUtils.getReceivedCredentials();
            //si no vienen credenciales basic, no se crea estructura de seguridad. 
            //sino, se genera excepción cuando hayan peticiones sin autenticación.
            if (credential != null)
            {
                ser.Credentials = credential;
                ser.PreAuthenticate = true;
            }
            return ser.CrearProyectoInmobiliario(body);
        }


        public static CrearEstructuraInmob.CrearEstructuraInmob.ServicioResponse crearEstructuraInmobiliaria(CrearEstructuraInmob.CrearEstructuraInmob.ConsumerHeader head, CrearEstructuraInmob.CrearEstructuraInmob.ServiceRequest body)
        {
            ProxyUtils.ByPassCertificate();
            BancoProyectos_CrearEstructInmoImpl ser = new BancoProyectos_CrearEstructInmoImpl();
            ser.consumerHeader = head;
            ser.Url = ProxyUtils.GetServiceEndpoint("URLCrearEstructura");
            NetworkCredential credential = ProxyUtils.getReceivedCredentials();
            //si no vienen credenciales basic, no se crea estructura de seguridad. 
            //sino, se genera excepción cuando hayan peticiones sin autenticación.
            if (credential != null)
            {
                ser.Credentials = credential;
                ser.PreAuthenticate = true;
            }
            return ser.CrearEstructuraInmobiliaria(body);
        }
    }
}
