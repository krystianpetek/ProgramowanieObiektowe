using System;

namespace _15_tabliceProstokatne2D
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] linia1 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int.TryParse(linia1[0], out int n); // liczba wierszy
            int.TryParse(linia1[1], out int m); // liczba kolumn
            string[,] tabDoTranspozycji = new string[n, m];

            for (int i = 0; i < n; i++)
            {
                string[] linia = Console.ReadLine().Split(" ");
                for (int j = 0; j < m; j++)
                {
                    tabDoTranspozycji[i, j] = linia[j];
                }
            }
            string[,] tablicaTransponowana = new string[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    tablicaTransponowana[i, j] = tabDoTranspozycji[j, i];
                }
            }
            Display(tablicaTransponowana);
        }

        public static void Display(string[,] tablica)
        {
            for (int i = 0; i < tablica.GetLength(0); i++)
            {
                for (int j = 0; j < tablica.GetLength(1); j++)
                {
                    Console.Write($"{tablica[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}