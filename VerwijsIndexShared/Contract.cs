using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Denion.WebService.VerwijsIndex
{

    public class Contracts : List<Contract>
    {
        public Contracts(DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Add(Data.DataRowToObject<Contract>(dr));
                }
            }
        }
    }

    public class Contract : IComparable
    {
        public int ID { get; set; }
        public string AREAMANAGERID { get; set; }
        public int PROVIDERID2 { get; set; }
        public int PRIORITY { get; set; }
        public string SENDLINKREQUEST { get; set; }
        public string LINKTYPE { get; set; }
        public bool RELAYINDICATOR { get; set; }
        public bool NPRREGISTRATION { get; set; }
        public DateTime STARTDATE { get; set; }
        public DateTime ENDDATE { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Contract otherContract = obj as Contract;
            if (otherContract != null)
                return this.PRIORITY.CompareTo(otherContract.PRIORITY);
            else
                throw new ArgumentException("Object is not a Contract");
        }
    }
}
