using System;

namespace _12_PrzetwarzanieTablic1D_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { -2, -1, 0, 1, 4 };
            int[] b = new int[] { -3, -2, -1, 1, 2, 3 };

            a = new int[] { -2, -1, 0, 1, 1, 4 };
            b = new int[] { -3, -2, -1, 1, 2, 3 };

            a = new int[] { 1 };
            b = new int[] { 2 };
            Print(a, b);
        }
        public static void Print(int[] a, int[] b)
        {
            string wyjscie = string.Empty;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    if (a[i] == b[j])
                    {
                        wyjscie += $"{a[i]} ";
                    }
                }
            }
            string[] tab = new string[1];
            string koniec = tab[0];
            if (wyjscie.Length < 2)
            {

            }
            else
            {
                tab = wyjscie.Split(" ");

                koniec = tab[0];
                int poprzednik = int.Parse(tab[0]);
                for (int i = 1; i < tab.Length - 1; i++)
                {
                    if (poprzednik != int.Parse(tab[i]))
                    {
                        koniec += $" {tab[i]}";
                    }
                    poprzednik = int.Parse(tab[i]);
                }
            }
            if (wyjscie.Length > 0)
                Console.Write(koniec);
            else
                Console.WriteLine("empty");

        }
    }
}
