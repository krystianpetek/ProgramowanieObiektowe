﻿namespace Interfejsy_8._0
{
    internal class NewConsoleLogger : OldConsoleLogger, ILoggerOLD
    {
        public void Warn(string message) => Console.WriteLine("warn: " + message);
    }
}