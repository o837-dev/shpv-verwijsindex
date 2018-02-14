using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace Denion.WebService.VerwijsIndex
{

    /// <summary>
    /// List of Link
    /// </summary>
    public class Links : List<Link>
    {
        /// <summary>
        /// Constructor, converts a DataTable
        /// </summary>
        /// <param name="dt">DataTable containing providers</param>
        public Links(DataTable dt)
        {
            //list = new List<Link>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Add(new Link(dr));
                }
            }
        }
    }

    /// <summary>
    /// Holds information about a link
    /// </summary>
    public class Link
    {
        /// <summary>
        /// database link Id
        /// </summary>
        public int ID { get; set; }

        public string VEHICLEID { get; set; }

        public string COUNTRYCODE { get; set; }

        public string PROVIDERID { get; set; }


        public double? AUTHORISATIONTHRESHOLD { get; set; }

        public DateTime STARTDATE { get; set; }

        public DateTime ENDDATE { get; set; }

        public string TOKEN { get; set; }

        /// <summary>
        /// holds, area information, optionaly
        /// </summary>
        public string AREAID { get; set; }

        public string VEHICLEIDTYPE { get; set; }

        public string TOKENTYPE { get; set; }


        public Link(object objId)
        {
            ID = int.Parse(objId.ToString());
        }

        public Link(object objId, object objArea)
        {
            ID = int.Parse(objId.ToString());
            AREAID = objArea.ToString();
        }

        public Link(DataRow dr)
        {
            DataColumnCollection col = dr.Table.Columns;

            if (col.Contains("ID"))
                ID = (int)dr["ID"];

            if (col.Contains("VEHICLEID"))
                VEHICLEID = dr["VEHICLEID"].ToString();

            if (col.Contains("COUNTRYCODE"))
                COUNTRYCODE = dr["COUNTRYCODE"].ToString();

            if (col.Contains("PROVIDERID"))
                PROVIDERID = dr["PROVIDERID"].ToString();

            if (col.Contains("AUTHORISATIONTHRESHOLD"))
            {
                double authorisationthreshold;
                double.TryParse(dr["AUTHORISATIONTHRESHOLD"].ToString(), out authorisationthreshold);
                AUTHORISATIONTHRESHOLD = authorisationthreshold;
            }
            if (col.Contains("STARTDATE"))
            {
                DateTime start;
                DateTime.TryParse(dr["STARTDATE"].ToString(), out start);
                STARTDATE = start;
            }
            if (col.Contains("ENDDATE"))
            {
                DateTime endate;
                DateTime.TryParse(dr["ENDDATE"].ToString(), out endate);
                ENDDATE = endate;
            }
            if (col.Contains("TOKEN"))
                TOKEN = dr["TOKEN"].ToString();

            if (col.Contains("AREAID"))
                AREAID = dr["AREAID"].ToString();

            if (col.Contains("VEHICLEIDTYPE"))
                VEHICLEIDTYPE = dr["VEHICLEIDTYPE"].ToString();

            if (col.Contains("TOKENTYPE"))
                TOKENTYPE = dr["TOKENTYPE"].ToString();
        }
    }
}