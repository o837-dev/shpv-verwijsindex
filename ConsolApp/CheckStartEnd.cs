using Denion.WebService.VerwijsIndex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolApp
{
    class CheckStartEnd
    {
        public CheckStartEnd()
        {
            VerwijsIndexClient clnt = new VerwijsIndexClient();
            DateTime now = DateTime.Now;

            PaymentCheckRequest req = new PaymentCheckRequest()
            {
                AreaId = "GRV009WP",
                AreaManagerId = "363",
                CheckDateTime = now,
                CountryCode = "NL",
                VehicleId = "VB196N"
            };
            PaymentCheckResponse res = clnt.PaymentCheck(req);

            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Res: " + res.Granted);
            
            PaymentStartRequest reqs = new PaymentStartRequest()
            {
                AreaId = "NO_PARKING",
                AreaManagerId = "666",
                StartDateTime = now,
                CountryCode = "NL",
                VehicleId = "HARM01"
            };
            DateTime ready = DateTime.Now;
            PaymentStartResponse ress = clnt.PaymentStart(reqs);
            DB.insertRecord(clnt.Endpoint.Address.ToString(), now, ready);

            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Ress: " + ress.PaymentAuthorisationId);

            PaymentEndRequest reqt = new PaymentEndRequest()
            {
                //Amount
                CountryCode = reqs.CountryCode,
                EndDateTime = now,
                PaymentAuthorisationId = ress.PaymentAuthorisationId,
                ProviderId = ress.ProviderId,
                //VAT
                VehicleId = reqs.VehicleId
            };
            PaymentEndResponse rest = clnt.PaymentEnd(reqt);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Ress: " + rest.Remark);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("Press any key...");
            Console.ReadKey();
        }
    }
}
