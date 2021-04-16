using System;
using GalPavyks.Controllers;
using Microsoft.Extensions.Logging;

namespace GalPavyks.Models
{
    
    public interface IMyLogger
    {
       
        void ToFile(string message);
    }
    public class MyLogger : IMyLogger
    {
        private bool PrintToConsole;
        private readonly ILogger<HomeController> log;

        public MyLogger(ILogger<HomeController> _iLogger)
        {
            PrintToConsole = false;
            log = _iLogger;
            ToFile("Logging started");
        }

        public void ToFile(string message)
        {
            string outputMessage = FormatMessage(message);
            log.LogInformation(outputMessage);
            if (PrintToConsole)
                ToConsole(outputMessage);
        }

        private string FormatMessage(string message)
        {
            return GetDate() + "=> " + message;
        }

        private DateTime GetDate()
        {
            return DateTime.Now;
        }
        public void ToConsole(string message)
        {
            Console.WriteLine(message);
        }

        public void SetPrintToConsole(bool enabled)
        {
            PrintToConsole = enabled;
        }
    }
}
