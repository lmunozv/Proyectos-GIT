using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bizagi.Proxy.Layer.BusinessObjects.Messages;
using Bizagi.Proxy.Layer.HUB.Operations;
using System.Xml;
using System.Web;
using Bizagi.Proxy.Layer.Util;
using System.Xml.Serialization;
using System.IO;
using Bizagi.Proxy.Layer.HUB.BizagiSOAObjects.GetEntities;
using Bizagi.Proxy.Layer.HUB.BizagiSOAObjects.CreateCase;
using System.Xml.Xsl;
using Bizagi.Proxy.Layer.HUB.BizagiSOAObjects;
using System.Reflection;
using System.Xml.XPath;
using Bizagi.Proxy.Layer.Manager.Controlador;

namespace Bizagi.Proxy.Layer.Manager.Desembolso
{
    public class ControladorGestionDesembolso
    {
        private GestionDesembolsoResponse respuesta;
        public GestionDesembolsoResponse ProcesarSolicitud(GestionDesembolsoRequest notificacion)
        {

            try
            {
                string numeroTramite = notificacion.InformacionDesembolso.NumeroTramite;
                respuesta = new GestionDesembolsoResponse();
                InfoCasoDesembolso infoCasoDesembolso = consultarCasoDesembolsoPorTramite(numeroTramite);




                if (infoCasoDesembolso == null)
                {
                    // crear caso
                    respuesta = crearCasoDesembolso(notificacion);
                    return respuesta;
                }
                else
                {

                    //valida que la estación que ejecuta la actividad sea la misma asociada en Bizagi. Si ha cambiado en Cobis, se consulta la estación en Bizagi para 
                    //enviarla en el perform activity, y asi registrar la estación que realmente ejecuta la acción.
                    //PENDIENTE IMPLEMENTACIÓN
                    //if (!notificacion.InformacionEstacion.TipoIdentificacionEstacion.Codigo.Equals(infoCasoDesembolso.OidTrackingDesembolso.OidTipoDocumentoEstac.SCodigo) &&
                    //    !notificacion.InformacionEstacion.IdentificacionEstacion.Equals(infoCasoDesembolso.OidTrackingDesembolso.SIdentificacionEstacion))
                    //{
                    //    InformacionEstacionBO datosEstacion = consultarUsuariosPorID(notificacion.InformacionEstacion.TipoIdentificacionEstacion.Codigo, notificacion.InformacionEstacion.IdentificacionEstacion);
                    //}
                    // perform activity
                    return performActivity2(notificacion, infoCasoDesembolso);
                }
            }
            catch (Exception e)
            {
                respuesta.Codigo = CodigoRespuesta.ErrorTecnico.ToString();
                respuesta.Mensaje = e.Message;
            }
            return respuesta;
        }

        /*
         * Andres Alberto Yepes
         * 06-01-2017
         * ***************************************************************************************************************
         * función encargada de realizar el perform activity. como base utiliza xslt para realizar la transformación de la información 
         * recibida en la fachada a la estructura esperada por Bizagi de acuerdo al modelo de datos del proceso. No tiene acoplamiento 
         * con la estructura del proceso, mas allá que a través de la xslt recibida anteriormente. Utiliza una clase generica para realizar 
         * el perform activity funcionando como un DTO.
         * 
         * */
        private GestionDesembolsoResponse performActivity2(GestionDesembolsoRequest notificacion, InfoCasoDesembolso casoDesembolsoConsultado)
        {
            XmlDocument request = SerializerManager.SerializarToXmlDocument<GestionDesembolsoRequest>(notificacion);

            HUB.BizagiSOAObjects.PeformActivityGeneric.BizAgiWSParam param = new HUB.BizagiSOAObjects.PeformActivityGeneric.BizAgiWSParam();
            HUB.BizagiSOAObjects.PeformActivityGeneric.BizAgiWSParamActivityData activity = new HUB.BizagiSOAObjects.PeformActivityGeneric.BizAgiWSParamActivityData();

            activity.idCase = casoDesembolsoConsultado.OidTrackingDesembolso.IIdCaso;
            activity.taskName = casoDesembolsoConsultado.OidTrackingDesembolso.OidActividadEspera.STaskName;
            param.domain = Properties.Resources.DominioFNA;
            param.userName = casoDesembolsoConsultado.OidTrackingDesembolso.SNombreUsuarioEstacion;

            param.ActivityData = activity;
            BizagiSOALayerOperations<HUB.BizagiSOAObjects.PeformActivityGeneric.BizAgiWSParam> ejecutar = new BizagiSOALayerOperations<HUB.BizagiSOAObjects.PeformActivityGeneric.BizAgiWSParam>();

            string xmlParam = SerializerManager.SerializarToXml(param);
            XmlDocument paramDocXML = new XmlDocument();
            paramDocXML.LoadXml(xmlParam);
            XPathNavigator navigatorParam = paramDocXML.CreateNavigator();

            //transforma el request en un xml con la definición de esquema del proceso en Bizagi
            string xmlEntities = XMLOperations.XSLTransformation(casoDesembolsoConsultado.OidTrackingDesembolso.OidActividadEspera.STransformacion, request);
            XmlDocument docEntitiesXml = new XmlDocument();
            docEntitiesXml.LoadXml(xmlEntities);
            XPathNavigator navEntities = docEntitiesXml.CreateNavigator();

            //crea el nodo de entities
            navigatorParam.MoveToChild("BizAgiWSParam", String.Empty);
            navigatorParam.AppendChild("<Entities></Entities>");
            navigatorParam.MoveToChild("Entities", String.Empty);
            //inserta en el nodo entities el xml con el xml transformado por la xslt
            navigatorParam.AppendChild(docEntitiesXml.OuterXml);

            processes performResp = ejecutar.performActivity(paramDocXML.OuterXml);
            return getRespuestaBO(performResp, EnumSOALayerAction.PerformActivity);

        }

        /*
         * Andres Alberto Yepes
         * 28-10-2016
         * ***************************************************************************************************************
         * función encargada de consultar un desembolso de acuerdo al número de trámite, para identificar su existencia, y 
         * obtener los datos básicos del caso.
         * 
         * */
        private InfoCasoDesembolso consultarCasoDesembolsoPorTramite(string numeroTramite)
        {
            BizAgiWSParam param = new BizAgiWSParam();
            BizAgiWSParamEntityData entity = new BizAgiWSParamEntityData();
            entity.EntityName = "M_Desembolso";
            entity.Filters = "SNumeroTramite = '" + numeroTramite + "' and (OidEstadoDesembolso <> 6  and OidEstadoDesembolso <> 7 and  OidEstadoDesembolso <> 8 and OidEstadoDesembolso <> 9 and OidEstadoDesembolso <> 10)";
            param.EntityData = entity;

            XmlDocument schemaDoc = new XmlDocument();
            string schemaPath = Path.Combine(AsDirectory.AssemblyDirectory, Properties.Resources.SchemaConsultarCasoDesembolso);
            schemaDoc.Load(schemaPath);

            BizagiSOALayerOperations ejecutar = new BizagiSOALayerOperations();
            string xml = SerializerManager.SerializarToXml<BizAgiWSParam>(param);
            string respuesta = ejecutar.getEntitiesUsingSchemaAsString(xml, schemaDoc.OuterXml);
            BizAgiWSResponse<BizAgiWSResponseEntities<InfoCasoDesembolso>> response = SerializerManager.DeserializarTo2<BizAgiWSResponse<BizAgiWSResponseEntities<InfoCasoDesembolso>>>(respuesta);
            return response.Entities.M_Desembolso;
        }


        private InformacionEstacionBO consultarUsuariosPorID(string tipoIdEstacion, string numIdEstacion)
        {
            BizAgiWSParam param = new BizAgiWSParam();
            BizAgiWSParamEntityData entity = new BizAgiWSParamEntityData();
            entity.EntityName = "WFUSER";
            entity.Filters = "SNumeroidentificacion = '" + numIdEstacion + "' and idTipodeDocumento = ";
            param.EntityData = entity;

            XmlDocument schemaDoc = new XmlDocument();
            string schemaPath = Path.Combine(AsDirectory.AssemblyDirectory, Properties.Resources.SchemaConsultarCasoDesembolso);
            schemaDoc.Load(schemaPath);

            BizagiSOALayerOperations ejecutar = new BizagiSOALayerOperations();
            string xml = SerializerManager.SerializarToXml<BizAgiWSParam>(param);
            string respuesta = ejecutar.getEntitiesUsingSchemaAsString(xml, schemaDoc.OuterXml);

            // pendiente ajustar esta parte, se debe generar objetos de tipo wfuser para poder hacer la extracción de la información.
            InformacionEstacionBO datosEstacion = new InformacionEstacionBO();

            return datosEstacion;
        }


        /*
        * Andres Alberto Yepes
        * 28-10-2016
        * ***************************************************************************************************************
        * función encargada crear un caso de gestión desembolso.
        * 
        * */
        private GestionDesembolsoResponse crearCasoDesembolso(GestionDesembolsoRequest notificacion)
        {
            BizAgiWSParam<M_CAT_GestionDesembolso> param = new BizAgiWSParam<M_CAT_GestionDesembolso>(Properties.Resources.DominioDomain, Properties.Resources.UsuarioCrearCaso);
            BizAgiWSParamCase<M_CAT_GestionDesembolso> caso = new BizAgiWSParamCase<M_CAT_GestionDesembolso>(Properties.Resources.ProcesoDesembolso);
            caso.Entities.InfoCaso = new M_CAT_GestionDesembolso();
            caso.Entities.InfoCaso.OidInformacionDesembolso.SNumeroTramite = notificacion.InformacionDesembolso.NumeroTramite;
            caso.Entities.InfoCaso.OidInformacionDesembolso.OidTrackingDesembolso.SCodigoEstacion = notificacion.InformacionEstacion.CodigoEstacion;
            caso.Entities.InfoCaso.OidInformacionDesembolso.OidTrackingDesembolso.SIdentificacionEstacion = notificacion.InformacionEstacion.IdentificacionEstacion;
            caso.Entities.InfoCaso.OidInformacionDesembolso.OidTrackingDesembolso.OidTipoDocumentoEstac.SCodigo = notificacion.InformacionEstacion.TipoIdentificacionEstacion.Codigo;
            caso.Entities.InfoCaso.OidInformacionDesembolso.OidTrackingDesembolso.IRuta = notificacion.RutaActual;
            caso.Entities.InfoCaso.OidInformacionDesembolso.OidTrackingDesembolso.IEtapa = notificacion.EtapaActual;
            caso.Entities.InfoCaso.OidInformacionDesembolso.OidTrackingDesembolso.DFechaNotificacion = notificacion.FechaNotificacion;
            if (notificacion.InformacionDesembolso.CausalReintegro != null)
                caso.Entities.InfoCaso.OidInformacionDesembolso.OidTrackingDesembolso.OidCausalReintegro.SCodigo = notificacion.InformacionDesembolso.CausalReintegro.Codigo;
            param.Cases[0] = caso;
            BizagiSOALayerOperations<BizAgiWSParam<M_CAT_GestionDesembolso>> ejecutar = new BizagiSOALayerOperations<BizAgiWSParam<M_CAT_GestionDesembolso>>();
            processes crearCasoResp = ejecutar.createCase2(param);
            return getRespuestaBO(crearCasoResp, EnumSOALayerAction.CreateCase);

        }


        private GestionDesembolsoResponse getRespuestaBO(processes crearCasoResp, EnumSOALayerAction tipoAccion)
        {
            GestionDesembolsoResponse respServicio = new GestionDesembolsoResponse();
            string errorCode = crearCasoResp.process[0].processError.errorCode;
            if (errorCode != null && errorCode.Length > 0)
            {
                respServicio.Codigo = Properties.Resources.ErrorTecnico;
                respServicio.ErrorSistema.Codigo = errorCode;
                if (crearCasoResp.process[0].processError.errorMessage.Entities == null)
                    respServicio.ErrorSistema.Mensaje = crearCasoResp.process[0].processError.errorMessage.Text[0];
                else
                    respServicio.ErrorSistema.Mensaje = crearCasoResp.process[0].processError.errorMessage.Entities.ErrorMessage;
                switch (tipoAccion)
                {
                    case EnumSOALayerAction.CreateCase:
                        respServicio.Mensaje = Properties.Resources.MsgErrorCreandoCaso;
                        break;
                    case EnumSOALayerAction.PerformActivity:
                        respServicio.Mensaje = Properties.Resources.MsgErrorPerformActivity;
                        break;
                }

            }
            else
            {
                respServicio.Codigo = Properties.Resources.CodigoExitoBizagi;
                switch (tipoAccion)
                {
                    case EnumSOALayerAction.CreateCase:
                        respServicio.processId = int.Parse(crearCasoResp.process[0].processId);
                        respServicio.Mensaje = Properties.Resources.MsgExitoCrearCaso;
                        respServicio.radNumber = crearCasoResp.process[0].processRadNumber;
                        break;
                    case EnumSOALayerAction.PerformActivity:
                        respServicio.Mensaje = Properties.Resources.MsgExitoPerformaActivity;
                        break;
                }

            }
            return respServicio;
        }

        //Deprecado, este codigo no funciona pero puede servir de base para algo mas adelante, con una revisión del por qué no funcionó.
        private GestionDesembolsoResponse getRespuestaBO(XmlDocument respuesta, EnumSOALayerAction tipoAccion)
        {
            GestionDesembolsoResponse respServicio = new GestionDesembolsoResponse();
            XmlNode ErrorStruct = respuesta.SelectSingleNode("//processes/process/processError/errorCode");
            //no hubo errores?
            if (ErrorStruct.Value == null)
            {
                //crear respuesta de exito
                respServicio.Codigo = Properties.Resources.CodigoExitoBizagi;
                respServicio.Mensaje = Properties.Resources.MsgExitoCrearCaso;
                switch (tipoAccion)
                {
                    case EnumSOALayerAction.CreateCase:
                        string idcase = respuesta.SelectSingleNode("//processes/process/processId").Value;
                        respServicio.processId = Convert.ToInt32(idcase);
                        respServicio.radNumber = respuesta.SelectSingleNode("//process/processRadNumber").ToString();
                        break;
                }

            }//si hubo error en el arbol de respuesta.
            else
            {
                respServicio.ErrorSistema.Codigo = respuesta.SelectSingleNode("//process/processError/errorCode").ToString();
                XmlNode Mensaje = respuesta.SelectSingleNode("//process/processError/errorMessage");
                if (Mensaje.HasChildNodes)
                    respServicio.ErrorSistema.Mensaje = Mensaje.SelectSingleNode("//process/processError/errorMessage/Entities/ErrorMessage").ToString();
                else
                    respServicio.ErrorSistema.Mensaje = Mensaje.SelectSingleNode("//process/processError/errorMessage").ToString();
                respServicio.Codigo = Properties.Resources.ErrorTecnico;
                switch (tipoAccion)
                {
                    case EnumSOALayerAction.CreateCase:

                        respServicio.Mensaje = Properties.Resources.MsgErrorCreandoCaso;

                        break;
                    case EnumSOALayerAction.PerformActivity:

                        respServicio.Mensaje = Properties.Resources.MsgErrorPerformActivity;
                        break;
                }
            }
            return respServicio;
        }

        //public static string AssemblyDirectory
        //{
        //    get
        //    {
        //        string codeBase = Assembly.GetExecutingAssembly().CodeBase;
        //        UriBuilder uri = new UriBuilder(codeBase);
        //        string path = Uri.UnescapeDataString(uri.Path);
        //        return Path.GetDirectoryName(path);
        //    }
        //}

    }
}
