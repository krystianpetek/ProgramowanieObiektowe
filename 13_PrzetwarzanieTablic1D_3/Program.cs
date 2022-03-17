using System;

namespace _13_PrzetwarzanieTablic1D_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { -2, -1, 0, 1, 4 };
            int[] b = new int[] { -3, -2, -1, 1, 2, 3 };
            Print(a, b);

            a = new int[] { 0, 1, 1, 2, 3, 3, 3 };
            b = new int[] { 0, 1, 2, 3, 3 };
            Print(a, b);
        }
        static void Print(int[] a, int[] b)
        {
            string wyjscie = string.Empty;
            for (int i = 0; i < a.Length; i++)
            {
                bool isInTab = false;
                for (int j = 0; j < b.Length; j++)
                {
                    if (a[i] == b[j])
                    {
                        isInTab = true;
                        continue;
                    }

                }
                if (!isInTab)
                {
                    wyjscie += $"{a[i]} ";
                }
            }
            for (int i = 0; i < b.Length; i++)
            {
                bool isInTab = false;
                for (int j = 0; j < a.Length; j++)
                {
                    if (b[i] == a[j])
                    {
                        isInTab = true;
                        continue;
                    }

                }
                if (!isInTab)
                {
                    wyjscie += $"{b[i]} ";
                }
            }
            if (wyjscie.Length > 0)
            {
                string[] x= wyjscie.Split(' ');
                int[] intx = new int[x.Length-1];
                for(int i = 0;i< x.Length-1; i++)
                {
                    intx[i] = int.Parse(x[i]);
                }
                Array.Sort(intx);
                int poprzednik = intx[0];
                string koniec = intx[0].ToString();
                for (int i = 1; i < x.Length - 1; i++)
                {
                    if (poprzednik != intx[i])
                    {
                        koniec += $" {intx[i]}";
                    }
                    poprzednik = intx[i];
                }
                Console.WriteLine(koniec);
            }
            else
            {
                Console.WriteLine("empty");
            }
        }
    }
}
