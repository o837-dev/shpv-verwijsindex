using Denion.WebService.VerwijsIndex;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolApp
{
    class DataTableConvertorDing
    {
        public DataTableConvertorDing()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ID", typeof(int)));
            dt.Columns.Add(new DataColumn("AREAid", typeof(string)));
            dt.Rows.Add(new object[] { 1, "2" });
            Links l = new Links(dt);
        }
    }
}
