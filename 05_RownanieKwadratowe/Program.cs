using System;

namespace _05_RownanieKwadratowe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            QuadraticEquation(0, 0, 1);
        }
        public static void QuadraticEquation(int a, int b, int c)
        {
            
            if (a == 0 && b == 0 && c == 0)
            {
                Console.WriteLine("infinity");
                return;
            }
            if (a == 0)
            {
                Console.WriteLine("empty");
                return;
            }
            double delta = (b * b) - (4 * a * c);
            if (delta > 0)
            {
                double x1 = (-b - Math.Sqrt(delta)) / 2 * a;
                double x2 = (-b + Math.Sqrt(delta)) / 2 * a;
                Console.WriteLine($"x1={Math.Round(x1,2):F2}");
                Console.WriteLine($"x2={Math.Round(x2,2):F2}");
            }
            else if (delta == 0)
            {
                double x0 = -b / (2 * a);

                Console.WriteLine($"x={Math.Round(x0,2):F2}");
            }
            else
            {
                Console.WriteLine("empty");
            }
        }
    }
}
