﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bizagi.Proxy.Layer.HUB.CorreosSeguros.CorreoSeguroClient {
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.fna.gov.co/cim/businessentities/excepciongenerica")]
    public partial class excepcionGenerica : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string codigoField;
        
        private string descripcionField;
        
        private excepcionGenerica subCodeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string codigo {
            get {
                return this.codigoField;
            }
            set {
                this.codigoField = value;
                this.RaisePropertyChanged("codigo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string descripcion {
            get {
                return this.descripcionField;
            }
            set {
                this.descripcionField = value;
                this.RaisePropertyChanged("descripcion");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public excepcionGenerica subCode {
            get {
                return this.subCodeField;
            }
            set {
                this.subCodeField = value;
                this.RaisePropertyChanged("subCode");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.fna.gov.co/pki/services/soap/seguridad/enviarcorreoseguro/v1")]
    public partial class EnviarCorreoSeguroRsType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string idMensajeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string idMensaje {
            get {
                return this.idMensajeField;
            }
            set {
                this.idMensajeField = value;
                this.RaisePropertyChanged("idMensaje");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.fna.gov.co/pki/services/soap/seguridad/enviarcorreoseguro/v1")]
    public partial class EnviarCorreoSeguroRqType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string usuarioField;
        
        private string asuntoField;
        
        private string mensajeField;
        
        private string nombreDestinatarioField;
        
        private string correoDestinatarioField;
        
        private string nombreArchivoField;
        
        private byte[] archivoField;
        
        private bool notificacionField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string usuario {
            get {
                return this.usuarioField;
            }
            set {
                this.usuarioField = value;
                this.RaisePropertyChanged("usuario");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string asunto {
            get {
                return this.asuntoField;
            }
            set {
                this.asuntoField = value;
                this.RaisePropertyChanged("asunto");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string mensaje {
            get {
                return this.mensajeField;
            }
            set {
                this.mensajeField = value;
                this.RaisePropertyChanged("mensaje");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string nombreDestinatario {
            get {
                return this.nombreDestinatarioField;
            }
            set {
                this.nombreDestinatarioField = value;
                this.RaisePropertyChanged("nombreDestinatario");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public string correoDestinatario {
            get {
                return this.correoDestinatarioField;
            }
            set {
                this.correoDestinatarioField = value;
                this.RaisePropertyChanged("correoDestinatario");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=5)]
        public string nombreArchivo {
            get {
                return this.nombreArchivoField;
            }
            set {
                this.nombreArchivoField = value;
                this.RaisePropertyChanged("nombreArchivo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary", IsNullable=true, Order=6)]
        public byte[] archivo {
            get {
                return this.archivoField;
            }
            set {
                this.archivoField = value;
                this.RaisePropertyChanged("archivo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=7)]
        public bool notificacion {
            get {
                return this.notificacionField;
            }
            set {
                this.notificacionField = value;
                this.RaisePropertyChanged("notificacion");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.fna.gov.co/pki/services/soap/seguridad/enviarcorreoseguro/v1", ConfigurationName="CorreoSeguroClient.PKI_CorreoSeguroPortType")]
    public interface PKI_CorreoSeguroPortType {
        
        [System.ServiceModel.OperationContractAttribute(Action="enviarCorreoSeguro", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(Bizagi.Proxy.Layer.HUB.CorreosSeguros.CorreoSeguroClient.excepcionGenerica), Action="enviarCorreoSeguro", Name="excepcionGenerica", Namespace="http://www.fna.gov.co/cim/businessentities/excepciongenerica")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Bizagi.Proxy.Layer.HUB.CorreosSeguros.CorreoSeguroClient.enviarCorreoSeguro_Output enviarCorreoSeguro(Bizagi.Proxy.Layer.HUB.CorreosSeguros.CorreoSeguroClient.enviarCorreoSeguro_Input request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.fna.gov.co/pki/services/soap/seguridad/enviarcorreoseguro/v1")]
    public partial class headerRq : ConsumerHeader {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.fna.gov.co/esb/services/cl/consumerheader")]
    public partial class ConsumerHeader : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string systemIdField;
        
        private string clientTransactionIDField;
        
        private string endHostField;
        
        private string endUserField;
        
        private System.DateTime datetimeField;
        
        private bool datetimeFieldSpecified;
        
        private RequestData requestDataField;
        
        private Property[] messageContextField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string systemId {
            get {
                return this.systemIdField;
            }
            set {
                this.systemIdField = value;
                this.RaisePropertyChanged("systemId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string clientTransactionID {
            get {
                return this.clientTransactionIDField;
            }
            set {
                this.clientTransactionIDField = value;
                this.RaisePropertyChanged("clientTransactionID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string endHost {
            get {
                return this.endHostField;
            }
            set {
                this.endHostField = value;
                this.RaisePropertyChanged("endHost");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string endUser {
            get {
                return this.endUserField;
            }
            set {
                this.endUserField = value;
                this.RaisePropertyChanged("endUser");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public System.DateTime datetime {
            get {
                return this.datetimeField;
            }
            set {
                this.datetimeField = value;
                this.RaisePropertyChanged("datetime");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool datetimeSpecified {
            get {
                return this.datetimeFieldSpecified;
            }
            set {
                this.datetimeFieldSpecified = value;
                this.RaisePropertyChanged("datetimeSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=5)]
        public RequestData requestData {
            get {
                return this.requestDataField;
            }
            set {
                this.requestDataField = value;
                this.RaisePropertyChanged("requestData");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=6)]
        [System.Xml.Serialization.XmlArrayItemAttribute("property", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public Property[] messageContext {
            get {
                return this.messageContextField;
            }
            set {
                this.messageContextField = value;
                this.RaisePropertyChanged("messageContext");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.fna.gov.co/esb/services/cl/consumerheader")]
    public partial class RequestData : object, System.ComponentModel.INotifyPropertyChanged {
        
        private UserId userIdField;
        
        private Destination destinationField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public UserId userId {
            get {
                return this.userIdField;
            }
            set {
                this.userIdField = value;
                this.RaisePropertyChanged("userId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public Destination destination {
            get {
                return this.destinationField;
            }
            set {
                this.destinationField = value;
                this.RaisePropertyChanged("destination");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.fna.gov.co/esb/services/cl/consumerheader")]
    public partial class UserId : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string userNameField;
        
        private string userTokenField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string userName {
            get {
                return this.userNameField;
            }
            set {
                this.userNameField = value;
                this.RaisePropertyChanged("userName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string userToken {
            get {
                return this.userTokenField;
            }
            set {
                this.userTokenField = value;
                this.RaisePropertyChanged("userToken");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.fna.gov.co/esb/services/cl/consumerheader")]
    public partial class Destination : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string nameField;
        
        private string namespaceField;
        
        private string operationField;
        
        private string versionField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
                this.RaisePropertyChanged("name");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="anyURI", Order=1)]
        public string @namespace {
            get {
                return this.namespaceField;
            }
            set {
                this.namespaceField = value;
                this.RaisePropertyChanged("namespace");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string operation {
            get {
                return this.operationField;
            }
            set {
                this.operationField = value;
                this.RaisePropertyChanged("operation");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string version {
            get {
                return this.versionField;
            }
            set {
                this.versionField = value;
                this.RaisePropertyChanged("version");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.fna.gov.co/esb/services/cl/consumerheader")]
    public partial class Property : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string keyField;
        
        private string typeField;
        
        private string valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string key {
            get {
                return this.keyField;
            }
            set {
                this.keyField = value;
                this.RaisePropertyChanged("key");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
                this.RaisePropertyChanged("type");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
                this.RaisePropertyChanged("value");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class enviarCorreoSeguro_Input {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://www.fna.gov.co/pki/services/soap/seguridad/enviarcorreoseguro/v1")]
        public Bizagi.Proxy.Layer.HUB.CorreosSeguros.CorreoSeguroClient.headerRq headerRq;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.fna.gov.co/pki/services/soap/seguridad/enviarcorreoseguro/v1", Order=0)]
        public Bizagi.Proxy.Layer.HUB.CorreosSeguros.CorreoSeguroClient.EnviarCorreoSeguroRqType EnviarCorreoSeguroRq;
        
        public enviarCorreoSeguro_Input() {
        }
        
        public enviarCorreoSeguro_Input(Bizagi.Proxy.Layer.HUB.CorreosSeguros.CorreoSeguroClient.headerRq headerRq, Bizagi.Proxy.Layer.HUB.CorreosSeguros.CorreoSeguroClient.EnviarCorreoSeguroRqType EnviarCorreoSeguroRq) {
            this.headerRq = headerRq;
            this.EnviarCorreoSeguroRq = EnviarCorreoSeguroRq;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class enviarCorreoSeguro_Output {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.fna.gov.co/pki/services/soap/seguridad/enviarcorreoseguro/v1", Order=0)]
        public Bizagi.Proxy.Layer.HUB.CorreosSeguros.CorreoSeguroClient.EnviarCorreoSeguroRsType EnviarCorreoSeguroRs;
        
        public enviarCorreoSeguro_Output() {
        }
        
        public enviarCorreoSeguro_Output(Bizagi.Proxy.Layer.HUB.CorreosSeguros.CorreoSeguroClient.EnviarCorreoSeguroRsType EnviarCorreoSeguroRs) {
            this.EnviarCorreoSeguroRs = EnviarCorreoSeguroRs;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface PKI_CorreoSeguroPortTypeChannel : Bizagi.Proxy.Layer.HUB.CorreosSeguros.CorreoSeguroClient.PKI_CorreoSeguroPortType, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PKI_CorreoSeguroPortTypeClient : System.ServiceModel.ClientBase<Bizagi.Proxy.Layer.HUB.CorreosSeguros.CorreoSeguroClient.PKI_CorreoSeguroPortType>, Bizagi.Proxy.Layer.HUB.CorreosSeguros.CorreoSeguroClient.PKI_CorreoSeguroPortType {
        
        public PKI_CorreoSeguroPortTypeClient() {
        }
        
        public PKI_CorreoSeguroPortTypeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PKI_CorreoSeguroPortTypeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PKI_CorreoSeguroPortTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PKI_CorreoSeguroPortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Bizagi.Proxy.Layer.HUB.CorreosSeguros.CorreoSeguroClient.enviarCorreoSeguro_Output enviarCorreoSeguro(Bizagi.Proxy.Layer.HUB.CorreosSeguros.CorreoSeguroClient.enviarCorreoSeguro_Input request) {
            return base.Channel.enviarCorreoSeguro(request);
        }
    }
}
