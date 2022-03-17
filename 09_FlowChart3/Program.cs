using System;

namespace _09_FlowChart3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] wejscie = Console.ReadLine().Split(' ');
            int.TryParse(wejscie[0], out int x);
            int.TryParse(wejscie[1], out int y);
            int.TryParse(wejscie[2], out int z);

            while (x >= 0 || y >= 0)
                if (x > 0)
                {
                    if (y > 0)
                    {
                        x--;
                        y--;
                        Console.Write("C");
                    }
                    else
                    {
                        Console.Write("D");
                        if (z > 0)
                        {
                            Console.WriteLine();
                            break;
                        }
                        else
                        {
                            Console.Write("G");
                            Console.WriteLine();
                            break;
                        }
                    }
                }
                else
                {
                    Console.Write("E");
                    Console.Write("G");
                    Console.WriteLine();
                    break;
                }
        }
    }
}