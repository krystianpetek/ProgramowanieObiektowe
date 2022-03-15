using System;

namespace _08_FlowChart2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] wejscie = Console.ReadLine().Split(' ');
            int.TryParse(wejscie[0], out int x);
            int.TryParse(wejscie[1], out int y);
            int.TryParse(wejscie[2], out int z);

            if (x > 0)
            {
                if (y > 0)
                {
                    x -= 1;
                    y -= 1;
                    Console.Write("C");
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
