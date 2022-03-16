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

            int globalna = 0;
            for (int i = n; i > 0; i-=2)
            {
                for(int Z = 0;Z<globalna;Z++)
                {
                    Console.Write(" ");
                }
                    globalna++;
                for (int j = 0; j < i; j++)
                {
                    Console.Write("*");
                }    
                Console.WriteLine();
            }
        }
    }
}
