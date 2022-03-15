using System;

namespace _05_RownanieKwadratowe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            QuadraticEquation(0, 2, 1);
            QuadraticEquation(1000000, 6000, -300295);
        }
        public static void QuadraticEquation(int a, int b, int c)
        {
            long A = a;
            long B = b;
            long C = c;

            if (A == 0 && B == 0 && C == 0)
            {
                Console.WriteLine("infinity");
                return;
            }

            if (A == 0 && B == 0)
            {
                Console.WriteLine("empty");
                return;
            }
            if (B == 0 || C == 0)
            {
                Console.WriteLine($"x=0.00");
                return;
            }

            long delta = (B * B) - (4 * A * C);
            if (delta > 0)
            {
                if (A == 0)
                {
                    double x = Math.Round(C * -1.0 / B,2);
                    Console.WriteLine($"x={x:F2}");
                }
                else
                {
                    //double x1 = (-B - Math.Sqrt(delta)) / 2 * A;
                    //double x2 = (-B + Math.Sqrt(delta)) / 2 * A;
                    double x1 = Math.Round(((B * -1) + Math.Sqrt(delta)) / (2 * A), 2);
                    double x2 = Math.Round((((B * -1) + (Math.Sqrt(delta) * -1)) / (2 * A)), 2);
                    if(x1 > x2)
                    {
                        double temp = x1;
                        x1 = x2;
                        x2 = temp;
                    }
                    Console.WriteLine($"x1={Math.Round(x1, 2):F2}");
                    Console.WriteLine($"x2={Math.Round(x2, 2):F2}");
                    return;
                }
            }
            else if (delta == 0)
            {
                double x0 = -B / (2 * A);

                Console.WriteLine($"x={Math.Round(x0, 2):F2}");
                return;
            }
            else
            {
                Console.WriteLine("empty");
                return;
            }
        }
    }
}
