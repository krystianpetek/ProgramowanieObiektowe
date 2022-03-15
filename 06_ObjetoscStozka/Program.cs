using System;

namespace _06_ObjetoscStozka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] wejscie = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            int.TryParse(wejscie[0], out int promien);
            int.TryParse(wejscie[1], out int tworzaca);

        }
    }
}
