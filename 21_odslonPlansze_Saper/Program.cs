using System;
using System.Collections.Generic;

namespace _21_odslonPlansze_Saper
{
    internal class Program
    {
        private static List<string[]> plansza = new List<string[]>();

        private static void Main(string[] args)
        {
            string[] wymiary = Console.ReadLine().Split(' ');
            int.TryParse(wymiary[0], out int x);
            int.TryParse(wymiary[1], out int y);

            for (int i = 0; i < x; i++)
            {
                string linia = Console.ReadLine();
                string[] wiersz = new string[linia.Length];
                int iter = 0;
                foreach (char znak in linia)
                {
                    wiersz[iter] = znak.ToString();
                    iter++;
                }
                plansza.Add(wiersz);
            }

            for (int i = 0; i < plansza.Count; i++)
            {
                for (int j = 0; j < plansza[i].Length; j++)
                {
                    plansza[i][j] = DoIt(i, j);
                }
            }

            for (int i = 0; i < plansza.Count; i++)
            {
                for (int j = 0; j < plansza[i].Length; j++)
                {
                    Console.Write($"{plansza[i][j]}");
                }
                Console.WriteLine();
            }
        }

        private static string DoIt(int i, int j)
        {
            if (plansza[i][j] == "*")
                return "*";

            if (plansza[i][j] == ".")
            {
                int licznik = 0;
                if (i == 0 && j == 0)
                {
                    licznik += Liczenie(Kierunek.Prawo, i, j);
                    licznik += Liczenie(Kierunek.DolPrawo, i, j);
                    licznik += Liczenie(Kierunek.Dol, i, j);
                    // prawo, prawo dol, dol
                }
                else if (i == 0 && j == plansza[i].Length - 1)
                {
                    licznik += Liczenie(Kierunek.Dol, i, j);
                    licznik += Liczenie(Kierunek.DolLewo, i, j);
                    licznik += Liczenie(Kierunek.Lewo, i, j);
                    // dol, lewo dol, lewo
                }
                else if (i == plansza.Count - 1 && j == plansza[i].Length - 1)
                {
                    licznik += Liczenie(Kierunek.Lewo, i, j);
                    licznik += Liczenie(Kierunek.GoraLewo, i, j);
                    licznik += Liczenie(Kierunek.Gora, i, j);
                    // lewo, lewo gora, gora
                }
                else if (i == plansza.Count - 1 && j == 0)
                {
                    licznik += Liczenie(Kierunek.Gora, i, j);
                    licznik += Liczenie(Kierunek.GoraPrawo, i, j);
                    licznik += Liczenie(Kierunek.Prawo, i, j);
                    // gora, prawo gora, prawo
                }
                else if (i == 0 && j > 0)
                {
                    licznik += Liczenie(Kierunek.Prawo, i, j);
                    licznik += Liczenie(Kierunek.DolPrawo, i, j);
                    licznik += Liczenie(Kierunek.Dol, i, j);
                    licznik += Liczenie(Kierunek.DolLewo, i, j);
                    licznik += Liczenie(Kierunek.Lewo, i, j);
                    // prawo, prawo dol, dol, lewo dol, lewo
                }
                else if (i > 0 && j == plansza[i].Length - 1)
                {
                    licznik += Liczenie(Kierunek.Dol, i, j);
                    licznik += Liczenie(Kierunek.DolLewo, i, j);
                    licznik += Liczenie(Kierunek.Lewo, i, j);
                    licznik += Liczenie(Kierunek.GoraLewo, i, j);
                    licznik += Liczenie(Kierunek.Gora, i, j);
                    // dol, lewo dol, lewo, lewo gora, gora
                }
                else if (i == plansza.Count - 1 && j > 0)
                {
                    licznik += Liczenie(Kierunek.Lewo, i, j);
                    licznik += Liczenie(Kierunek.GoraLewo, i, j);
                    licznik += Liczenie(Kierunek.Gora, i, j);
                    licznik += Liczenie(Kierunek.GoraPrawo, i, j);
                    licznik += Liczenie(Kierunek.Prawo, i, j);
                    // lewo, lewo gora, gora, prawo gora, prawo
                }
                else if (i > 0 && j == 0)
                {
                    licznik += Liczenie(Kierunek.Gora, i, j);
                    licznik += Liczenie(Kierunek.GoraPrawo, i, j);
                    licznik += Liczenie(Kierunek.Prawo, i, j);
                    licznik += Liczenie(Kierunek.DolPrawo, i, j);
                    licznik += Liczenie(Kierunek.Dol, i, j);
                    // gora, prawo gora, prawo, prawo dol, dol
                }
                else
                {
                    licznik += Liczenie(Kierunek.Gora, i, j);
                    licznik += Liczenie(Kierunek.GoraPrawo, i, j);
                    licznik += Liczenie(Kierunek.Prawo, i, j);
                    licznik += Liczenie(Kierunek.DolPrawo, i, j);
                    licznik += Liczenie(Kierunek.Dol, i, j);
                    licznik += Liczenie(Kierunek.DolLewo, i, j);
                    licznik += Liczenie(Kierunek.Lewo, i, j);
                    licznik += Liczenie(Kierunek.GoraLewo, i, j);
                }
                if (licznik == 0)
                    return ".";
                else
                    return $"{licznik}";
            }

            return plansza[i][j];
        }

        private static int Liczenie(Kierunek kierunek, int x, int y)
        {
            switch (kierunek)
            {
                case Kierunek.Gora:
                    if (plansza[x - 1][y] == "*")
                        return 1;
                    break;

                case Kierunek.GoraPrawo:
                    if (plansza[x - 1][y + 1] == "*")
                        return 1;
                    break;

                case Kierunek.Prawo:
                    if (plansza[x][y + 1] == "*")
                        return 1;
                    break;

                case Kierunek.DolPrawo:
                    if (plansza[x + 1][y + 1] == "*")
                        return 1;
                    break;

                case Kierunek.Dol:
                    if (plansza[x + 1][y] == "*")
                        return 1;
                    break;

                case Kierunek.DolLewo:
                    if (plansza[x + 1][y - 1] == "*")
                        return 1;
                    break;

                case Kierunek.Lewo:
                    if (plansza[x][y - 1] == "*")
                        return 1;
                    break;

                case Kierunek.GoraLewo:
                    if (plansza[x - 1][y - 1] == "*")
                        return 1;
                    break;
            }
            return 0;
        }
    }

    public enum Kierunek
    {
        GoraLewo = 7,
        Gora = 8,
        GoraPrawo = 9,
        Prawo = 6,
        DolPrawo = 3,
        Dol = 2,
        DolLewo = 1,
        Lewo = 4
    }
}