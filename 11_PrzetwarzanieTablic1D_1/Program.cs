using System;
using System.Text;

namespace _11_PrzetwarzanieTablic1D_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { -2, -1, 0, 1, 4 };
            int[] b = new int[] { -3, -2, -1, 1, 2, 3 };
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
                if (!foundInt && !sBuilder.Contains($"{a[i]}"))
                {
                    sBuilder += $"{a[i]} ";
                }
            }
            if (sBuilder.Length > 0)
                Console.WriteLine(sBuilder);
            else
                Console.WriteLine("empty");
        }
    }
}
