using System;

namespace _16_tabliceProstokatne2D_2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] wymiaryMacierzA = Console.ReadLine().Split(' '); 
            int[] wartosciMacierzA = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), element => int.Parse(element));
            string[] wymiaryMacierzB = Console.ReadLine().Split(' ');
            int[] wartosciMacierzB = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), element => int.Parse(element));

            int.TryParse(wymiaryMacierzA[0], out int nA);
            int.TryParse(wymiaryMacierzA[1], out int mA);
            
            int.TryParse(wymiaryMacierzB[0], out int nB);
            int.TryParse(wymiaryMacierzB[1], out int mB);
        
            
        }
    }
}