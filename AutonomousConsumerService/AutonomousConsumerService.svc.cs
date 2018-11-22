using Denion.WebService.Database;
using Denion.WebService.VerwijsIndex;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace AutonomousConsumerService
{
    [LogBehavior]
    [ServiceBehavior(Name = "AutonomousConsumer", Namespace = "https://verwijsindex.shpv.nl/service/")]
    public class AutonomousConsumerService : IConsumer
    {
        public ActivateAuthorisationResponse ActivateAuthorisation(ActivateAuthorisationRequest req)
        {
            ActivateAuthorisationResponse res = new ActivateAuthorisationResponse();
            res.Remark = "";
            res.RemarkId = "";
            try
            {
                Database.ProviderLog(ConfigurationManager.AppSettings["ServiceId"], "ActivateAuthorisation", req.VehicleId, req.VehicleIdType, req.CountryCode, req.AreaManagerId, req.AreaId);
                
                SqlCommand cmd = new SqlCommand("select * from testconsumer where AREAMANAGERID=@AreaManagerId and AREAID=@AreaId and VehicleId=@VehicleId");
                cmd.Parameters.Add("@AreaManagerId", SqlDbType.NVarChar, 200).Value = req.AreaManagerId;
                cmd.Parameters.Add("@AreaId", SqlDbType.NVarChar, 100).Value = req.AreaId;
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


                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    res.Granted = true;
                    res.PaymentAuthorisationId = Guid.NewGuid().ToString();

                    if (dr["AMOUNT"] != DBNull.Value)
                        res.Amount = Double.Parse(dr["AMOUNT"].ToString());

                    if (dr["VAT"] != DBNull.Value)
                        res.VAT = Double.Parse (dr["VAT"].ToString());

                    if (dr["ENDDATETIME"] != DBNull.Value)
                        res.EndDateTime = DateTime.Parse(dr["ENDDATETIME"].ToString());

                    if (dr["STARTDATETIME"] != DBNull.Value)
                        res.StartDateTimeAdjusted = DateTime.Parse(dr["STARTDATETIME"].ToString());
                }
                else
                {
                    res.Granted = false;
                }

                res.ProviderId = req.ProviderId;

                //res.Amount = null;
                //res.EndDateTime = null;
                //res.Remark = null;
                //res.RemarkId = null;
                //res.VAT = null;
            }
            catch (Exception ex)
            {
                res.Remark = ex.Message + "; " + ex.StackTrace;
                res.RemarkId = "-1";
            }
            return res;
        }

        public CancelAuthorisationResponse CancelAuthorisation(CancelAuthorisationRequest req)
        {
            CancelAuthorisationResponse res = new CancelAuthorisationResponse();
            res.Remark = "";
            res.RemarkId = "";
            try
            {
                Database.ProviderLog(ConfigurationManager.AppSettings["ServiceId"], "CancelAuthorisation", req.VehicleId, req.VehicleIdType, req.CountryCode, req.AreaManagerId, req.AreaId);

                SqlCommand cmd = new SqlCommand("select * from testconsumer where AREAMANAGERID=@AreaManagerId and AREAID=@AreaId and VehicleId=@VehicleId");
                cmd.Parameters.Add("@AreaManagerId", SqlDbType.NVarChar, 200).Value = req.AreaManagerId;
                cmd.Parameters.Add("@AreaId", SqlDbType.NVarChar, 100).Value = req.AreaId;
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

                if (dt != null && dt.Rows.Count > 0)
                {
                    res.Granted = true;
                    //res.CanceledDateTime = req.CancelDateTime;
                    res.EndTimeAdjusted = req.CancelDateTime;

                    String unparsedAmount = dt.Rows[0]["AMOUNT"] != null? Convert.ToString(dt.Rows[0]["AMOUNT"]):"0";
                    String unparsedVAT = dt.Rows[0]["VAT"] != null ? Convert.ToString(dt.Rows[0]["VAT"]) : "0";

                    res.Amount = Convert.ToDouble(unparsedAmount.Equals("")? "0": unparsedAmount);
                    res.VAT = Convert.ToDouble(unparsedVAT.Equals("")? "0": unparsedVAT);
                }
                else
                {
                    res.Granted = false;
                }

                res.PaymentAuthorisationId = req.PaymentAuthorisationId;
                res.ProviderId = req.ProviderId;
            }
            catch (Exception ex)
            {
                res.Remark = ex.Message + "; " + ex.StackTrace;
                res.RemarkId = "-1";
            }
            return res;
        }
    }
}
