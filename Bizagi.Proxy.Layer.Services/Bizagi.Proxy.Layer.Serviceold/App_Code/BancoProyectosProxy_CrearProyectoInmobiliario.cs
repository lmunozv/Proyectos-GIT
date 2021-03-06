﻿using Bizagi.Proxy.Layer.BancoProyectos;
using Bizagi.Proxy.Layer.BancoProyectos.CrearProyectoInmob.CrearProyectoInmob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

/// <summary>
/// Summary description for BancoProyectosProxy_CrearProyectoInmobiliario
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class BancoProyectosProxy_CrearProyectoInmobiliario : System.Web.Services.WebService
{
    public Bizagi.Proxy.Layer.BancoProyectos.CrearProyectoInmob.CrearProyectoInmob.ConsumerHeader head;

    [TraceExtensionAttribute(Filename = "C:/LogWSFacadeService/")]
    [WebMethod]
    [SoapHeader("head")]
    public ServicioResponse crearProyectoInmobiliarioRequest(ServiceRequest DatosProyecto)
    {
        return BancoProyectosManager.crearProyectoInmobiliario(head, DatosProyecto);
    }


}
