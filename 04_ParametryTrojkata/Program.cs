using System;
using System.Globalization;

namespace _04_ParametryTrojkata
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            string[] wejscie = Console.ReadLine().Split("; ");
            double a, b, c;
            double.TryParse(wejscie[0], out a);
            double.TryParse(wejscie[1], out b);
            double.TryParse(wejscie[2], out c);

            if (a < 0 || b < 0 || c < 0)
            {
                Console.WriteLine($"Błędne dane. Długości boków muszą być dodatnie!");
                return;
            }
            // i wykonaj obliczenia
        }
    }
}
