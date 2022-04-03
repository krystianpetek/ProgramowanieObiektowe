namespace Interfejsy_8._0
{
    internal class OldConsoleLogger : ILoggerOLD
    {
        public void Error(string message)
        {
            Console.WriteLine($"error: {message}");
        }

        public void Info(string message)
        {
            Console.WriteLine($"info: {message}");
        }
    }
}