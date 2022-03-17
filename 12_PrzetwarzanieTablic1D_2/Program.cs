using System;

namespace _12_PrzetwarzanieTablic1D_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { -2, -1, 0, 1, 4 };
            int[] b = new int[] { -3, -2, -1, 1, 2, 3 };
            
            a = new int[] { -2, -1, 0, 1, 4 };
            b = new int[] { -3, -2, -1, 1, 2, 3 };
            
            Print(a, b);
        }
        public static void Print(int[] a, int[] b)
        {
            string sBuilder = "";
            for (int i = 0; i < a.Length; i++)
            {
                bool foundInt = false;
                for (int j = 0; j < b.Length; j++)
                {
                    if (a[i] == b[j])
                    {
                        foundInt = true;
                        break;
                    }
                }
                if (foundInt && !sBuilder.Contains($"{a[i]}"))
                {
                    sBuilder += $"{a[i]} ";
                }
            }
            
            for (int i = 0; i < b.Length; i++)
            {
                bool foundInt = false;
                for (int j = 0; j < a.Length; j++)
                {
                    if (b[i] == a[j])
                    {
                        foundInt = true;
                        break;
                    }
                }
                if (foundInt && !sBuilder.Contains($"{a[i]}"))
                {
                    sBuilder += $"{b[i]} ";
                }
            }
            if (sBuilder.Length > 0)
                Console.WriteLine(sBuilder);
            else
                Console.WriteLine("empty");
        }
    }
}
