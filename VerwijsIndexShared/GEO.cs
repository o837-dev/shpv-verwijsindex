using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Denion.WebService.VerwijsIndex
{
    public class GEO
    {
        private const string baseSql = "SELECT AreaManagerId, AreaId, Latitude, Longitude, SellingPointId from AreaToGeo ";
        public static GEOinfo FromSellingPoint(string sellingPointId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = baseSql  + " where sellingPointId=@sellingPointId";
            cmd.Parameters.Add("@sellingPointId", SqlDbType.NVarChar, 100).Value = sellingPointId;

            return GetAreaData(cmd);
        }

        public static GEOinfo FromLatLon(decimal lat, decimal lon)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = baseSql + " where Latitude=@Latitude and Longitude=@Longitude";
            cmd.Parameters.Add("@Latitude", SqlDbType.Float).Value = lat;
            cmd.Parameters.Add("@Longitude", SqlDbType.Float).Value = lon;

            return GetAreaData(cmd);
        }

        public static GEOinfo FromArea(string AreaManagerId, string AreaId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = baseSql + " where AreaManagerId=@AreaManagerId and AreaId=@AreaId";
            cmd.Parameters.Add("@AREAMANAGERID", SqlDbType.NVarChar, 200).Value = AreaManagerId;
            cmd.Parameters.Add("@AREAID", SqlDbType.NVarChar, 100).Value = AreaId;

            return GetAreaData(cmd);
        }

        private static GEOinfo GetAreaData(SqlCommand cmd)
        {
            GEOinfo geo = null;
            DataTable dt = Database.Database.ExecuteQuery(cmd);
            if (dt != null && dt.Rows.Count > 0)
            {
                geo = new GEOinfo(dt.Rows[0]);
            }
            return geo;
        }
    }

    public class GEOinfo
    {
        public decimal lat { get; set; }
        public decimal lon { get; set; }

        public string AreaManagerId { get; set; }
        public string AreaId { get; set; }
        public string SellingPointId { get; set; }

        public GEOinfo()
        {
        }

        public GEOinfo(DataRow dr)
        {
            string slat = dr["Latitude"].ToString();
            if (!string.IsNullOrEmpty(slat))
                lat = decimal.Parse(slat);

            string slon = dr["Longitude"].ToString();
            if (!string.IsNullOrEmpty(slon))
                lon = decimal.Parse(slon);

            AreaManagerId = dr["AreaManagerId"] as string;

            AreaId = dr["AreaId"] as string;

            SellingPointId = dr["SellingPointId"] as string;
        }


    }

}
