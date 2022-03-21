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
        static void Main(string[] args)
        {
            int.TryParse(Console.ReadLine(), out int howManyLogs);
            //string[][] lista = new string[howManyLogs][];
            //for(int i = 0; i < howManyLogs; i++)
            //{
            //    lista[i] = Console.ReadLine().Split(" ");
            //}
            List<Logi> listaLogow = new List<Logi>();
            for (int i = 0; i < howManyLogs; i++)
            {
                string[] linia = Console.ReadLine().Split(" ");
                Logi x = new Logi(linia[0], linia[1], int.Parse(linia[2]));
                listaLogow.Add(x);
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
}
