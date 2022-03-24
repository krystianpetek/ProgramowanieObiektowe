using System;

namespace _27_kontoWBanku_1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /* Utworzenie konta dla dwóch argumentów,
nazwa jest zbyt krótka */
            try
            {
                var account = new Account("   Jo   ", 100.0m);
                Console.WriteLine(account);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Name is to short");
            }
        }
    }
}