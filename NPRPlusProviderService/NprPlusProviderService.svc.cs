using Denion.WebService.Cryptography;
using Denion.WebService.Database;
using Denion.WebService.VerwijsIndex;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace NPRPlusProviderService
{
    [LogBehavior]
    [ServiceBehavior(Name = "Registration", Namespace = "http://rdw.nl/rpv/1.0")]
    public class NprPlusProviderService : INprPlus
    {
        public ActivateEnrollRequestResponse ActivateEnroll(ActivateEnrollRequestRequest request)
        {
            ActivateEnrollRequestResponseData data = new ActivateEnrollRequestResponseData();
            ActivateEnrollRequestResponseError error = null;

            data.AuthorisationMaxAmount = -0.01;
            data.AuthorisationValidUntil = DateTime.Now.AddHours(1);
            data.PaymentAuthorisationId = Guid.NewGuid().ToString();
            data.ProviderId = ConfigurationManager.AppSettings["ProviderId"];
            //data.Remark = "string";
            //data.RemarkId = "string";
            //data.Token = "string";
            //data.TokenType = "string";

            CreateRegistration(request.ActivateEnrollRequestRequestData, data.PaymentAuthorisationId);

            return new ActivateEnrollRequestResponse(data, error);
        }

        public RevokedByThirdPartyRequestResponse RevokedByThirdParty(RevokedByThirdPartyRequestRequest request)
        {
            RevokedByThirdPartyRequestResponseData data = new RevokedByThirdPartyRequestResponseData();
            RevokedByThirdPartyRequestResponseError error = null;
            
            //data.RemarkId = "string";
            //data.Remark = "string";
            data.PaymentAuthorisationId = request.RevokedByThirdPartyRequestRequestData.PaymentAuthorisationId;

            UpdateRegistration(request.RevokedByThirdPartyRequestRequestData);
            return new RevokedByThirdPartyRequestResponse(data, error);
        }

        private void CreateRegistration(ActivateEnrollRequestRequestData req, string AuthorisationId)
        {
            if (ConfigurationManager.AppSettings["AVG"].ToLower() == "false")
                return;

            SqlCommand com = new SqlCommand();
            com.CommandText =
                "insert into Administration (CREATED, AREAMANAGERID, AREAID, VEHICLEID, COUNTRYCODE, ACCESSID, AUTHORISATIONID, STARTDATETIME) values " +
                "  (@CREATED, @AREAMANAGERID, @AREAID, @VEHICLEID, @COUNTRYCODE, @ACCESSID, @AUTHORISATIONID, @STARTDATETIME)";
            com.Parameters.Add("@CREATED", SqlDbType.DateTime).Value = DateTime.Now;
            com.Parameters.Add("@AREAMANAGERID", SqlDbType.NVarChar, 200).Value = req.AreaManagerId;
            com.Parameters.Add("@AREAID", SqlDbType.NVarChar, 200).Value = req.AreaId;
            com.Parameters.Add("@VEHICLEID", SqlDbType.NVarChar, 100).Value = Rijndael.Encrypt(req.VehicleId);
            if (!string.IsNullOrEmpty(req.CountryCode))
                com.Parameters.Add("@COUNTRYCODE", SqlDbType.NVarChar, 10).Value = req.CountryCode;
            else
                com.Parameters.Add("@COUNTRYCODE", SqlDbType.NVarChar, 10).Value = "";
            if (!string.IsNullOrEmpty(req.AccessId))
                com.Parameters.Add("@ACCESSID", SqlDbType.NVarChar, 50).Value = req.AccessId;
            else
                com.Parameters.Add("@ACCESSID", SqlDbType.NVarChar, 50).Value = "";
            com.Parameters.Add("@AUTHORISATIONID", SqlDbType.NVarChar, 50).Value = AuthorisationId;
            com.Parameters.Add("@STARTDATETIME", SqlDbType.DateTime).Value = req.StartDateTime;

            DatabaseQueue.Add(new QueueObject(com, true, string.Format(ConfigurationManager.ConnectionStrings["Denion.WebService.Database.SqlServer.AVG"].ConnectionString, Environment.MachineName)));
        }

        private void UpdateRegistration(RevokedByThirdPartyRequestRequestData req)
        {
            if (ConfigurationManager.AppSettings["AVG"].ToLower() == "false")
                return;

             SqlCommand com = new SqlCommand();
            com.CommandText =
                "Update Administration set UPDATED=@UPDATED, ENDDATETIME=@ENDDATETIME where VEHICLEID=@VEHICLEID and COUNTRYCODE=@COUNTRYCODE and AUTHORISATIONID=@AUTHORISATIONID";

            com.Parameters.Add("@UPDATED", SqlDbType.DateTime).Value = DateTime.Now;
            com.Parameters.Add("@ENDDATETIME", SqlDbType.DateTime).Value = req.EndDateTime;

            com.Parameters.Add("@VEHICLEID", SqlDbType.NVarChar, 100).Value = Rijndael.Encrypt(req.VehicleId);
            if (!string.IsNullOrEmpty(req.CountryCode))
                com.Parameters.Add("@COUNTRYCODE", SqlDbType.NVarChar, 10).Value = req.CountryCode;
            else
                com.Parameters.Add("@COUNTRYCODE", SqlDbType.NVarChar, 10).Value = "";

            com.Parameters.Add("@AUTHORISATIONID", SqlDbType.NVarChar, 50).Value = req.PaymentAuthorisationId;

            DatabaseQueue.Add(new QueueObject(com, true, string.Format(ConfigurationManager.ConnectionStrings["Denion.WebService.Database.SqlServer.AVG"].ConnectionString, Environment.MachineName)));
        }
    }
}
