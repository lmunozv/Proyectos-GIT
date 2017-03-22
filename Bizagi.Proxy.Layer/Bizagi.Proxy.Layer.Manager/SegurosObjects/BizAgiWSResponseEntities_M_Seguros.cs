using System.Xml.Serialization;

namespace Bizagi.Proxy.Layer.Manager.SegurosObjects
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [XmlInclude(typeof(InfoCasoDesembolso))]
    public partial class BizAgiWSResponseEntities<T> where T : class
    {

        private T des;
        [XmlElement("M_Solicitud")]
        public T M_Solicitud
        {
            get
            {
                return des;
            }

            set
            {
                des = value;
            }
        }
    }
}
