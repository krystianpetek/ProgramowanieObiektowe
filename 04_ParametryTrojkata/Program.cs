using System;
using System.Globalization;

namespace _04_ParametryTrojkata
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            string[] wejscie = Console.ReadLine().Split("; ");
            double a, b, c;
            double.TryParse(wejscie[0], out a);
            double.TryParse(wejscie[1], out b);
            double.TryParse(wejscie[2], out c);

            if (a <= 0 || b <= 0 || c <= 0)
            {
                Console.WriteLine($"Błędne dane. Długości boków muszą być dodatnie!");
                return;
            }

            if (a + c < b || a + b < c || b + c < a)
            {
                Console.WriteLine($"Błędne dane. Trójkąta nie można zbudować!");
                return;
            }
            double obwod = a + b + c;
            Console.WriteLine($"obwód = {Math.Round(obwod, 2):F2}");
            double p = (a + b + c) / 2;
            double pole = p * (p - a) * (p - b) * (p - c);
            pole = Math.Sqrt(pole);
            Console.WriteLine($"pole = {Math.Round(pole, 2):F2}");

            if ((a * a + b * b) == c * c || (a * a + c * c) == b * b || (b * b + c * c) == a * a)
                Console.WriteLine($"trójkąt jest prostokątny");
            else if ((a * a + b * b) < c * c || (a * a + c * c) < b * b || (b * b + c * c) < a * a)
                Console.WriteLine($"trójkąt jest rozwartokątny");
            else if ((a * a + b * b) > c * c || (a * a + c * c) > b * b || (b * b + c * c) > a * a)
                Console.WriteLine($"trójkąt jest ostrokątny");

            if (a == b && b == c && c == a)
                Console.WriteLine($"trójkąt równoboczny");
            else if (a == b || b == c || a == c)
                Console.WriteLine($"trójkąt równoramienny");
        }
    }
}