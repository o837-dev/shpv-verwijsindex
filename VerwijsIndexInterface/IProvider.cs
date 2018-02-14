using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Denion.WebService.VerwijsIndex
{
    [ServiceContract(Name = "Provider", Namespace = "https://verwijsindex.shpv.nl/service/")]
    public interface IProvider
    {
        //[OperationContract]
        //LinkResponse Request(LinkRequest req);

        [OperationContract]
        LinkRegistrationResponse Registration(LinkRegistrationRequest req);

        [OperationContract]
        LinkRegistrationBatchResponse BatchRegistration(LinkRegistrationBatchRequest req);

        [OperationContract]
        CancelAuthorisationResponse CancelAuthorisation(CancelAuthorisationRequest CancelAuthorisationRequest);

        [OperationContract]
        StatusResponse ServiceStatus();

        [OperationContract]
        LinkTerminationAcknowledged Terminated(LinkTerminationNotification ltn);
    }

    /// <summary>
    /// Bevestiging van ontvangst
    /// </summary>
    [DataContract(Namespace = "https://verwijsindex.shpv.nl/messages/")]
    public class LinkTerminationAcknowledged
    {
        [DataMember(Order = 0, IsRequired =true)]
        public DateTime AcknowledgeDateTime { get; set; }
    }

    /// <summary>
    /// Melding bij het overrulen van een Link
    /// </summary>
    [DataContract(Namespace = "https://verwijsindex.shpv.nl/messages/")]
    public class LinkTerminationNotification
    {
        /// <summary>
        /// Voertuigkenteken, verplicht
        /// </summary>
        [DataMember(Order = 0, IsRequired = true)]
        public string VehicleId { get; set; }

        /// <summary>
        /// Voertuigkenteken landscode, optioneel
        /// </summary>
        [DataMember(Order = 1, IsRequired = false)]
        public string CountryCode { get; set; }

        /// <summary>
        /// Waarde type van het VehicleId veld, optioneel
        /// </summary>
        [DataMember(Order = 2, IsRequired = false)]
        public string VehicleIdType { get; set; }

        /// <summary>
        /// Beëndigingsdatum/tijd
        /// </summary>
        public DateTime TerminationDateTime { get; set; }
    }

    /// <summary>
    /// Link registratie verzoek
    /// </summary>
    [DataContract(Namespace = "https://verwijsindex.shpv.nl/messages/")]
    public class LinkRegistrationRequest
    {
        /// <summary>
        /// De provider die voor de betaling instaat, verplicht
        /// </summary>
        [DataMember(Order = 0, IsRequired = true)]
        public string ProviderId { get; set; }

        /// <summary>
        /// kenmerk van de provider, verplicht
        /// </summary>
        [DataMember(Order = 1, IsRequired = true)]
        public string LinkId { get; set; }

        /// <summary>
        /// Voertuigkenteken, verplicht
        /// </summary>
        [DataMember(Order = 2, IsRequired = true)]
        public string VehicleId { get; set; }

        /// <summary>
        /// Voertuigkenteken landscode, optioneel
        /// </summary>
        [DataMember(Order = 3, IsRequired = false)]
        public string CountryCode { get; set; }

        /// <summary>
        /// ingangsdatum, verplicht
        /// </summary>
        [DataMember(Order = 4, IsRequired = true)]
        public DateTime ValidFrom { get; set; }

        /// <summary>
        /// geldigheid, verplicht
        /// </summary>
        [DataMember(Order = 5, IsRequired = true)]
        public DateTime ValidUntil { get; set; }

        /// <summary>
        /// geldigeheid gebiedscode, optioneel
        /// </summary>
        [DataMember(Order = 6, IsRequired = false)]
        public string AreaId { get; set; }

        /// <summary>
        /// Waarde type van het VehicleId veld, optioneel
        /// </summary>
        [DataMember(Order = 7, IsRequired = false)]
        public string VehicleIdType { get; set; }

        public Err IsValid()
        {
            VehicleId = VehicleId.StripVehicleId();

            if (string.IsNullOrEmpty(ProviderId))
            {
                return new Err60("ProviderId");
            }
            else if (string.IsNullOrEmpty(LinkId))
            {
                return new Err60("LinkId");
            }
            else if (string.IsNullOrEmpty(VehicleId))
            {
                return new Err60("VehicleId");
            }
            else if (ValidFrom == DateTime.MinValue)
            {
                return new Err60("ValidFrom");
            }
            else if (ValidUntil == DateTime.MinValue)
            {
                return new Err60("ValidUntil");
            }
            else if (ValidUntil < ValidFrom)
            {
                return new Err65();
            }
            else if (!string.IsNullOrEmpty(VehicleIdType) && !Functions.IsValidType(VehicleIdType))
            {
                return new Err105("VehicleIdType");
            }
            return null;
        }
    }

    /// <summary>
    /// Link registratie antwoord
    /// </summary>
    [DataContract(Namespace = "https://verwijsindex.shpv.nl/messages/")]
    public class LinkRegistrationResponse
    {
        /// <summary>
        /// Code van de foutmelding of opmerking, optioneel
        /// </summary>
        [DataMember(Order = 0, IsRequired = false)]
        public string RemarkId { get; set; }

        /// <summary>
        /// Foutmelding of opmerking, optioneel
        /// </summary>
        [DataMember(Order = 1, IsRequired = false)]
        public string Remark { get; set; }
    }

    /// <summary>
    /// Container met link registraties
    /// </summary>
    [DataContract(Namespace = "https://verwijsindex.shpv.nl/messages/")]
    public class LinkRegistrationBatchRequest
    {
        /// <summary>
        /// Link registratie verzoeken
        /// </summary>
        [DataMember(Order = 0, IsRequired = true)]
        public LinkRegistrationRequest[] Batch { get; set; }
    }

    /// <summary>
    /// Container met link registratie antwoorden
    /// </summary>
    [DataContract(Namespace = "https://verwijsindex.shpv.nl/messages/")]
    public class LinkRegistrationBatchResponse
    {
        /// <summary>
        /// Link registratie antwoorden
        /// </summary>
        [DataMember(Order = 0, IsRequired = true)]
        public LinkRegistrationResponse[] Batch { get; set; }
    }

    ///// <summary>
    ///// registratie verzoek
    ///// </summary>
    //[DataContract(Namespace = "https://verwijsindex.shpv.nl/messages/")]
    //public class LinkRequest
    //{
    //    /// <summary>
    //    /// De provider die voor de betaling instaat, verplicht
    //    /// </summary>
    //    [DataMember(Order = 0, IsRequired = true)]
    //    public string ProviderId { get; set; }

    //    /// <summary>
    //    /// Voertuigkenteken, verplicht
    //    /// </summary>
    //    [DataMember(Order = 1, IsRequired = true)]
    //    public string VehicleId { get; set; }

    //    /// <summary>
    //    /// Voertuigkenteken landscode, optioneel
    //    /// </summary>
    //    [DataMember(Order = 2, IsRequired = false)]
    //    public string CountryCode { get; set; }

    //    /// <summary>
    //    /// Waarde type van het VehicleId veld, verplicht
    //    /// </summary>
    //    [DataMember(Order = 3, IsRequired = false)]
    //    public string VehicleIdType { get; set; }

    //    public Err IsValid()
    //    {
    //        VehicleId = VehicleId.StripVehicleId();

    //        if (string.IsNullOrEmpty(ProviderId))
    //        {
    //            return new Err60("ProviderId");
    //        }
    //        else if (string.IsNullOrEmpty(VehicleId))
    //        {
    //            return new Err60("VehicleId");
    //        }
    //        else if (!string.IsNullOrEmpty(VehicleIdType) && !Functions.IsValidType(VehicleIdType))
    //        {
    //            return new Err105("VehicleIdType");
    //        }
    //        return null;
    //    }
    //}

    ///// <summary>
    ///// antwoord op een registratie verzoek
    ///// </summary>
    //[DataContract(Namespace = "https://verwijsindex.shpv.nl/messages/")]
    //public class LinkResponse
    //{
    //    /// <summary>
    //    /// De provider die voor de betaling instaat, verplicht
    //    /// </summary>
    //    [DataMember(Order = 0, IsRequired = true)]
    //    public string ProviderId { get; set; }

    //    /// <summary>
    //    /// kenmerk van de provider, verplicht
    //    /// </summary>
    //    [DataMember(Order = 1, IsRequired = true)]
    //    public string LinkId { get; set; }

    //    /// <summary>
    //    /// ingangsdatum, verplicht
    //    /// </summary>
    //    [DataMember(Order = 2, IsRequired = true)]
    //    public DateTime ValidFrom { get; set; }

    //    /// <summary>
    //    /// geldigheid, verplicht
    //    /// </summary>
    //    [DataMember(Order = 3, IsRequired = true)]
    //    public DateTime ValidUntil { get; set; }
    //}

    /// <summary>
    /// annuleringsverzoek van de provider naar consumer (= garage)
    /// </summary>
    [DataContract(Namespace = "https://verwijsindex.shpv.nl/messages/")]
    public class CancelAuthorisationRequest
    {
        /// <summary>
        /// De provider die voor de betaling instaat, verplicht
        /// </summary>
        [DataMember(Order = 0, IsRequired = true)]
        public string ProviderId { get; set; }

        /// <summary>
        /// Betalingskenmerk van de Provider,verplicht
        /// </summary>
        [DataMember(Order = 1, IsRequired = true)]
        public string PaymentAuthorisationId { get; set; }

        /// <summary>
        /// Voertuigkenteken, verplicht
        /// Redundant maar ter controle, in combinatie met ProviderId en PaymentAuthorisationId
        /// </summary>
        [DataMember(Order = 2, IsRequired = true)]
        public string VehicleId { get; set; }

        /// <summary>
        /// Voertuigkenteken landscode, optioneel
        /// </summary>
        [DataMember(Order = 3, IsRequired = false)]
        public string CountryCode { get; set; }

        /// <summary>
        /// Waarde type van het VehicleId veld, verplicht
        /// </summary>
        [DataMember(Order = 4, IsRequired = false)]
        public string VehicleIdType { get; set; }

        /// <summary>
        /// Gebiedscode van de stad, verplicht
        /// </summary>
        [DataMember(Order = 5, IsRequired = true)]
        public string AreaManagerId { get; set; }

        /// <summary>
        /// Gebiedscode van de parkeerplaats, verplicht
        /// </summary>
        [DataMember(Order = 6, IsRequired = true)]
        public string AreaId { get; set; }

        /// <summary>
        /// De tijd van annuleren
        /// Leeg is volledige annulering en ingevuld is een gedeeltelijke annulering.
        /// </summary>
        [DataMember(Order = 7, IsRequired = false)]
        public DateTime? CancelDateTime { get; set; }

        public Err IsValid()
        {
            VehicleId = VehicleId.StripVehicleId();

            if (string.IsNullOrEmpty(ProviderId))
            {
                return new Err60("ProviderId");
            }
            else if (string.IsNullOrEmpty(PaymentAuthorisationId))
            {
                return new Err60("PaymentAuthorisationId");
            }
            else if (string.IsNullOrEmpty(VehicleId))
            {
                return new Err60("VehicleId");
            }
            else if (string.IsNullOrEmpty(AreaManagerId))
            {
                return new Err60("AreaManagerId");
            }
            else if (string.IsNullOrEmpty(AreaId))
            {
                return new Err60("AreaId");
            }
            else if (!string.IsNullOrEmpty(VehicleIdType) && !Functions.IsValidType(VehicleIdType))
            {
                return new Err105("VehicleIdType");
            }
            return null;
        }
    }

    /// <summary>
    /// antwoord van de garage op het annuleringsverzoek
    /// </summary>
    [DataContract(Namespace = "https://verwijsindex.shpv.nl/messages/")]
    public class CancelAuthorisationResponse
    {
        /// <summary>
        /// De provider die voor de betaling instaat, verplicht
        /// </summary>
        [DataMember(Order = 0, IsRequired = true)]
        public string ProviderId { get; set; }

        /// <summary>
        /// Betalingskenmerk van de Provider,verplicht
        /// </summary>
        [DataMember(Order = 1, IsRequired = true)]
        public string PaymentAuthorisationId { get; set; }

        /// <summary>
        /// Wordt er toegang verleend (of juist niet), optioneel
        /// </summary>
        [DataMember(Order = 2, IsRequired = false)]
        public Nullable<bool> Granted { get; set; }

        ///// <summary>
        ///// De tijd van annuleren
        ///// Leeg is volledige annulering en ingevuld is een gedeeltelijke: die kan afwijken van de gevraagde CancelDateTime.
        ///// </summary>
        //[DataMember(Order = 3, IsRequired = false)]
        //public DateTime? CanceledDateTime { get; set; }

        /// <summary>
        /// Code van de foutmelding of opmerking, optioneel
        /// </summary>
        [DataMember(Order = 4, IsRequired = false)]
        public string RemarkId { get; set; }

        /// <summary>
        /// Foutmelding of opmerking, optioneel
        /// </summary>
        [DataMember(Order = 5, IsRequired = false)]
        public string Remark { get; set; }

        /// <summary>
        /// Bedrag, optioneel
        /// </summary>
        [DataMember(Order = 6, IsRequired = false)]
        public double? Amount { get; set; }

        /// <summary>
        /// BTW over het bedrag, optioneel
        /// </summary>
        [DataMember(Order = 7, IsRequired = false)]
        public double? VAT { get; set; }

        /// <summary>
        /// Aangepaste begintijd, optioneel
        /// </summary>
        [DataMember(Order = 8, IsRequired = false)]
        public DateTime? StartTimeAdjusted { get; set; }

        /// <summary>
        /// Aangepaste eindtijd, optioneel
        /// Leeg is volledige annulering en ingevuld is een gedeeltelijke: die kan afwijken van de gevraagde CancelDateTime.
        /// </summary>
        [DataMember(Order = 9, IsRequired = false)]
        public DateTime? EndTimeAdjusted { get; set; }
    }

    /// <summary>
    /// betalingsverzoek van de provider naar consumer (= garage)
    /// </summary>
    [DataContract(Namespace = "https://verwijsindex.shpv.nl/messages/")]
    public class ActivateAuthorisationRequest
    {
        /// <summary>
        /// De provider die voor de betaling instaat, verplicht
        /// </summary>
        [DataMember(Order = 0, IsRequired = true)]
        public string ProviderId { get; set; }

        /// <summary>
        /// Betalingskenmerk van de Provider,verplicht
        /// </summary>
        [DataMember(Order = 1, IsRequired = true)]
        public string PaymentAuthorisationId { get; set; }

        /// <summary>
        /// Voertuigkenteken, verplicht
        /// Redundant maar ter controle, in combinatie met ProviderId en PaymentAuthorisationId
        /// </summary>
        [DataMember(Order = 2, IsRequired = true)]
        public string VehicleId { get; set; }

        /// <summary>
        /// Voertuigkenteken landscode, optioneel
        /// </summary>
        [DataMember(Order = 3, IsRequired = false)]
        public string CountryCode { get; set; }

        /// <summary>
        /// Waarde type van het VehicleId veld, verplicht
        /// </summary>
        [DataMember(Order = 4, IsRequired = false)]
        public string VehicleIdType { get; set; }

        /// <summary>
        /// Gebiedscode van de stad, verplicht
        /// </summary>
        [DataMember(Order = 5, IsRequired = true)]
        public string AreaManagerId { get; set; }

        /// <summary>
        /// Gebiedscode van de parkeerplaats, verplicht
        /// </summary>
        [DataMember(Order = 6, IsRequired = true)]
        public string AreaId { get; set; }

        /// <summary>
        /// Eindtijd bekend = start + afrekenen, optioneel
        /// </summary>
        [DataMember(Order = 7, IsRequired = false)]
        public DateTime? EndDateTime { get; set; }
    }

    /// <summary>
    /// antwoord van de garage op het betalingsverzoek
    /// </summary>
    [DataContract(Namespace = "https://verwijsindex.shpv.nl/messages/")]
    public class ActivateAuthorisationResponse
    {
        /// <summary>
        /// De provider die voor de betaling instaat, verplicht
        /// </summary>
        [DataMember(Order = 0, IsRequired = true)]
        public string ProviderId { get; set; }

        /// <summary>
        /// Betalingskenmerk van de Provider,verplicht
        /// </summary>
        [DataMember(Order = 1, IsRequired = true)]
        public string PaymentAuthorisationId { get; set; }

        /// <summary>
        /// Wordt er toegang verleend (of juist niet), optioneel
        /// </summary>
        [DataMember(Order = 2, IsRequired = false)]
        public Nullable<bool> Granted { get; set; }

        /// <summary>
        /// ...
        /// </summary>
        [DataMember(Order = 3, IsRequired = false)]
        public DateTime? EndDateTime { get; set; }

        /// <summary>
        /// Code van de foutmelding of opmerking, optioneel
        /// </summary>
        [DataMember(Order = 4, IsRequired = false)]
        public string RemarkId { get; set; }

        /// <summary>
        /// Foutmelding of opmerking, optioneel
        /// </summary>
        [DataMember(Order = 5, IsRequired = false)]
        public string Remark { get; set; }

        /// <summary>
        /// Het te betalen bedrag, optioneel
        /// </summary>
        [DataMember(Order = 6, IsRequired = false)]
        public Nullable<double> Amount { get; set; }

        /// <summary>
        /// BTW over het te betalen bedag, optioneel
        /// </summary>
        [DataMember(Order = 7, IsRequired = false)]
        public Nullable<double> VAT { get; set; }

        /// <summary>
        /// starttijd/ inrijdtijd, optioneel
        /// </summary>
        [DataMember(Order = 8, IsRequired = false)]
        public DateTime? StartDateTimeAdjusted { get; set; }
    }
}
