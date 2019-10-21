using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Denion.WebService.VerwijsIndex
{
    [ServiceContract(Name = "VerwijsIndex", Namespace = "https://verwijsindex.shpv.nl/service/")]
    public interface IVerwijsIndex
    {
        [OperationContract]
        PaymentStartResponse PaymentStart(PaymentStartRequest PaymentStartRequest);

        [OperationContract]
        PaymentEndResponse PaymentEnd(PaymentEndRequest PaymentEndRequest);

        [OperationContract]
        PaymentCheckResponse PaymentCheck(PaymentCheckRequest PaymentCheckRequest);

        [OperationContract]
        StatusResponse ServiceStatus();
    }

    /// <summary>
    /// Verzoek tot inrijden van de Garage
    /// </summary>
    [DataContract(Namespace = "https://verwijsindex.shpv.nl/messages/")]
    public class PaymentStartRequest
    {
        /// <summary>
        /// Gebiedscode van de stad, verplicht
        /// </summary>
        [DataMember(Order = 0, IsRequired = true)]
        public string AreaManagerId { get; set; }

        /// <summary>
        /// Gebiedscode van de parkeerplaats, verplicht
        /// </summary>
        [DataMember(Order = 1, IsRequired = true)]
        public string AreaId { get; set; }

        /// <summary>
        /// voertuigen kenteken, verplicht
        /// </summary>
        [DataMember(Order = 2, IsRequired = true)]
        public string VehicleId { get; set; }

        /// <summary>
        /// voertuig kenteken landscode, optioneel
        /// </summary>
        [DataMember(Order = 3, IsRequired = false)]
        public string CountryCode { get; set; }

        /// <summary>
        /// Berichtkenmerk van de garage, optioneel
        /// </summary>
        [DataMember(Order = 4, IsRequired = false)]
        public string AccessId { get; set; }

        /// <summary>
        /// starttijd/ inrijdtijd, verplicht
        /// </summary>
        [DataMember(Order = 5, IsRequired = true)]
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// eindtijd/ laatste uitrijdtijd, optioneel
        /// </summary>
        [DataMember(Order = 6, IsRequired = false)]
        public Nullable<DateTime> EndDateTime { get; set; }

        /// <summary>
        /// Bedrag, optioneel
        /// </summary>
        [DataMember(Order = 7, IsRequired = false)]
        public Nullable<double> Amount { get; set; }

        /// <summary>
        /// BTW over het bedrag, optioneel
        /// </summary>
        [DataMember(Order = 8, IsRequired = false)]
        public Nullable<double> VAT { get; set; }

        /// <summary>
        /// Kenmerk van het parkeerrecht, optioneel
        /// </summary>
        [DataMember(Order = 9, IsRequired = false)]
        public string Token { get; set; }

        /// <summary>
        /// Waarde type van het VehicleId veld, verplicht
        /// </summary>
        [DataMember(Order = 10, IsRequired = false)]
        public string VehicleIdType { get; set; }

        /// <summary>
        /// Waarde type voor het Token veld, optioneel
        /// </summary>
        [DataMember(Order = 11, IsRequired = false)]
        public string TokenType { get; set; }

        public Err IsValid()
        {
            VehicleId = VehicleId.StripVehicleId();

            if (string.IsNullOrEmpty(VehicleId))
            {
                return new Err60("VehicleId");
            }
            else if (string.IsNullOrEmpty(AreaId))
            {
                return new Err60("AreaId");
            }
            else if (string.IsNullOrEmpty(AreaManagerId))
            {
                return new Err60("AreaManagerId");
            }
            else if (!Functions.IsValidAreaManagerId(AreaManagerId))
            {
                return new Err105("AreaManagerId");
            }
            else if (StartDateTime == DateTime.MinValue)
            {
                return new Err60("StartDateTime");
            }
            else if (EndDateTime.HasValue && EndDateTime.Value < StartDateTime)
            {
                return new Err65();
            }
            else if (!string.IsNullOrEmpty(VehicleIdType) && !Functions.IsValidType(VehicleIdType))
            {
                return new Err105("VehicleIdType");
            }
            else if (!string.IsNullOrEmpty(TokenType) && !Functions.IsValidType(TokenType))
            {
                return new Err105("TokenType");
            }
            return null;
        }
    }

    /// <summary>
    /// Antwoord op het inrijdverzoek
    /// </summary>
    [DataContract(Namespace = "https://verwijsindex.shpv.nl/messages/")]
    public class PaymentStartResponse
    {
        /// <summary>
        /// Provider die toegang verleend, verplicht
        /// </summary>
        [DataMember(Order = 0, IsRequired = true)]
        public string ProviderId { get; set; }

        /// <summary>
        /// Kenmerk van de provider, optioneel
        /// leeg indien geen authorisatie is gegeven
        /// </summary>
        [DataMember(Order = 1, IsRequired = false)]
        public string PaymentAuthorisationId { get; set; }

        /// <summary>
        /// Provider kan maximum bedrag terug melden, optioneel
        /// in geval van netwerk problemen kan van deze informatie gebruik gemaakt worden
        /// </summary>
        [DataMember(Order = 2, IsRequired = false)]
        public Nullable<double> AuthorisationMaxAmount { get; set; }

        /// <summary>
        /// Verlooptijd van de authorisatie, optioneel
        /// </summary>
        [DataMember(Order = 3, IsRequired = false)]
        public Nullable<DateTime> AuthorisationValidUntil { get; set; }

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
        /// Kenmerk van het parkeerrecht, optioneel
        /// </summary>
        [DataMember(Order = 6, IsRequired = false)]
        public string Token { get; set; }

        /// <summary>
        /// Waarde type voor het Token veld, optioneel
        /// </summary>
        [DataMember(Order = 7, IsRequired = false)]
        public string TokenType { get; set; }
    }

    /// <summary>
    /// Verzoek tot uitrijden van de garage
    /// </summary>
    [DataContract(Namespace = "https://verwijsindex.shpv.nl/messages/")]
    public class PaymentEndRequest
    {
        [System.ServiceModel.MessageHeaderAttribute(Namespace = "http://rdw.nl/rpv/1.0")]
        public string PIN;

        /// <summary>
        /// De provider die voor de betaling instaat, verplicht
        /// </summary>
        [DataMember(Order = 0, IsRequired = false)]
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
        [DataMember(Order = 2, IsRequired = false)]
        public string VehicleId { get; set; }

        /// <summary>
        /// Voertuigkenteken landscode, optioneel
        /// </summary>
        [DataMember(Order = 3, IsRequired = false)]
        public string CountryCode { get; set; }

        /// <summary>
        /// Uitrijdtijd, verplicht
        /// </summary>
        [DataMember(Order = 4, IsRequired = true)]
        public DateTime EndDateTime { get; set; }

        /// <summary>
        /// Het te betalen bedrag, optioneel
        /// </summary>
        [DataMember(Order = 5, IsRequired = false)]
        public Nullable<double> Amount { get; set; }

        /// <summary>
        /// BTW over het te betalen bedag, optioneel
        /// </summary>
        [DataMember(Order = 6, IsRequired = false)]
        public Nullable<double> VAT { get; set; }

        /// <summary>
        /// Type van het VehicleID veld, optioneel
        /// </summary>
        [DataMember(Order = 7, IsRequired = false)]
        public string VehicleIdType { get; set; }

        public Err IsValid()
        {
            VehicleId = VehicleId.StripVehicleId();

            if (EndDateTime == DateTime.MinValue)
            {
                return new Err60("EndDateTime");
            }
            else if (string.IsNullOrEmpty(PaymentAuthorisationId))
            {
                return new Err60("PaymentAuthorisationId");
            }
            else if (!string.IsNullOrEmpty(VehicleIdType) && !Functions.IsValidType(VehicleIdType))
            {
                return new Err105("VehicleIdType");
            }
            return null;
        }
    }

    /// <summary>
    /// antwoord op het uitrijdverzoek
    /// </summary>
    [DataContract(Namespace = "https://verwijsindex.shpv.nl/messages/")]
    public class PaymentEndResponse
    {
        /// <summary>
        /// Betalingskenmerk van de provider, verplicht
        /// </summary>
        [DataMember(Order = 0, IsRequired = true)]
        public string PaymentAuthorisationId { get; set; }

        /// <summary>
        /// Code van de foutmelding of opmerking, optioneel
        /// </summary>
        [DataMember(Order = 1, IsRequired = false)]
        public string RemarkId { get; set; }

        /// <summary>
        /// Foutmelding of opmerking, optioneel
        /// </summary>
        [DataMember(Order = 2, IsRequired = false)]
        public string Remark { get; set; }
    }

    /// <summary>
    /// Controleer toegang voor het voertuig
    /// </summary>
    [DataContract(Namespace = "https://verwijsindex.shpv.nl/messages/")]
    public class PaymentCheckRequest
    {
        /// <summary>
        /// Gebiedscode van de stad, verplicht
        /// </summary>
        [DataMember(Order = 0, IsRequired = true)]
        public string AreaManagerId { get; set; }

        /// <summary>
        /// Gebiedscode van de parkeerplaats, optioneel
        /// </summary>
        [DataMember(Order = 1, IsRequired = false)]
        public string AreaId { get; set; }

        /// <summary>
        /// voertuigen kenteken, verplicht
        /// </summary>
        [DataMember(Order = 2, IsRequired = true)]
        public string VehicleId { get; set; }

        /// <summary>
        /// voertuig kenteken landscode, optioneel
        /// </summary>
        [DataMember(Order = 3, IsRequired = false)]
        public string CountryCode { get; set; }

        /// <summary>
        /// controletijd, verplicht
        /// </summary>
        [DataMember(Order = 4, IsRequired = true)]
        public DateTime CheckDateTime { get; set; }

        /// <summary>
        /// Provider, optioneel
        /// </summary>
        [DataMember(Order = 5, IsRequired = false)]
        public string Provider { get; set; }

        /// <summary>
        /// Waarde type van het VehicleId veld, verplicht
        /// </summary>
        [DataMember(Order = 6, IsRequired = false)]
        public string VehicleIdType { get; set; }

        public Err IsValid()
        {
            VehicleId = VehicleId.StripVehicleId();

            if (string.IsNullOrEmpty(VehicleId))
            {
                return new Err60("VehicleId");
            }
            else if (string.IsNullOrEmpty(AreaManagerId))
            {
                return new Err60("AreaManagerId");
            }
            else if (!Functions.IsValidAreaManagerId(AreaManagerId))
            {
                return new Err105("AreaManagerId");
            }
            else if (CheckDateTime == DateTime.MinValue)
            {
                return new Err60("CheckDateTime");
            }
            else if (!string.IsNullOrEmpty(VehicleIdType) && !Functions.IsValidType(VehicleIdType))
            {
                return new Err105("VehicleIdType");
            }
            return null;
        }
    }

    /// <summary>
    /// Antwoord op een controle verzoek
    /// </summary>
    [DataContract(Namespace = "https://verwijsindex.shpv.nl/messages/")]
    public class PaymentCheckResponse
    {
        /// <summary>
        /// Wordt er toegang verleend (of juist niet), optioneel
        /// </summary>
        [DataMember(Order = 0, IsRequired = false)]
        public Nullable<bool> Granted { get; set; }

        /// <summary>
        /// Gebiedscode van de parkeerplaats, optioneel
        /// </summary>
        [DataMember(Order = 1, IsRequired = false)]
        public string AreaId { get; set; }
            
        /// <summary>
        /// Code van de foutmelding of opmerking, optioneel
        /// </summary>
        [DataMember(Order = 2, IsRequired = false)]
        public string RemarkId { get; set; }

        /// <summary>
        /// Foutmelding of opmerking, optioneel
        /// </summary>
        [DataMember(Order = 3, IsRequired = false)]
        public string Remark { get; set; }

        /// <summary>
        /// De provider die voor de betaling instaat, optioneel
        /// </summary>
        [DataMember(Order = 4, IsRequired = false)]
        public string ProviderId { get; set; }
    }

    
}