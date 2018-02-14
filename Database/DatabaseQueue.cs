using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;

namespace Denion.WebService.Database
{
    public class QueueObject
    {
        public QueueObject(SqlCommand com)
        {
            this.com = com;
            this.withLog = true;
        }

        public QueueObject(SqlCommand com, bool withLog)
            : this(com)
        {
            this.withLog = withLog;
        }

        public QueueObject(SqlCommand com, bool withLog, string connectionString)
            : this(com, withLog)
        {
            this.connectionString = connectionString;
        }

        public SqlCommand com { get; set; }
        public string connectionString { get; set; }
        public bool  withLog { get; set; }
    }
    public static class DatabaseQueue
    {
        private static Queue _queue = new Queue();
        private static QueueWorker _worker = new QueueWorker();

        //public static string ActivationContext()
        //{
            
        //    System.Diagnostics.StackFrame[] frames = new System.Diagnostics.StackTrace().GetFrames();
        //    //string initialAssembly = (from f in frames
        //    //                          select f.GetMethod().ReflectedType.AssemblyQualifiedName
        //    //                         ).Distinct().Last();
        //    string myNamespace = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
        //    System.Diagnostics.StackFrame myFrame = frames.Last();
        //    Type myType = myFrame.GetMethod().ReflectedType;
        //    System.Diagnostics.StackFrame parentFrame;
        //    Type parentType = null;
        //    myType =  System.Reflection.Assembly.GetExecutingAssembly().GetType();
        //    foreach (System.Diagnostics.StackFrame fr in frames.Reverse())
        //    {
        //        Type t = fr.GetMethod().ReflectedType;
        //        Console.WriteLine(t);
        //        if (!t.Namespace.Equals(myNamespace) && t.Namespace.StartsWith(myNamespace.Split('.')[0]))
        //        {
        //            parentType = t;
        //            parentFrame = fr;
        //            break;
        //        }
        //    }

        //    string rv = "";
        //    if (parentType != null) rv = parentType.Module.FullyQualifiedName;
        //    else rv = "Unknown";
        //    return rv;
        //}

        public static void Add(QueueObject com)
        {
            lock (_queue.SyncRoot)
            {
                //Database.Log(DateTime.Now + " Enqueue: " + Database.PrintCommand(com));
                _queue.Enqueue(com);
            }
        }

        public static int Length
        {
            get
            {
                int rv;
                lock (_queue.SyncRoot)
                {
                    rv = _queue.Count;
                }
                return rv;
            }
        }

        internal class QueueWorker
        {
            private bool _doWork;

            public QueueWorker()
            {
                _doWork = true;
                Thread t = new Thread(new ThreadStart(run));
                t.Name = "QueueWorker";
                t.Start();
            }

            private void run()
            {
                Database.Log(DateTime.Now + " QueueWorker (" + ConfigurationManager.AppSettings["ServiceId"] + ") start");
                do
                {
                    QueueObject qo = null;
                    lock (_queue.SyncRoot)
                    {
                        if (_queue.Count > 0)
                        {
                            qo = (QueueObject)_queue.Dequeue();
                        }
                        else
                        {
                            // nothing to do, release lock and sleep later
                            // blnWork = false;
                        }
                    }

                    if (qo != null)
                    {
                        // do your slow work
                        //Database.Log(DateTime.Now + " Working on: " + Database.PrintCommand(com));
                        //Thread.Sleep(500);
                        
                        if (string.IsNullOrEmpty(qo.connectionString))
                            Database.ExecuteScalar(qo.com, qo.withLog);
                        else
                            Database.ExecuteScalar(qo.com, qo.withLog, qo.connectionString);
                    }
                    else
                    {
                        // nothing to do, just sleep
                        //Database.Log(DateTime.Now + " nothing to do");
                        Thread.Sleep(500);
                    }
                }
                while (_doWork);
            }

            internal void finalize()
            {
                do
                {
                    lock (_queue.SyncRoot)
                    {
                        if (_queue.Count == 0)
                        {
                            _doWork = false;
                        }
                    }

                    if (_doWork)
                        Thread.Sleep(1000);
                }
                while (_doWork);
            }
        }
    }
}
