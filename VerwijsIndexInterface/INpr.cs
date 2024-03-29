﻿namespace Denion.WebService.VerwijsIndex
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://rdw.nl/rpv/1.0", ConfigurationName = "Denion.WebService.VerwijsIndex.IRegistration")]
    public interface IRegistration
    {
        #region not implemented
        // CODEGEN: Generating message contract since the wrapper name (CalculatePriceRequest) of message CalculatePriceRequest does not match the default value (CalculatePrice)
        [System.ServiceModel.OperationContractAttribute(Action = "http://rdw.nl/rpv/1.0/IRegistration/CalculatePrice")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ResponseError))]
        Denion.WebService.VerwijsIndex.CalculatePriceResponse CalculatePrice(Denion.WebService.VerwijsIndex.CalculatePriceRequest request);

        // CODEGEN: Generating message contract since the wrapper name (PSRightCheckRequest) of message PSRightCheckRequest does not match the default value (CheckPSRight)
        [System.ServiceModel.OperationContractAttribute(Action = "http://rdw.nl/rpv/1.0/IRegistration/CheckPSRight")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ResponseError))]
        Denion.WebService.VerwijsIndex.PSRightCheckResponse CheckPSRight(Denion.WebService.VerwijsIndex.PSRightCheckRequest request);

       
        // CODEGEN: Generating message contract since the wrapper name (RetrieveAreaRegulationFareInfoRequest) of message RetrieveAreaRegulationFareInfoRequest does not match the default value (RetrieveAreaRegulationFareInfo)
        [System.ServiceModel.OperationContractAttribute(Action = "http://rdw.nl/rpv/1.0/IRegistration/RetrieveAreaRegulationFareInfo")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ResponseError))]
        Denion.WebService.VerwijsIndex.RetrieveAreaRegulationFareInfoResponse RetrieveAreaRegulationFareInfo(Denion.WebService.VerwijsIndex.RetrieveAreaRegulationFareInfoRequest request);

        // CODEGEN: Generating message contract since the wrapper name (RetrieveAreasByLocationRequest) of message RetrieveAreasByLocationRequest does not match the default value (RetrieveAreasByLocation)
        [System.ServiceModel.OperationContractAttribute(Action = "http://rdw.nl/rpv/1.0/IRegistration/RetrieveAreasByLocation")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ResponseError))]
        Denion.WebService.VerwijsIndex.RetrieveAreasByLocationResponse RetrieveAreasByLocation(Denion.WebService.VerwijsIndex.RetrieveAreasByLocationRequest request);

        // CODEGEN: Generating message contract since the wrapper name (RetrieveCheckInfoRequest) of message RetrieveCheckInfoRequest does not match the default value (RetrieveCheckInfo)
        [System.ServiceModel.OperationContractAttribute(Action = "http://rdw.nl/rpv/1.0/IRegistration/RetrieveCheckInfo")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ResponseError))]
        Denion.WebService.VerwijsIndex.RetrieveCheckInfoResponse RetrieveCheckInfo(Denion.WebService.VerwijsIndex.RetrieveCheckInfoRequest request);

        // CODEGEN: Generating message contract since the wrapper name (RetrieveRightInfoRequest) of message RetrieveRightInfoRequest does not match the default value (RetrieveRightInfo)
        [System.ServiceModel.OperationContractAttribute(Action = "http://rdw.nl/rpv/1.0/IRegistration/RetrieveRightInfo")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ResponseError))]
        Denion.WebService.VerwijsIndex.RetrieveRightInfoResponse RetrieveRightInfo(Denion.WebService.VerwijsIndex.RetrieveRightInfoRequest request);

        // CODEGEN: Generating message contract since the wrapper name (RetrieveRightInfoForProviderRequest) of message RetrieveRightInfoForProviderRequest does not match the default value (RetrieveRightInfoForProvider)
        [System.ServiceModel.OperationContractAttribute(Action = "http://rdw.nl/rpv/1.0/IRegistration/RetrieveRightInfoForProvider")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ResponseError))]
        Denion.WebService.VerwijsIndex.RetrieveRightInfoForProviderResponse RetrieveRightInfoForProvider(Denion.WebService.VerwijsIndex.RetrieveRightInfoForProviderRequest request);
        #endregion

        // CODEGEN: Generating message contract since the wrapper name (PSRightEnrollRequest) of message PSRightEnrollRequest does not match the default value (EnrollPSRight)
        [System.ServiceModel.OperationContractAttribute(Action = "http://rdw.nl/rpv/1.0/IRegistration/EnrollPSRight")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ResponseError))]
        Denion.WebService.VerwijsIndex.PSRightEnrollResponse EnrollPSRight(Denion.WebService.VerwijsIndex.PSRightEnrollRequest request);

        // CODEGEN: Generating message contract since the wrapper name (PSRightRevokeRequest) of message PSRightRevokeRequest does not match the default value (RevokePSRight)
        [System.ServiceModel.OperationContractAttribute(Action = "http://rdw.nl/rpv/1.0/IRegistration/RevokePSRight")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ResponseError))]
        Denion.WebService.VerwijsIndex.PSRightRevokeResponse RevokePSRight(Denion.WebService.VerwijsIndex.PSRightRevokeRequest request);

        // CODEGEN: Generating message contract since the wrapper name (StatusRequestRequest) of message StatusRequestRequest does not match the default value (StatusRequest)
        [System.ServiceModel.OperationContractAttribute(Action = "http://rdw.nl/rpv/1.0/IRegistration/StatusRequest")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ResponseError))]
        Denion.WebService.VerwijsIndex.StatusRequestResponse StatusRequest(Denion.WebService.VerwijsIndex.StatusRequestRequest request);
    }


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class CalculatePriceRequestData : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string vehicleIdField;

        private System.Nullable<UneceLandCodesType> countryCodeVehicleField;

        private bool countryCodeVehicleFieldSpecified;

        private string areaManagerIdField;

        private string areaIdField;

        private CalculatePriceRequestDataLocationPSRight locationPSRightField;

        private string sellingPointIdField;

        private string usageIdField;

        private System.DateTime startTimePSrightField;

        private System.Nullable<System.DateTime> endTimePSrightField;

        private bool endTimePSrightFieldSpecified;

        private PSRightWindowData[] pSRightWindowListField;

        private System.Nullable<decimal> amountPSrightField;

        private bool amountPSrightFieldSpecified;

        private System.Nullable<decimal> vATPSrightField;

        private bool vATPSrightFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string VehicleId
        {
            get
            {
                return this.vehicleIdField;
            }
            set
            {
                this.vehicleIdField = value;
                this.RaisePropertyChanged("VehicleId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 1)]
        public System.Nullable<UneceLandCodesType> CountryCodeVehicle
        {
            get
            {
                return this.countryCodeVehicleField;
            }
            set
            {
                this.countryCodeVehicleField = value;
                this.RaisePropertyChanged("CountryCodeVehicle");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CountryCodeVehicleSpecified
        {
            get
            {
                return this.countryCodeVehicleFieldSpecified;
            }
            set
            {
                this.countryCodeVehicleFieldSpecified = value;
                this.RaisePropertyChanged("CountryCodeVehicleSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", IsNullable = true, Order = 2)]
        public string AreaManagerId
        {
            get
            {
                return this.areaManagerIdField;
            }
            set
            {
                this.areaManagerIdField = value;
                this.RaisePropertyChanged("AreaManagerId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 3)]
        public string AreaId
        {
            get
            {
                return this.areaIdField;
            }
            set
            {
                this.areaIdField = value;
                this.RaisePropertyChanged("AreaId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public CalculatePriceRequestDataLocationPSRight LocationPSRight
        {
            get
            {
                return this.locationPSRightField;
            }
            set
            {
                this.locationPSRightField = value;
                this.RaisePropertyChanged("LocationPSRight");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", IsNullable = true, Order = 5)]
        public string SellingPointId
        {
            get
            {
                return this.sellingPointIdField;
            }
            set
            {
                this.sellingPointIdField = value;
                this.RaisePropertyChanged("SellingPointId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string UsageId
        {
            get
            {
                return this.usageIdField;
            }
            set
            {
                this.usageIdField = value;
                this.RaisePropertyChanged("UsageId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public System.DateTime StartTimePSright
        {
            get
            {
                return this.startTimePSrightField;
            }
            set
            {
                this.startTimePSrightField = value;
                this.RaisePropertyChanged("StartTimePSright");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 8)]
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

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 9)]
        public PSRightWindowData[] PSRightWindowList
        {
            get
            {
                return this.pSRightWindowListField;
            }
            set
            {
                this.pSRightWindowListField = value;
                this.RaisePropertyChanged("PSRightWindowList");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 10)]
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
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 11)]
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

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public enum UneceLandCodesType
    {

        /// <remarks/>
        A,

        /// <remarks/>
        AFG,

        /// <remarks/>
        AL,

        /// <remarks/>
        AM,

        /// <remarks/>
        AND,

        /// <remarks/>
        AUS,

        /// <remarks/>
        AZ,

        /// <remarks/>
        B,

        /// <remarks/>
        BD,

        /// <remarks/>
        BDS,

        /// <remarks/>
        BF,

        /// <remarks/>
        BG,

        /// <remarks/>
        BH,

        /// <remarks/>
        BIH,

        /// <remarks/>
        BOL,

        /// <remarks/>
        BR,

        /// <remarks/>
        BRN,

        /// <remarks/>
        BRU,

        /// <remarks/>
        BS,

        /// <remarks/>
        BUR,

        /// <remarks/>
        BVI,

        /// <remarks/>
        BW,

        /// <remarks/>
        BY,

        /// <remarks/>
        CAM,

        /// <remarks/>
        CDN,

        /// <remarks/>
        CH,

        /// <remarks/>
        CI,

        /// <remarks/>
        CL,

        /// <remarks/>
        CO,

        /// <remarks/>
        CR,

        /// <remarks/>
        CU,

        /// <remarks/>
        CY,

        /// <remarks/>
        CZ,

        /// <remarks/>
        D,

        /// <remarks/>
        DK,

        /// <remarks/>
        DOM,

        /// <remarks/>
        DY,

        /// <remarks/>
        DZ,

        /// <remarks/>
        E,

        /// <remarks/>
        EAK,

        /// <remarks/>
        EAT,

        /// <remarks/>
        EAU,

        /// <remarks/>
        EAZ,

        /// <remarks/>
        EC,

        /// <remarks/>
        ER,

        /// <remarks/>
        ES,

        /// <remarks/>
        EST,

        /// <remarks/>
        ET,

        /// <remarks/>
        ETH,

        /// <remarks/>
        F,

        /// <remarks/>
        FIN,

        /// <remarks/>
        FJI,

        /// <remarks/>
        FL,

        /// <remarks/>
        FR,

        /// <remarks/>
        G,

        /// <remarks/>
        GB,

        /// <remarks/>
        GBA,

        /// <remarks/>
        GBG,

        /// <remarks/>
        GBJ,

        /// <remarks/>
        GBM,

        /// <remarks/>
        GBZ,

        /// <remarks/>
        GCA,

        /// <remarks/>
        GE,

        /// <remarks/>
        GH,

        /// <remarks/>
        GR,

        /// <remarks/>
        GUY,

        /// <remarks/>
        H,

        /// <remarks/>
        HKJ,

        /// <remarks/>
        HR,

        /// <remarks/>
        I,

        /// <remarks/>
        IL,

        /// <remarks/>
        IND,

        /// <remarks/>
        IR,

        /// <remarks/>
        IRL,

        /// <remarks/>
        IRQ,

        /// <remarks/>
        IS,

        /// <remarks/>
        J,

        /// <remarks/>
        JA,

        /// <remarks/>
        K,

        /// <remarks/>
        KS,

        /// <remarks/>
        KWT,

        /// <remarks/>
        KZ,

        /// <remarks/>
        L,

        /// <remarks/>
        LAO,

        /// <remarks/>
        LAR,

        /// <remarks/>
        LB,

        /// <remarks/>
        LS,

        /// <remarks/>
        LT,

        /// <remarks/>
        LV,

        /// <remarks/>
        M,

        /// <remarks/>
        MA,

        /// <remarks/>
        MC,

        /// <remarks/>
        MD,

        /// <remarks/>
        MAL,

        /// <remarks/>
        MEX,

        /// <remarks/>
        MGL,

        /// <remarks/>
        MK,

        /// <remarks/>
        MNE,

        /// <remarks/>
        MOC,

        /// <remarks/>
        MS,

        /// <remarks/>
        MW,

        /// <remarks/>
        N,

        /// <remarks/>
        NA,

        /// <remarks/>
        NAM,

        /// <remarks/>
        NAU,

        /// <remarks/>
        NEP,

        /// <remarks/>
        NIC,

        /// <remarks/>
        NL,

        /// <remarks/>
        NZ,

        /// <remarks/>
        P,

        /// <remarks/>
        PA,

        /// <remarks/>
        PE,

        /// <remarks/>
        PK,

        /// <remarks/>
        PL,

        /// <remarks/>
        PNG,

        /// <remarks/>
        PY,

        /// <remarks/>
        Q,

        /// <remarks/>
        RA,

        /// <remarks/>
        RC,

        /// <remarks/>
        RCA,

        /// <remarks/>
        RCB,

        /// <remarks/>
        RCH,

        /// <remarks/>
        RG,

        /// <remarks/>
        RH,

        /// <remarks/>
        RI,

        /// <remarks/>
        RIM,

        /// <remarks/>
        RL,

        /// <remarks/>
        RM,

        /// <remarks/>
        RMM,

        /// <remarks/>
        RN,

        /// <remarks/>
        RNR,

        /// <remarks/>
        RO,

        /// <remarks/>
        ROK,

        /// <remarks/>
        ROU,

        /// <remarks/>
        RP,

        /// <remarks/>
        RSM,

        /// <remarks/>
        RU,

        /// <remarks/>
        RUS,

        /// <remarks/>
        RWA,

        /// <remarks/>
        S,

        /// <remarks/>
        SA,

        /// <remarks/>
        SD,

        /// <remarks/>
        SGP,

        /// <remarks/>
        SK,

        /// <remarks/>
        SLO,

        /// <remarks/>
        SME,

        /// <remarks/>
        SN,

        /// <remarks/>
        SO,

        /// <remarks/>
        SRB,

        /// <remarks/>
        SUD,

        /// <remarks/>
        SY,

        /// <remarks/>
        SYR,

        /// <remarks/>
        T,

        /// <remarks/>
        TCH,

        /// <remarks/>
        TD,

        /// <remarks/>
        TG,

        /// <remarks/>
        TJ,

        /// <remarks/>
        TM,

        /// <remarks/>
        TN,

        /// <remarks/>
        TR,

        /// <remarks/>
        TT,

        /// <remarks/>
        UA,

        /// <remarks/>
        UAE,

        /// <remarks/>
        USA,

        /// <remarks/>
        UZ,

        /// <remarks/>
        V,

        /// <remarks/>
        VN,

        /// <remarks/>
        WAG,

        /// <remarks/>
        WAN,

        /// <remarks/>
        WG,

        /// <remarks/>
        WL,

        /// <remarks/>
        WS,

        /// <remarks/>
        WV,

        /// <remarks/>
        YAR,

        /// <remarks/>
        YV,

        /// <remarks/>
        ZA,

        /// <remarks/>
        ZRE,

        /// <remarks/>
        ZW,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class CalculatePriceRequestDataLocationPSRight : object, System.ComponentModel.INotifyPropertyChanged
    {

        private decimal latitudeField;

        private decimal longitudeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public decimal Latitude
        {
            get
            {
                return this.latitudeField;
            }
            set
            {
                this.latitudeField = value;
                this.RaisePropertyChanged("Latitude");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public decimal Longitude
        {
            get
            {
                return this.longitudeField;
            }
            set
            {
                this.longitudeField = value;
                this.RaisePropertyChanged("Longitude");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class StatusRequestResponseData : object, System.ComponentModel.INotifyPropertyChanged
    {

        private System.DateTime statusTimeField;

        private string statusRPVField;

        private string statusReferenceField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public System.DateTime StatusTime
        {
            get
            {
                return this.statusTimeField;
            }
            set
            {
                this.statusTimeField = value;
                this.RaisePropertyChanged("StatusTime");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string StatusRPV
        {
            get
            {
                return this.statusRPVField;
            }
            set
            {
                this.statusRPVField = value;
                this.RaisePropertyChanged("StatusRPV");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 2)]
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

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class StatusRequestRequestData : object, System.ComponentModel.INotifyPropertyChanged
    {

        private System.Nullable<System.DateTime> statusTimeField;

        private string statusReferenceField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 0)]
        public System.Nullable<System.DateTime> StatusTime
        {
            get
            {
                return this.statusTimeField;
            }
            set
            {
                this.statusTimeField = value;
                this.RaisePropertyChanged("StatusTime");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 1)]
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

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class PSRightRevokeResponseData : object, System.ComponentModel.INotifyPropertyChanged
    {

        private System.Nullable<System.DateTime> endTimePSRightAdjustedField;

        private bool endTimePSRightAdjustedFieldSpecified;

        private System.Nullable<decimal> amountPSRightCalculatedField;

        private bool amountPSRightCalculatedFieldSpecified;

        private System.Nullable<decimal> vATPSRightCalculatedField;

        private bool vATPSRightCalculatedFieldSpecified;

        private SpecifCalcAmountData[] specifCalcAmountListField;

        private PSRightRemarkData[] pSRightRemarkListField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 0)]
        public System.Nullable<System.DateTime> EndTimePSRightAdjusted
        {
            get
            {
                return this.endTimePSRightAdjustedField;
            }
            set
            {
                this.endTimePSRightAdjustedField = value;
                this.RaisePropertyChanged("EndTimePSRightAdjusted");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EndTimePSRightAdjustedSpecified
        {
            get
            {
                return this.endTimePSRightAdjustedFieldSpecified;
            }
            set
            {
                this.endTimePSRightAdjustedFieldSpecified = value;
                this.RaisePropertyChanged("EndTimePSRightAdjustedSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 1)]
        public System.Nullable<decimal> AmountPSRightCalculated
        {
            get
            {
                return this.amountPSRightCalculatedField;
            }
            set
            {
                this.amountPSRightCalculatedField = value;
                this.RaisePropertyChanged("AmountPSRightCalculated");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AmountPSRightCalculatedSpecified
        {
            get
            {
                return this.amountPSRightCalculatedFieldSpecified;
            }
            set
            {
                this.amountPSRightCalculatedFieldSpecified = value;
                this.RaisePropertyChanged("AmountPSRightCalculatedSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 2)]
        public System.Nullable<decimal> VATPSRightCalculated
        {
            get
            {
                return this.vATPSRightCalculatedField;
            }
            set
            {
                this.vATPSRightCalculatedField = value;
                this.RaisePropertyChanged("VATPSRightCalculated");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool VATPSRightCalculatedSpecified
        {
            get
            {
                return this.vATPSRightCalculatedFieldSpecified;
            }
            set
            {
                this.vATPSRightCalculatedFieldSpecified = value;
                this.RaisePropertyChanged("VATPSRightCalculatedSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 3)]
        public SpecifCalcAmountData[] SpecifCalcAmountList
        {
            get
            {
                return this.specifCalcAmountListField;
            }
            set
            {
                this.specifCalcAmountListField = value;
                this.RaisePropertyChanged("SpecifCalcAmountList");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 4)]
        public PSRightRemarkData[] PSRightRemarkList
        {
            get
            {
                return this.pSRightRemarkListField;
            }
            set
            {
                this.pSRightRemarkListField = value;
                this.RaisePropertyChanged("PSRightRemarkList");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class SpecifCalcAmountData : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string regulationIdField;

        private System.DateTime startTimeAppliedField;

        private System.DateTime endTimeAppliedField;

        private decimal amountFractionField;

        private System.Nullable<decimal> vATAmountFractionField;

        private bool vATAmountFractionFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string RegulationId
        {
            get
            {
                return this.regulationIdField;
            }
            set
            {
                this.regulationIdField = value;
                this.RaisePropertyChanged("RegulationId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public System.DateTime StartTimeApplied
        {
            get
            {
                return this.startTimeAppliedField;
            }
            set
            {
                this.startTimeAppliedField = value;
                this.RaisePropertyChanged("StartTimeApplied");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public System.DateTime EndTimeApplied
        {
            get
            {
                return this.endTimeAppliedField;
            }
            set
            {
                this.endTimeAppliedField = value;
                this.RaisePropertyChanged("EndTimeApplied");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public decimal AmountFraction
        {
            get
            {
                return this.amountFractionField;
            }
            set
            {
                this.amountFractionField = value;
                this.RaisePropertyChanged("AmountFraction");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 4)]
        public System.Nullable<decimal> VATAmountFraction
        {
            get
            {
                return this.vATAmountFractionField;
            }
            set
            {
                this.vATAmountFractionField = value;
                this.RaisePropertyChanged("VATAmountFraction");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool VATAmountFractionSpecified
        {
            get
            {
                return this.vATAmountFractionFieldSpecified;
            }
            set
            {
                this.vATAmountFractionFieldSpecified = value;
                this.RaisePropertyChanged("VATAmountFractionSpecified");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class PSRightRemarkData : object, System.ComponentModel.INotifyPropertyChanged
    {

        private KindOfRemarksType pSRightRemarkTypeField;

        private System.Nullable<System.DateTime> startTimeRemarkField;

        private bool startTimeRemarkFieldSpecified;

        private System.Nullable<System.DateTime> endTimeRemarkField;

        private bool endTimeRemarkFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public KindOfRemarksType PSRightRemarkType
        {
            get
            {
                return this.pSRightRemarkTypeField;
            }
            set
            {
                this.pSRightRemarkTypeField = value;
                this.RaisePropertyChanged("PSRightRemarkType");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 1)]
        public System.Nullable<System.DateTime> StartTimeRemark
        {
            get
            {
                return this.startTimeRemarkField;
            }
            set
            {
                this.startTimeRemarkField = value;
                this.RaisePropertyChanged("StartTimeRemark");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StartTimeRemarkSpecified
        {
            get
            {
                return this.startTimeRemarkFieldSpecified;
            }
            set
            {
                this.startTimeRemarkFieldSpecified = value;
                this.RaisePropertyChanged("StartTimeRemarkSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 2)]
        public System.Nullable<System.DateTime> EndTimeRemark
        {
            get
            {
                return this.endTimeRemarkField;
            }
            set
            {
                this.endTimeRemarkField = value;
                this.RaisePropertyChanged("EndTimeRemark");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EndTimeRemarkSpecified
        {
            get
            {
                return this.endTimeRemarkFieldSpecified;
            }
            set
            {
                this.endTimeRemarkFieldSpecified = value;
                this.RaisePropertyChanged("EndTimeRemarkSpecified");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public enum KindOfRemarksType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1")]
        Item1,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("2")]
        Item2,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("3")]
        Item3,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class PSRightRevokeRequestData : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string pSRightIdField;

        private System.DateTime endTimePSRightField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 0)]
        public string PSRightId {
            get {
                return this.pSRightIdField;
            }
            set {
                this.pSRightIdField = value;
                this.RaisePropertyChanged("PSRightId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public System.DateTime EndTimePSRight
        {
            get
            {
                return this.endTimePSRightField;
            }
            set
            {
                this.endTimePSRightField = value;
                this.RaisePropertyChanged("EndTimePSRight");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class RetrieveRightInfoForProviderResponseData : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string vehicleIdField;

        private PSRightInfoData[] pSRightInfoListField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 0)]
        public string VehicleId
        {
            get
            {
                return this.vehicleIdField;
            }
            set
            {
                this.vehicleIdField = value;
                this.RaisePropertyChanged("VehicleId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 1)]
        public PSRightInfoData[] PSRightInfoList
        {
            get
            {
                return this.pSRightInfoListField;
            }
            set
            {
                this.pSRightInfoListField = value;
                this.RaisePropertyChanged("PSRightInfoList");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class PSRightInfoData : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string pSRightIdField;

        private string referencePSRightField;

        private System.Nullable<UneceLandCodesType> countryCodeVehicleField;

        private bool countryCodeVehicleFieldSpecified;

        private string sellingPointIdField;

        private System.DateTime startTimePSRightField;

        private System.Nullable<System.DateTime> endTimePSRightField;

        private bool endTimePSRightFieldSpecified;

        private System.Nullable<System.DateTime> endTimePSRightAdjustedField;

        private bool endTimePSRightAdjustedFieldSpecified;

        private PSRightWindowData[] pSRightWindowListField;

        private string pSRightAcquirerCodeField;

        private string pSRightAcquirerDescField;

        private string areaManagerIdField;

        private string areaManagerDescField;

        private string areaIdField;

        private string areaDescField;

        private string usageIdField;

        private string usageDescField;

        private System.DateTime registrationTimePSRightField;

        private System.DateTime registrationEndTimePSRightField;

        private bool registrationEndTimePSRightFieldSpecified;

        private PSRightInfoDataLocationPSRight locationPSRightField;

        private System.Nullable<decimal> amountPSRightField;

        private bool amountPSRightFieldSpecified;

        private System.Nullable<decimal> vATPSRightField;

        private bool vATPSRightFieldSpecified;

        private System.Nullable<decimal> amountPSRightCalculatedField;

        private bool amountPSRightCalculatedFieldSpecified;

        private System.Nullable<decimal> vATPSRightCalculatedField;

        private bool vATPSRightCalculatedFieldSpecified;

        private System.Nullable<decimal> amountPSRightRecalculatedField;

        private bool amountPSRightRecalculatedFieldSpecified;

        private System.Nullable<decimal> vATPSRightRecalculatedField;

        private bool vATPSRightRecalculatedFieldSpecified;

        private System.DateTime timeRecalculationField;

        private bool timeRecalculationFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 0)]
        public string PSRightId
        {
            get
            {
                return this.pSRightIdField;
            }
            set
            {
                this.pSRightIdField = value;
                this.RaisePropertyChanged("PSRightId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 1)]
        public string ReferencePSRight
        {
            get
            {
                return this.referencePSRightField;
            }
            set
            {
                this.referencePSRightField = value;
                this.RaisePropertyChanged("ReferencePSRight");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 2)]
        public System.Nullable<UneceLandCodesType> CountryCodeVehicle
        {
            get
            {
                return this.countryCodeVehicleField;
            }
            set
            {
                this.countryCodeVehicleField = value;
                this.RaisePropertyChanged("CountryCodeVehicle");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CountryCodeVehicleSpecified
        {
            get
            {
                return this.countryCodeVehicleFieldSpecified;
            }
            set
            {
                this.countryCodeVehicleFieldSpecified = value;
                this.RaisePropertyChanged("CountryCodeVehicleSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", IsNullable = true, Order = 3)]
        public string SellingPointId
        {
            get
            {
                return this.sellingPointIdField;
            }
            set
            {
                this.sellingPointIdField = value;
                this.RaisePropertyChanged("SellingPointId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public System.DateTime StartTimePSRight
        {
            get
            {
                return this.startTimePSRightField;
            }
            set
            {
                this.startTimePSRightField = value;
                this.RaisePropertyChanged("StartTimePSRight");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 5)]
        public System.Nullable<System.DateTime> EndTimePSRight
        {
            get
            {
                return this.endTimePSRightField;
            }
            set
            {
                this.endTimePSRightField = value;
                this.RaisePropertyChanged("EndTimePSRight");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EndTimePSRightSpecified
        {
            get
            {
                return this.endTimePSRightFieldSpecified;
            }
            set
            {
                this.endTimePSRightFieldSpecified = value;
                this.RaisePropertyChanged("EndTimePSRightSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 6)]
        public System.Nullable<System.DateTime> EndTimePSRightAdjusted
        {
            get
            {
                return this.endTimePSRightAdjustedField;
            }
            set
            {
                this.endTimePSRightAdjustedField = value;
                this.RaisePropertyChanged("EndTimePSRightAdjusted");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EndTimePSRightAdjustedSpecified
        {
            get
            {
                return this.endTimePSRightAdjustedFieldSpecified;
            }
            set
            {
                this.endTimePSRightAdjustedFieldSpecified = value;
                this.RaisePropertyChanged("EndTimePSRightAdjustedSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 7)]
        public PSRightWindowData[] PSRightWindowList
        {
            get
            {
                return this.pSRightWindowListField;
            }
            set
            {
                this.pSRightWindowListField = value;
                this.RaisePropertyChanged("PSRightWindowList");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string PSRightAcquirerCode
        {
            get
            {
                return this.pSRightAcquirerCodeField;
            }
            set
            {
                this.pSRightAcquirerCodeField = value;
                this.RaisePropertyChanged("PSRightAcquirerCode");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 9)]
        public string PSRightAcquirerDesc
        {
            get
            {
                return this.pSRightAcquirerDescField;
            }
            set
            {
                this.pSRightAcquirerDescField = value;
                this.RaisePropertyChanged("PSRightAcquirerDesc");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 10)]
        public string AreaManagerId
        {
            get
            {
                return this.areaManagerIdField;
            }
            set
            {
                this.areaManagerIdField = value;
                this.RaisePropertyChanged("AreaManagerId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 11)]
        public string AreaManagerDesc
        {
            get
            {
                return this.areaManagerDescField;
            }
            set
            {
                this.areaManagerDescField = value;
                this.RaisePropertyChanged("AreaManagerDesc");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public string AreaId
        {
            get
            {
                return this.areaIdField;
            }
            set
            {
                this.areaIdField = value;
                this.RaisePropertyChanged("AreaId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 13)]
        public string AreaDesc
        {
            get
            {
                return this.areaDescField;
            }
            set
            {
                this.areaDescField = value;
                this.RaisePropertyChanged("AreaDesc");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public string UsageId
        {
            get
            {
                return this.usageIdField;
            }
            set
            {
                this.usageIdField = value;
                this.RaisePropertyChanged("UsageId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public string UsageDesc
        {
            get
            {
                return this.usageDescField;
            }
            set
            {
                this.usageDescField = value;
                this.RaisePropertyChanged("UsageDesc");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public System.DateTime RegistrationTimePSRight
        {
            get
            {
                return this.registrationTimePSRightField;
            }
            set
            {
                this.registrationTimePSRightField = value;
                this.RaisePropertyChanged("RegistrationTimePSRight");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        public System.DateTime RegistrationEndTimePSRight
        {
            get
            {
                return this.registrationEndTimePSRightField;
            }
            set
            {
                this.registrationEndTimePSRightField = value;
                this.RaisePropertyChanged("RegistrationEndTimePSRight");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RegistrationEndTimePSRightSpecified
        {
            get
            {
                return this.registrationEndTimePSRightFieldSpecified;
            }
            set
            {
                this.registrationEndTimePSRightFieldSpecified = value;
                this.RaisePropertyChanged("RegistrationEndTimePSRightSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        public PSRightInfoDataLocationPSRight LocationPSRight
        {
            get
            {
                return this.locationPSRightField;
            }
            set
            {
                this.locationPSRightField = value;
                this.RaisePropertyChanged("LocationPSRight");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 19)]
        public System.Nullable<decimal> AmountPSRight
        {
            get
            {
                return this.amountPSRightField;
            }
            set
            {
                this.amountPSRightField = value;
                this.RaisePropertyChanged("AmountPSRight");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AmountPSRightSpecified
        {
            get
            {
                return this.amountPSRightFieldSpecified;
            }
            set
            {
                this.amountPSRightFieldSpecified = value;
                this.RaisePropertyChanged("AmountPSRightSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 20)]
        public System.Nullable<decimal> VATPSRight
        {
            get
            {
                return this.vATPSRightField;
            }
            set
            {
                this.vATPSRightField = value;
                this.RaisePropertyChanged("VATPSRight");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool VATPSRightSpecified
        {
            get
            {
                return this.vATPSRightFieldSpecified;
            }
            set
            {
                this.vATPSRightFieldSpecified = value;
                this.RaisePropertyChanged("VATPSRightSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 21)]
        public System.Nullable<decimal> AmountPSRightCalculated
        {
            get
            {
                return this.amountPSRightCalculatedField;
            }
            set
            {
                this.amountPSRightCalculatedField = value;
                this.RaisePropertyChanged("AmountPSRightCalculated");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AmountPSRightCalculatedSpecified
        {
            get
            {
                return this.amountPSRightCalculatedFieldSpecified;
            }
            set
            {
                this.amountPSRightCalculatedFieldSpecified = value;
                this.RaisePropertyChanged("AmountPSRightCalculatedSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 22)]
        public System.Nullable<decimal> VATPSRightCalculated
        {
            get
            {
                return this.vATPSRightCalculatedField;
            }
            set
            {
                this.vATPSRightCalculatedField = value;
                this.RaisePropertyChanged("VATPSRightCalculated");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool VATPSRightCalculatedSpecified
        {
            get
            {
                return this.vATPSRightCalculatedFieldSpecified;
            }
            set
            {
                this.vATPSRightCalculatedFieldSpecified = value;
                this.RaisePropertyChanged("VATPSRightCalculatedSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 23)]
        public System.Nullable<decimal> AmountPSRightRecalculated
        {
            get
            {
                return this.amountPSRightRecalculatedField;
            }
            set
            {
                this.amountPSRightRecalculatedField = value;
                this.RaisePropertyChanged("AmountPSRightRecalculated");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AmountPSRightRecalculatedSpecified
        {
            get
            {
                return this.amountPSRightRecalculatedFieldSpecified;
            }
            set
            {
                this.amountPSRightRecalculatedFieldSpecified = value;
                this.RaisePropertyChanged("AmountPSRightRecalculatedSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 24)]
        public System.Nullable<decimal> VATPSRightRecalculated
        {
            get
            {
                return this.vATPSRightRecalculatedField;
            }
            set
            {
                this.vATPSRightRecalculatedField = value;
                this.RaisePropertyChanged("VATPSRightRecalculated");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool VATPSRightRecalculatedSpecified
        {
            get
            {
                return this.vATPSRightRecalculatedFieldSpecified;
            }
            set
            {
                this.vATPSRightRecalculatedFieldSpecified = value;
                this.RaisePropertyChanged("VATPSRightRecalculatedSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        public System.DateTime TimeRecalculation
        {
            get
            {
                return this.timeRecalculationField;
            }
            set
            {
                this.timeRecalculationField = value;
                this.RaisePropertyChanged("TimeRecalculation");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TimeRecalculationSpecified
        {
            get
            {
                return this.timeRecalculationFieldSpecified;
            }
            set
            {
                this.timeRecalculationFieldSpecified = value;
                this.RaisePropertyChanged("TimeRecalculationSpecified");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class PSRightWindowData : object, System.ComponentModel.INotifyPropertyChanged
    {

        private System.Nullable<DaysOfTheWeekType> startTimePSrightDayWindowField;

        private bool startTimePSrightDayWindowFieldSpecified;

        private System.Nullable<DaysOfTheWeekType> endTimePSrightDayWindowField;

        private bool endTimePSrightDayWindowFieldSpecified;

        private string startTimePSrightWindowField;

        private string endTimePSrightWindowField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 0)]
        public System.Nullable<DaysOfTheWeekType> StartTimePSrightDayWindow
        {
            get
            {
                return this.startTimePSrightDayWindowField;
            }
            set
            {
                this.startTimePSrightDayWindowField = value;
                this.RaisePropertyChanged("StartTimePSrightDayWindow");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StartTimePSrightDayWindowSpecified
        {
            get
            {
                return this.startTimePSrightDayWindowFieldSpecified;
            }
            set
            {
                this.startTimePSrightDayWindowFieldSpecified = value;
                this.RaisePropertyChanged("StartTimePSrightDayWindowSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 1)]
        public System.Nullable<DaysOfTheWeekType> EndTimePSrightDayWindow
        {
            get
            {
                return this.endTimePSrightDayWindowField;
            }
            set
            {
                this.endTimePSrightDayWindowField = value;
                this.RaisePropertyChanged("EndTimePSrightDayWindow");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EndTimePSrightDayWindowSpecified
        {
            get
            {
                return this.endTimePSrightDayWindowFieldSpecified;
            }
            set
            {
                this.endTimePSrightDayWindowFieldSpecified = value;
                this.RaisePropertyChanged("EndTimePSrightDayWindowSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", IsNullable = true, Order = 2)]
        public string StartTimePSrightWindow
        {
            get
            {
                return this.startTimePSrightWindowField;
            }
            set
            {
                this.startTimePSrightWindowField = value;
                this.RaisePropertyChanged("StartTimePSrightWindow");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", IsNullable = true, Order = 3)]
        public string EndTimePSrightWindow
        {
            get
            {
                return this.endTimePSrightWindowField;
            }
            set
            {
                this.endTimePSrightWindowField = value;
                this.RaisePropertyChanged("EndTimePSrightWindow");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public enum DaysOfTheWeekType
    {

        /// <remarks/>
        ZONDAG,

        /// <remarks/>
        MAANDAG,

        /// <remarks/>
        DINSDAG,

        /// <remarks/>
        WOENSDAG,

        /// <remarks/>
        DONDERDAG,

        /// <remarks/>
        VRIJDAG,

        /// <remarks/>
        ZATERDAG,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class PSRightInfoDataLocationPSRight : object, System.ComponentModel.INotifyPropertyChanged
    {

        private decimal latitudeField;

        private decimal longitudeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public decimal Latitude
        {
            get
            {
                return this.latitudeField;
            }
            set
            {
                this.latitudeField = value;
                this.RaisePropertyChanged("Latitude");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public decimal Longitude
        {
            get
            {
                return this.longitudeField;
            }
            set
            {
                this.longitudeField = value;
                this.RaisePropertyChanged("Longitude");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class RetrieveRightInfoForProviderRequestData : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string vehicleIdField;

        private string pSRightIdField;

        private System.Nullable<System.DateTime> startTimePSRightsField;

        private bool startTimePSRightsFieldSpecified;

        private System.Nullable<System.DateTime> endTimePSRightsField;

        private bool endTimePSRightsFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string VehicleId
        {
            get
            {
                return this.vehicleIdField;
            }
            set
            {
                this.vehicleIdField = value;
                this.RaisePropertyChanged("VehicleId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 1)]
        public string PSRightId
        {
            get
            {
                return this.pSRightIdField;
            }
            set
            {
                this.pSRightIdField = value;
                this.RaisePropertyChanged("PSRightId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 2)]
        public System.Nullable<System.DateTime> StartTimePSRights
        {
            get
            {
                return this.startTimePSRightsField;
            }
            set
            {
                this.startTimePSRightsField = value;
                this.RaisePropertyChanged("StartTimePSRights");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StartTimePSRightsSpecified
        {
            get
            {
                return this.startTimePSRightsFieldSpecified;
            }
            set
            {
                this.startTimePSRightsFieldSpecified = value;
                this.RaisePropertyChanged("StartTimePSRightsSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 3)]
        public System.Nullable<System.DateTime> EndTimePSRights
        {
            get
            {
                return this.endTimePSRightsField;
            }
            set
            {
                this.endTimePSRightsField = value;
                this.RaisePropertyChanged("EndTimePSRights");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EndTimePSRightsSpecified
        {
            get
            {
                return this.endTimePSRightsFieldSpecified;
            }
            set
            {
                this.endTimePSRightsFieldSpecified = value;
                this.RaisePropertyChanged("EndTimePSRightsSpecified");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class RetrieveRightInfoResponseData : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string vehicleIdField;

        private System.DateTime indicatorTimeField;

        private bool indicatorTimeFieldSpecified;

        private PSRightInfoData[] pSRightInfoListField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string VehicleId
        {
            get
            {
                return this.vehicleIdField;
            }
            set
            {
                this.vehicleIdField = value;
                this.RaisePropertyChanged("VehicleId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public System.DateTime IndicatorTime
        {
            get
            {
                return this.indicatorTimeField;
            }
            set
            {
                this.indicatorTimeField = value;
                this.RaisePropertyChanged("IndicatorTime");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IndicatorTimeSpecified
        {
            get
            {
                return this.indicatorTimeFieldSpecified;
            }
            set
            {
                this.indicatorTimeFieldSpecified = value;
                this.RaisePropertyChanged("IndicatorTimeSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 2)]
        public PSRightInfoData[] PSRightInfoList
        {
            get
            {
                return this.pSRightInfoListField;
            }
            set
            {
                this.pSRightInfoListField = value;
                this.RaisePropertyChanged("PSRightInfoList");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class RetrieveRightInfoRequestData : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string vehicleIdField;

        private string pSRightIdField;

        private System.Nullable<System.DateTime> indicatorTimeField;

        private bool indicatorTimeFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string VehicleId
        {
            get
            {
                return this.vehicleIdField;
            }
            set
            {
                this.vehicleIdField = value;
                this.RaisePropertyChanged("VehicleId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 1)]
        public string PSRightId
        {
            get
            {
                return this.pSRightIdField;
            }
            set
            {
                this.pSRightIdField = value;
                this.RaisePropertyChanged("PSRightId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 2)]
        public System.Nullable<System.DateTime> IndicatorTime
        {
            get
            {
                return this.indicatorTimeField;
            }
            set
            {
                this.indicatorTimeField = value;
                this.RaisePropertyChanged("IndicatorTime");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IndicatorTimeSpecified
        {
            get
            {
                return this.indicatorTimeFieldSpecified;
            }
            set
            {
                this.indicatorTimeFieldSpecified = value;
                this.RaisePropertyChanged("IndicatorTimeSpecified");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class CheckInfoData : object, System.ComponentModel.INotifyPropertyChanged
    {

        private System.Nullable<UneceLandCodesType> countryCodeCheckField;

        private bool countryCodeCheckFieldSpecified;

        private System.DateTime checkTimeField;

        private IndicatorYNType extraInfoIndicatorField;

        private string referenceCheckOrgField;

        private System.Nullable<IndicatorYNType> checkAnswerField;

        private bool checkAnswerFieldSpecified;

        private string checkOrgCodeField;

        private string checkOrgDescField;

        private string usageIdField;

        private string areaIdField;

        private string areaDescField;

        private CheckInfoDataCheckLocation checkLocationField;

        private AddressDataResponse checkAddressField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 0)]
        public System.Nullable<UneceLandCodesType> CountryCodeCheck
        {
            get
            {
                return this.countryCodeCheckField;
            }
            set
            {
                this.countryCodeCheckField = value;
                this.RaisePropertyChanged("CountryCodeCheck");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CountryCodeCheckSpecified
        {
            get
            {
                return this.countryCodeCheckFieldSpecified;
            }
            set
            {
                this.countryCodeCheckFieldSpecified = value;
                this.RaisePropertyChanged("CountryCodeCheckSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public System.DateTime CheckTime
        {
            get
            {
                return this.checkTimeField;
            }
            set
            {
                this.checkTimeField = value;
                this.RaisePropertyChanged("CheckTime");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public IndicatorYNType ExtraInfoIndicator
        {
            get
            {
                return this.extraInfoIndicatorField;
            }
            set
            {
                this.extraInfoIndicatorField = value;
                this.RaisePropertyChanged("ExtraInfoIndicator");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 3)]
        public string ReferenceCheckOrg
        {
            get
            {
                return this.referenceCheckOrgField;
            }
            set
            {
                this.referenceCheckOrgField = value;
                this.RaisePropertyChanged("ReferenceCheckOrg");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 4)]
        public System.Nullable<IndicatorYNType> CheckAnswer
        {
            get
            {
                return this.checkAnswerField;
            }
            set
            {
                this.checkAnswerField = value;
                this.RaisePropertyChanged("CheckAnswer");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CheckAnswerSpecified
        {
            get
            {
                return this.checkAnswerFieldSpecified;
            }
            set
            {
                this.checkAnswerFieldSpecified = value;
                this.RaisePropertyChanged("CheckAnswerSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", IsNullable = true, Order = 5)]
        public string CheckOrgCode
        {
            get
            {
                return this.checkOrgCodeField;
            }
            set
            {
                this.checkOrgCodeField = value;
                this.RaisePropertyChanged("CheckOrgCode");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 6)]
        public string CheckOrgDesc
        {
            get
            {
                return this.checkOrgDescField;
            }
            set
            {
                this.checkOrgDescField = value;
                this.RaisePropertyChanged("CheckOrgDesc");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 7)]
        public string UsageId
        {
            get
            {
                return this.usageIdField;
            }
            set
            {
                this.usageIdField = value;
                this.RaisePropertyChanged("UsageId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 8)]
        public string AreaId
        {
            get
            {
                return this.areaIdField;
            }
            set
            {
                this.areaIdField = value;
                this.RaisePropertyChanged("AreaId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 9)]
        public string AreaDesc
        {
            get
            {
                return this.areaDescField;
            }
            set
            {
                this.areaDescField = value;
                this.RaisePropertyChanged("AreaDesc");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public CheckInfoDataCheckLocation CheckLocation
        {
            get
            {
                return this.checkLocationField;
            }
            set
            {
                this.checkLocationField = value;
                this.RaisePropertyChanged("CheckLocation");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public AddressDataResponse CheckAddress
        {
            get
            {
                return this.checkAddressField;
            }
            set
            {
                this.checkAddressField = value;
                this.RaisePropertyChanged("CheckAddress");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public enum IndicatorYNType
    {

        /// <remarks/>
        Y,

        /// <remarks/>
        N,

        /// <remarks/>
        y,

        /// <remarks/>
        n,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class CheckInfoDataCheckLocation : object, System.ComponentModel.INotifyPropertyChanged
    {

        private decimal latitudeField;

        private decimal longitudeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public decimal Latitude
        {
            get
            {
                return this.latitudeField;
            }
            set
            {
                this.latitudeField = value;
                this.RaisePropertyChanged("Latitude");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public decimal Longitude
        {
            get
            {
                return this.longitudeField;
            }
            set
            {
                this.longitudeField = value;
                this.RaisePropertyChanged("Longitude");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class AddressDataResponse : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string streetCodeField;

        private string streetNameField;

        private string houseNumberField;

        private string houseNumberAdditionsField;

        private string placeOfResidenceField;

        private AddressDataResponseLocation locationField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 0)]
        public string StreetCode
        {
            get
            {
                return this.streetCodeField;
            }
            set
            {
                this.streetCodeField = value;
                this.RaisePropertyChanged("StreetCode");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 1)]
        public string StreetName
        {
            get
            {
                return this.streetNameField;
            }
            set
            {
                this.streetNameField = value;
                this.RaisePropertyChanged("StreetName");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 2)]
        public string HouseNumber
        {
            get
            {
                return this.houseNumberField;
            }
            set
            {
                this.houseNumberField = value;
                this.RaisePropertyChanged("HouseNumber");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 3)]
        public string HouseNumberAdditions
        {
            get
            {
                return this.houseNumberAdditionsField;
            }
            set
            {
                this.houseNumberAdditionsField = value;
                this.RaisePropertyChanged("HouseNumberAdditions");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string PlaceOfResidence
        {
            get
            {
                return this.placeOfResidenceField;
            }
            set
            {
                this.placeOfResidenceField = value;
                this.RaisePropertyChanged("PlaceOfResidence");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public AddressDataResponseLocation Location
        {
            get
            {
                return this.locationField;
            }
            set
            {
                this.locationField = value;
                this.RaisePropertyChanged("Location");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class AddressDataResponseLocation : object, System.ComponentModel.INotifyPropertyChanged
    {

        private decimal latitudeField;

        private decimal longitudeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public decimal Latitude
        {
            get
            {
                return this.latitudeField;
            }
            set
            {
                this.latitudeField = value;
                this.RaisePropertyChanged("Latitude");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public decimal Longitude
        {
            get
            {
                return this.longitudeField;
            }
            set
            {
                this.longitudeField = value;
                this.RaisePropertyChanged("Longitude");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class RetrieveCheckInfoResponseData : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string vehicleIdField;

        private string areaManagerIdField;

        private string areaManagerDescField;

        private CheckInfoData[] checkInfoListField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string VehicleId
        {
            get
            {
                return this.vehicleIdField;
            }
            set
            {
                this.vehicleIdField = value;
                this.RaisePropertyChanged("VehicleId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 1)]
        public string AreaManagerId
        {
            get
            {
                return this.areaManagerIdField;
            }
            set
            {
                this.areaManagerIdField = value;
                this.RaisePropertyChanged("AreaManagerId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 2)]
        public string AreaManagerDesc
        {
            get
            {
                return this.areaManagerDescField;
            }
            set
            {
                this.areaManagerDescField = value;
                this.RaisePropertyChanged("AreaManagerDesc");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 3)]
        public CheckInfoData[] CheckInfoList
        {
            get
            {
                return this.checkInfoListField;
            }
            set
            {
                this.checkInfoListField = value;
                this.RaisePropertyChanged("CheckInfoList");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class RetrieveCheckInfoRequestData : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string vehicleIdField;

        private System.DateTime indicatorTimeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string VehicleId
        {
            get
            {
                return this.vehicleIdField;
            }
            set
            {
                this.vehicleIdField = value;
                this.RaisePropertyChanged("VehicleId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public System.DateTime IndicatorTime
        {
            get
            {
                return this.indicatorTimeField;
            }
            set
            {
                this.indicatorTimeField = value;
                this.RaisePropertyChanged("IndicatorTime");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class RetrieveAreasByLocationResponseData : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string areaManagerIdField;

        private AreaData[] areaTableField;

        private AddressDataResponse locationAddressField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", IsNullable = true, Order = 0)]
        public string AreaManagerId
        {
            get
            {
                return this.areaManagerIdField;
            }
            set
            {
                this.areaManagerIdField = value;
                this.RaisePropertyChanged("AreaManagerId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 1)]
        public AreaData[] AreaTable
        {
            get
            {
                return this.areaTableField;
            }
            set
            {
                this.areaTableField = value;
                this.RaisePropertyChanged("AreaTable");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 2)]
        public AddressDataResponse LocationAddress
        {
            get
            {
                return this.locationAddressField;
            }
            set
            {
                this.locationAddressField = value;
                this.RaisePropertyChanged("LocationAddress");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class AreaData : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string areaIdField;

        private string areaDescField;

        private string startDateAreaField;

        private string endDateAreaField;

        private string usageIdField;

        private string usageDescField;

        private string gracePeriodBeforeField;

        private string gracePeriodAfterField;

        private System.Nullable<decimal> priceOneHourParkingField;

        private bool priceOneHourParkingFieldSpecified;

        private AreaRegulationData[] areaRegulationTableField;

        private string geometryField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string AreaId
        {
            get
            {
                return this.areaIdField;
            }
            set
            {
                this.areaIdField = value;
                this.RaisePropertyChanged("AreaId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 1)]
        public string AreaDesc
        {
            get
            {
                return this.areaDescField;
            }
            set
            {
                this.areaDescField = value;
                this.RaisePropertyChanged("AreaDesc");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", IsNullable = true, Order = 2)]
        public string StartDateArea
        {
            get
            {
                return this.startDateAreaField;
            }
            set
            {
                this.startDateAreaField = value;
                this.RaisePropertyChanged("StartDateArea");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", IsNullable = true, Order = 3)]
        public string EndDateArea
        {
            get
            {
                return this.endDateAreaField;
            }
            set
            {
                this.endDateAreaField = value;
                this.RaisePropertyChanged("EndDateArea");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 4)]
        public string UsageId
        {
            get
            {
                return this.usageIdField;
            }
            set
            {
                this.usageIdField = value;
                this.RaisePropertyChanged("UsageId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 5)]
        public string UsageDesc
        {
            get
            {
                return this.usageDescField;
            }
            set
            {
                this.usageDescField = value;
                this.RaisePropertyChanged("UsageDesc");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", IsNullable = true, Order = 6)]
        public string GracePeriodBefore
        {
            get
            {
                return this.gracePeriodBeforeField;
            }
            set
            {
                this.gracePeriodBeforeField = value;
                this.RaisePropertyChanged("GracePeriodBefore");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", IsNullable = true, Order = 7)]
        public string GracePeriodAfter
        {
            get
            {
                return this.gracePeriodAfterField;
            }
            set
            {
                this.gracePeriodAfterField = value;
                this.RaisePropertyChanged("GracePeriodAfter");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 8)]
        public System.Nullable<decimal> PriceOneHourParking
        {
            get
            {
                return this.priceOneHourParkingField;
            }
            set
            {
                this.priceOneHourParkingField = value;
                this.RaisePropertyChanged("PriceOneHourParking");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PriceOneHourParkingSpecified
        {
            get
            {
                return this.priceOneHourParkingFieldSpecified;
            }
            set
            {
                this.priceOneHourParkingFieldSpecified = value;
                this.RaisePropertyChanged("PriceOneHourParkingSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 9)]
        public AreaRegulationData[] AreaRegulationTable
        {
            get
            {
                return this.areaRegulationTableField;
            }
            set
            {
                this.areaRegulationTableField = value;
                this.RaisePropertyChanged("AreaRegulationTable");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 10)]
        public string Geometry
        {
            get
            {
                return this.geometryField;
            }
            set
            {
                this.geometryField = value;
                this.RaisePropertyChanged("Geometry");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class AreaRegulationData : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string regulationIdAreaField;

        private System.Nullable<System.DateTime> startDateAreaRegulationField;

        private bool startDateAreaRegulationFieldSpecified;

        private System.Nullable<System.DateTime> endDateAreaRegulationField;

        private bool endDateAreaRegulationFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string RegulationIdArea
        {
            get
            {
                return this.regulationIdAreaField;
            }
            set
            {
                this.regulationIdAreaField = value;
                this.RaisePropertyChanged("RegulationIdArea");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 1)]
        public System.Nullable<System.DateTime> StartDateAreaRegulation
        {
            get
            {
                return this.startDateAreaRegulationField;
            }
            set
            {
                this.startDateAreaRegulationField = value;
                this.RaisePropertyChanged("StartDateAreaRegulation");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StartDateAreaRegulationSpecified
        {
            get
            {
                return this.startDateAreaRegulationFieldSpecified;
            }
            set
            {
                this.startDateAreaRegulationFieldSpecified = value;
                this.RaisePropertyChanged("StartDateAreaRegulationSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 2)]
        public System.Nullable<System.DateTime> EndDateAreaRegulation
        {
            get
            {
                return this.endDateAreaRegulationField;
            }
            set
            {
                this.endDateAreaRegulationField = value;
                this.RaisePropertyChanged("EndDateAreaRegulation");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EndDateAreaRegulationSpecified
        {
            get
            {
                return this.endDateAreaRegulationFieldSpecified;
            }
            set
            {
                this.endDateAreaRegulationFieldSpecified = value;
                this.RaisePropertyChanged("EndDateAreaRegulationSpecified");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class RetrieveAreasByLocationRequestData : object, System.ComponentModel.INotifyPropertyChanged
    {

        private RetrieveAreasByLocationRequestDataAreaLocation areaLocationField;

        private AddressDataRequest requestAddressField;

        private string sellingPointIdField;

        private string areaManagerIdField;

        private string areaIdField;

        private System.Nullable<System.DateTime> referenceTimeField;

        private bool referenceTimeFieldSpecified;

        private string usageIdField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public RetrieveAreasByLocationRequestDataAreaLocation AreaLocation
        {
            get
            {
                return this.areaLocationField;
            }
            set
            {
                this.areaLocationField = value;
                this.RaisePropertyChanged("AreaLocation");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public AddressDataRequest RequestAddress
        {
            get
            {
                return this.requestAddressField;
            }
            set
            {
                this.requestAddressField = value;
                this.RaisePropertyChanged("RequestAddress");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", IsNullable = true, Order = 2)]
        public string SellingPointId
        {
            get
            {
                return this.sellingPointIdField;
            }
            set
            {
                this.sellingPointIdField = value;
                this.RaisePropertyChanged("SellingPointId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 3)]
        public string AreaManagerId
        {
            get
            {
                return this.areaManagerIdField;
            }
            set
            {
                this.areaManagerIdField = value;
                this.RaisePropertyChanged("AreaManagerId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 4)]
        public string AreaId
        {
            get
            {
                return this.areaIdField;
            }
            set
            {
                this.areaIdField = value;
                this.RaisePropertyChanged("AreaId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 5)]
        public System.Nullable<System.DateTime> ReferenceTime
        {
            get
            {
                return this.referenceTimeField;
            }
            set
            {
                this.referenceTimeField = value;
                this.RaisePropertyChanged("ReferenceTime");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReferenceTimeSpecified
        {
            get
            {
                return this.referenceTimeFieldSpecified;
            }
            set
            {
                this.referenceTimeFieldSpecified = value;
                this.RaisePropertyChanged("ReferenceTimeSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 6)]
        public string UsageId
        {
            get
            {
                return this.usageIdField;
            }
            set
            {
                this.usageIdField = value;
                this.RaisePropertyChanged("UsageId");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class RetrieveAreasByLocationRequestDataAreaLocation : object, System.ComponentModel.INotifyPropertyChanged
    {

        private decimal latitudeField;

        private decimal longitudeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public decimal Latitude
        {
            get
            {
                return this.latitudeField;
            }
            set
            {
                this.latitudeField = value;
                this.RaisePropertyChanged("Latitude");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public decimal Longitude
        {
            get
            {
                return this.longitudeField;
            }
            set
            {
                this.longitudeField = value;
                this.RaisePropertyChanged("Longitude");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class AddressDataRequest : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string streetCodeField;

        private string streetNameField;

        private string houseNumberField;

        private string houseNumberAdditionsField;

        private string placeOfResidenceField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 0)]
        public string StreetCode
        {
            get
            {
                return this.streetCodeField;
            }
            set
            {
                this.streetCodeField = value;
                this.RaisePropertyChanged("StreetCode");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 1)]
        public string StreetName
        {
            get
            {
                return this.streetNameField;
            }
            set
            {
                this.streetNameField = value;
                this.RaisePropertyChanged("StreetName");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 2)]
        public string HouseNumber
        {
            get
            {
                return this.houseNumberField;
            }
            set
            {
                this.houseNumberField = value;
                this.RaisePropertyChanged("HouseNumber");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 3)]
        public string HouseNumberAdditions
        {
            get
            {
                return this.houseNumberAdditionsField;
            }
            set
            {
                this.houseNumberAdditionsField = value;
                this.RaisePropertyChanged("HouseNumberAdditions");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string PlaceOfResidence
        {
            get
            {
                return this.placeOfResidenceField;
            }
            set
            {
                this.placeOfResidenceField = value;
                this.RaisePropertyChanged("PlaceOfResidence");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class SpecialDay : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string specialDayNameField;

        private string specialDayDateField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string SpecialDayName
        {
            get
            {
                return this.specialDayNameField;
            }
            set
            {
                this.specialDayNameField = value;
                this.RaisePropertyChanged("SpecialDayName");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 1)]
        public string SpecialDayDate
        {
            get
            {
                return this.specialDayDateField;
            }
            set
            {
                this.specialDayDateField = value;
                this.RaisePropertyChanged("SpecialDayDate");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class FarePartData : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string startDateFarePartField;

        private string endDateFarePartField;

        private string startDurationFarePartField;

        private string endDurationFarePartField;

        private decimal totalAmountPartsField;

        private decimal amountFarePartField;

        private string stepSizeFarePartField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 0)]
        public string StartDateFarePart
        {
            get
            {
                return this.startDateFarePartField;
            }
            set
            {
                this.startDateFarePartField = value;
                this.RaisePropertyChanged("StartDateFarePart");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", IsNullable = true, Order = 1)]
        public string EndDateFarePart
        {
            get
            {
                return this.endDateFarePartField;
            }
            set
            {
                this.endDateFarePartField = value;
                this.RaisePropertyChanged("EndDateFarePart");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 2)]
        public string StartDurationFarePart
        {
            get
            {
                return this.startDurationFarePartField;
            }
            set
            {
                this.startDurationFarePartField = value;
                this.RaisePropertyChanged("StartDurationFarePart");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 3)]
        public string EndDurationFarePart
        {
            get
            {
                return this.endDurationFarePartField;
            }
            set
            {
                this.endDurationFarePartField = value;
                this.RaisePropertyChanged("EndDurationFarePart");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public decimal TotalAmountParts
        {
            get
            {
                return this.totalAmountPartsField;
            }
            set
            {
                this.totalAmountPartsField = value;
                this.RaisePropertyChanged("TotalAmountParts");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public decimal AmountFarePart
        {
            get
            {
                return this.amountFarePartField;
            }
            set
            {
                this.amountFarePartField = value;
                this.RaisePropertyChanged("AmountFarePart");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 6)]
        public string StepSizeFarePart
        {
            get
            {
                return this.stepSizeFarePartField;
            }
            set
            {
                this.stepSizeFarePartField = value;
                this.RaisePropertyChanged("StepSizeFarePart");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class FareData : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string fareCalculationCodeField;

        private string fareCalculationDescField;

        private string startDateFareField;

        private string endDateFareField;

        private System.Nullable<decimal> vATPercentageField;

        private bool vATPercentageFieldSpecified;

        private FarePartData[] farePartTableField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string FareCalculationCode
        {
            get
            {
                return this.fareCalculationCodeField;
            }
            set
            {
                this.fareCalculationCodeField = value;
                this.RaisePropertyChanged("FareCalculationCode");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 1)]
        public string FareCalculationDesc
        {
            get
            {
                return this.fareCalculationDescField;
            }
            set
            {
                this.fareCalculationDescField = value;
                this.RaisePropertyChanged("FareCalculationDesc");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", IsNullable = true, Order = 2)]
        public string StartDateFare
        {
            get
            {
                return this.startDateFareField;
            }
            set
            {
                this.startDateFareField = value;
                this.RaisePropertyChanged("StartDateFare");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", IsNullable = true, Order = 3)]
        public string EndDateFare
        {
            get
            {
                return this.endDateFareField;
            }
            set
            {
                this.endDateFareField = value;
                this.RaisePropertyChanged("EndDateFare");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 4)]
        public System.Nullable<decimal> VATPercentage
        {
            get
            {
                return this.vATPercentageField;
            }
            set
            {
                this.vATPercentageField = value;
                this.RaisePropertyChanged("VATPercentage");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool VATPercentageSpecified
        {
            get
            {
                return this.vATPercentageFieldSpecified;
            }
            set
            {
                this.vATPercentageFieldSpecified = value;
                this.RaisePropertyChanged("VATPercentageSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true, Order = 5)]
        public FarePartData[] FarePartTable
        {
            get
            {
                return this.farePartTableField;
            }
            set
            {
                this.farePartTableField = value;
                this.RaisePropertyChanged("FarePartTable");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class TimeFrameData : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string dayTimeFrameField;

        private System.Nullable<System.DateTime> startDateTimeFrameField;

        private bool startDateTimeFrameFieldSpecified;

        private string startTimeTimeFrameField;

        private System.Nullable<System.DateTime> endDateTimeFrameField;

        private bool endDateTimeFrameFieldSpecified;

        private string endTimeTimeFrameField;

        private IndicatorYNType claimRightPossibleField;

        private string maxDurationRightField;

        private string minParkingInterruptionField;

        private string fareTimeFrameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string DayTimeFrame
        {
            get
            {
                return this.dayTimeFrameField;
            }
            set
            {
                this.dayTimeFrameField = value;
                this.RaisePropertyChanged("DayTimeFrame");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 1)]
        public System.Nullable<System.DateTime> StartDateTimeFrame
        {
            get
            {
                return this.startDateTimeFrameField;
            }
            set
            {
                this.startDateTimeFrameField = value;
                this.RaisePropertyChanged("StartDateTimeFrame");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StartDateTimeFrameSpecified
        {
            get
            {
                return this.startDateTimeFrameFieldSpecified;
            }
            set
            {
                this.startDateTimeFrameFieldSpecified = value;
                this.RaisePropertyChanged("StartDateTimeFrameSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 2)]
        public string StartTimeTimeFrame
        {
            get
            {
                return this.startTimeTimeFrameField;
            }
            set
            {
                this.startTimeTimeFrameField = value;
                this.RaisePropertyChanged("StartTimeTimeFrame");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 3)]
        public System.Nullable<System.DateTime> EndDateTimeFrame
        {
            get
            {
                return this.endDateTimeFrameField;
            }
            set
            {
                this.endDateTimeFrameField = value;
                this.RaisePropertyChanged("EndDateTimeFrame");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EndDateTimeFrameSpecified
        {
            get
            {
                return this.endDateTimeFrameFieldSpecified;
            }
            set
            {
                this.endDateTimeFrameFieldSpecified = value;
                this.RaisePropertyChanged("EndDateTimeFrameSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 4)]
        public string EndTimeTimeFrame
        {
            get
            {
                return this.endTimeTimeFrameField;
            }
            set
            {
                this.endTimeTimeFrameField = value;
                this.RaisePropertyChanged("EndTimeTimeFrame");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public IndicatorYNType ClaimRightPossible
        {
            get
            {
                return this.claimRightPossibleField;
            }
            set
            {
                this.claimRightPossibleField = value;
                this.RaisePropertyChanged("ClaimRightPossible");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", IsNullable = true, Order = 6)]
        public string MaxDurationRight
        {
            get
            {
                return this.maxDurationRightField;
            }
            set
            {
                this.maxDurationRightField = value;
                this.RaisePropertyChanged("MaxDurationRight");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", IsNullable = true, Order = 7)]
        public string MinParkingInterruption
        {
            get
            {
                return this.minParkingInterruptionField;
            }
            set
            {
                this.minParkingInterruptionField = value;
                this.RaisePropertyChanged("MinParkingInterruption");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 8)]
        public string FareTimeFrame
        {
            get
            {
                return this.fareTimeFrameField;
            }
            set
            {
                this.fareTimeFrameField = value;
                this.RaisePropertyChanged("FareTimeFrame");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class RegulationData : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string regulationIdField;

        private string regulationDescField;

        private System.Nullable<TypeOfRegulationType> regulationTypeField;

        private bool regulationTypeFieldSpecified;

        private string startDateRegulationField;

        private string endDateRegulationField;

        private TimeFrameData[] timeFrameTableField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string RegulationId
        {
            get
            {
                return this.regulationIdField;
            }
            set
            {
                this.regulationIdField = value;
                this.RaisePropertyChanged("RegulationId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 1)]
        public string RegulationDesc
        {
            get
            {
                return this.regulationDescField;
            }
            set
            {
                this.regulationDescField = value;
                this.RaisePropertyChanged("RegulationDesc");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 2)]
        public System.Nullable<TypeOfRegulationType> RegulationType
        {
            get
            {
                return this.regulationTypeField;
            }
            set
            {
                this.regulationTypeField = value;
                this.RaisePropertyChanged("RegulationType");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RegulationTypeSpecified
        {
            get
            {
                return this.regulationTypeFieldSpecified;
            }
            set
            {
                this.regulationTypeFieldSpecified = value;
                this.RaisePropertyChanged("RegulationTypeSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", IsNullable = true, Order = 3)]
        public string StartDateRegulation
        {
            get
            {
                return this.startDateRegulationField;
            }
            set
            {
                this.startDateRegulationField = value;
                this.RaisePropertyChanged("StartDateRegulation");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", IsNullable = true, Order = 4)]
        public string EndDateRegulation
        {
            get
            {
                return this.endDateRegulationField;
            }
            set
            {
                this.endDateRegulationField = value;
                this.RaisePropertyChanged("EndDateRegulation");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true, Order = 5)]
        public TimeFrameData[] TimeFrameTable
        {
            get
            {
                return this.timeFrameTableField;
            }
            set
            {
                this.timeFrameTableField = value;
                this.RaisePropertyChanged("TimeFrameTable");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public enum TypeOfRegulationType
    {

        /// <remarks/>
        A,

        /// <remarks/>
        B,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class RetrieveAreaRegulationFareInfoResponseData : object, System.ComponentModel.INotifyPropertyChanged
    {

        private AreaData[] areaTableField;

        private RegulationData[] regulationTableField;

        private FareData[] fareTableField;

        private SpecialDay[] specialDaysTableField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 0)]
        public AreaData[] AreaTable
        {
            get
            {
                return this.areaTableField;
            }
            set
            {
                this.areaTableField = value;
                this.RaisePropertyChanged("AreaTable");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 1)]
        public RegulationData[] RegulationTable
        {
            get
            {
                return this.regulationTableField;
            }
            set
            {
                this.regulationTableField = value;
                this.RaisePropertyChanged("RegulationTable");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 2)]
        public FareData[] FareTable
        {
            get
            {
                return this.fareTableField;
            }
            set
            {
                this.fareTableField = value;
                this.RaisePropertyChanged("FareTable");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 3)]
        public SpecialDay[] SpecialDaysTable
        {
            get
            {
                return this.specialDaysTableField;
            }
            set
            {
                this.specialDaysTableField = value;
                this.RaisePropertyChanged("SpecialDaysTable");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class RetrieveAreaRegulationFareInfoRequestData : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string areaManagerIdField;

        private string areaIdField;

        private System.Nullable<System.DateTime> checkTimeField;

        private bool checkTimeFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 0)]
        public string AreaManagerId
        {
            get
            {
                return this.areaManagerIdField;
            }
            set
            {
                this.areaManagerIdField = value;
                this.RaisePropertyChanged("AreaManagerId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 1)]
        public string AreaId
        {
            get
            {
                return this.areaIdField;
            }
            set
            {
                this.areaIdField = value;
                this.RaisePropertyChanged("AreaId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 2)]
        public System.Nullable<System.DateTime> CheckTime
        {
            get
            {
                return this.checkTimeField;
            }
            set
            {
                this.checkTimeField = value;
                this.RaisePropertyChanged("CheckTime");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CheckTimeSpecified
        {
            get
            {
                return this.checkTimeFieldSpecified;
            }
            set
            {
                this.checkTimeFieldSpecified = value;
                this.RaisePropertyChanged("CheckTimeSpecified");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class PSRightEnrollResponseData : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string pSRightIdField;

        private string areaManagerIdField;

        private string areaIdField;

        private string sellingPointIdField;

        private System.Nullable<System.DateTime> endTimePSRightAdjustedField;

        private bool endTimePSRightAdjustedFieldSpecified;

        private System.Nullable<decimal> amountPSRightCalculatedField;

        private bool amountPSRightCalculatedFieldSpecified;

        private System.Nullable<decimal> vATPSRightCalculatedField;

        private bool vATPSRightCalculatedFieldSpecified;

        private SpecifCalcAmountData[] specifCalcAmountListField;

        private PSRightRemarkData[] pSRightRemarkListField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 0)]
        public string PSRightId
        {
            get
            {
                return this.pSRightIdField;
            }
            set
            {
                this.pSRightIdField = value;
                this.RaisePropertyChanged("PSRightId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", IsNullable = true, Order = 1)]
        public string AreaManagerId
        {
            get
            {
                return this.areaManagerIdField;
            }
            set
            {
                this.areaManagerIdField = value;
                this.RaisePropertyChanged("AreaManagerId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 2)]
        public string AreaId
        {
            get
            {
                return this.areaIdField;
            }
            set
            {
                this.areaIdField = value;
                this.RaisePropertyChanged("AreaId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", IsNullable = true, Order = 3)]
        public string SellingPointId
        {
            get
            {
                return this.sellingPointIdField;
            }
            set
            {
                this.sellingPointIdField = value;
                this.RaisePropertyChanged("SellingPointId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 4)]
        public System.Nullable<System.DateTime> EndTimePSRightAdjusted
        {
            get
            {
                return this.endTimePSRightAdjustedField;
            }
            set
            {
                this.endTimePSRightAdjustedField = value;
                this.RaisePropertyChanged("EndTimePSRightAdjusted");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EndTimePSRightAdjustedSpecified
        {
            get
            {
                return this.endTimePSRightAdjustedFieldSpecified;
            }
            set
            {
                this.endTimePSRightAdjustedFieldSpecified = value;
                this.RaisePropertyChanged("EndTimePSRightAdjustedSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 5)]
        public System.Nullable<decimal> AmountPSRightCalculated
        {
            get
            {
                return this.amountPSRightCalculatedField;
            }
            set
            {
                this.amountPSRightCalculatedField = value;
                this.RaisePropertyChanged("AmountPSRightCalculated");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AmountPSRightCalculatedSpecified
        {
            get
            {
                return this.amountPSRightCalculatedFieldSpecified;
            }
            set
            {
                this.amountPSRightCalculatedFieldSpecified = value;
                this.RaisePropertyChanged("AmountPSRightCalculatedSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 6)]
        public System.Nullable<decimal> VATPSRightCalculated
        {
            get
            {
                return this.vATPSRightCalculatedField;
            }
            set
            {
                this.vATPSRightCalculatedField = value;
                this.RaisePropertyChanged("VATPSRightCalculated");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool VATPSRightCalculatedSpecified
        {
            get
            {
                return this.vATPSRightCalculatedFieldSpecified;
            }
            set
            {
                this.vATPSRightCalculatedFieldSpecified = value;
                this.RaisePropertyChanged("VATPSRightCalculatedSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 7)]
        public SpecifCalcAmountData[] SpecifCalcAmountList
        {
            get
            {
                return this.specifCalcAmountListField;
            }
            set
            {
                this.specifCalcAmountListField = value;
                this.RaisePropertyChanged("SpecifCalcAmountList");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 8)]
        public PSRightRemarkData[] PSRightRemarkList
        {
            get
            {
                return this.pSRightRemarkListField;
            }
            set
            {
                this.pSRightRemarkListField = value;
                this.RaisePropertyChanged("PSRightRemarkList");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class PSRightEnrollRequestData : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string vehicleIdField;

        private System.Nullable<UneceLandCodesType> countryCodeVehicleField;

        private bool countryCodeVehicleFieldSpecified;

        private string areaManagerIdField;

        private string areaIdField;

        private PSRightEnrollRequestDataLocationPSRight locationPSRightField;

        private string sellingPointIdField;

        private string usageIdField;

        private System.DateTime startTimePSrightField;

        private System.Nullable<System.DateTime> endTimePSrightField;

        private bool endTimePSrightFieldSpecified;

        private PSRightWindowData[] pSRightWindowListField;

        private System.Nullable<decimal> amountPSrightField;

        private bool amountPSrightFieldSpecified;

        private System.Nullable<decimal> vATPSrightField;

        private bool vATPSrightFieldSpecified;

        private string referencePSRightField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string VehicleId
        {
            get
            {
                return this.vehicleIdField;
            }
            set
            {
                this.vehicleIdField = value;
                this.RaisePropertyChanged("VehicleId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 1)]
        public System.Nullable<UneceLandCodesType> CountryCodeVehicle
        {
            get
            {
                return this.countryCodeVehicleField;
            }
            set
            {
                this.countryCodeVehicleField = value;
                this.RaisePropertyChanged("CountryCodeVehicle");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CountryCodeVehicleSpecified
        {
            get
            {
                return this.countryCodeVehicleFieldSpecified;
            }
            set
            {
                this.countryCodeVehicleFieldSpecified = value;
                this.RaisePropertyChanged("CountryCodeVehicleSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", IsNullable = true, Order = 2)]
        public string AreaManagerId
        {
            get
            {
                return this.areaManagerIdField;
            }
            set
            {
                this.areaManagerIdField = value;
                this.RaisePropertyChanged("AreaManagerId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 3)]
        public string AreaId
        {
            get
            {
                return this.areaIdField;
            }
            set
            {
                this.areaIdField = value;
                this.RaisePropertyChanged("AreaId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public PSRightEnrollRequestDataLocationPSRight LocationPSRight
        {
            get
            {
                return this.locationPSRightField;
            }
            set
            {
                this.locationPSRightField = value;
                this.RaisePropertyChanged("LocationPSRight");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", IsNullable = true, Order = 5)]
        public string SellingPointId
        {
            get
            {
                return this.sellingPointIdField;
            }
            set
            {
                this.sellingPointIdField = value;
                this.RaisePropertyChanged("SellingPointId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 6)]
        public string UsageId
        {
            get
            {
                return this.usageIdField;
            }
            set
            {
                this.usageIdField = value;
                this.RaisePropertyChanged("UsageId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public System.DateTime StartTimePSright
        {
            get
            {
                return this.startTimePSrightField;
            }
            set
            {
                this.startTimePSrightField = value;
                this.RaisePropertyChanged("StartTimePSright");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 8)]
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

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 9)]
        public PSRightWindowData[] PSRightWindowList
        {
            get
            {
                return this.pSRightWindowListField;
            }
            set
            {
                this.pSRightWindowListField = value;
                this.RaisePropertyChanged("PSRightWindowList");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 10)]
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
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 11)]
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

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 12)]
        public string ReferencePSRight
        {
            get
            {
                return this.referencePSRightField;
            }
            set
            {
                this.referencePSRightField = value;
                this.RaisePropertyChanged("ReferencePSRight");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class PSRightEnrollRequestDataLocationPSRight : object, System.ComponentModel.INotifyPropertyChanged
    {

        private decimal latitudeField;

        private decimal longitudeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public decimal Latitude
        {
            get
            {
                return this.latitudeField;
            }
            set
            {
                this.latitudeField = value;
                this.RaisePropertyChanged("Latitude");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public decimal Longitude
        {
            get
            {
                return this.longitudeField;
            }
            set
            {
                this.longitudeField = value;
                this.RaisePropertyChanged("Longitude");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class InformationalMessageType : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string errorCodeField;

        private string errorDescField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", IsNullable = true, Order = 0)]
        public string ErrorCode
        {
            get
            {
                return this.errorCodeField;
            }
            set
            {
                this.errorCodeField = value;
                this.RaisePropertyChanged("ErrorCode");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 1)]
        public string ErrorDesc
        {
            get
            {
                return this.errorDescField;
            }
            set
            {
                this.errorDescField = value;
                this.RaisePropertyChanged("ErrorDesc");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class PSRightCheckPSRightData : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string pSRightIdField;

        private string areaIdField;

        private string areaDescField;

        private System.DateTime startTimePSRightField;

        private System.Nullable<System.DateTime> endTimePSRightField;

        private bool endTimePSRightFieldSpecified;

        private System.Nullable<System.DateTime> endTimePSRightAdjustedField;

        private bool endTimePSRightAdjustedFieldSpecified;

        private PSRightWindowData[] pSRightWindowListField;

        private string referencePSRightField;

        private string sellingPointIdField;

        private string sellingPointDescField;

        private string usageIdField;

        private string usageDescField;

        private string regulationDescField;

        private System.Nullable<decimal> amountRatePartField;

        private bool amountRatePartFieldSpecified;

        private string stepSizeFarePartField;

        private string gracePeriodBeforeField;

        private string gracePeriodAfterField;

        private InformationalMessageType informationalMessageField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 0)]
        public string PSRightId
        {
            get
            {
                return this.pSRightIdField;
            }
            set
            {
                this.pSRightIdField = value;
                this.RaisePropertyChanged("PSRightId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string AreaId
        {
            get
            {
                return this.areaIdField;
            }
            set
            {
                this.areaIdField = value;
                this.RaisePropertyChanged("AreaId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string AreaDesc
        {
            get
            {
                return this.areaDescField;
            }
            set
            {
                this.areaDescField = value;
                this.RaisePropertyChanged("AreaDesc");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public System.DateTime StartTimePSRight
        {
            get
            {
                return this.startTimePSRightField;
            }
            set
            {
                this.startTimePSRightField = value;
                this.RaisePropertyChanged("StartTimePSRight");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 4)]
        public System.Nullable<System.DateTime> EndTimePSRight
        {
            get
            {
                return this.endTimePSRightField;
            }
            set
            {
                this.endTimePSRightField = value;
                this.RaisePropertyChanged("EndTimePSRight");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EndTimePSRightSpecified
        {
            get
            {
                return this.endTimePSRightFieldSpecified;
            }
            set
            {
                this.endTimePSRightFieldSpecified = value;
                this.RaisePropertyChanged("EndTimePSRightSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 5)]
        public System.Nullable<System.DateTime> EndTimePSRightAdjusted
        {
            get
            {
                return this.endTimePSRightAdjustedField;
            }
            set
            {
                this.endTimePSRightAdjustedField = value;
                this.RaisePropertyChanged("EndTimePSRightAdjusted");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EndTimePSRightAdjustedSpecified
        {
            get
            {
                return this.endTimePSRightAdjustedFieldSpecified;
            }
            set
            {
                this.endTimePSRightAdjustedFieldSpecified = value;
                this.RaisePropertyChanged("EndTimePSRightAdjustedSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 6)]
        public PSRightWindowData[] PSRightWindowList
        {
            get
            {
                return this.pSRightWindowListField;
            }
            set
            {
                this.pSRightWindowListField = value;
                this.RaisePropertyChanged("PSRightWindowList");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 7)]
        public string ReferencePSRight
        {
            get
            {
                return this.referencePSRightField;
            }
            set
            {
                this.referencePSRightField = value;
                this.RaisePropertyChanged("ReferencePSRight");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", IsNullable = true, Order = 8)]
        public string SellingPointId
        {
            get
            {
                return this.sellingPointIdField;
            }
            set
            {
                this.sellingPointIdField = value;
                this.RaisePropertyChanged("SellingPointId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 9)]
        public string SellingPointDesc
        {
            get
            {
                return this.sellingPointDescField;
            }
            set
            {
                this.sellingPointDescField = value;
                this.RaisePropertyChanged("SellingPointDesc");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string UsageId
        {
            get
            {
                return this.usageIdField;
            }
            set
            {
                this.usageIdField = value;
                this.RaisePropertyChanged("UsageId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 11)]
        public string UsageDesc
        {
            get
            {
                return this.usageDescField;
            }
            set
            {
                this.usageDescField = value;
                this.RaisePropertyChanged("UsageDesc");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 12)]
        public string RegulationDesc
        {
            get
            {
                return this.regulationDescField;
            }
            set
            {
                this.regulationDescField = value;
                this.RaisePropertyChanged("RegulationDesc");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 13)]
        public System.Nullable<decimal> AmountRatePart
        {
            get
            {
                return this.amountRatePartField;
            }
            set
            {
                this.amountRatePartField = value;
                this.RaisePropertyChanged("AmountRatePart");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AmountRatePartSpecified
        {
            get
            {
                return this.amountRatePartFieldSpecified;
            }
            set
            {
                this.amountRatePartFieldSpecified = value;
                this.RaisePropertyChanged("AmountRatePartSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", IsNullable = true, Order = 14)]
        public string StepSizeFarePart
        {
            get
            {
                return this.stepSizeFarePartField;
            }
            set
            {
                this.stepSizeFarePartField = value;
                this.RaisePropertyChanged("StepSizeFarePart");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", IsNullable = true, Order = 15)]
        public string GracePeriodBefore
        {
            get
            {
                return this.gracePeriodBeforeField;
            }
            set
            {
                this.gracePeriodBeforeField = value;
                this.RaisePropertyChanged("GracePeriodBefore");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", IsNullable = true, Order = 16)]
        public string GracePeriodAfter
        {
            get
            {
                return this.gracePeriodAfterField;
            }
            set
            {
                this.gracePeriodAfterField = value;
                this.RaisePropertyChanged("GracePeriodAfter");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 17)]
        public InformationalMessageType InformationalMessage
        {
            get
            {
                return this.informationalMessageField;
            }
            set
            {
                this.informationalMessageField = value;
                this.RaisePropertyChanged("InformationalMessage");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class PSRightCheckResponseData : object, System.ComponentModel.INotifyPropertyChanged
    {

        private IndicatorYNType checkAnswerField;

        private string areaManagerIdField;

        private AddressDataResponse checkAddressField;

        private AreaData[] areaTableField;

        private PSRightCheckPSRightData[] pSRightCheckPSRightListField;

        private InformationalMessageType informationalMessageField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public IndicatorYNType CheckAnswer
        {
            get
            {
                return this.checkAnswerField;
            }
            set
            {
                this.checkAnswerField = value;
                this.RaisePropertyChanged("CheckAnswer");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", IsNullable = true, Order = 1)]
        public string AreaManagerId
        {
            get
            {
                return this.areaManagerIdField;
            }
            set
            {
                this.areaManagerIdField = value;
                this.RaisePropertyChanged("AreaManagerId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public AddressDataResponse CheckAddress
        {
            get
            {
                return this.checkAddressField;
            }
            set
            {
                this.checkAddressField = value;
                this.RaisePropertyChanged("CheckAddress");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 3)]
        public AreaData[] AreaTable
        {
            get
            {
                return this.areaTableField;
            }
            set
            {
                this.areaTableField = value;
                this.RaisePropertyChanged("AreaTable");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 4)]
        public PSRightCheckPSRightData[] PSRightCheckPSRightList
        {
            get
            {
                return this.pSRightCheckPSRightListField;
            }
            set
            {
                this.pSRightCheckPSRightListField = value;
                this.RaisePropertyChanged("PSRightCheckPSRightList");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public InformationalMessageType InformationalMessage
        {
            get
            {
                return this.informationalMessageField;
            }
            set
            {
                this.informationalMessageField = value;
                this.RaisePropertyChanged("InformationalMessage");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class PSRightCheckRequestData : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string areaManagerIdField;

        private string areaIdField;

        private PSRightCheckRequestDataCheckLocation checkLocationField;

        private AddressDataRequest checkAddressField;

        private string usageIdField;

        private string vehicleIdField;

        private System.Nullable<UneceLandCodesType> countryCodeVehicleField;

        private bool countryCodeVehicleFieldSpecified;

        private System.DateTime checkTimeField;

        private string referenceCheckOrgField;

        private IndicatorYNType extraInfoIndicatorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", IsNullable = true, Order = 0)]
        public string AreaManagerId
        {
            get
            {
                return this.areaManagerIdField;
            }
            set
            {
                this.areaManagerIdField = value;
                this.RaisePropertyChanged("AreaManagerId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 1)]
        public string AreaId
        {
            get
            {
                return this.areaIdField;
            }
            set
            {
                this.areaIdField = value;
                this.RaisePropertyChanged("AreaId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public PSRightCheckRequestDataCheckLocation CheckLocation
        {
            get
            {
                return this.checkLocationField;
            }
            set
            {
                this.checkLocationField = value;
                this.RaisePropertyChanged("CheckLocation");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public AddressDataRequest CheckAddress
        {
            get
            {
                return this.checkAddressField;
            }
            set
            {
                this.checkAddressField = value;
                this.RaisePropertyChanged("CheckAddress");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string UsageId
        {
            get
            {
                return this.usageIdField;
            }
            set
            {
                this.usageIdField = value;
                this.RaisePropertyChanged("UsageId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string VehicleId
        {
            get
            {
                return this.vehicleIdField;
            }
            set
            {
                this.vehicleIdField = value;
                this.RaisePropertyChanged("VehicleId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 6)]
        public System.Nullable<UneceLandCodesType> CountryCodeVehicle
        {
            get
            {
                return this.countryCodeVehicleField;
            }
            set
            {
                this.countryCodeVehicleField = value;
                this.RaisePropertyChanged("CountryCodeVehicle");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CountryCodeVehicleSpecified
        {
            get
            {
                return this.countryCodeVehicleFieldSpecified;
            }
            set
            {
                this.countryCodeVehicleFieldSpecified = value;
                this.RaisePropertyChanged("CountryCodeVehicleSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public System.DateTime CheckTime
        {
            get
            {
                return this.checkTimeField;
            }
            set
            {
                this.checkTimeField = value;
                this.RaisePropertyChanged("CheckTime");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 8)]
        public string ReferenceCheckOrg
        {
            get
            {
                return this.referenceCheckOrgField;
            }
            set
            {
                this.referenceCheckOrgField = value;
                this.RaisePropertyChanged("ReferenceCheckOrg");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public IndicatorYNType ExtraInfoIndicator
        {
            get
            {
                return this.extraInfoIndicatorField;
            }
            set
            {
                this.extraInfoIndicatorField = value;
                this.RaisePropertyChanged("ExtraInfoIndicator");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class PSRightCheckRequestDataCheckLocation : object, System.ComponentModel.INotifyPropertyChanged
    {

        private decimal latitudeField;

        private decimal longitudeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public decimal Latitude
        {
            get
            {
                return this.latitudeField;
            }
            set
            {
                this.latitudeField = value;
                this.RaisePropertyChanged("Latitude");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public decimal Longitude
        {
            get
            {
                return this.longitudeField;
            }
            set
            {
                this.longitudeField = value;
                this.RaisePropertyChanged("Longitude");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(StatusRequestResponseError))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RetrieveAreasByLocationResponseError))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CalculatePriceResponseError))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RetrieveAreaRegulationFareInfoResponseError))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RetrieveRightInfoForProviderResponseError))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RetrieveRightInfoResponseError))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RetrieveCheckInfoResponseError))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PSRightCheckResponseError))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PSRightRevokeResponseError))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PSRightEnrollResponseError))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class ResponseError : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string errorCodeField;

        private string errorDescField;

        private string errorVariableField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", IsNullable = true, Order = 0)]
        public string ErrorCode
        {
            get
            {
                return this.errorCodeField;
            }
            set
            {
                this.errorCodeField = value;
                this.RaisePropertyChanged("ErrorCode");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 1)]
        public string ErrorDesc
        {
            get
            {
                return this.errorDescField;
            }
            set
            {
                this.errorDescField = value;
                this.RaisePropertyChanged("ErrorDesc");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 2)]
        public string ErrorVariable
        {
            get
            {
                return this.errorVariableField;
            }
            set
            {
                this.errorVariableField = value;
                this.RaisePropertyChanged("ErrorVariable");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class StatusRequestResponseError : ResponseError
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

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class RetrieveAreasByLocationResponseError : ResponseError
    {

        private RetrieveAreasByLocationResponseErrorAreaLocation areaLocationField;

        private string sellingPointIdField;

        private string referenceTimeField;

        private string usageIdField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public RetrieveAreasByLocationResponseErrorAreaLocation AreaLocation
        {
            get
            {
                return this.areaLocationField;
            }
            set
            {
                this.areaLocationField = value;
                this.RaisePropertyChanged("AreaLocation");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 1)]
        public string SellingPointId
        {
            get
            {
                return this.sellingPointIdField;
            }
            set
            {
                this.sellingPointIdField = value;
                this.RaisePropertyChanged("SellingPointId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 2)]
        public string ReferenceTime
        {
            get
            {
                return this.referenceTimeField;
            }
            set
            {
                this.referenceTimeField = value;
                this.RaisePropertyChanged("ReferenceTime");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 3)]
        public string UsageId
        {
            get
            {
                return this.usageIdField;
            }
            set
            {
                this.usageIdField = value;
                this.RaisePropertyChanged("UsageId");
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class RetrieveAreasByLocationResponseErrorAreaLocation : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string latitudeField;

        private string longitudeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 0)]
        public string Latitude
        {
            get
            {
                return this.latitudeField;
            }
            set
            {
                this.latitudeField = value;
                this.RaisePropertyChanged("Latitude");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 1)]
        public string Longitude
        {
            get
            {
                return this.longitudeField;
            }
            set
            {
                this.longitudeField = value;
                this.RaisePropertyChanged("Longitude");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class CalculatePriceResponseError : ResponseError
    {

        private string vehicleIdField;

        private string countryCodeVehicleField;

        private string areaManagerIdField;

        private AreaData[] areaTableField;

        private CalculatePriceResponseErrorLocationPSRight locationPSRightField;

        private string sellingPointIdField;

        private string usageIdField;

        private string startTimePSrightField;

        private string endTimePSrightField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 0)]
        public string VehicleId
        {
            get
            {
                return this.vehicleIdField;
            }
            set
            {
                this.vehicleIdField = value;
                this.RaisePropertyChanged("VehicleId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 1)]
        public string CountryCodeVehicle
        {
            get
            {
                return this.countryCodeVehicleField;
            }
            set
            {
                this.countryCodeVehicleField = value;
                this.RaisePropertyChanged("CountryCodeVehicle");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 2)]
        public string AreaManagerId
        {
            get
            {
                return this.areaManagerIdField;
            }
            set
            {
                this.areaManagerIdField = value;
                this.RaisePropertyChanged("AreaManagerId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 3)]
        public AreaData[] AreaTable
        {
            get
            {
                return this.areaTableField;
            }
            set
            {
                this.areaTableField = value;
                this.RaisePropertyChanged("AreaTable");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public CalculatePriceResponseErrorLocationPSRight LocationPSRight
        {
            get
            {
                return this.locationPSRightField;
            }
            set
            {
                this.locationPSRightField = value;
                this.RaisePropertyChanged("LocationPSRight");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 5)]
        public string SellingPointId
        {
            get
            {
                return this.sellingPointIdField;
            }
            set
            {
                this.sellingPointIdField = value;
                this.RaisePropertyChanged("SellingPointId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 6)]
        public string UsageId
        {
            get
            {
                return this.usageIdField;
            }
            set
            {
                this.usageIdField = value;
                this.RaisePropertyChanged("UsageId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 7)]
        public string StartTimePSright
        {
            get
            {
                return this.startTimePSrightField;
            }
            set
            {
                this.startTimePSrightField = value;
                this.RaisePropertyChanged("StartTimePSright");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 8)]
        public string EndTimePSright
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
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class CalculatePriceResponseErrorLocationPSRight : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string latitudeField;

        private string longitudeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 0)]
        public string Latitude
        {
            get
            {
                return this.latitudeField;
            }
            set
            {
                this.latitudeField = value;
                this.RaisePropertyChanged("Latitude");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 1)]
        public string Longitude
        {
            get
            {
                return this.longitudeField;
            }
            set
            {
                this.longitudeField = value;
                this.RaisePropertyChanged("Longitude");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class RetrieveAreaRegulationFareInfoResponseError : ResponseError
    {
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class RetrieveRightInfoForProviderResponseError : ResponseError
    {

        private string vehicleIdField;

        private string pSRightIdField;

        private string startTimePSRightsField;

        private string endTimePSRightsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 0)]
        public string VehicleId
        {
            get
            {
                return this.vehicleIdField;
            }
            set
            {
                this.vehicleIdField = value;
                this.RaisePropertyChanged("VehicleId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 1)]
        public string PSRightId
        {
            get
            {
                return this.pSRightIdField;
            }
            set
            {
                this.pSRightIdField = value;
                this.RaisePropertyChanged("PSRightId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 2)]
        public string StartTimePSRights
        {
            get
            {
                return this.startTimePSRightsField;
            }
            set
            {
                this.startTimePSRightsField = value;
                this.RaisePropertyChanged("StartTimePSRights");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 3)]
        public string EndTimePSRights
        {
            get
            {
                return this.endTimePSRightsField;
            }
            set
            {
                this.endTimePSRightsField = value;
                this.RaisePropertyChanged("EndTimePSRights");
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class RetrieveRightInfoResponseError : ResponseError
    {

        private string vehicleIdField;

        private string indicatorTimeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 0)]
        public string VehicleId
        {
            get
            {
                return this.vehicleIdField;
            }
            set
            {
                this.vehicleIdField = value;
                this.RaisePropertyChanged("VehicleId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 1)]
        public string IndicatorTime
        {
            get
            {
                return this.indicatorTimeField;
            }
            set
            {
                this.indicatorTimeField = value;
                this.RaisePropertyChanged("IndicatorTime");
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class RetrieveCheckInfoResponseError : ResponseError
    {

        private string vehicleIdField;

        private string indicatorTimeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 0)]
        public string VehicleId
        {
            get
            {
                return this.vehicleIdField;
            }
            set
            {
                this.vehicleIdField = value;
                this.RaisePropertyChanged("VehicleId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 1)]
        public string IndicatorTime
        {
            get
            {
                return this.indicatorTimeField;
            }
            set
            {
                this.indicatorTimeField = value;
                this.RaisePropertyChanged("IndicatorTime");
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class PSRightCheckResponseError : ResponseError
    {

        private string areaManagerIdField;

        private string areaIdField;

        private PSRightCheckResponseErrorCheckLocation checkLocationField;

        private AddressDataResponse checkAddressField;

        private string vehicleIdField;

        private string countryCodeVehicleField;

        private string checkTimeField;

        private string referenceCheckOrgField;

        private string extraInfoIndicatorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 0)]
        public string AreaManagerId
        {
            get
            {
                return this.areaManagerIdField;
            }
            set
            {
                this.areaManagerIdField = value;
                this.RaisePropertyChanged("AreaManagerId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 1)]
        public string AreaId
        {
            get
            {
                return this.areaIdField;
            }
            set
            {
                this.areaIdField = value;
                this.RaisePropertyChanged("AreaId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public PSRightCheckResponseErrorCheckLocation CheckLocation
        {
            get
            {
                return this.checkLocationField;
            }
            set
            {
                this.checkLocationField = value;
                this.RaisePropertyChanged("CheckLocation");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 3)]
        public AddressDataResponse CheckAddress
        {
            get
            {
                return this.checkAddressField;
            }
            set
            {
                this.checkAddressField = value;
                this.RaisePropertyChanged("CheckAddress");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 4)]
        public string VehicleId
        {
            get
            {
                return this.vehicleIdField;
            }
            set
            {
                this.vehicleIdField = value;
                this.RaisePropertyChanged("VehicleId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 5)]
        public string CountryCodeVehicle
        {
            get
            {
                return this.countryCodeVehicleField;
            }
            set
            {
                this.countryCodeVehicleField = value;
                this.RaisePropertyChanged("CountryCodeVehicle");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 6)]
        public string CheckTime
        {
            get
            {
                return this.checkTimeField;
            }
            set
            {
                this.checkTimeField = value;
                this.RaisePropertyChanged("CheckTime");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 7)]
        public string ReferenceCheckOrg
        {
            get
            {
                return this.referenceCheckOrgField;
            }
            set
            {
                this.referenceCheckOrgField = value;
                this.RaisePropertyChanged("ReferenceCheckOrg");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 8)]
        public string ExtraInfoIndicator
        {
            get
            {
                return this.extraInfoIndicatorField;
            }
            set
            {
                this.extraInfoIndicatorField = value;
                this.RaisePropertyChanged("ExtraInfoIndicator");
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class PSRightCheckResponseErrorCheckLocation : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string latitudeField;

        private string longitudeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 0)]
        public string Latitude
        {
            get
            {
                return this.latitudeField;
            }
            set
            {
                this.latitudeField = value;
                this.RaisePropertyChanged("Latitude");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 1)]
        public string Longitude
        {
            get
            {
                return this.longitudeField;
            }
            set
            {
                this.longitudeField = value;
                this.RaisePropertyChanged("Longitude");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class PSRightRevokeResponseError : ResponseError
    {

        private string pSRightIdField;

        private string endTimePSRightField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 0)]
        public string PSRightId
        {
            get
            {
                return this.pSRightIdField;
            }
            set
            {
                this.pSRightIdField = value;
                this.RaisePropertyChanged("PSRightId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 1)]
        public string EndTimePSRight
        {
            get
            {
                return this.endTimePSRightField;
            }
            set
            {
                this.endTimePSRightField = value;
                this.RaisePropertyChanged("EndTimePSRight");
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class PSRightEnrollResponseError : ResponseError
    {

        private string vehicleIdField;

        private string countryCodeVehicleField;

        private string areaManagerIdField;

        private AreaData[] areaTableField;

        private PSRightEnrollResponseErrorLocationPSRight locationPSRightField;

        private string sellingPointIdField;

        private string usageIdField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 0)]
        public string VehicleId
        {
            get
            {
                return this.vehicleIdField;
            }
            set
            {
                this.vehicleIdField = value;
                this.RaisePropertyChanged("VehicleId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 1)]
        public string CountryCodeVehicle
        {
            get
            {
                return this.countryCodeVehicleField;
            }
            set
            {
                this.countryCodeVehicleField = value;
                this.RaisePropertyChanged("CountryCodeVehicle");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 2)]
        public string AreaManagerId
        {
            get
            {
                return this.areaManagerIdField;
            }
            set
            {
                this.areaManagerIdField = value;
                this.RaisePropertyChanged("AreaManagerId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 3)]
        public AreaData[] AreaTable
        {
            get
            {
                return this.areaTableField;
            }
            set
            {
                this.areaTableField = value;
                this.RaisePropertyChanged("AreaTable");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public PSRightEnrollResponseErrorLocationPSRight LocationPSRight
        {
            get
            {
                return this.locationPSRightField;
            }
            set
            {
                this.locationPSRightField = value;
                this.RaisePropertyChanged("LocationPSRight");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 5)]
        public string SellingPointId
        {
            get
            {
                return this.sellingPointIdField;
            }
            set
            {
                this.sellingPointIdField = value;
                this.RaisePropertyChanged("SellingPointId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 6)]
        public string UsageId
        {
            get
            {
                return this.usageIdField;
            }
            set
            {
                this.usageIdField = value;
                this.RaisePropertyChanged("UsageId");
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class PSRightEnrollResponseErrorLocationPSRight : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string latitudeField;

        private string longitudeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 0)]
        public string Latitude
        {
            get
            {
                return this.latitudeField;
            }
            set
            {
                this.latitudeField = value;
                this.RaisePropertyChanged("Latitude");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 1)]
        public string Longitude
        {
            get
            {
                return this.longitudeField;
            }
            set
            {
                this.longitudeField = value;
                this.RaisePropertyChanged("Longitude");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
    public partial class CalculatePriceResponseData : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string areaManagerIdField;

        private string areaIdField;

        private string sellingPointIdField;

        private System.Nullable<System.DateTime> endTimePSRightAdjustedField;

        private bool endTimePSRightAdjustedFieldSpecified;

        private decimal amountPSRightCalculatedField;

        private System.Nullable<decimal> vATPSRightCalculatedField;

        private bool vATPSRightCalculatedFieldSpecified;

        private SpecifCalcAmountData[] specifCalcAmountListField;

        private PSRightRemarkData[] pSRightRemarkListField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", IsNullable = true, Order = 0)]
        public string AreaManagerId
        {
            get
            {
                return this.areaManagerIdField;
            }
            set
            {
                this.areaManagerIdField = value;
                this.RaisePropertyChanged("AreaManagerId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 1)]
        public string AreaId
        {
            get
            {
                return this.areaIdField;
            }
            set
            {
                this.areaIdField = value;
                this.RaisePropertyChanged("AreaId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", IsNullable = true, Order = 2)]
        public string SellingPointId
        {
            get
            {
                return this.sellingPointIdField;
            }
            set
            {
                this.sellingPointIdField = value;
                this.RaisePropertyChanged("SellingPointId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 3)]
        public System.Nullable<System.DateTime> EndTimePSRightAdjusted
        {
            get
            {
                return this.endTimePSRightAdjustedField;
            }
            set
            {
                this.endTimePSRightAdjustedField = value;
                this.RaisePropertyChanged("EndTimePSRightAdjusted");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EndTimePSRightAdjustedSpecified
        {
            get
            {
                return this.endTimePSRightAdjustedFieldSpecified;
            }
            set
            {
                this.endTimePSRightAdjustedFieldSpecified = value;
                this.RaisePropertyChanged("EndTimePSRightAdjustedSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public decimal AmountPSRightCalculated
        {
            get
            {
                return this.amountPSRightCalculatedField;
            }
            set
            {
                this.amountPSRightCalculatedField = value;
                this.RaisePropertyChanged("AmountPSRightCalculated");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 5)]
        public System.Nullable<decimal> VATPSRightCalculated
        {
            get
            {
                return this.vATPSRightCalculatedField;
            }
            set
            {
                this.vATPSRightCalculatedField = value;
                this.RaisePropertyChanged("VATPSRightCalculated");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool VATPSRightCalculatedSpecified
        {
            get
            {
                return this.vATPSRightCalculatedFieldSpecified;
            }
            set
            {
                this.vATPSRightCalculatedFieldSpecified = value;
                this.RaisePropertyChanged("VATPSRightCalculatedSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 6)]
        public SpecifCalcAmountData[] SpecifCalcAmountList
        {
            get
            {
                return this.specifCalcAmountListField;
            }
            set
            {
                this.specifCalcAmountListField = value;
                this.RaisePropertyChanged("SpecifCalcAmountList");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 7)]
        public PSRightRemarkData[] PSRightRemarkList
        {
            get
            {
                return this.pSRightRemarkListField;
            }
            set
            {
                this.pSRightRemarkListField = value;
                this.RaisePropertyChanged("PSRightRemarkList");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "CalculatePriceRequest", WrapperNamespace = "http://rdw.nl/rpv/1.0", IsWrapped = true)]
    public partial class CalculatePriceRequest
    {

        [System.ServiceModel.MessageHeaderAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
        public string PIN;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://rdw.nl/rpv/1.0", Order = 0)]
        public Denion.WebService.VerwijsIndex.CalculatePriceRequestData CalculatePriceRequestData;

        public CalculatePriceRequest()
        {
        }

        public CalculatePriceRequest(string PIN, Denion.WebService.VerwijsIndex.CalculatePriceRequestData CalculatePriceRequestData)
        {
            this.PIN = PIN;
            this.CalculatePriceRequestData = CalculatePriceRequestData;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "CalculatePriceResponse", WrapperNamespace = "http://rdw.nl/rpv/1.0", IsWrapped = true)]
    public partial class CalculatePriceResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://rdw.nl/rpv/1.0", Order = 0)]
        public Denion.WebService.VerwijsIndex.CalculatePriceResponseData CalculatePriceResponseData;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://rdw.nl/rpv/1.0", Order = 1)]
        public Denion.WebService.VerwijsIndex.CalculatePriceResponseError CalculatePriceResponseError;

        public CalculatePriceResponse()
        {
        }

        public CalculatePriceResponse(Denion.WebService.VerwijsIndex.CalculatePriceResponseData CalculatePriceResponseData, Denion.WebService.VerwijsIndex.CalculatePriceResponseError CalculatePriceResponseError)
        {
            this.CalculatePriceResponseData = CalculatePriceResponseData;
            this.CalculatePriceResponseError = CalculatePriceResponseError;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "PSRightCheckRequest", WrapperNamespace = "http://rdw.nl/rpv/1.0", IsWrapped = true)]
    public partial class PSRightCheckRequest
    {

        [System.ServiceModel.MessageHeaderAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
        public string PIN;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://rdw.nl/rpv/1.0", Order = 0)]
        public Denion.WebService.VerwijsIndex.PSRightCheckRequestData PSRightCheckRequestData;

        public PSRightCheckRequest()
        {
        }

        public PSRightCheckRequest(string PIN, Denion.WebService.VerwijsIndex.PSRightCheckRequestData PSRightCheckRequestData)
        {
            this.PIN = PIN;
            this.PSRightCheckRequestData = PSRightCheckRequestData;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "PSRightCheckResponse", WrapperNamespace = "http://rdw.nl/rpv/1.0", IsWrapped = true)]
    public partial class PSRightCheckResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://rdw.nl/rpv/1.0", Order = 0)]
        public Denion.WebService.VerwijsIndex.PSRightCheckResponseData PSRightCheckResponseData;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://rdw.nl/rpv/1.0", Order = 1)]
        public Denion.WebService.VerwijsIndex.PSRightCheckResponseError PSRightCheckResponseError;

        public PSRightCheckResponse()
        {
        }

        public PSRightCheckResponse(Denion.WebService.VerwijsIndex.PSRightCheckResponseData PSRightCheckResponseData, Denion.WebService.VerwijsIndex.PSRightCheckResponseError PSRightCheckResponseError)
        {
            this.PSRightCheckResponseData = PSRightCheckResponseData;
            this.PSRightCheckResponseError = PSRightCheckResponseError;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "PSRightEnrollRequest", WrapperNamespace = "http://rdw.nl/rpv/1.0", IsWrapped = true)]
    public partial class PSRightEnrollRequest
    {

        [System.ServiceModel.MessageHeaderAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
        public string PIN;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://rdw.nl/rpv/1.0", Order = 0)]
        public Denion.WebService.VerwijsIndex.PSRightEnrollRequestData PSRightEnrollRequestData;

        public PSRightEnrollRequest()
        {
        }

        public PSRightEnrollRequest(string PIN, Denion.WebService.VerwijsIndex.PSRightEnrollRequestData PSRightEnrollRequestData)
        {
            this.PIN = PIN;
            this.PSRightEnrollRequestData = PSRightEnrollRequestData;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "PSRightEnrollResponse", WrapperNamespace = "http://rdw.nl/rpv/1.0", IsWrapped = true)]
    public partial class PSRightEnrollResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://rdw.nl/rpv/1.0", Order = 0)]
        public Denion.WebService.VerwijsIndex.PSRightEnrollResponseData PSRightEnrollResponseData;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://rdw.nl/rpv/1.0", Order = 1)]
        public Denion.WebService.VerwijsIndex.PSRightEnrollResponseError PSRightEnrollResponseError;

        public PSRightEnrollResponse()
        {
        }

        public PSRightEnrollResponse(Denion.WebService.VerwijsIndex.PSRightEnrollResponseData PSRightEnrollResponseData, Denion.WebService.VerwijsIndex.PSRightEnrollResponseError PSRightEnrollResponseError)
        {
            this.PSRightEnrollResponseData = PSRightEnrollResponseData;
            this.PSRightEnrollResponseError = PSRightEnrollResponseError;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "RetrieveAreaRegulationFareInfoRequest", WrapperNamespace = "http://rdw.nl/rpv/1.0", IsWrapped = true)]
    public partial class RetrieveAreaRegulationFareInfoRequest
    {

        [System.ServiceModel.MessageHeaderAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
        public string PIN;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://rdw.nl/rpv/1.0", Order = 0)]
        public Denion.WebService.VerwijsIndex.RetrieveAreaRegulationFareInfoRequestData AreaArrangeAccountInfoRequestData;

        public RetrieveAreaRegulationFareInfoRequest()
        {
        }

        public RetrieveAreaRegulationFareInfoRequest(string PIN, Denion.WebService.VerwijsIndex.RetrieveAreaRegulationFareInfoRequestData AreaArrangeAccountInfoRequestData)
        {
            this.PIN = PIN;
            this.AreaArrangeAccountInfoRequestData = AreaArrangeAccountInfoRequestData;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "RetrieveAreaRegulationFareInfoResponse", WrapperNamespace = "http://rdw.nl/rpv/1.0", IsWrapped = true)]
    public partial class RetrieveAreaRegulationFareInfoResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://rdw.nl/rpv/1.0", Order = 0)]
        public Denion.WebService.VerwijsIndex.RetrieveAreaRegulationFareInfoResponseData AreaRegulationFareInfoResponseData;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://rdw.nl/rpv/1.0", Order = 1)]
        public Denion.WebService.VerwijsIndex.RetrieveAreaRegulationFareInfoResponseError AreaRegulationFareInfoResponseError;

        public RetrieveAreaRegulationFareInfoResponse()
        {
        }

        public RetrieveAreaRegulationFareInfoResponse(Denion.WebService.VerwijsIndex.RetrieveAreaRegulationFareInfoResponseData AreaRegulationFareInfoResponseData, Denion.WebService.VerwijsIndex.RetrieveAreaRegulationFareInfoResponseError AreaRegulationFareInfoResponseError)
        {
            this.AreaRegulationFareInfoResponseData = AreaRegulationFareInfoResponseData;
            this.AreaRegulationFareInfoResponseError = AreaRegulationFareInfoResponseError;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "RetrieveAreasByLocationRequest", WrapperNamespace = "http://rdw.nl/rpv/1.0", IsWrapped = true)]
    public partial class RetrieveAreasByLocationRequest
    {

        [System.ServiceModel.MessageHeaderAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
        public string PIN;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://rdw.nl/rpv/1.0", Order = 0)]
        public Denion.WebService.VerwijsIndex.RetrieveAreasByLocationRequestData RetrieveAreasByLocationRequestData;

        public RetrieveAreasByLocationRequest()
        {
        }

        public RetrieveAreasByLocationRequest(string PIN, Denion.WebService.VerwijsIndex.RetrieveAreasByLocationRequestData RetrieveAreasByLocationRequestData)
        {
            this.PIN = PIN;
            this.RetrieveAreasByLocationRequestData = RetrieveAreasByLocationRequestData;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "RetrieveAreasByLocationResponse", WrapperNamespace = "http://rdw.nl/rpv/1.0", IsWrapped = true)]
    public partial class RetrieveAreasByLocationResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://rdw.nl/rpv/1.0", Order = 0)]
        public Denion.WebService.VerwijsIndex.RetrieveAreasByLocationResponseData RetrieveAreasByLocationResponseData;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://rdw.nl/rpv/1.0", Order = 1)]
        public Denion.WebService.VerwijsIndex.RetrieveAreasByLocationResponseError RetrieveAreasByLocationResponseError;

        public RetrieveAreasByLocationResponse()
        {
        }

        public RetrieveAreasByLocationResponse(Denion.WebService.VerwijsIndex.RetrieveAreasByLocationResponseData RetrieveAreasByLocationResponseData, Denion.WebService.VerwijsIndex.RetrieveAreasByLocationResponseError RetrieveAreasByLocationResponseError)
        {
            this.RetrieveAreasByLocationResponseData = RetrieveAreasByLocationResponseData;
            this.RetrieveAreasByLocationResponseError = RetrieveAreasByLocationResponseError;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "RetrieveCheckInfoRequest", WrapperNamespace = "http://rdw.nl/rpv/1.0", IsWrapped = true)]
    public partial class RetrieveCheckInfoRequest
    {

        [System.ServiceModel.MessageHeaderAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
        public string PIN;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://rdw.nl/rpv/1.0", Order = 0)]
        public Denion.WebService.VerwijsIndex.RetrieveCheckInfoRequestData CheckInfoRequestData;

        public RetrieveCheckInfoRequest()
        {
        }

        public RetrieveCheckInfoRequest(string PIN, Denion.WebService.VerwijsIndex.RetrieveCheckInfoRequestData CheckInfoRequestData)
        {
            this.PIN = PIN;
            this.CheckInfoRequestData = CheckInfoRequestData;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "RetrieveCheckInfoResponse", WrapperNamespace = "http://rdw.nl/rpv/1.0", IsWrapped = true)]
    public partial class RetrieveCheckInfoResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://rdw.nl/rpv/1.0", Order = 0)]
        public Denion.WebService.VerwijsIndex.RetrieveCheckInfoResponseData CheckInfoResponseData;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://rdw.nl/rpv/1.0", Order = 1)]
        public Denion.WebService.VerwijsIndex.RetrieveCheckInfoResponseError CheckInfoResponseError;

        public RetrieveCheckInfoResponse()
        {
        }

        public RetrieveCheckInfoResponse(Denion.WebService.VerwijsIndex.RetrieveCheckInfoResponseData CheckInfoResponseData, Denion.WebService.VerwijsIndex.RetrieveCheckInfoResponseError CheckInfoResponseError)
        {
            this.CheckInfoResponseData = CheckInfoResponseData;
            this.CheckInfoResponseError = CheckInfoResponseError;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "RetrieveRightInfoRequest", WrapperNamespace = "http://rdw.nl/rpv/1.0", IsWrapped = true)]
    public partial class RetrieveRightInfoRequest
    {

        [System.ServiceModel.MessageHeaderAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
        public string PIN;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://rdw.nl/rpv/1.0", Order = 0)]
        public Denion.WebService.VerwijsIndex.RetrieveRightInfoRequestData RightInfoRequestData;

        public RetrieveRightInfoRequest()
        {
        }

        public RetrieveRightInfoRequest(string PIN, Denion.WebService.VerwijsIndex.RetrieveRightInfoRequestData RightInfoRequestData)
        {
            this.PIN = PIN;
            this.RightInfoRequestData = RightInfoRequestData;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "RetrieveRightInfoResponse", WrapperNamespace = "http://rdw.nl/rpv/1.0", IsWrapped = true)]
    public partial class RetrieveRightInfoResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://rdw.nl/rpv/1.0", Order = 0)]
        public Denion.WebService.VerwijsIndex.RetrieveRightInfoResponseData PSRightInfoResponseData;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://rdw.nl/rpv/1.0", Order = 1)]
        public Denion.WebService.VerwijsIndex.RetrieveRightInfoResponseError RightInfoResponseError;

        public RetrieveRightInfoResponse()
        {
        }

        public RetrieveRightInfoResponse(Denion.WebService.VerwijsIndex.RetrieveRightInfoResponseData PSRightInfoResponseData, Denion.WebService.VerwijsIndex.RetrieveRightInfoResponseError RightInfoResponseError)
        {
            this.PSRightInfoResponseData = PSRightInfoResponseData;
            this.RightInfoResponseError = RightInfoResponseError;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "RetrieveRightInfoForProviderRequest", WrapperNamespace = "http://rdw.nl/rpv/1.0", IsWrapped = true)]
    public partial class RetrieveRightInfoForProviderRequest
    {

        [System.ServiceModel.MessageHeaderAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
        public string PIN;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://rdw.nl/rpv/1.0", Order = 0)]
        public Denion.WebService.VerwijsIndex.RetrieveRightInfoForProviderRequestData RightInfoRequestData;

        public RetrieveRightInfoForProviderRequest()
        {
        }

        public RetrieveRightInfoForProviderRequest(string PIN, Denion.WebService.VerwijsIndex.RetrieveRightInfoForProviderRequestData RightInfoRequestData)
        {
            this.PIN = PIN;
            this.RightInfoRequestData = RightInfoRequestData;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "RetrieveRightInfoForProviderResponse", WrapperNamespace = "http://rdw.nl/rpv/1.0", IsWrapped = true)]
    public partial class RetrieveRightInfoForProviderResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://rdw.nl/rpv/1.0", Order = 0)]
        public Denion.WebService.VerwijsIndex.RetrieveRightInfoForProviderResponseData PSRightInfoForProviderResponseData;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://rdw.nl/rpv/1.0", Order = 1)]
        public Denion.WebService.VerwijsIndex.RetrieveRightInfoForProviderResponseError RightInfoForProviderResponseError;

        public RetrieveRightInfoForProviderResponse()
        {
        }

        public RetrieveRightInfoForProviderResponse(Denion.WebService.VerwijsIndex.RetrieveRightInfoForProviderResponseData PSRightInfoForProviderResponseData, Denion.WebService.VerwijsIndex.RetrieveRightInfoForProviderResponseError RightInfoForProviderResponseError)
        {
            this.PSRightInfoForProviderResponseData = PSRightInfoForProviderResponseData;
            this.RightInfoForProviderResponseError = RightInfoForProviderResponseError;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "PSRightRevokeRequest", WrapperNamespace = "http://rdw.nl/rpv/1.0", IsWrapped = true)]
    public partial class PSRightRevokeRequest
    {

        [System.ServiceModel.MessageHeaderAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
        public string PIN;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://rdw.nl/rpv/1.0", Order = 0)]
        public Denion.WebService.VerwijsIndex.PSRightRevokeRequestData PSRightRevokeRequestData;

        public PSRightRevokeRequest()
        {
        }

        public PSRightRevokeRequest(string PIN, Denion.WebService.VerwijsIndex.PSRightRevokeRequestData PSRightRevokeRequestData)
        {
            this.PIN = PIN;
            this.PSRightRevokeRequestData = PSRightRevokeRequestData;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "PSRightRevokeResponse", WrapperNamespace = "http://rdw.nl/rpv/1.0", IsWrapped = true)]
    public partial class PSRightRevokeResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://rdw.nl/rpv/1.0", Order = 0)]
        public Denion.WebService.VerwijsIndex.PSRightRevokeResponseData PSRightRevokeResponseData;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://rdw.nl/rpv/1.0", Order = 1)]
        public Denion.WebService.VerwijsIndex.PSRightRevokeResponseError PSRightRevokeResponseError;

        public PSRightRevokeResponse()
        {
        }

        public PSRightRevokeResponse(Denion.WebService.VerwijsIndex.PSRightRevokeResponseData PSRightRevokeResponseData, Denion.WebService.VerwijsIndex.PSRightRevokeResponseError PSRightRevokeResponseError)
        {
            this.PSRightRevokeResponseData = PSRightRevokeResponseData;
            this.PSRightRevokeResponseError = PSRightRevokeResponseError;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "StatusRequestRequest", WrapperNamespace = "http://rdw.nl/rpv/1.0", IsWrapped = true)]
    public partial class StatusRequestRequest
    {

        [System.ServiceModel.MessageHeaderAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
        public string PIN;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://rdw.nl/rpv/1.0", Order = 0)]
        public Denion.WebService.VerwijsIndex.StatusRequestRequestData StatusRequestRequestData;

        public StatusRequestRequest()
        {
        }

        public StatusRequestRequest(string PIN, Denion.WebService.VerwijsIndex.StatusRequestRequestData StatusRequestRequestData)
        {
            this.PIN = PIN;
            this.StatusRequestRequestData = StatusRequestRequestData;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "StatusRequestResponse", WrapperNamespace = "http://rdw.nl/rpv/1.0", IsWrapped = true)]
    public partial class StatusRequestResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://rdw.nl/rpv/1.0", Order = 0)]
        public Denion.WebService.VerwijsIndex.StatusRequestResponseData StatusRequestResponseData;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://rdw.nl/rpv/1.0", Order = 1)]
        public Denion.WebService.VerwijsIndex.StatusRequestResponseError StatusRequestResponseError;

        public StatusRequestResponse()
        {
        }

        public StatusRequestResponse(Denion.WebService.VerwijsIndex.StatusRequestResponseData StatusRequestResponseData, Denion.WebService.VerwijsIndex.StatusRequestResponseError StatusRequestResponseError)
        {
            this.StatusRequestResponseData = StatusRequestResponseData;
            this.StatusRequestResponseError = StatusRequestResponseError;
        }
    }


    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RegistrationClient : System.ServiceModel.ClientBase<Denion.WebService.VerwijsIndex.IRegistration>, Denion.WebService.VerwijsIndex.IRegistration
    {

        public RegistrationClient()
        {
        }

        public RegistrationClient(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public RegistrationClient(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public RegistrationClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public RegistrationClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Denion.WebService.VerwijsIndex.CalculatePriceResponse Denion.WebService.VerwijsIndex.IRegistration.CalculatePrice(Denion.WebService.VerwijsIndex.CalculatePriceRequest request)
        {
            return base.Channel.CalculatePrice(request);
        }

        public Denion.WebService.VerwijsIndex.CalculatePriceResponseData CalculatePrice(string PIN, Denion.WebService.VerwijsIndex.CalculatePriceRequestData CalculatePriceRequestData, out Denion.WebService.VerwijsIndex.CalculatePriceResponseError CalculatePriceResponseError)
        {
            Denion.WebService.VerwijsIndex.CalculatePriceRequest inValue = new Denion.WebService.VerwijsIndex.CalculatePriceRequest();
            inValue.PIN = PIN;
            inValue.CalculatePriceRequestData = CalculatePriceRequestData;
            Denion.WebService.VerwijsIndex.CalculatePriceResponse retVal = ((Denion.WebService.VerwijsIndex.IRegistration)(this)).CalculatePrice(inValue);
            CalculatePriceResponseError = retVal.CalculatePriceResponseError;
            return retVal.CalculatePriceResponseData;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Denion.WebService.VerwijsIndex.PSRightCheckResponse Denion.WebService.VerwijsIndex.IRegistration.CheckPSRight(Denion.WebService.VerwijsIndex.PSRightCheckRequest request)
        {
            return base.Channel.CheckPSRight(request);
        }

        public Denion.WebService.VerwijsIndex.PSRightCheckResponseData CheckPSRight(string PIN, Denion.WebService.VerwijsIndex.PSRightCheckRequestData PSRightCheckRequestData, out Denion.WebService.VerwijsIndex.PSRightCheckResponseError PSRightCheckResponseError)
        {
            Denion.WebService.VerwijsIndex.PSRightCheckRequest inValue = new Denion.WebService.VerwijsIndex.PSRightCheckRequest();
            inValue.PIN = PIN;
            inValue.PSRightCheckRequestData = PSRightCheckRequestData;
            Denion.WebService.VerwijsIndex.PSRightCheckResponse retVal = ((Denion.WebService.VerwijsIndex.IRegistration)(this)).CheckPSRight(inValue);
            PSRightCheckResponseError = retVal.PSRightCheckResponseError;
            return retVal.PSRightCheckResponseData;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Denion.WebService.VerwijsIndex.PSRightEnrollResponse Denion.WebService.VerwijsIndex.IRegistration.EnrollPSRight(Denion.WebService.VerwijsIndex.PSRightEnrollRequest request)
        {
            return base.Channel.EnrollPSRight(request);
        }

        public Denion.WebService.VerwijsIndex.PSRightEnrollResponseData EnrollPSRight(string PIN, Denion.WebService.VerwijsIndex.PSRightEnrollRequestData PSRightEnrollRequestData, out Denion.WebService.VerwijsIndex.PSRightEnrollResponseError PSRightEnrollResponseError)
        {
            Denion.WebService.VerwijsIndex.PSRightEnrollRequest inValue = new Denion.WebService.VerwijsIndex.PSRightEnrollRequest();
            inValue.PIN = PIN;
            inValue.PSRightEnrollRequestData = PSRightEnrollRequestData;
            Denion.WebService.VerwijsIndex.PSRightEnrollResponse retVal = ((Denion.WebService.VerwijsIndex.IRegistration)(this)).EnrollPSRight(inValue);
            PSRightEnrollResponseError = retVal.PSRightEnrollResponseError;
            return retVal.PSRightEnrollResponseData;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Denion.WebService.VerwijsIndex.RetrieveAreaRegulationFareInfoResponse Denion.WebService.VerwijsIndex.IRegistration.RetrieveAreaRegulationFareInfo(Denion.WebService.VerwijsIndex.RetrieveAreaRegulationFareInfoRequest request)
        {
            return base.Channel.RetrieveAreaRegulationFareInfo(request);
        }

        public Denion.WebService.VerwijsIndex.RetrieveAreaRegulationFareInfoResponseData RetrieveAreaRegulationFareInfo(string PIN, Denion.WebService.VerwijsIndex.RetrieveAreaRegulationFareInfoRequestData AreaArrangeAccountInfoRequestData, out Denion.WebService.VerwijsIndex.RetrieveAreaRegulationFareInfoResponseError AreaRegulationFareInfoResponseError)
        {
            Denion.WebService.VerwijsIndex.RetrieveAreaRegulationFareInfoRequest inValue = new Denion.WebService.VerwijsIndex.RetrieveAreaRegulationFareInfoRequest();
            inValue.PIN = PIN;
            inValue.AreaArrangeAccountInfoRequestData = AreaArrangeAccountInfoRequestData;
            Denion.WebService.VerwijsIndex.RetrieveAreaRegulationFareInfoResponse retVal = ((Denion.WebService.VerwijsIndex.IRegistration)(this)).RetrieveAreaRegulationFareInfo(inValue);
            AreaRegulationFareInfoResponseError = retVal.AreaRegulationFareInfoResponseError;
            return retVal.AreaRegulationFareInfoResponseData;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Denion.WebService.VerwijsIndex.RetrieveAreasByLocationResponse Denion.WebService.VerwijsIndex.IRegistration.RetrieveAreasByLocation(Denion.WebService.VerwijsIndex.RetrieveAreasByLocationRequest request)
        {
            return base.Channel.RetrieveAreasByLocation(request);
        }

        public Denion.WebService.VerwijsIndex.RetrieveAreasByLocationResponseData RetrieveAreasByLocation(string PIN, Denion.WebService.VerwijsIndex.RetrieveAreasByLocationRequestData RetrieveAreasByLocationRequestData, out Denion.WebService.VerwijsIndex.RetrieveAreasByLocationResponseError RetrieveAreasByLocationResponseError)
        {
            Denion.WebService.VerwijsIndex.RetrieveAreasByLocationRequest inValue = new Denion.WebService.VerwijsIndex.RetrieveAreasByLocationRequest();
            inValue.PIN = PIN;
            inValue.RetrieveAreasByLocationRequestData = RetrieveAreasByLocationRequestData;
            Denion.WebService.VerwijsIndex.RetrieveAreasByLocationResponse retVal = ((Denion.WebService.VerwijsIndex.IRegistration)(this)).RetrieveAreasByLocation(inValue);
            RetrieveAreasByLocationResponseError = retVal.RetrieveAreasByLocationResponseError;
            return retVal.RetrieveAreasByLocationResponseData;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Denion.WebService.VerwijsIndex.RetrieveCheckInfoResponse Denion.WebService.VerwijsIndex.IRegistration.RetrieveCheckInfo(Denion.WebService.VerwijsIndex.RetrieveCheckInfoRequest request)
        {
            return base.Channel.RetrieveCheckInfo(request);
        }

        public Denion.WebService.VerwijsIndex.RetrieveCheckInfoResponseData RetrieveCheckInfo(string PIN, Denion.WebService.VerwijsIndex.RetrieveCheckInfoRequestData CheckInfoRequestData, out Denion.WebService.VerwijsIndex.RetrieveCheckInfoResponseError CheckInfoResponseError)
        {
            Denion.WebService.VerwijsIndex.RetrieveCheckInfoRequest inValue = new Denion.WebService.VerwijsIndex.RetrieveCheckInfoRequest();
            inValue.PIN = PIN;
            inValue.CheckInfoRequestData = CheckInfoRequestData;
            Denion.WebService.VerwijsIndex.RetrieveCheckInfoResponse retVal = ((Denion.WebService.VerwijsIndex.IRegistration)(this)).RetrieveCheckInfo(inValue);
            CheckInfoResponseError = retVal.CheckInfoResponseError;
            return retVal.CheckInfoResponseData;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Denion.WebService.VerwijsIndex.RetrieveRightInfoResponse Denion.WebService.VerwijsIndex.IRegistration.RetrieveRightInfo(Denion.WebService.VerwijsIndex.RetrieveRightInfoRequest request)
        {
            return base.Channel.RetrieveRightInfo(request);
        }

        public Denion.WebService.VerwijsIndex.RetrieveRightInfoResponseData RetrieveRightInfo(string PIN, Denion.WebService.VerwijsIndex.RetrieveRightInfoRequestData RightInfoRequestData, out Denion.WebService.VerwijsIndex.RetrieveRightInfoResponseError RightInfoResponseError)
        {
            Denion.WebService.VerwijsIndex.RetrieveRightInfoRequest inValue = new Denion.WebService.VerwijsIndex.RetrieveRightInfoRequest();
            inValue.PIN = PIN;
            inValue.RightInfoRequestData = RightInfoRequestData;
            Denion.WebService.VerwijsIndex.RetrieveRightInfoResponse retVal = ((Denion.WebService.VerwijsIndex.IRegistration)(this)).RetrieveRightInfo(inValue);
            RightInfoResponseError = retVal.RightInfoResponseError;
            return retVal.PSRightInfoResponseData;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Denion.WebService.VerwijsIndex.RetrieveRightInfoForProviderResponse Denion.WebService.VerwijsIndex.IRegistration.RetrieveRightInfoForProvider(Denion.WebService.VerwijsIndex.RetrieveRightInfoForProviderRequest request)
        {
            return base.Channel.RetrieveRightInfoForProvider(request);
        }

        public Denion.WebService.VerwijsIndex.RetrieveRightInfoForProviderResponseData RetrieveRightInfoForProvider(string PIN, Denion.WebService.VerwijsIndex.RetrieveRightInfoForProviderRequestData RightInfoRequestData, out Denion.WebService.VerwijsIndex.RetrieveRightInfoForProviderResponseError RightInfoForProviderResponseError)
        {
            Denion.WebService.VerwijsIndex.RetrieveRightInfoForProviderRequest inValue = new Denion.WebService.VerwijsIndex.RetrieveRightInfoForProviderRequest();
            inValue.PIN = PIN;
            inValue.RightInfoRequestData = RightInfoRequestData;
            Denion.WebService.VerwijsIndex.RetrieveRightInfoForProviderResponse retVal = ((Denion.WebService.VerwijsIndex.IRegistration)(this)).RetrieveRightInfoForProvider(inValue);
            RightInfoForProviderResponseError = retVal.RightInfoForProviderResponseError;
            return retVal.PSRightInfoForProviderResponseData;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Denion.WebService.VerwijsIndex.PSRightRevokeResponse Denion.WebService.VerwijsIndex.IRegistration.RevokePSRight(Denion.WebService.VerwijsIndex.PSRightRevokeRequest request)
        {
            return base.Channel.RevokePSRight(request);
        }

        public Denion.WebService.VerwijsIndex.PSRightRevokeResponseData RevokePSRight(string PIN, Denion.WebService.VerwijsIndex.PSRightRevokeRequestData PSRightRevokeRequestData, out Denion.WebService.VerwijsIndex.PSRightRevokeResponseError PSRightRevokeResponseError)
        {
            Denion.WebService.VerwijsIndex.PSRightRevokeRequest inValue = new Denion.WebService.VerwijsIndex.PSRightRevokeRequest();
            inValue.PIN = PIN;
            inValue.PSRightRevokeRequestData = PSRightRevokeRequestData;
            Denion.WebService.VerwijsIndex.PSRightRevokeResponse retVal = ((Denion.WebService.VerwijsIndex.IRegistration)(this)).RevokePSRight(inValue);
            PSRightRevokeResponseError = retVal.PSRightRevokeResponseError;
            return retVal.PSRightRevokeResponseData;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Denion.WebService.VerwijsIndex.StatusRequestResponse Denion.WebService.VerwijsIndex.IRegistration.StatusRequest(Denion.WebService.VerwijsIndex.StatusRequestRequest request)
        {
            return base.Channel.StatusRequest(request);
        }

        public Denion.WebService.VerwijsIndex.StatusRequestResponseData StatusRequest(string PIN, Denion.WebService.VerwijsIndex.StatusRequestRequestData StatusRequestRequestData, out Denion.WebService.VerwijsIndex.StatusRequestResponseError StatusRequestResponseError)
        {
            Denion.WebService.VerwijsIndex.StatusRequestRequest inValue = new Denion.WebService.VerwijsIndex.StatusRequestRequest();
            inValue.PIN = PIN;
            inValue.StatusRequestRequestData = StatusRequestRequestData;
            Denion.WebService.VerwijsIndex.StatusRequestResponse retVal = ((Denion.WebService.VerwijsIndex.IRegistration)(this)).StatusRequest(inValue);
            StatusRequestResponseError = retVal.StatusRequestResponseError;
            return retVal.StatusRequestResponseData;
        }
    }
}
