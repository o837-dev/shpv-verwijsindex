using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolApp
{
    class DB
    {
        private static SQLiteConnection getConnection()
        {
            string sqlitecon = "Data Source=_test.db;Pooling=true;FailIfMissing=false";
            SQLiteConnection con = new SQLiteConnection(sqlitecon);
            con.Open();
            return con;
        }

        public static void createTable()
        {
            SQLiteConnection con = getConnection();
            using (SQLiteCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name='TIMING'";
                object rv = cmd.ExecuteScalar();
                if (rv == null)
                {
                    cmd.CommandText = string.Format("CREATE TABLE TIMING (what varchar(200), START datetime2, EIND datetime2, DIFF double)");

                    cmd.ExecuteNonQuery();
                }

            }
            con.Close();
        }
        
        public static void insertRecord(string text, DateTime start, DateTime end)
        {            
            SQLiteConnection con = getConnection();
            using (SQLiteCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "INSERT into Timing (WHAT, START, EIND, DIFF) values (@WHAT, @START, @EIND, @DIFF)";

                cmd.Parameters.AddWithValue("@WHAT", text);
                cmd.Parameters.AddWithValue("@START", start);
                cmd.Parameters.AddWithValue("@EIND", end);
                cmd.Parameters.AddWithValue("@DIFF", end.Subtract(start).TotalSeconds);

                cmd.ExecuteNonQuery();
            }
            con.Close();
        }

        public DataTable getData()
        {
            DataTable dt = null; 
            SQLiteConnection con = getConnection();
            using (SQLiteCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "Select ROWID, What, Start, Eind, Diff from Timing";
                DataSet ds = new DataSet();
                cmd.Connection = con;

                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            con.Close();
            return dt;
        }
        public void printData()
        {
            SQLiteConnection con = getConnection();
            using (SQLiteCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "Select ID, Start, Eind, Diff from Timing";

                DbDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                while (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            Debug.WriteLine("Row: " + dr.GetName(i) + ", " + dr.GetValue(i).ToString());
                        }
                    }
                }
            }
            con.Close();
        }
    }
}
