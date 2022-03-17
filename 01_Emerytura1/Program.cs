using System;

namespace _01_Emerytura1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string nazwisko = Console.ReadLine();
            int wiek = int.Parse(Console.ReadLine());
            int wiekEmerytalny = int.Parse(Console.ReadLine());

            Console.WriteLine($"Witaj, {nazwisko}!");
            if (wiek < 0 || wiekEmerytalny < 0)
            {
                Console.WriteLine($"Wiek nie może być ujemny!");
            }
            else
            if (wiekEmerytalny <= wiek)
            {
                Console.WriteLine("Jesteś emerytem!");
            }
            else
            {
                Console.WriteLine($"Do emerytury brakuje Ci {wiekEmerytalny - wiek} lat!");
            }
        }
    }
}