using System;

namespace _18_tabliceProstokatne2D_4
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[,] tablica;
            tablica = new int[,] { { 1, 1, 1, 1, 1, 1 }, { 2, 2, 2, 2, 2, 2 }, { 3, 3, 3, 3, 3, 3 } };
            //tablica = new int[,] { { 1, 2, 3 } };
            //tablica = new int[,] { { -1 }, { 1 }, { 1 } };
            tablica = new int[,] { { 1, 1 }, { 2, -1 } };
            Console.WriteLine(Srednia(tablica));
        }

        public static double Srednia(int[,] tab)
        {
            if (tab.Length == 0 || tab == null)
                return Math.Round(0.00, 2);

            int licznik = 0;
            double srednia = 0.0;
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    if (tab[i, j] > 0)
                    {
                        licznik++;
                        srednia += tab[i, j];
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            double final = Math.Round(srednia * 1.00 / licznik, 2);
            if (double.IsNaN(final))
                return 0.00;
            return final;
        }
    }
}