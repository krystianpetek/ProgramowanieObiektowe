using System;

namespace _10_Wzorek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Wzorek(5);    
        }
        public static void Wzorek(int n)
        {
            if (n < 3)
                return;
            if (n % 2 == 0)
            {
                n--;
            }
            for (int i = n; i > 0; i--)
            {
                Console.WriteLine("*");
                for (int j = 0; j < n / 2; j++)
                {
                    Console.Write(" ");
                }
            }
        }
    }
}
