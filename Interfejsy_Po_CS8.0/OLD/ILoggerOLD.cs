namespace Interfejsy_8._0
{
    internal interface ILoggerOLD
    {
        void Info(string message);

        void Error(string message);

        void Warn(string message) => Console.WriteLine("warn default: " + message);
    }
}