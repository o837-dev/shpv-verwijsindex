using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Denion.WebService.VerwijsIndex
{
    public static class Log
    {
        private static TextWriter textWriter = TextWriter.Synchronized(File.AppendText(@"C:\temp\log.txt"));

        public static void WriteLine(string text)
        {
            textWriter.WriteLine(DateTime.Now + ";"+ text);
            textWriter.Flush();
        }
    }
}
