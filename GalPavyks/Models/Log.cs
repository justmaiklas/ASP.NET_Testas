using System;
using GalPavyks.Controllers;
using Microsoft.Extensions.Logging;

namespace GalPavyks.Models
{
    

    public class MyLogger : IMyLogger
    {
        private bool printToConsole;
        private readonly ILogger<HomeController> _log;

        public MyLogger(ILogger<HomeController> iLogger)
        {
            printToConsole = false;
            _log = iLogger;
            ToFile("Logging started");
        }

        public void ToFile(string message)
        {
            string outputMessage = FormatMessage(message);
            _log.LogInformation(outputMessage);
            if (printToConsole)
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
            printToConsole = enabled;
        }
    }
}
