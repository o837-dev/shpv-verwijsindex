using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Denion.WebService.Database
{
    public class Timing
    {
        public Timing(string ServiceName, string SourceName, string DesitinationName)
        {
            _start = DateTime.Now;
            Service = ServiceName;
            Source = SourceName;
            Destination = DesitinationName;
        }

        public string Source { get; set; }
        public string Destination { get; set; }
        public string Service { get; set; }

        private DateTime _start;
        public DateTime Start { get { return _start; } }
        
        private DateTime _stop;
        public DateTime Stop { get { return _stop; } }
        public void Finish()
        {
            _stop = DateTime.Now;
            Save();
        }

        public TimeSpan Consumed {
            get { 
                return Stop.Subtract(Start);
            }
        }

        private void Save()
        {
            SqlCommand com = new SqlCommand();
            com.CommandText = "insert into Timing (SOURCE, DESTINATION, SERVICE, START, STOP, CONSUMED) values(@SOURCE, @DESTINATION, @SERVICE, @START, @STOP, @CONSUMED)";
            com.Parameters.Add("@SOURCE", SqlDbType.NVarChar, 200).Value = Source;
            com.Parameters.Add("@DESTINATION", SqlDbType.NVarChar, 200).Value = Destination;
            com.Parameters.Add("@SERVICE", SqlDbType.NVarChar, 200).Value = Service;

            com.Parameters.Add("@START", SqlDbType.DateTime).Value = Start;
            com.Parameters.Add("@STOP", SqlDbType.DateTime).Value = Stop;
            com.Parameters.Add("@CONSUMED", SqlDbType.Int).Value = Consumed.TotalMilliseconds;

            //Database.ExecuteScalar(com, true);
            DatabaseQueue.Add(new QueueObject(com, true));
        }
    }

}
