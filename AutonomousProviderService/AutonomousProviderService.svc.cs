using Denion.WebService.Cryptography;
using Denion.WebService.Database;
using Denion.WebService.VerwijsIndex;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel;
using System.Threading;

namespace AutonomousProviderService
{
    [LogBehavior]
    [ServiceBehavior(Name = "AutonomousProvider", Namespace = "https://verwijsindex.shpv.nl/service/")]
    public class AutonomousProviderService : IVerwijsIndex
    {
        public AutonomousProviderService()
        {
            if (Thread.CurrentThread.Name == null)
            {
                Thread.CurrentThread.Name = "AutonomousProviderService";
            }
        }
        
        #region IVerwijsIndex implementation
        PaymentStartResponse IVerwijsIndex.PaymentStart(PaymentStartRequest req)
        {
            PaymentStartResponse res = new PaymentStartResponse();

            res.ProviderId = ConfigurationManager.AppSettings["ProviderId"];
            res.Remark = "";
            res.RemarkId = "";

            try
            {
                //Database.Log("Provider: " + ConfigurationManager.AppSettings["ProviderId"] + "; Received PaymentStart: " + req.VehicleId);
                Database.ProviderLog(ConfigurationManager.AppSettings["ProviderId"], "PaymentStart", req.VehicleId, req.VehicleIdType, req.CountryCode, req.AreaManagerId, req.AreaId);
                SqlCommand cmd = new SqlCommand("select * from testprovider where ID=@ProviderId and VehicleId=@VehicleId");
                cmd.Parameters.Add("@ProviderId", SqlDbType.NVarChar, 200).Value = ConfigurationManager.AppSettings["ProviderId"];
                cmd.Parameters.Add("@VehicleId", SqlDbType.NVarChar, 100).Value = req.VehicleId;
                if (!string.IsNullOrEmpty(req.CountryCode))
                {
                    cmd.CommandText += " and COUNTRYCODE=@CountryCode";
                    cmd.Parameters.Add("@CountryCode", SqlDbType.NVarChar, 10).Value = req.CountryCode;
                }
                if (!string.IsNullOrEmpty(req.VehicleIdType))
                {
                    cmd.CommandText += " and VehicleIdType=@VehicleIdType";
                    cmd.Parameters.Add("@VehicleIdType", SqlDbType.NVarChar, 50).Value = req.VehicleIdType;
                }

                DataTable dt = Database.ExecuteQuery(cmd);

                //DEBUG
                //System.Threading.Thread.Sleep(2000);

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    double Max = (dr["MAXAMOUNT"] != DBNull.Value) ? double.Parse(dr["MAXAMOUNT"].ToString()) : ((req.Amount.HasValue) ? req.Amount.Value : 0.0);
                    DateTime valid = (dr["VALIDUNTIL"] != DBNull.Value) ? DateTime.Parse(dr["VALIDUNTIL"].ToString()) : req.StartDateTime;

                    if (req.StartDateTime > valid)
                    {
                        res.Remark += "Verlopen";
                        res.RemarkId += "1;";
                    }
                    if (req.EndDateTime > valid)
                    {
                        res.Remark += "Geen dekking op einddatum";
                        res.RemarkId += "2;";
                    }
                    if (req.Amount > Max)
                    {
                        res.Remark += "Geen dekking voor bedrag";
                        res.RemarkId += "3;";
                    }

                    res.Token = dr["TOKEN"].ToString();
                    res.TokenType = dr["TOKENTYPE"].ToString();

                    if (string.IsNullOrEmpty(res.Remark))
                    {
                        res.PaymentAuthorisationId = Hashing.CalculateMD5Hash(req.AreaId + req.VehicleId + req.StartDateTime.ToFileTime().ToString());
                        CreateRegistration(req, res.PaymentAuthorisationId);
                    }
                    
                    res.AuthorisationMaxAmount = Max;
                    res.AuthorisationValidUntil = valid;                    
                }
                else
                {
                    res.Remark += "Kenteken niet bekend";
                    res.RemarkId += "0;";
                }
            }
            catch (Exception e)
            {
                res.Remark += e.Message + ";" + e.StackTrace;
                res.RemarkId += "-1;";
            }

            return res;
        }

        PaymentEndResponse IVerwijsIndex.PaymentEnd(PaymentEndRequest req)
        {
            Database.ProviderLog(ConfigurationManager.AppSettings["ProviderId"], "PaymentEnd", req.VehicleId, req.VehicleIdType, req.CountryCode, null, null);
            PaymentEndResponse response = new PaymentEndResponse();
            response.PaymentAuthorisationId = req.PaymentAuthorisationId;
            response.Remark = "AutonomousProvider; No PaymentStop";
            response.RemarkId = "85";

            UpdateRegistration(req);

            return response;
        }

        PaymentCheckResponse IVerwijsIndex.PaymentCheck(PaymentCheckRequest req)
        {
            PaymentCheckResponse res = new PaymentCheckResponse();

            //res.ProviderId = Settings.Default.ProviderId;
            res.Remark = "";
            res.RemarkId = "";

            try
            {
                //Database.Log("Provider: " + ConfigurationManager.AppSettings["ProviderId"] + "; Received PaymentCheck: " + req.VehicleId);
                Database.ProviderLog(ConfigurationManager.AppSettings["ProviderId"], "PaymentCheck", req.VehicleId, req.VehicleIdType, req.CountryCode, req.AreaManagerId, req.AreaId);
                SqlCommand cmd = new SqlCommand("SELECT * FROM [VerwijsIndex].[dbo].[TestProvider] WHERE [VEHICLEID]=@VEHICLEID");

                cmd.Parameters.Add("@PROVIDERID", SqlDbType.NVarChar, 100).Value = ConfigurationManager.AppSettings["ProviderId"];
                cmd.Parameters.Add("@VEHICLEID", SqlDbType.NVarChar, 100).Value = req.VehicleId;

                if (!string.IsNullOrEmpty(req.CountryCode))
                {
                    cmd.CommandText += " and COUNTRYCODE=@COUNTRYCODE";
                    cmd.Parameters.Add("@COUNTRYCODE", SqlDbType.NVarChar, 10).Value = req.CountryCode;
                }

                DataTable dt = Database.ExecuteQuery(cmd);

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    res.Granted = true;
                    res.ProviderId = ConfigurationManager.AppSettings["ProviderId"];
                }
                else
                {
                    res.Remark += "Kenteken niet bekend";
                    res.RemarkId += "0;";
                }
            }
            catch (Exception e)
            {
                res.Remark += e.Message + ";" + e.StackTrace;
                res.RemarkId += "-1;";
            }

            return res;
        }

        StatusResponse IVerwijsIndex.ServiceStatus()
        {
            return Service.ServiceStatus();
        }
        #endregion

        private void CreateRegistration(PaymentStartRequest req, string AuthorisationId)
        {
            if (ConfigurationManager.AppSettings["AVG"] == null || !bool.Parse(ConfigurationManager.AppSettings["AVG"])) return;

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

            //Database.ExecuteScalar(com, true, ConfigurationManager.ConnectionStrings["Denion.WebService.Database.SqlServer.AVG"].ConnectionString);
            DatabaseQueue.Add(new QueueObject(com, true, string.Format(ConfigurationManager.ConnectionStrings["Denion.WebService.Database.SqlServer.AVG"].ConnectionString, Environment.MachineName)));
        }

        private void UpdateRegistration(PaymentEndRequest req)
        {
            if (ConfigurationManager.AppSettings["AVG"] == null || !bool.Parse(ConfigurationManager.AppSettings["AVG"])) return;

            SqlCommand com = new SqlCommand();
            com.CommandText =
                "Update Administration set UPDATED=@UPDATED, ENDDATETIME = @ENDDATETIME where VEHICLEID=@VEHICLEID and COUNTRYCODE=@COUNTRYCODE and AUTHORISATIONID=@AUTHORISATIONID";

            com.Parameters.Add("@UPDATED", SqlDbType.DateTime).Value = DateTime.Now;
            com.Parameters.Add("@ENDDATETIME", SqlDbType.DateTime).Value = req.EndDateTime;

            com.Parameters.Add("@VEHICLEID", SqlDbType.NVarChar, 100).Value = Rijndael.Encrypt(req.VehicleId);
            if (!string.IsNullOrEmpty(req.CountryCode))
                com.Parameters.Add("@COUNTRYCODE", SqlDbType.NVarChar, 10).Value = req.CountryCode;
            else
                com.Parameters.Add("@COUNTRYCODE", SqlDbType.NVarChar, 10).Value = "";

            com.Parameters.Add("@AUTHORISATIONID", SqlDbType.NVarChar, 50).Value = req.PaymentAuthorisationId;

            //Database.ExecuteScalar(com, true, ConfigurationManager.ConnectionStrings["Denion.WebService.Database.SqlServer.AVG"].ConnectionString);
            DatabaseQueue.Add(new QueueObject(com, true, string.Format(ConfigurationManager.ConnectionStrings["Denion.WebService.Database.SqlServer.AVG"].ConnectionString, Environment.MachineName)));
        }

    }
}
