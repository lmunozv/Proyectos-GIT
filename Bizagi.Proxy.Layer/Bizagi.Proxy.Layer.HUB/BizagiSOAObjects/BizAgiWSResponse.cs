﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;
using System;
// 
// This source code was auto-generated by xsd, Version=4.6.1055.0.
// 


///// <remarks/>
//[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
//[System.SerializableAttribute()]
//[System.Diagnostics.DebuggerStepThroughAttribute()]
//[System.ComponentModel.DesignerCategoryAttribute("code")]
//[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
//[System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
[XmlRoot("BizAgiWSResponse", IsNullable = false)]
public partial class BizAgiWSResponse<T> where T: class  {
    
    private T entitiesField;
    
    /// <remarks/>
    public T Entities {
        get
        {
   
            return this.entitiesField;
        }
        set {
            this.entitiesField = value;
        }
    }
}