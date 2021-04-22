using System;
using System.IO;

namespace GalPavyks.Models
{
    

    public class MyLogger : IMyLogger
    {
        private bool _printToConsole;
        
        public MyLogger()
        {
            _printToConsole = false;
          // ToFile("Logging started");
        }

        public void ToFile(string message)
        {
            StreamWriter w = File.AppendText("mylog.txt");
            string outputMessage = FormatMessage(message);
            w.WriteLine(outputMessage);
            w.Close();
            if (_printToConsole)
                ToConsole(message);
        }

        private static string FormatMessage(string message)
        {
            return GetDate() + "=> " + message;
        }

        private static DateTime GetDate()
        {
            return DateTime.Now;
        }
        public void ToConsole(string message)
        {
            string outputMessage = FormatMessage(message);
            Console.WriteLine(outputMessage);
        }

        public void SetPrintToConsole(bool enabled)
        {
            _printToConsole = enabled;
        }
    }
}
