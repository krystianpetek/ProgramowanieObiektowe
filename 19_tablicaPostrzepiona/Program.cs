using System;

namespace _19_tablicaPostrzepiona
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            char[][] jagged = ReadJaggedArrayFromStdInput();
            PrintJaggedArrayToStdOutput(jagged);
            jagged = TransposeJaggedArray(jagged);
            Console.WriteLine();
            PrintJaggedArrayToStdOutput(jagged);
        }

        public static char[][] ReadJaggedArrayFromStdInput()
        {
            int.TryParse(Console.ReadLine(), out int numberOfRows);
            char[][] jaggedArray = new char[numberOfRows][];
            for (int i = 0; i < numberOfRows; i++)
            {
                string[] inputStringArray = Console.ReadLine().Split(' ');
                jaggedArray[i] = Array.ConvertAll<string, char>(inputStringArray, char.Parse);
            }
            return jaggedArray;
        }

        public static char[][] TransposeJaggedArray(char[][] tab)
        {
            int longestArray = 0;
            foreach (char[] jagged in tab)
            {
                if (longestArray < jagged.Length)
                    longestArray = jagged.Length;
            }
            char[][] newJaggedArray = new char[longestArray][];
            for (int i = 0; i < longestArray; i++)
            {
                newJaggedArray[i] = new char[tab.Length];
            }

            for (int i = 0; i < tab.Length; i++)
            {
                for (int j = 0; j < tab[i].Length; j++)
                {
                    newJaggedArray[j][i] = tab[i][j];
                }
            }
            return newJaggedArray;
        }

        public static void PrintJaggedArrayToStdOutput(char[][] tab)
        {
            for (int i = 0; i < tab.Length; i++)
            {
                for (int j = 0; j < tab[i].Length; j++)
                {
                    if (tab[i][j] == '\0')
                    {
                        
                        Console.Write("  ");
                    }
                    else
                    {
                        Console.Write($"{tab[i][j]} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}