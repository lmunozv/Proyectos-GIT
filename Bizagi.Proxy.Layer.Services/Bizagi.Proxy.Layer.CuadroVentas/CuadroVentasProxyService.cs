﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

// 
// This source code was auto-generated by wsdl, Version=4.6.1055.0.
// 

namespace Bizagi.Proxy.Layer.CuadroVentas
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "CuadroVentas_CrearSolicitud_Binding12", Namespace = "http://www.fna.gov.co/esb/services/cuadroventas/crearsolicitud/v1")]
    public partial class CuadroVentas_CrearSolicitud_Service : System.Web.Services.Protocols.SoapHttpClientProtocol
    {

        private ConsumerHeader consumerHeaderField;

        private System.Threading.SendOrPostCallback CrearSolicitudOperationCompleted;

        /// <remarks/>
        public CuadroVentas_CrearSolicitud_Service()
        {
            this.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
            this.Url = "http://localhost:7800/esb/services/soap";
        }

        public ConsumerHeader consumerHeader
        {
            get
            {
                return this.consumerHeaderField;
            }
            set
            {
                this.consumerHeaderField = value;
            }
        }

        /// <remarks/>
        public event CrearSolicitudCompletedEventHandler CrearSolicitudCompleted;

        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("consumerHeader")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("CrearSolicitud", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("CrearSolicitudResponse", Namespace = "http://www.fna.gov.co/esb/services/cuadroventas/crearsolicitud/v1")]
        public ServicioResponse CrearSolicitud([System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.fna.gov.co/esb/services/cuadroventas/crearsolicitud/v1")] ServiceRequest CrearSolicitudRequest)
        {
            object[] results = this.Invoke("CrearSolicitud", new object[] {
                    CrearSolicitudRequest});
            return ((ServicioResponse)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginCrearSolicitud(ServiceRequest CrearSolicitudRequest, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("CrearSolicitud", new object[] {
                    CrearSolicitudRequest}, callback, asyncState);
        }

        /// <remarks/>
        public ServicioResponse EndCrearSolicitud(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((ServicioResponse)(results[0]));
        }

        /// <remarks/>
        public void CrearSolicitudAsync(ServiceRequest CrearSolicitudRequest)
        {
            this.CrearSolicitudAsync(CrearSolicitudRequest, null);
        }

        /// <remarks/>
        public void CrearSolicitudAsync(ServiceRequest CrearSolicitudRequest, object userState)
        {
            if ((this.CrearSolicitudOperationCompleted == null))
            {
                this.CrearSolicitudOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCrearSolicitudOperationCompleted);
            }
            this.InvokeAsync("CrearSolicitud", new object[] {
                    CrearSolicitudRequest}, this.CrearSolicitudOperationCompleted, userState);
        }

        private void OnCrearSolicitudOperationCompleted(object arg)
        {
            if ((this.CrearSolicitudCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CrearSolicitudCompleted(this, new CrearSolicitudCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        public new void CancelAsync(object userState)
        {
            base.CancelAsync(userState);
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.fna.gov.co/esb/services/cl/consumerheader")]
    [System.Xml.Serialization.XmlRootAttribute("consumerHeader", Namespace = "http://www.fna.gov.co/esb/services/cuadroventas/crearsolicitud/v1", IsNullable = false)]
    public partial class ConsumerHeader : System.Web.Services.Protocols.SoapHeader
    {

        private string systemIdField;

        private string clientTransactionIDField;

        private string endHostField;

        private string endUserField;

        private System.DateTime datetimeField;

        private bool datetimeFieldSpecified;

        private RequestData requestDataField;

        private Property[] messageContextField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string systemId
        {
            get
            {
                return this.systemIdField;
            }
            set
            {
                this.systemIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string clientTransactionID
        {
            get
            {
                return this.clientTransactionIDField;
            }
            set
            {
                this.clientTransactionIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string endHost
        {
            get
            {
                return this.endHostField;
            }
            set
            {
                this.endHostField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string endUser
        {
            get
            {
                return this.endUserField;
            }
            set
            {
                this.endUserField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.DateTime datetime
        {
            get
            {
                return this.datetimeField;
            }
            set
            {
                this.datetimeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool datetimeSpecified
        {
            get
            {
                return this.datetimeFieldSpecified;
            }
            set
            {
                this.datetimeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RequestData requestData
        {
            get
            {
                return this.requestDataField;
            }
            set
            {
                this.requestDataField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("property", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public Property[] messageContext
        {
            get
            {
                return this.messageContextField;
            }
            set
            {
                this.messageContextField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.fna.gov.co/esb/services/cl/consumerheader")]
    public partial class RequestData
    {

        private UserId userIdField;

        private Destination destinationField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public UserId userId
        {
            get
            {
                return this.userIdField;
            }
            set
            {
                this.userIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Destination destination
        {
            get
            {
                return this.destinationField;
            }
            set
            {
                this.destinationField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.fna.gov.co/esb/services/cl/consumerheader")]
    public partial class UserId
    {

        private string userNameField;

        private string userTokenField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string userName
        {
            get
            {
                return this.userNameField;
            }
            set
            {
                this.userNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string userToken
        {
            get
            {
                return this.userTokenField;
            }
            set
            {
                this.userTokenField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.fna.gov.co/esb/services/cuadroventas/crearsolicitud/v1")]
    public partial class ServicioResponse
    {

        private int codigoRetornoField;

        private string descripcionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int codigoRetorno
        {
            get
            {
                return this.codigoRetornoField;
            }
            set
            {
                this.codigoRetornoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string descripcion
        {
            get
            {
                return this.descripcionField;
            }
            set
            {
                this.descripcionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.fna.gov.co/esb/services/cuadroventas/crearsolicitud/v1")]
    public partial class ServiceRequest
    {

        private int numeroRadicadoField;

        private int idEstructuraField;

        private string nombreConstructorField;

        private int numeroProyectoField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int numeroRadicado
        {
            get
            {
                return this.numeroRadicadoField;
            }
            set
            {
                this.numeroRadicadoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int idEstructura
        {
            get
            {
                return this.idEstructuraField;
            }
            set
            {
                this.idEstructuraField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string nombreConstructor
        {
            get
            {
                return this.nombreConstructorField;
            }
            set
            {
                this.nombreConstructorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int numeroProyecto
        {
            get
            {
                return this.numeroProyectoField;
            }
            set
            {
                this.numeroProyectoField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.fna.gov.co/esb/services/cl/consumerheader")]
    public partial class Property
    {

        private string keyField;

        private string typeField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string key
        {
            get
            {
                return this.keyField;
            }
            set
            {
                this.keyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.fna.gov.co/esb/services/cl/consumerheader")]
    public partial class Destination
    {

        private string nameField;

        private string namespaceField;

        private string operationField;

        private string versionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "anyURI")]
        public string @namespace
        {
            get
            {
                return this.namespaceField;
            }
            set
            {
                this.namespaceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string operation
        {
            get
            {
                return this.operationField;
            }
            set
            {
                this.operationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    public delegate void CrearSolicitudCompletedEventHandler(object sender, CrearSolicitudCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CrearSolicitudCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal CrearSolicitudCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public ServicioResponse Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((ServicioResponse)(this.results[0]));
            }
        }
    }
}