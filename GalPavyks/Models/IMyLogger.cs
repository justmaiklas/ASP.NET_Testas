namespace GalPavyks.Models
{
    public interface IMyLogger
    {
        void ToFile(string message);
        void ToConsole(string message);
        void SetPrintToConsole(bool enabled);
    }
}