using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Denion.WebService.Database
{
    public static class Database
    {
        public static object ExecuteScalar(SqlCommand com)
        {
            return ExecuteScalar(com, true);
        }

        public static object ExecuteScalar(SqlCommand com, bool withLog)
        {
            return ExecuteScalar(com, withLog, string.Format(ConfigurationManager.ConnectionStrings["Denion.WebService.Database.SqlServer"].ConnectionString, Environment.MachineName));
        }

        public static object ExecuteScalar(SqlCommand com, bool withLog, string connectionString)
        {
            SqlConnection con = new SqlConnection();
            object rv = null;
            try
            {
                //foreach (SqlParameter parameter in com.Parameters)
                //{
                //    if (parameter.Value == null)
                //    {
                //        parameter.Value = DBNull.Value;
                //    }
                //}

                con.ConnectionString = connectionString;
                con.Open();
                com.Connection = con;
                //if (!com.CommandText.Contains("Log"))
                //{
                //    Log("ExecuteScalar on thread " + System.Threading.Thread.CurrentThread.Name + "." +System.Threading.Thread.CurrentThread.ManagedThreadId);
                //}
                rv = com.ExecuteScalar();
            }
            catch (Exception ex)
            {
                if (withLog)
                {
                    Log(string.Format("DB; EXCEP:{0}; STACK: {1}", ex.Message, ex.StackTrace));
                    Log(PrintExecutableCommand(com));
                }
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }

            return rv;
        }

        public static string LoggingServerConnectionString() {
            if(ConfigurationManager.ConnectionStrings["Denion.WebService.Database.LoggingServer"] == null) {
                return ConfigurationManager.ConnectionStrings["Denion.WebService.Database.SQLServer"].ConnectionString;
            }

            return ConfigurationManager.ConnectionStrings["Denion.WebService.Database.LoggingServer"].ConnectionString;
        }

        public static object ExecuteScalar(string query)
        {
            SqlCommand com = new SqlCommand();
            com.CommandText = query;

            return ExecuteScalar(com);
        }

        /// <summary>
        /// Save incomming and outgoing messages into the database
        ///  insertion is evaluted at runtime based upon the value of the settings table
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="Destination"></param>
        /// <param name="Service"></param>
        /// <param name="Message"></param>
        /// <param name="WebSerivceName"></param>
        public static void MessageLog(string Source, string Destination, string Service, string Message, string WebSerivceName)
        {
            SqlCommand com = new SqlCommand();
            com.CommandText =
                //"if (select convert(bit, [VALUE]) from [SETTINGS] where [PROPERTY] = @WEBSERVICE) = 1 " +
                " insert into Messages (SOURCE, DESTINATION, SERVICE, RECEIVED, MESSAGE) values " +
                "  (@SOURCE, @DESTINATION, @SERVICE, @RECEIVED, @MESSAGE)";
            com.Parameters.Add("@SOURCE", SqlDbType.NVarChar, 200).Value = Source;
            com.Parameters.Add("@DESTINATION", SqlDbType.NVarChar, 200).Value = Destination;
            com.Parameters.Add("@SERVICE", SqlDbType.NVarChar, 200).Value = Service;
            com.Parameters.Add("@RECEIVED", SqlDbType.DateTime).Value = DateTime.Now;
            com.Parameters.Add("@MESSAGE", SqlDbType.NVarChar).Value = Message;
            com.Parameters.Add("@WEBSERVICE", SqlDbType.NVarChar, 200).Value = WebSerivceName;

            //Database.ExecuteScalar(com, true);
            DatabaseQueue.Add(new QueueObject(com, true, LoggingServerConnectionString()));
        }

        public static void Log(string Message)
        {
            SqlCommand com = new SqlCommand();
            com.CommandText = "insert into Log (MESSAGE, RECEIVED) output INSERTED.ID values(@MESSAGE, @RECEIVED)";
            com.Parameters.Add("@MESSAGE", SqlDbType.NVarChar, 4000).Value = Message.Substring(0, Math.Min(Message.Length, 3999));
            com.Parameters.Add("@RECEIVED", SqlDbType.DateTime, 100).Value = DateTime.Now;

            DatabaseQueue.Add(new QueueObject(com, false, LoggingServerConnectionString()));
        }

        public static object GetProperty(string PropertyName)
        {
            SqlCommand com = new SqlCommand();
            com.CommandText = "select [VALUE] from [SETTINGS] where [PROPERTY] = @PROPERTY";
            com.Parameters.Add("@PROPERTY", SqlDbType.NVarChar, 200).Value = PropertyName;

            return ExecuteScalar(com, true);
        }

        public static DataTable ExecuteQuery(string query)
        {
            SqlCommand com = new SqlCommand();
            com.CommandText = query;

            return ExecuteQuery(com);
        }

        public static DataTable ExecuteQuery(string query, string connectionString) {
            SqlCommand com = new SqlCommand();
            com.CommandText = query;

            return ExecuteQuery(com, connectionString);
        }

        public static DataTable ExecuteQuery(SqlCommand com) {
            return ExecuteQuery(com, ConfigurationManager.ConnectionStrings["Denion.WebService.Database.SqlServer"].ConnectionString);
        }

        public static DataTable ExecuteQuery(SqlCommand com, string connectionString)
        {
            SqlConnection con = new SqlConnection();
            DataTable rv = null;
            try
            {
                //foreach (SqlParameter parameter in com.Parameters)
                //{
                //    if (parameter.Value == null)
                //    {
                //        parameter.Value = DBNull.Value;
                //    }
                //}

                con.ConnectionString = string.Format(connectionString, Environment.MachineName);
                con.Open();

                DataSet ds = new DataSet();
                com.Connection = con;

                //Log(PrintExecutableCommand(com));

                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);

                if (ds.Tables.Count > 0)    
                    rv = ds.Tables[0];
            }
            catch (Exception ex)
            {
                Log(string.Format("DB; EXCEP:{0}; STACK: {1}", ex.Message, ex.StackTrace));
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }

            return rv;
        }

        public static DataTable getTables()
        {
            return ExecuteQuery("SELECT name FROM sys.Tables");
        }

        public static DataTable ShowTable(string table)
        {
            return ExecuteQuery("Select * FROM " + table);
        }

        public static DataTable DescTable(string table)
        {
            return ExecuteQuery("Select top 0 * FROM " + table);
        }

        public static DataTable DescTable(string table, string connectionString) {
            return ExecuteQuery("Select top 0 * FROM " + table, connectionString);
        }

        public static int CountRecords(string table)
        {
            object o = ExecuteScalar("Select count(*) FROM " + table);
            if (o != null)
                return int.Parse(o.ToString());
            else
                return -1;
        }

        public static string PrintCommand(SqlCommand com)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("CommandType: {0}\r\n", com.CommandType);
            sb.AppendFormat("CommandText: {0}\r\n", com.CommandText);

            foreach (SqlParameter parameter in com.Parameters)
            {
                sb.AppendFormat("   Parameter {0}, {1}: \"{2}\" ({3})\r\n",
                    parameter.ParameterName,
                    parameter.DbType,
                    parameter.Value,
                    parameter.Value.GetType().Name);
            }
            return sb.ToString();
        }

        public static string PrintExecutableCommand(SqlCommand com)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("--ExecutableCommand--\r\n");
            foreach (SqlParameter parameter in com.Parameters)
            {
                sb.AppendFormat("DECLARE {0} {1}{3} = '{2}';\r\n",
                    parameter.ParameterName,
                    parameter.SqlDbType,
                    parameter.Value,
                    ((parameter.Size > 1) ? "(" + parameter.Size + ")" : ""));
            }
            sb.AppendFormat("\r\n{0}\r\n", com.CommandText);

            return sb.ToString();
        }

        public static void ProviderLog(string serviceId, string what, string vehicleId, string vehicleIdType, string countryCode, string areamanagerId, string areaId)
        {
            SqlCommand com = new SqlCommand();
            com.CommandText = "INSERT INTO [TestProviderLog] "+
                "([WHEN], [SERVICEID], [WHAT], [VEHICLEID], [VEHICLEIDTYPE], [COUNTRYCODE], [AREAMANAGERID], [AREAID]) VALUES " +
                "(@WHEN, @SERVICEID, @WHAT, @VEHICLEID, @VEHICLEIDTYPE, @COUNTRYCODE, @AREAMANAGERID, @AREAID)";
            com.Parameters.Add("@WHEN", SqlDbType.DateTime).Value = DateTime.Now;
            com.Parameters.Add("@SERVICEID", SqlDbType.NVarChar, 100).Value = serviceId;
            com.Parameters.Add("@WHAT", SqlDbType.NVarChar, 200).Value = what;
            com.Parameters.Add("@VEHICLEID", SqlDbType.NVarChar, 100).Value = (object)vehicleId ?? DBNull.Value;
            com.Parameters.Add("@VEHICLEIDTYPE", SqlDbType.NVarChar, 50).Value = (object)vehicleIdType ?? DBNull.Value;
            com.Parameters.Add("@COUNTRYCODE", SqlDbType.NVarChar, 10).Value = (object)countryCode ?? DBNull.Value;
            com.Parameters.Add("@AREAMANAGERID", SqlDbType.NVarChar, 200).Value = (object)areamanagerId ?? DBNull.Value;
            com.Parameters.Add("@AREAID", SqlDbType.NVarChar, 200).Value = (object)areaId ?? DBNull.Value;

            DatabaseQueue.Add(new QueueObject(com, true));
        }
    }
}
