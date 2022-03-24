using System;
using System.Collections.Generic;

namespace _25_kolekcjeAgregatorLogow
{
    internal class Program
    {
        //7
        //192.168.0.11 peter 33
        //10.10.17.33 alex 12
        //10.10.17.35 peter 30
        //10.10.17.34 peter 120
        //10.10.17.34 peter 120
        //212.50.118.81 alex 46
        //212.50.118.81 alex 4

        //2
        //84.238.140.178 mol 25
        //84.238.140.178 mol 35
        private static void Main(string[] args)
        {
            int.TryParse(Console.ReadLine(), out int howManyLogs);

            List<Logi> listaLogow = new List<Logi>();
            for (int i = 0; i < howManyLogs; i++)
            {
                string[] linia = Console.ReadLine().Split(" ");
                Logi x = new Logi(linia[0], linia[1], int.Parse(linia[2]));
                listaLogow.Add(x);
            }

            List<Wyjscie> listaWyjsciowa = new List<Wyjscie>();
            for (int i = 0; i < listaLogow.Count; i++)
            {
                Wyjscie encja = new Wyjscie(listaLogow[i].IP, listaLogow[i].Nazwa, listaLogow[i].Czas);
                bool sprawdz = false;
                for (int j = 0; j < listaWyjsciowa.Count; j++)
                {
                    if (listaWyjsciowa[j].Nazwa == encja.Nazwa)
                    {
                        sprawdz = true;
                        listaWyjsciowa[j].Czas += encja.Czas;
                        if (!listaWyjsciowa[j].listaIP.Contains(encja.listaIP[0]))
                        {
                            listaWyjsciowa[j].listaIP.Add(encja.listaIP[0]);
                        }
                    }
                    listaWyjsciowa[j].listaIP.Sort();
                }
                if (!sprawdz)
                {
                    listaWyjsciowa.Add(encja);
                }
            }
            listaWyjsciowa.Sort();

            for (int i = 0; i < listaWyjsciowa.Count; i++)
            {
                Console.Write($"{listaWyjsciowa[i].Nazwa}: {listaWyjsciowa[i].Czas} ");
                for (int j = 0; j < listaWyjsciowa[i].listaIP.Count; j++)
                {
                    if (j == 0)
                        Console.Write("[");
                    if (j == listaWyjsciowa[i].listaIP.Count - 1)
                    {
                        Console.Write($"{listaWyjsciowa[i].listaIP[j]}]");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.Write($"{listaWyjsciowa[i].listaIP[j]}, ");
                    }
                }
            }
        }

        public class Logi
        {
            public Logi(string ip, string nazwa, int czas)
            {
                Nazwa = nazwa;
                IP = ip;
                Czas = czas;
            }

            public string Nazwa { get; set; }
            public string IP { get; set; }
            public int Czas { get; set; }
            public int aIP => int.Parse(IP.Split(".")[0]);
            public int bIP => int.Parse(IP.Split(".")[1]);
            public int cIP => int.Parse(IP.Split(".")[2]);
            public int dIP => int.Parse(IP.Split(".")[3]);
        }

        public class Wyjscie : IComparable<Wyjscie>
        {
            public Wyjscie(string ip, string nazwa, int czas)
            {
                listaIP.Add(ip);
                Nazwa = nazwa;
                Czas = czas;
            }

            public List<string> listaIP = new List<string>();
            public string Nazwa { get; set; }
            public int Czas { get; set; }

            public int CompareTo(Wyjscie other)
            {
                return this.Nazwa.CompareTo(other.Nazwa);
            }
        }
    }
}