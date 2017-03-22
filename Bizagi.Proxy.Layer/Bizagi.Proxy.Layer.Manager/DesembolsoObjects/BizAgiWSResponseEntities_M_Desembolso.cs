using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace Bizagi.Proxy.Layer.Manager.Desembolso
{ 

/*
 * Vision Software - 2016-10-27
 * Todos los derechos pertenecen a Vision Software y su uso debe ser autorizado.
 *************************************************************************************************
 * Desarrollado por : Luis Fernando Muñoz-Andres Alberto Yepes
 *   
 * Clase concreta para el manejo de entidades de desembolso utilizadas para la consulta por trámite de Desembolso.
 * La clase BizAgiWSResponse tiene dependencia de esta clase al momento de ser implementada.
 * 
 */
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
    [XmlElement("M_Desembolso")]
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