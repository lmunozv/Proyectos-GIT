using Bizagi.Proxy.Layer.BusinessObjects.Messages;
using Bizagi.Proxy.Layer.HUB.Operations;
using System;
using System.IO;
using System.Xml;
using Bizagi.Proxy.Layer.Manager.SegurosObjects;
using Bizagi.Proxy.Layer.Util;
using System.Collections.Generic;

namespace Bizagi.Proxy.Layer.Manager.Controlador
{
    /// <summary>
    /// Luis Fernando Muñoz Vega
    /// Clase que permite realizar operaciones en Bizagi para realizar transacciones 
    /// en la Capa SOA de Bizagi
    /// </summary>
    public class ControladorReclamacionSeguros
    {
        #region Propiedades
        BizagiSOALayerOperations ejecutar;
        BizagiSOALayerOperations Ejecutar
        {
            get
            {
                if (ejecutar == null)
                { ejecutar = new BizagiSOALayerOperations(); }
                return ejecutar;
            }
        }
        #endregion

        public AjustePNCSegurosResponse AjustarPNCSeguros(AjustePNCSegurosRequest request)
        {
            try
            {
                AjustePNCSegurosResponse res = new AjustePNCSegurosResponse();
                res.Codigo = "1";
                res.Mensaje = "Proceso Ejecutado";               
                var rr2 = SerializerManager.SerializarToXml<AjustePNCSegurosRequest>(request);
                
                #region Consultar
                XmlDocument schemaDoc = new XmlDocument();
                string schemaPath = Path.Combine(AsDirectory.AssemblyDirectory, Properties.Resources.SchemaConsultarCasoSeguros);
                schemaDoc.Load(schemaPath);
                string respuesta = Ejecutar.getCaseDataUsingSchemaAsString(string.Empty, request.WorkItem, schemaDoc.OuterXml);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(respuesta);

                BizAgiWSResponseType con = SerializerManager.DeserializarTo2<BizAgiWSResponseType>(respuesta);

                #endregion

                #region Modificar
                M_Solicitud mSol = new M_Solicitud();

                mSol.key = con.M_Solicitud.key;
                mSol.keySpecified = true;
                mSol.OidReclamacionSeguro = new M_SolicitudOidReclamacionSeguro();
                mSol.OidReclamacionSeguro.key = con.M_Solicitud.OidReclamacionSeguro;
                mSol.OidReclamacionSeguro.keySpecified = true;
                mSol.OidReclamacionSeguro.XDocumentosReclamacion = 
                    new List<M_SolicitudOidReclamacionSeguroXDocumentosReclamacionM_DocumentoRecSeguro>();
                foreach (var item in request.LstDocumentos)
                {
                    mSol.OidReclamacionSeguro.XDocumentosReclamacion.Add
                        (new M_SolicitudOidReclamacionSeguroXDocumentosReclamacionM_DocumentoRecSeguro() { SUrlDocumento = item });
                }
                BizAgiWSParamType<M_Solicitud> saveEntity = new BizAgiWSParamType<M_Solicitud>();            
                saveEntity.Entities = new EntitiesType<M_Solicitud>();
                saveEntity.Entities.Informacion = new M_Solicitud();
                saveEntity.Entities.Informacion= mSol;

                var save = SerializerManager.SerializarToXml<BizAgiWSParamType<M_Solicitud>>(saveEntity);
                var rt = Ejecutar.saveEntityAsString(save);
                #endregion
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
