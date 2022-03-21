using System;

namespace _20_sprawdzSudoku
{
    // dopracować
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[][] sudoku = new int[9][];
            for (int i = 0; i < sudoku.Length; i++)
            {
                sudoku[i] = Array.ConvertAll(Console.ReadLine().Split(" "), Convert);
            }
            if (!CheckWidth(sudoku))
            {
                Console.WriteLine("no");
                return;
            }
            if (!CheckHeight(sudoku))
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

        private static bool CheckHeight(int[][] sudoku)
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

                        if (sudoku[j][i] == sudoku[k][i])
                        {
                            judge = false;
                            return judge;
                        }
                    }
                }
            }
            return judge;
        }

        public static int Convert(string x)
        {
            return int.Parse(x);
        }

        public static bool CheckWidth(int[][] sudoku)
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

        //public static int[][,] Przepisanie(int[][] tab)
        //{
        //    int[][,] sudoku3x3 = new int[9][,];

        //    for (int i = 0; i < tab.Length; i++)
        //    {
        //        sudoku3x3[i] = new int[3, 3];
        //        for (int j = 0; j < tab[i].Length; j++)
        //        {
        //            for (int k = 0; k < tab[i].Length; k++)

        //            {
        //                int X = 0;
        //                int Y = 0;
        //                try
        //                {
        //                    X = j / 3;
        //                    Y = k / 3;
        //                }
        //                catch (DivideByZeroException)
        //                {
        //                }
        //                sudoku3x3[i][j / 3, k / 3] = tab[j][k];
        //            }
        //        }
        //    }

        //    return sudoku3x3;
        //}

        public static bool Check3x3(int[][] sudoku)
        {
            bool judge = true;
            int[] lista1 = new int[9];
            int[] lista2 = new int[9];
            int[] lista3 = new int[9];

            int x = 0;
            int mnoznik = 0;

            for (int i = 0; i < sudoku.Length; i++)
            {
                if (i == 3)
                {
                    if (!jeszczeJedenCheck(lista1))
                        return false;
                    if (!jeszczeJedenCheck(lista2))
                        return false;
                    if (!jeszczeJedenCheck(lista3))
                        return false;
                    lista1 = new int[9];
                    lista2 = new int[9];
                    lista3 = new int[9];
                    mnoznik = 0;
                }
                if (i == 0 || i == 3 || i == 6)
                {
                    mnoznik = 0;
                }
                else
                {
                    mnoznik += 3;
                }
                for (int j = 0; j < sudoku[i].Length; j++)
                {
                    if (j < 3)
                        lista1[x + mnoznik] = sudoku[i][j];
                    else if (j < 6)
                        lista2[x + mnoznik] = sudoku[i][j];
                    else if (j < 9)
                        lista3[x + mnoznik] = sudoku[i][j];

                    x++;
                    if (x % 3 == 0)
                    {
                        x = 0;
                    }
                }
            }
            return judge;
        }

        public static bool jeszczeJedenCheck(int[] tab)
        {
            for (int c = 0; c < tab.Length; c++)
            {
                for (int d = 0; d < tab.Length; d++)
                {
                    if (c == d)
                        continue;

                    if (tab[c] == tab[d])
                        return false;
                }
            }
            return true;
        }
    }
}