using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Bizagi.Proxy.Layer.HUB.Operations;

using System.IO;
using System.Xml.Serialization;
using Bizagi.Proxy.Layer.HUB.BizagiSOAObjects.CreateCase;
using Bizagi.Proxy.Layer.Util;
using Bizagi.Proxy.Layer.HUB.EntityManagerSOA;

namespace Bizagi.Proxy.Layer.HUB.Operations
{
    public class BizagiSOALayerOperations<T> 
            where T : class 
    {
      
        public XmlDocument createCase(T param)
        {
            WorkflowEngineSOA.WorkflowEngineSOA wfEngine = new WorkflowEngineSOA.WorkflowEngineSOA();
            string xml = SerializerManager.SerializarToXml<T>(param);
            string xmlRespuesta = wfEngine.createCasesAsString(xml);
            XmlDocument respuesta = new XmlDocument();
            respuesta.LoadXml(xmlRespuesta);    
                //SerializerManager.DeserializarTo<processes>(xmlRespuesta);
            return respuesta;
        }

        public processes createCase2(T param)
        {
            WorkflowEngineSOA.WorkflowEngineSOA wfEngine = new WorkflowEngineSOA.WorkflowEngineSOA();
            string xml = SerializerManager.SerializarToXml<T>(param);
            string xmlRespuesta = wfEngine.createCasesAsString(xml);
            //XmlDocument respuesta = new XmlDocument();
            //respuesta.LoadXml(xmlRespuesta);
            processes respuesta = SerializerManager.DeserializarTo<processes>(xmlRespuesta);
            return respuesta;
        }

        public processes performActivity(T param)
        {
            WorkflowEngineSOA.WorkflowEngineSOA wfEngine = new WorkflowEngineSOA.WorkflowEngineSOA();
            string xml = SerializerManager.SerializarToXml<T>(param);
            string xmlRespuesta = wfEngine.performActivityAsString(xml);
            processes respuesta = SerializerManager.DeserializarTo<processes>(xmlRespuesta);
            return respuesta;
        }

        public processes performActivity(string xml)
        {
            WorkflowEngineSOA.WorkflowEngineSOA wfEngine = new WorkflowEngineSOA.WorkflowEngineSOA();
            string xmlRespuesta = wfEngine.performActivityAsString(xml);
            processes respuesta = SerializerManager.DeserializarTo<processes>(xmlRespuesta);
            return respuesta;
        }

        public string getEntitiesUsingSchemaAsString(string bzgParams,string schema)
        {
            EntityManagerSOA.EntityManagerSOA wfEntityManSOA = new EntityManagerSOA.EntityManagerSOA();
            string respuesta = wfEntityManSOA.getEntitiesUsingSchemaAsString(bzgParams, schema);
            return respuesta;
        }


    }


    public class BizagiSOALayerOperations
    {

        #region Propiedades
        EntityManagerSOA.EntityManagerSOA wfEntityManSOA;
        EntityManagerSOA.EntityManagerSOA WfEntityManSOA
        {
            get
            {
                if (wfEntityManSOA == null)
                {
                    wfEntityManSOA = new EntityManagerSOA.EntityManagerSOA();
                }
                return wfEntityManSOA;
            }            
        }
        #endregion

        public string getEntitiesUsingSchemaAsString(string bzgParams, string schema)
        {
            try
            {
                string respuesta = WfEntityManSOA.getEntitiesUsingSchemaAsString(bzgParams, schema);
                return respuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }                
        }

        public string getCaseDataUsingSchemaAsString(string idCase, string idWorkItem, string xsd)
        {
            try
            {
                return WfEntityManSOA.getCaseDataUsingSchemaAsString(idCase, idWorkItem, xsd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string saveEntityAsString(string entityInfo)
        {
            try
            {
                return WfEntityManSOA.saveEntityAsString(entityInfo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
