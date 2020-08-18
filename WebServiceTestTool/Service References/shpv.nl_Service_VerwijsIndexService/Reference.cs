﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebServiceTestTool.shpv.nl_Service_VerwijsIndexService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PaymentStartRequest", Namespace="https://verwijsindex.shpv.nl/messages/")]
    [System.SerializableAttribute()]
    public partial class PaymentStartRequest : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string AreaManagerIdField;
        
        private string AreaIdField;
        
        private string VehicleIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CountryCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AccessIdField;
        
        private System.DateTime StartDateTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> EndDateTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<double> AmountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<double> VATField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TokenField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string AreaManagerId {
            get {
                return this.AreaManagerIdField;
            }
            set {
                if ((object.ReferenceEquals(this.AreaManagerIdField, value) != true)) {
                    this.AreaManagerIdField = value;
                    this.RaisePropertyChanged("AreaManagerId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=1)]
        public string AreaId {
            get {
                return this.AreaIdField;
            }
            set {
                if ((object.ReferenceEquals(this.AreaIdField, value) != true)) {
                    this.AreaIdField = value;
                    this.RaisePropertyChanged("AreaId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=2)]
        public string VehicleId {
            get {
                return this.VehicleIdField;
            }
            set {
                if ((object.ReferenceEquals(this.VehicleIdField, value) != true)) {
                    this.VehicleIdField = value;
                    this.RaisePropertyChanged("VehicleId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public string CountryCode {
            get {
                return this.CountryCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.CountryCodeField, value) != true)) {
                    this.CountryCodeField = value;
                    this.RaisePropertyChanged("CountryCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public string AccessId {
            get {
                return this.AccessIdField;
            }
            set {
                if ((object.ReferenceEquals(this.AccessIdField, value) != true)) {
                    this.AccessIdField = value;
                    this.RaisePropertyChanged("AccessId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=5)]
        public System.DateTime StartDateTime {
            get {
                return this.StartDateTimeField;
            }
            set {
                if ((this.StartDateTimeField.Equals(value) != true)) {
                    this.StartDateTimeField = value;
                    this.RaisePropertyChanged("StartDateTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=6)]
        public System.Nullable<System.DateTime> EndDateTime {
            get {
                return this.EndDateTimeField;
            }
            set {
                if ((this.EndDateTimeField.Equals(value) != true)) {
                    this.EndDateTimeField = value;
                    this.RaisePropertyChanged("EndDateTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=7)]
        public System.Nullable<double> Amount {
            get {
                return this.AmountField;
            }
            set {
                if ((this.AmountField.Equals(value) != true)) {
                    this.AmountField = value;
                    this.RaisePropertyChanged("Amount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=8)]
        public System.Nullable<double> VAT {
            get {
                return this.VATField;
            }
            set {
                if ((this.VATField.Equals(value) != true)) {
                    this.VATField = value;
                    this.RaisePropertyChanged("VAT");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=9)]
        public string Token {
            get {
                return this.TokenField;
            }
            set {
                if ((object.ReferenceEquals(this.TokenField, value) != true)) {
                    this.TokenField = value;
                    this.RaisePropertyChanged("Token");
                }
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PaymentStartResponse", Namespace="https://verwijsindex.shpv.nl/messages/")]
    [System.SerializableAttribute()]
    public partial class PaymentStartResponse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string ProviderIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PaymentAuthorisationIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<double> AuthorisationMaxAmountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> AuthorisationValidUntilField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RemarkIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RemarkField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TokenField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string ProviderId {
            get {
                return this.ProviderIdField;
            }
            set {
                if ((object.ReferenceEquals(this.ProviderIdField, value) != true)) {
                    this.ProviderIdField = value;
                    this.RaisePropertyChanged("ProviderId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public string PaymentAuthorisationId {
            get {
                return this.PaymentAuthorisationIdField;
            }
            set {
                if ((object.ReferenceEquals(this.PaymentAuthorisationIdField, value) != true)) {
                    this.PaymentAuthorisationIdField = value;
                    this.RaisePropertyChanged("PaymentAuthorisationId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public System.Nullable<double> AuthorisationMaxAmount {
            get {
                return this.AuthorisationMaxAmountField;
            }
            set {
                if ((this.AuthorisationMaxAmountField.Equals(value) != true)) {
                    this.AuthorisationMaxAmountField = value;
                    this.RaisePropertyChanged("AuthorisationMaxAmount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public System.Nullable<System.DateTime> AuthorisationValidUntil {
            get {
                return this.AuthorisationValidUntilField;
            }
            set {
                if ((this.AuthorisationValidUntilField.Equals(value) != true)) {
                    this.AuthorisationValidUntilField = value;
                    this.RaisePropertyChanged("AuthorisationValidUntil");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public string RemarkId {
            get {
                return this.RemarkIdField;
            }
            set {
                if ((object.ReferenceEquals(this.RemarkIdField, value) != true)) {
                    this.RemarkIdField = value;
                    this.RaisePropertyChanged("RemarkId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public string Remark {
            get {
                return this.RemarkField;
            }
            set {
                if ((object.ReferenceEquals(this.RemarkField, value) != true)) {
                    this.RemarkField = value;
                    this.RaisePropertyChanged("Remark");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=6)]
        public string Token {
            get {
                return this.TokenField;
            }
            set {
                if ((object.ReferenceEquals(this.TokenField, value) != true)) {
                    this.TokenField = value;
                    this.RaisePropertyChanged("Token");
                }
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PaymentEndRequest", Namespace="https://verwijsindex.shpv.nl/messages/")]
    [System.SerializableAttribute()]
    public partial class PaymentEndRequest : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string ProviderIdField;
        
        private string PaymentAuthorisationIdField;
        
        private string VehicleIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CountryCodeField;
        
        private System.DateTime EndDateTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<double> AmountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<double> VATField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string ProviderId {
            get {
                return this.ProviderIdField;
            }
            set {
                if ((object.ReferenceEquals(this.ProviderIdField, value) != true)) {
                    this.ProviderIdField = value;
                    this.RaisePropertyChanged("ProviderId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=1)]
        public string PaymentAuthorisationId {
            get {
                return this.PaymentAuthorisationIdField;
            }
            set {
                if ((object.ReferenceEquals(this.PaymentAuthorisationIdField, value) != true)) {
                    this.PaymentAuthorisationIdField = value;
                    this.RaisePropertyChanged("PaymentAuthorisationId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=2)]
        public string VehicleId {
            get {
                return this.VehicleIdField;
            }
            set {
                if ((object.ReferenceEquals(this.VehicleIdField, value) != true)) {
                    this.VehicleIdField = value;
                    this.RaisePropertyChanged("VehicleId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public string CountryCode {
            get {
                return this.CountryCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.CountryCodeField, value) != true)) {
                    this.CountryCodeField = value;
                    this.RaisePropertyChanged("CountryCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=4)]
        public System.DateTime EndDateTime {
            get {
                return this.EndDateTimeField;
            }
            set {
                if ((this.EndDateTimeField.Equals(value) != true)) {
                    this.EndDateTimeField = value;
                    this.RaisePropertyChanged("EndDateTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public System.Nullable<double> Amount {
            get {
                return this.AmountField;
            }
            set {
                if ((this.AmountField.Equals(value) != true)) {
                    this.AmountField = value;
                    this.RaisePropertyChanged("Amount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=6)]
        public System.Nullable<double> VAT {
            get {
                return this.VATField;
            }
            set {
                if ((this.VATField.Equals(value) != true)) {
                    this.VATField = value;
                    this.RaisePropertyChanged("VAT");
                }
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PaymentEndResponse", Namespace="https://verwijsindex.shpv.nl/messages/")]
    [System.SerializableAttribute()]
    public partial class PaymentEndResponse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string PaymentAuthorisationIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RemarkIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RemarkField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string PaymentAuthorisationId {
            get {
                return this.PaymentAuthorisationIdField;
            }
            set {
                if ((object.ReferenceEquals(this.PaymentAuthorisationIdField, value) != true)) {
                    this.PaymentAuthorisationIdField = value;
                    this.RaisePropertyChanged("PaymentAuthorisationId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RemarkId {
            get {
                return this.RemarkIdField;
            }
            set {
                if ((object.ReferenceEquals(this.RemarkIdField, value) != true)) {
                    this.RemarkIdField = value;
                    this.RaisePropertyChanged("RemarkId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public string Remark {
            get {
                return this.RemarkField;
            }
            set {
                if ((object.ReferenceEquals(this.RemarkField, value) != true)) {
                    this.RemarkField = value;
                    this.RaisePropertyChanged("Remark");
                }
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="https://verwijsindex.shpv.nl/service/", ConfigurationName="shpv.nl_Service_VerwijsIndexService.VerwijsIndex")]
    public interface VerwijsIndex {
        
        [System.ServiceModel.OperationContractAttribute(Action="https://verwijsindex.shpv.nl/service/VerwijsIndex/PaymentStart", ReplyAction="https://verwijsindex.shpv.nl/service/VerwijsIndex/PaymentStartResponse")]
        WebServiceTestTool.shpv.nl_Service_VerwijsIndexService.PaymentStartResponse PaymentStart(WebServiceTestTool.shpv.nl_Service_VerwijsIndexService.PaymentStartRequest PaymentStartRequest);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://verwijsindex.shpv.nl/service/VerwijsIndex/PaymentEnd", ReplyAction="https://verwijsindex.shpv.nl/service/VerwijsIndex/PaymentEndResponse")]
        WebServiceTestTool.shpv.nl_Service_VerwijsIndexService.PaymentEndResponse PaymentEnd(WebServiceTestTool.shpv.nl_Service_VerwijsIndexService.PaymentEndRequest PaymentEndRequest);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface VerwijsIndexChannel : WebServiceTestTool.shpv.nl_Service_VerwijsIndexService.VerwijsIndex, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class VerwijsIndexClient : System.ServiceModel.ClientBase<WebServiceTestTool.shpv.nl_Service_VerwijsIndexService.VerwijsIndex>, WebServiceTestTool.shpv.nl_Service_VerwijsIndexService.VerwijsIndex {
        
        public VerwijsIndexClient() {
        }
        
        public VerwijsIndexClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public VerwijsIndexClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VerwijsIndexClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VerwijsIndexClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public WebServiceTestTool.shpv.nl_Service_VerwijsIndexService.PaymentStartResponse PaymentStart(WebServiceTestTool.shpv.nl_Service_VerwijsIndexService.PaymentStartRequest PaymentStartRequest) {
            return base.Channel.PaymentStart(PaymentStartRequest);
        }
        
        public WebServiceTestTool.shpv.nl_Service_VerwijsIndexService.PaymentEndResponse PaymentEnd(WebServiceTestTool.shpv.nl_Service_VerwijsIndexService.PaymentEndRequest PaymentEndRequest) {
            return base.Channel.PaymentEnd(PaymentEndRequest);
        }
    }
}
