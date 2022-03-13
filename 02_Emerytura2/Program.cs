using System;

namespace _02_Emerytura2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nazwisko = Console.ReadLine();
            int wiek = int.Parse(Console.ReadLine());
            int wiekEmerytalny = int.Parse(Console.ReadLine());

            Console.WriteLine($"Witaj, {nazwisko}!");
            if (wiek < 0 || wiekEmerytalny < 0)
            {
                Console.WriteLine($"Wiek nie może być ujemny!");
            }
            else if (wiekEmerytalny <= wiek)
            {
                Console.WriteLine("Jesteś emerytem!");
            }
            else
            {
                Console.Write($"Do emerytury brakuje Ci {wiekEmerytalny - wiek}");

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
