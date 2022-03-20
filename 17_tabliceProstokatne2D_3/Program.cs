using System;
using System.Collections.Generic;

namespace _17_tabliceProstokatne2D_3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int[]> tablicaProstokatna = new List<int[]>();
            while (true)
            {
                string linia = Console.ReadLine();
                if (linia == string.Empty || linia == null)
                {
                    break;
                }
                Converter<string, int> converter = new Converter<string, int>(Konwersja);
                int[] listaIntow = Array.ConvertAll(linia.Split(" "), converter);
                tablicaProstokatna.Add(listaIntow);
                linia = "";
            }
            int[] listaWynikow = new int[tablicaProstokatna[0].Length];
            for (int i = 0; i < tablicaProstokatna.Count; i++)
            {
                for (int j = 0; j < tablicaProstokatna[i].Length; j++)
                {
                    listaWynikow[j] += tablicaProstokatna[i][j];
                }
            }

            int licznikIndexow = 0;
            int indexNajwyzszejWartosci = 0;
            int najwyzszaWartosc = 0;
            foreach (var x in listaWynikow)
            {
                if (x > najwyzszaWartosc)
                {
                    najwyzszaWartosc = x;
                    indexNajwyzszejWartosci = licznikIndexow;
                }
                licznikIndexow++;
            }
            Console.WriteLine(indexNajwyzszejWartosci);
        }

        public static int Konwersja(string x)
        {
            return int.Parse(x);
        }
    }
}