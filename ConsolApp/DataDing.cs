using Denion.WebService.VerwijsIndex;
using System;
using System.Threading;

namespace ConsolApp
{
    class DataDing
    {
        public DataDing()
        {
            DB.createTable();

            System.Collections.Generic.List<Thread> threads = new System.Collections.Generic.List<Thread>();

            for (int i = 0; i < 3; i++)
            {
                worker w = new worker("Thread" + i);
                Thread t = new Thread(new ThreadStart(w.doWork));
                t.Name = w.Name;
                t.Start();
                threads.Add(t);
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            Console.ReadKey();
        }
    }

    class worker
    {
        public string Name { get; set; }

        public worker(string name)
        {
            Name = name;
        }

        public void doWork()
        {
            DateTime now = DateTime.Now;
            VerwijsIndexClient clnt = new VerwijsIndexClient();
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
            DB.insertRecord("[" + Name + "]" + clnt.Endpoint.Address.ToString(), now, ready);
        }
    }
}
