using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bizagi.Proxy.Layer.HUB.BizagiSOAObjects
{
    /*
    * Vision Software - 2016-10-27
    * Todos los derechos pertenecen a Vision Software y su uso debe ser autorizado.
    *************************************************************************************************
    * Desarrollado por : Luis Fernando Muñoz-Andres Alberto Yepes
    *   
    * Clase Base Generica para el manejo de entidades utilizada en transacciones de Consulta por capa SOA Bizagi, objeto BizAgiWSResponseEntities
    * La clase BizAgiWSResponse tiene dependencia de esta clase al momento de ser implementada. Utilizar namespaces al momento de implementar 
    * para no generar conflictos.
    * 
    */

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [XmlInclude(typeof(Object))] //En vez de Object debe ser el nombre de la entidad NombreEntidad
    public partial class BizAgiWSResponseEntities<T> where T : class
    {

        private T des;
        [XmlElement("NombreEntidad")] //NOmbre de la entidad que responde Bizagi por capa SOA
        public T M_Desembolso
        {


            get
            {
                return des;// == null? Activator.CreateInstance<T>(): M_Desembolso;
            }

            set
            {
                des = value;
            }
        }
    }
}
