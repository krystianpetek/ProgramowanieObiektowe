using System;

namespace _06_ObjetoscStozka
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] wejscie = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            _ = long.TryParse(wejscie[0], out long R);
            _ = long.TryParse(wejscie[1], out long L);

            if (R < 0 || L < 0)
            {
                Console.WriteLine($"ujemny argument");
                return;
            }
            if (R > L)
            {
                Console.WriteLine($"obiekt nie istnieje");
                return;
            }

            decimal H = (decimal)Math.Sqrt((L * L) - (R * R));
            decimal Pp = (decimal)Math.PI * (decimal)R * R;
            decimal V = Pp * H / 3;
            decimal a = Math.Floor(V);
            decimal b = Math.Ceiling(V);
            Console.WriteLine($"{a} {b}");
        }
    }
}