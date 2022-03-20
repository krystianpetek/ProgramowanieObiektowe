using System;

namespace _20_sprawdzSudoku
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] sudoku = new int[9][];
            for (int i = 0; i < sudoku.Length; i++)
            {
                sudoku[i] = Array.ConvertAll(Console.ReadLine().Split(" "), Convert);
            }
            if (!CheckLinear(sudoku))
            { Console.WriteLine("no");
                return;
            }
            int[][,] sudoku3x3 = new int[9][,];
            if (!Check3x3(sudoku3x3))
            {
                Console.WriteLine("no");
                return;
            }
            Console.WriteLine("yes");            
        }

        

        public static int Convert(string x)
        {
            return int.Parse(x);
        }

        public static bool CheckLinear(int[][] sudoku)
        {
            bool judge = true;
            for (int i = 0; i < sudoku.Length; i++)
            {

            }
            return judge;
        }

        public static bool Check3x3(int[][,] sudoku3x3)
        {
            throw new NotImplementedException();
        }

    }
}
