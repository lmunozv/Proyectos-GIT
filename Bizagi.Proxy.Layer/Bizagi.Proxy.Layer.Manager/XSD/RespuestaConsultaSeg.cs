﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.8745
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=2.0.50727.3038.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlRootAttribute("BizAgiWSResponse", Namespace="", IsNullable=false)]
public partial class BizAgiWSResponseType {
    
    private M_SolicitudType m_SolicitudField;
    
    /// <remarks/>
    public M_SolicitudType M_Solicitud {
        get {
            return this.m_SolicitudField;
        }
        set {
            this.m_SolicitudField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class M_SolicitudType {
    
    private int oidReclamacionSeguroField;
    
    private int keyField;
    
    private bool keyFieldSpecified;
    
    /// <remarks/>
    public int OidReclamacionSeguro {
        get {
            return this.oidReclamacionSeguroField;
        }
        set {
            this.oidReclamacionSeguroField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int key {
        get {
            return this.keyField;
        }
        set {
            this.keyField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool keySpecified {
        get {
            return this.keyFieldSpecified;
        }
        set {
            this.keyFieldSpecified = value;
        }
    }
}
