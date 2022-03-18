using System;

namespace _16_tabliceProstokatne2D_2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] wymiaryMacierzA = Console.ReadLine().Split(' ');
            int[] wartosciMacierzA = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), element => int.Parse(element));
            string[] wymiaryMacierzB = Console.ReadLine().Split(' ');
            int[] wartosciMacierzB = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), element => int.Parse(element));

            int.TryParse(wymiaryMacierzA[0], out int nA);
            int.TryParse(wymiaryMacierzA[1], out int mA);

            int.TryParse(wymiaryMacierzB[0], out int nB);
            int.TryParse(wymiaryMacierzB[1], out int mB);

            if(mA != nB)
            {
                Console.WriteLine("impossible");
                return;
            }

            int[,] macierzA = new int[nA, mA];
            PrzepisanieMacierzy(wartosciMacierzA, macierzA);
            int[,] macierzB = new int[nB, mB];
            PrzepisanieMacierzy(wartosciMacierzB, macierzB);

            WyswietlMacierz(macierzA);
            WyswietlMacierz(macierzB);
        
            // liczenie

        }

        public static void PrzepisanieMacierzy(int[] wartosciMacierzy, int[,] macierzWynikowa)
        {
            for (int i = 0; i < wartosciMacierzy.Length;)
            {
                for (int k = 0; k < macierzWynikowa.GetLength(0); k++)
                {
                    for (int l = 0; l < macierzWynikowa.GetLength(1); l++)
                    {
                        macierzWynikowa[k, l] = wartosciMacierzy[i];
                        i++;
                    }
                }
            }
        }

        public static void WyswietlMacierz(int[,] macierz)
        {
            for(int i = 0; i < macierz.GetLength(0); i++)
            {
                for(int j = 0;j< macierz.GetLength(1); j++)
                {
                    Console.Write($"{macierz[i,j]} ");
                }
                Console.WriteLine();
            }
        }
    }
    
}

