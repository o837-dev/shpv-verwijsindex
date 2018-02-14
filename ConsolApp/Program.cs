using System;
using System.Threading;
using Denion.WebService.VerwijsIndex;
using System.Diagnostics;
using System.ServiceModel;
using System.Data;
using Denion.WebService.Beheer;
using Denion.WebService.Database;

namespace ConsolApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //new ClassDesc();
            new NPRPlusTest();
            Environment.Exit(-2);
            //Debug.WriteLine(Denion.WebService.Cryptography.Rijndael.Decrypt("Pc44Um+B9AzSEwA5ANNkxQ=="));

            //DoesWSMeetSpec d = new DoesWSMeetSpec();
            //checkDing();
            //DateTime LinkDt1 = new DateTime(2017, 01, 18, 15, 00, 00);
            //DateTime LinkDt2 = new DateTime(2017, 01, 20, 14, 00, 00);
            //DateTimeRange linkR = new DateTimeRange(LinkDt1, LinkDt2);

            //DateTime ReqDt1 = new DateTime(2017, 01, 20, 14, 00, 00);
            //DateTime ReqDt2 = new DateTime(2017, 01, 21, 15, 00, 00);
            //DateTimeRange ReqR = new DateTimeRange(ReqDt1, ReqDt2);
            //bool check  = linkR.Intersects(ReqR);
        }

        private static void checkDing()
        {
            localInit();
            //Denion.WebService.RDWRight r = Denion.WebService.Functions.RDWEnrollRight("3", "02065", "CENTRUM", "BETAALDP", "HARM01", DateTime.Now, null, "NL", null, null, "HtH console call lalalalallalalalallalalalalallalalala");
            //Denion.WebService.Functions.RDWRevokeRight("3", r.PSRightId, DateTime.Now);
            Denion.WebService.VerwijsIndex.LinkRegistrationRequest req = new LinkRegistrationRequest
            {
                VehicleId = "Harm03",
                CountryCode = null,
                VehicleIdType = "LICENSE_PLATE",

                ValidFrom = new DateTime(2017, 01, 21, 15, 00, 00),
                ValidUntil = new DateTime(2017, 01, 25, 14, 00, 00),

                ProviderId = "5",
                AreaId = null,
                LinkId = "1"
            };
            Denion.WebService.VerwijsIndex.Err err = req.IsValid();
            if (err == null)
            {
                Denion.WebService.VerwijsIndex.LinkRegistrationResponse res = Denion.WebService.VerwijsIndex.DatabaseFunctions.VerifyLink(req);
                Debug.WriteLine(res.Remark);
            }
            else
            {
                Debug.WriteLine(err.Remark);
            }
        }



        private static void localInit()
        {
            DataTable dt = Database.ExecuteQuery("Select Type FROM Types");
            if (dt != null && dt.Rows.Count > 0)
            {
                lock (Functions.ValidTypes)
                {
                    Functions.ValidTypes.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {
                        Functions.ValidTypes.Add(dr["Type"].ToString().ToUpper());
                    }
                }
            }

            dt = Database.ExecuteQuery("Select ID FROM AreaManager");
            if (dt != null && dt.Rows.Count > 0)
            {
                lock (Functions.ValidAreaManagerIds)
                {
                    Functions.ValidAreaManagerIds.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {
                        Functions.ValidAreaManagerIds.Add(dr["ID"].ToString().ToUpper());
                    }
                }
            }
        }
    }
}
