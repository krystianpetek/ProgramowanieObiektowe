using System;

namespace _07_FlowChart1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] wejscie = Console.ReadLine().Split(' ');
            int.TryParse(wejscie[0], out int x);
            int.TryParse(wejscie[1], out int y);
            int.TryParse(wejscie[2], out int z);

        Poczatek:
            if (x > 0)
            {
                if (y > 0)
                {
                    x -= 1;
                    y -= 1;
                    Console.Write("C");
                    goto Poczatek;
                }
                else
                {
                    Console.Write("D");
                    if (z > 0)
                    {
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.Write("G");
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                Console.Write("E");
                Console.Write("G");
                Console.WriteLine();
            }
        }
    }
}