using System;

namespace _03_Emerytura3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string wejscie = Console.ReadLine();
            string[] split = wejscie.Split(" ");
            string nazwisko = split[0];
            int wiek = int.Parse(split[1]);
            int wiekEmerytalny = int.Parse(split[2]);

            if (wiek < 0 || wiekEmerytalny < 0)
            {
                Console.Write($"Wiek nie może być ujemny! ");
            }
            else if (wiekEmerytalny <= wiek)
            {
                Console.Write($"Witaj emerycie {nazwisko}!");
            }
            else
            {
                Console.Write($"Witaj {nazwisko}! Do emerytury brakuje Ci {wiekEmerytalny - wiek}");

                if (wiekEmerytalny - wiek == 1)
                {
                    Console.Write($" rok!");
                }
                else if (((wiekEmerytalny - wiek) % 10) > 1 && ((wiekEmerytalny - wiek) % 10) < 5)
                {
                    Console.Write($" lata!");
                }
                else
                {
                    Console.Write($" lat!");
                }

            }
        }
    }
}
