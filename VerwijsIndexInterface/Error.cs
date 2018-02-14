using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Denion.WebService.VerwijsIndex
{
    public class Err
    {
        public Err(string id, string msg)
        {
            RemarkId = id;
            Remark = msg;
        }

        public string RemarkId { get; set; }
        
        public string Remark { get; set; }
    }

    public class Err60 : Err
    {
        private const String msg = "Required field '{0}' null or empty";

        public Err60(string field)
            : base("60", String.Format(msg, field))
        { }
    }
    
    public class Err65 : Err
    {
        private const String msg = "EndTime Before StartTime";

        public Err65()
            : base("65", msg)
        { }

    }

    public class Err105 : Err
    {
        private const String msg = "Value specified in field '{0}' is not valid";

        public Err105(string field)
            : base("105", String.Format(msg, field))
        { }
    }
}