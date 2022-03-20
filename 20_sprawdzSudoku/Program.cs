using System;
using System.Collections.Generic;

namespace _20_sprawdzSudoku
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[][] sudoku = new int[9][];
            for (int i = 0; i < sudoku.Length; i++)
            {
                sudoku[i] = Array.ConvertAll(Console.ReadLine().Split(" "), Convert);
            }
            if (!CheckLinear(sudoku))
            {
                Console.WriteLine("no");
                return;
            }

            if (!Check3x3(sudoku))
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
                for (int j = 0; j < sudoku[i].Length; j++)
                {
                    for (int k = 0; k < sudoku[i].Length; k++)
                    {
                        if (j == k)
                            continue;

                        if (sudoku[i][j] == sudoku[i][k])
                        {
                            judge = false;
                            return judge;
                        }
                    }
                }
            }
            return judge;
        }

        public static int[][,] Przepisanie(int[][] tab)
        {
            int[][,] sudoku3x3 = new int[9][,];

            for (int i = 0; i < tab.Length; i++)
            {
                sudoku3x3[i] = new int[3, 3];
                for (int j = 0; j < tab[i].Length; j++)
                {
                    for (int k = 0; k < tab[i].Length; k++)

                    {
                        int X = 0;
                        int Y = 0;
                        try
                        {
                            X = j / 3;
                            Y = k / 3;
                        }
                        catch (DivideByZeroException)
                        {
                        }
                        sudoku3x3[i][j / 3, k / 3] = tab[j][k];
                    }
                }
            }

            return sudoku3x3;
        }

        public static bool Check3x3(int[][] sudoku)
        {
            List<int[]> X = new List<int[]>();
            bool judge = true;
            int licznik = 0;
            int[] tab = new int[3];

            for (int i = 0; i < sudoku.Length; i++)
            {
                for (int j = 0; j < sudoku[i].Length; j++)
                {
                    if (licznik == 3)
                    {
                        licznik = 0;
                        X.Add(tab);
                        tab = new int[3];
                    }
                    tab[licznik] = sudoku[i][j];
                    licznik++;

                    if (i == 8 && j == 8)
                        X.Add(tab);
                }
            }



            return judge;
        }
    }
}