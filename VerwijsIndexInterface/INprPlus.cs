using System;

namespace Denion.WebService.VerwijsIndex
{
    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://rdw.nl/rpv/1.0", ConfigurationName = "Denion.WebService.VerwijsIndex.INprPlus")]
    public interface INprPlus
    {
        [System.ServiceModel.OperationContractAttribute(Action = "http://rdw.nl/rpv/1.0/IRegistration/ActivateEnroll")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ResponseError))]
        Denion.WebService.VerwijsIndex.ActivateEnrollRequestResponse ActivateEnroll(ActivateEnrollRequestRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://rdw.nl/rpv/1.0/IRegistration/RevokedByThirdParty")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ResponseError))]
        Denion.WebService.VerwijsIndex.RevokedByThirdPartyRequestResponse RevokedByThirdParty(RevokedByThirdPartyRequestRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://rdw.nl/rpv/1.0/IRegistration/CheckPSRight")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ResponseError))]
        Denion.WebService.VerwijsIndex.PSRightCheckResponse CheckPSRight(PSRightCheckRequest request);
    }

    public partial class PSRightEnrollRequestData : object, System.ComponentModel.INotifyPropertyChanged
    {
        private string providerId;

        //private System.Nullable<System.DateTime> startTimeAdjustedField;

        //private bool startTimeAdjustedSpecified;

        private string vehicleIdType;

        ///// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 98)]
        //public System.Nullable<System.DateTime> StartTimeAdjusted
        //{
        //    get
        //    {
        //        return this.startTimeAdjustedField;
        //    }
        //    set
        //    {
        //        this.startTimeAdjustedField = value;
        //        this.RaisePropertyChanged("StartTimeAdjusted");
        //    }
        //}

        ///// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool StartTimeAdjustedSpecified
        //{
        //    get
        //    {
        //        return this.startTimeAdjustedSpecified;
        //    }
        //    set
        //    {
        //        this.startTimeAdjustedSpecified = value;
        //        this.RaisePropertyChanged("StartTimeAdjustedSpecified");
        //    }
        //}

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 99)]
        public string VehicleIdType
        {
            get
            {
                return this.vehicleIdType;
            }
            set
            {
                this.vehicleIdType = value;
                this.RaisePropertyChanged("VehicleIdType");
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = false, Order = 100)]
        public string ProviderId
        {
            get
            {
                return this.providerId;
            }
            set
            {
                this.providerId = value;
                this.RaisePropertyChanged("ProviderId");
            }
        }
    }

    public partial class PSRightEnrollResponseData
    {
        private System.Nullable<System.DateTime> startTimeAdjustedField;

        private bool startTimeAdjustedSpecified;

        private System.Nullable<System.DateTime> endTimePSrightField;

        private bool endTimePSrightFieldSpecified;

        private System.Nullable<decimal> amountPSrightField;

        private bool amountPSrightFieldSpecified;

        private System.Nullable<decimal> vATPSrightField;

        private bool vATPSrightFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 99)]
        public System.Nullable<System.DateTime> StartTimeAdjusted
        {
            get
            {
                return this.startTimeAdjustedField;
            }
            set
            {
                this.startTimeAdjustedField = value;
                this.RaisePropertyChanged("StartTimeAdjusted");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StartTimeAdjustedSpecified
        {
            get
            {
                return this.startTimeAdjustedSpecified;
            }
            set
            {
                this.startTimeAdjustedSpecified = value;
                this.RaisePropertyChanged("StartTimeAdjustedSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 100)]
        public System.Nullable<System.DateTime> EndTimePSright
        {
            get
            {
                return this.endTimePSrightField;
            }
            set
            {
                this.endTimePSrightField = value;
                this.RaisePropertyChanged("EndTimePSright");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EndTimePSrightSpecified
        {
            get
            {
                return this.endTimePSrightFieldSpecified;
            }
            set
            {
                this.endTimePSrightFieldSpecified = value;
                this.RaisePropertyChanged("EndTimePSrightSpecified");
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 101)]
        public System.Nullable<decimal> AmountPSright
        {
            get
            {
                return this.amountPSrightField;
            }
            set
            {
                this.amountPSrightField = value;
                this.RaisePropertyChanged("AmountPSright");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AmountPSrightSpecified
        {
            get
            {
                return this.amountPSrightFieldSpecified;
            }
            set
            {
                this.amountPSrightFieldSpecified = value;
                this.RaisePropertyChanged("AmountPSrightSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 102)]
        public System.Nullable<decimal> VATPSright
        {
            get
            {
                return this.vATPSrightField;
            }
            set
            {
                this.vATPSrightField = value;
                this.RaisePropertyChanged("VATPSright");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool VATPSrightSpecified
        {
            get
            {
                return this.vATPSrightFieldSpecified;
            }
            set
            {
                this.vATPSrightFieldSpecified = value;
                this.RaisePropertyChanged("VATPSrightSpecified");
            }
        }

    }

    public partial class PSRightEnrollRequest
    {
        public Err IsValid()
        {
            PSRightEnrollRequestData req = PSRightEnrollRequestData;
            var geoLoc = req.LocationPSRight;
            bool hasAmi = !(string.IsNullOrEmpty(req.AreaManagerId) || string.IsNullOrEmpty(req.AreaId));
            bool hasSp = !string.IsNullOrEmpty(req.SellingPointId);
            bool hasLatLon = (geoLoc != null);
            
            if (req == null)
            {
                return new Err60("PSRightEnrollRequestData");
            }
            else if (string.IsNullOrEmpty(req.ProviderId))
            {
                return new Err60("ProviderId");
            }
            else if (string.IsNullOrEmpty(req.VehicleId))
            {
                return new Err60("VehicleId");
            }
            else if (!string.IsNullOrEmpty(req.VehicleIdType) && !Functions.IsValidType(req.VehicleIdType))
            {
                return new Err105("VehicleIdType");
            }
            else if (!(hasAmi || hasSp || hasLatLon))
            {
                return new Err("145", "Location information incomplete");
            }

            PSRightEnrollRequestData.VehicleId = PSRightEnrollRequestData.VehicleId.StripVehicleId();
            return null;
        }
    }

    public partial class PSRightRevokeResponseData : object, System.ComponentModel.INotifyPropertyChanged
    {

        private System.Nullable<System.DateTime> startTimePSRightAdjustedField;

        private bool startTimePSRightAdjustedFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 100)]
        public System.Nullable<System.DateTime> StartTimePSRightAdjusted
        {
            get
            {
                return this.startTimePSRightAdjustedField;
            }
            set
            {
                this.startTimePSRightAdjustedField = value;
                this.RaisePropertyChanged("StartTimePSRightAdjusted");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StartTimePSRightAdjustedSpecified
        {
            get
            {
                return this.startTimePSRightAdjustedFieldSpecified;
            }
            set
            {
                this.startTimePSRightAdjustedFieldSpecified = value;
                this.RaisePropertyChanged("StartTimePSRightAdjustedSpecified");
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class ActivateEnrollRequestResponseError : ResponseError
    {

        private string statusReferenceField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 0)]
        public string StatusReference
        {
            get
            {
                return this.statusReferenceField;
            }
            set
            {
                this.statusReferenceField = value;
                this.RaisePropertyChanged("StatusReference");
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "ActivateEnrollRequestRequest", WrapperNamespace = "http://rdw.nl/rpv/1.0", IsWrapped = true)]
    public partial class ActivateEnrollRequestRequest
    {

        [System.ServiceModel.MessageHeaderAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
        public string PIN;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://rdw.nl/rpv/1.0", Order = 0)]
        public Denion.WebService.VerwijsIndex.ActivateEnrollRequestRequestData ActivateEnrollRequestRequestData;

        public ActivateEnrollRequestRequest()
        {
        }

        public ActivateEnrollRequestRequest(string PIN, Denion.WebService.VerwijsIndex.ActivateEnrollRequestRequestData ActivateEnrollRequestRequestData)
        {
            this.PIN = PIN;
            this.ActivateEnrollRequestRequestData = ActivateEnrollRequestRequestData;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "ActivateEnrollRequestResponse", WrapperNamespace = "http://rdw.nl/rpv/1.0", IsWrapped = true)]
    public partial class ActivateEnrollRequestResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://rdw.nl/rpv/1.0", Order = 0)]
        public Denion.WebService.VerwijsIndex.ActivateEnrollRequestResponseData ActivateEnrollRequestResponseData;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://rdw.nl/rpv/1.0", Order = 1)]
        public Denion.WebService.VerwijsIndex.ActivateEnrollRequestResponseError ActivateEnrollRequestResponseError;

        public ActivateEnrollRequestResponse()
        {
        }

        public ActivateEnrollRequestResponse(Denion.WebService.VerwijsIndex.ActivateEnrollRequestResponseData ActivateEnrollRequestResponseData, Denion.WebService.VerwijsIndex.ActivateEnrollRequestResponseError ActivateEnrollRequestResponseError)
        {
            this.ActivateEnrollRequestResponseData = ActivateEnrollRequestResponseData;
            this.ActivateEnrollRequestResponseError = ActivateEnrollRequestResponseError;
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public class ActivateEnrollRequestResponseData
    {
        /// <summary>
        /// Provider die toegang verleend, verplicht
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = false, Order = 0)]
        public string ProviderId { get; set; }

        /// <summary>
        /// Kenmerk van de provider, optioneel
        /// leeg indien geen authorisatie is gegeven
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 1)]
        public string PaymentAuthorisationId { get; set; }

        /// <summary>
        /// Provider kan maximum bedrag terug melden, optioneel
        /// in geval van netwerk problemen kan van deze informatie gebruik gemaakt worden
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 2)]
        public Nullable<double> AuthorisationMaxAmount { get; set; }

        /// <summary>
        /// Verlooptijd van de authorisatie, optioneel
        /// </summary>        
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 3)]
        public Nullable<DateTime> AuthorisationValidUntil { get; set; }

        /// <summary>
        /// Code van de foutmelding of opmerking, optioneel
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 4)]
        public string RemarkId { get; set; }

        /// <summary>
        /// Foutmelding of opmerking, optioneel
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 5)]
        public string Remark { get; set; }

        /// <summary>
        /// Kenmerk van het parkeerrecht, optioneel
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 6)]
        public string Token { get; set; }

        /// <summary>
        /// Waarde type voor het Token veld, optioneel
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 7)]
        public string TokenType { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public class ActivateEnrollRequestRequestData
    {
        /// <summary>
        /// Gebiedscode van de stad, verplicht
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = false, Order = 0)]
        public string AreaManagerId { get; set; }

        /// <summary>
        /// Gebiedscode van de parkeerplaats, verplicht
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = false, Order = 1)]
        public string AreaId { get; set; }

        /// <summary>
        /// voertuigen kenteken, verplicht
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = false, Order = 2)]
        public string VehicleId { get; set; }

        /// <summary>
        /// voertuig kenteken landscode, optioneel
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 3)]
        public string CountryCode { get; set; }

        /// <summary>
        /// Berichtkenmerk van de garage, optioneel
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 4)]
        public string AccessId { get; set; }

        /// <summary>
        /// starttijd/ inrijdtijd, verplicht
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = false, Order = 5)]
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// eindtijd/ laatste uitrijdtijd, optioneel
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 6)]
        public Nullable<DateTime> EndDateTime { get; set; }

        /// <summary>
        /// Bedrag, optioneel
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 7)]
        public Nullable<double> Amount { get; set; }

        /// <summary>
        /// BTW over het bedrag, optioneel
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 8)]
        public Nullable<double> VAT { get; set; }

        /// <summary>
        /// Kenmerk van het parkeerrecht, optioneel
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 9)]
        public string Token { get; set; }

        /// <summary>
        /// Waarde type van het VehicleId veld, verplicht
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = false, Order = 10)]
        public string VehicleIdType { get; set; }

        /// <summary>
        /// Waarde type voor het Token veld, optioneel
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 11)]
        public string TokenType { get; set; }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class RevokedByThirdPartyRequestResponseError : ResponseError
    {

        private string statusReferenceField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 0)]
        public string StatusReference
        {
            get
            {
                return this.statusReferenceField;
            }
            set
            {
                this.statusReferenceField = value;
                this.RaisePropertyChanged("StatusReference");
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "RevokedByThirdPartyRequestRequest", WrapperNamespace = "http://rdw.nl/rpv/1.0", IsWrapped = true)]
    public partial class RevokedByThirdPartyRequestRequest
    {

        [System.ServiceModel.MessageHeaderAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
        public string PIN;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://rdw.nl/rpv/1.0", Order = 0)]
        public Denion.WebService.VerwijsIndex.RevokedByThirdPartyRequestRequestData RevokedByThirdPartyRequestRequestData;

        public RevokedByThirdPartyRequestRequest()
        {
        }

        public RevokedByThirdPartyRequestRequest(string PIN, Denion.WebService.VerwijsIndex.RevokedByThirdPartyRequestRequestData RevokedByThirdPartyRequestRequestData)
        {
            this.PIN = PIN;
            this.RevokedByThirdPartyRequestRequestData = RevokedByThirdPartyRequestRequestData;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "RevokedByThirdPartyRequestResponse", WrapperNamespace = "http://rdw.nl/rpv/1.0", IsWrapped = true)]
    public partial class RevokedByThirdPartyRequestResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://rdw.nl/rpv/1.0", Order = 0)]
        public Denion.WebService.VerwijsIndex.RevokedByThirdPartyRequestResponseData RevokedByThirdPartyRequestResponseData;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://rdw.nl/rpv/1.0", Order = 1)]
        public Denion.WebService.VerwijsIndex.RevokedByThirdPartyRequestResponseError RevokedByThirdPartyRequestResponseError;

        public RevokedByThirdPartyRequestResponse()
        {
        }

        public RevokedByThirdPartyRequestResponse(Denion.WebService.VerwijsIndex.RevokedByThirdPartyRequestResponseData RevokedByThirdPartyRequestResponseData, Denion.WebService.VerwijsIndex.RevokedByThirdPartyRequestResponseError RevokedByThirdPartyRequestResponseError)
        {
            this.RevokedByThirdPartyRequestResponseData = RevokedByThirdPartyRequestResponseData;
            this.RevokedByThirdPartyRequestResponseError = RevokedByThirdPartyRequestResponseError;
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public class RevokedByThirdPartyRequestResponseData
    {
        /// <summary>
        /// Betalingskenmerk van de provider, verplicht
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = false, Order = 0)]

        public string PaymentAuthorisationId { get; set; }

        /// <summary>
        /// Code van de foutmelding of opmerking, optioneel
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 1)]

        public string RemarkId { get; set; }

        /// <summary>
        /// Foutmelding of opmerking, optioneel
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 2)]

        public string Remark { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public class RevokedByThirdPartyRequestRequestData
    {
        /// <summary>
        /// De provider die voor de betaling instaat, verplicht
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = false, Order = 0)]
        public string ProviderId { get; set; }

        /// <summary>
        /// Betalingskenmerk van de Provider,verplicht
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = false, Order = 1)]
        public string PaymentAuthorisationId { get; set; }

        /// <summary>
        /// Voertuigkenteken, verplicht
        /// Redundant maar ter controle, in combinatie met ProviderId en PaymentAuthorisationId
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = false, Order = 2)]
        public string VehicleId { get; set; }

        /// <summary>
        /// Voertuigkenteken landscode, optioneel
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 3)]
        public string CountryCode { get; set; }

        /// <summary>
        /// Uitrijdtijd, verplicht
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = false, Order = 4)]
        public DateTime EndDateTime { get; set; }

        /// <summary>
        /// Het te betalen bedrag, optioneel
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 5)]
        public Nullable<double> Amount { get; set; }

        /// <summary>
        /// BTW over het te betalen bedag, optioneel
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 6)]
        public Nullable<double> VAT { get; set; }

        /// <summary>
        /// Type van het VehicleID veld, optioneel
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 7)]
        public string VehicleIdType { get; set; }
    }

    /// <remarks/>

    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RevokedByThirdPartyRequestResponseError))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ActivateEnrollRequestResponseError))]
    public partial class ResponseError : object, System.ComponentModel.INotifyPropertyChanged
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RegistrationPlusClient : System.ServiceModel.ClientBase<Denion.WebService.VerwijsIndex.INprPlus>, Denion.WebService.VerwijsIndex.INprPlus
    {

        public RegistrationPlusClient()
        {
        }

        public RegistrationPlusClient(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public RegistrationPlusClient(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public RegistrationPlusClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public RegistrationPlusClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        public ActivateEnrollRequestResponse ActivateEnroll(ActivateEnrollRequestRequest request)
        {
            return base.Channel.ActivateEnroll(request);
        }

        public ActivateEnrollRequestResponseData ActivateEnroll(string PIN, ActivateEnrollRequestRequestData ActivateEnrollRequestRequestData, out ActivateEnrollRequestResponseError ActivateEnrollRequestResponseError)
        {
            ActivateEnrollRequestRequest inValue = new ActivateEnrollRequestRequest();
            inValue.PIN = PIN;
            inValue.ActivateEnrollRequestRequestData = ActivateEnrollRequestRequestData;
            ActivateEnrollRequestResponse retVal = ((INprPlus)(this)).ActivateEnroll(inValue);
            ActivateEnrollRequestResponseError = retVal.ActivateEnrollRequestResponseError;
            return retVal.ActivateEnrollRequestResponseData;
        }

        public RevokedByThirdPartyRequestResponse RevokedByThirdParty(RevokedByThirdPartyRequestRequest request)
        {
            return base.Channel.RevokedByThirdParty(request);
        }

        public RevokedByThirdPartyRequestResponseData RevokedByThirdParty(string PIN, RevokedByThirdPartyRequestRequestData RevokedByThirdPartyRequestData, out RevokedByThirdPartyRequestResponseError RevokedByThirdPartyRequestResponseError)
        {
            RevokedByThirdPartyRequestRequest inValue = new RevokedByThirdPartyRequestRequest();
            inValue.PIN = PIN;
            inValue.RevokedByThirdPartyRequestRequestData = RevokedByThirdPartyRequestData;
            RevokedByThirdPartyRequestResponse retVal = ((INprPlus)(this)).RevokedByThirdParty(inValue);
            RevokedByThirdPartyRequestResponseError = retVal.RevokedByThirdPartyRequestResponseError;
            return retVal.RevokedByThirdPartyRequestResponseData;
        }

        public PSRightCheckResponseData CheckPSRight(string PIN, PSRightCheckRequestData PSRightCheckRequestData, out PSRightCheckResponseError PSRightCheckResponseError) {
            PSRightCheckRequest inValue = new PSRightCheckRequest();
            inValue.PIN = PIN;
            inValue.PSRightCheckRequestData = PSRightCheckRequestData;
            PSRightCheckResponse retVal = ((INprPlus)(this)).CheckPSRight(inValue);
            PSRightCheckResponseError = retVal.PSRightCheckResponseError;
            return retVal.PSRightCheckResponseData;
        }

        public PSRightCheckResponse CheckPSRight(PSRightCheckRequest request) {
            return base.Channel.CheckPSRight(request);
        }
    }

}
