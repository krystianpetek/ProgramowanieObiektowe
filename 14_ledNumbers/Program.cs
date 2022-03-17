using System;

namespace _14_ledNumbers
{
    public class Program
    {
        public static string[,] zero = new string[,] { { " ", "_", " " }, { "|", " ", "|" }, { "|", "_", "|" } };
        public static string[,] jeden = new string[,] { { " ", " ", " " }, { " ", " ", "|" }, { " ", " ", "|" } };
        public static string[,] dwa = new string[,] { { " ", "_", " " }, { " ", "_", "|" }, { "|", "_", " " } };
        public static string[,] trzy = new string[,] { { " ", "_", " " }, { " ", "_", "|" }, { " ", "_", "|" } };
        public static string[,] cztery = new string[,] { { " ", " ", " " }, { "|", "_", "|" }, { " ", " ", "|" } };
        public static string[,] piec = new string[,] { { " ", "_", " " }, { "|", "_", " " }, { " ", "_", "|" } };
        public static string[,] szesc = new string[,] { { " ", "_", " " }, { "|", "_", " " }, { "|", "_", "|" } };
        public static string[,] siedem = new string[,] { { " ", "_", " " }, { " ", " ", "|" }, { " ", " ", "|" } };
        public static string[,] osiem = new string[,] { { " ", "_", " " }, { "|", "_", "|" }, { "|", "_", "|" } };
        public static string[,] dziewiec = new string[,] { { " ", "_", " " }, { "|", "_", "|" }, { " ", " ", "|" } };

        //public static string[,,] tablicaLiczb = new string[,,]
        private static void Main(string[] args)
        {
            string linia = Console.ReadLine();
            Skrypcik(linia);
        }

        private static void Skrypcik(string linia)
        {
            int[] inty = new int[linia.Length];
            for (int i = 0; i < linia.Length; i++)
            {
                inty[i] = int.Parse(linia[i].ToString());
            }
            string wyjscie = string.Empty;
            for (int x = 0; x < 3; x++)
            {
                for (int i = 0; i < inty.Length; i++)
                {
                    switch (inty[i])
                    {
                        case 0:
                            wyjscie += zero[x, 0];
                            wyjscie += zero[x, 1];
                            wyjscie += zero[x, 2];
                            break;

                        case 1:
                            wyjscie += jeden[x, 0];
                            wyjscie += jeden[x, 1];
                            wyjscie += jeden[x, 2];
                            break;

                        case 2:
                            wyjscie += dwa[x, 0];
                            wyjscie += dwa[x, 1];
                            wyjscie += dwa[x, 2];
                            break;

                        case 3:
                            wyjscie += trzy[x, 0];
                            wyjscie += trzy[x, 1];
                            wyjscie += trzy[x, 2];
                            break;

                        case 4:
                            wyjscie += cztery[x, 0];
                            wyjscie += cztery[x, 1];
                            wyjscie += cztery[x, 2];
                            break;

                        case 5:
                            wyjscie += piec[x, 0];
                            wyjscie += piec[x, 1];
                            wyjscie += piec[x, 2];
                            break;

                        case 6:
                            wyjscie += szesc[x, 0];
                            wyjscie += szesc[x, 1];
                            wyjscie += szesc[x, 2];
                            break;

                        case 7:
                            wyjscie += siedem[x, 0];
                            wyjscie += siedem[x, 1];
                            wyjscie += siedem[x, 2];
                            break;

                        case 8:
                            wyjscie += osiem[x, 0];
                            wyjscie += osiem[x, 1];
                            wyjscie += osiem[x, 2];
                            break;

                        case 9:
                            wyjscie += dziewiec[x, 0];
                            wyjscie += dziewiec[x, 1];
                            wyjscie += dziewiec[x, 2];
                            break;
                    }
                }
                wyjscie += $"\n";
            }
            Console.WriteLine(wyjscie);
        }
    }
}