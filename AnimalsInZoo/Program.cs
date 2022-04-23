using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsInZoo
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Zoo zoo = new Zoo();
            zoo.AddMammal("Whale");
            zoo.AddMammal("Rhinoceros");
            zoo.AddBird("Penguin");
            zoo.AddBird("Warbler");

            foreach(string name in zoo.Birds())
            {
                Console.Write(name + " ");
            }
            Console.WriteLine();

            foreach(string name in zoo.Mammals())
            {
                Console.Write(name + " ");
            }
            Console.WriteLine();
        }
    }
}
