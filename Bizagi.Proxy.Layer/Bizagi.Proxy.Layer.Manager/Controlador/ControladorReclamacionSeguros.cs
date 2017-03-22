using Bizagi.Proxy.Layer.BusinessObjects.Messages;
using Bizagi.Proxy.Layer.HUB.Operations;
using System;
using System.IO;
using System.Xml;
using Bizagi.Proxy.Layer.Manager.SegurosObjects;
using Bizagi.Proxy.Layer.Util;

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
                res.Mensaje = "OK";

                var rr = SerializerManager.SerializarToXml<AjustePNCSegurosResponse>(res);
                var rr2 = SerializerManager.SerializarToXml<AjustePNCSegurosRequest>(request);


                #region Consultar
                XmlDocument schemaDoc = new XmlDocument();
                string schemaPath = Path.Combine(AsDirectory.AssemblyDirectory, Properties.Resources.SchemaConsultarCasoSeguros);
                schemaDoc.Load(schemaPath);
                string respuesta = Ejecutar.getCaseDataUsingSchemaAsString(string.Empty, request.WorkItem, schemaDoc.OuterXml);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(respuesta);

                

                #endregion

                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
