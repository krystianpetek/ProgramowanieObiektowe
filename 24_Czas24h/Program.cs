using System;

namespace _24_Czas24h
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Test 1
            var t = new Czas24h(2, 15, 37);
            t.Minuta = 20;
            t.Godzina = 1;
            t.Sekunda = 26;
            Console.WriteLine(t);
            // Test 2
            t = new Czas24h(2, 15, 37);
            t.Minuta = 20;
            t.Godzina = 24;
            Console.WriteLine(t);
            // Test 3
            t = new Czas24h(2, 15, 37);
            t.Minuta = -20;
            t.Godzina = 23;
            Console.WriteLine(t);
            // Test 4
            t = new Czas24h(2, 15, 37);
            t.Minuta = 20;
            t.Godzina = 23;
            t.Godzina = 1;
            t.Sekunda = 15;
            t.Minuta = 10;
            t.Sekunda = 23;
            t.Sekunda = 1;
            t.Minuta = 12;
            Console.WriteLine(t);
            // Test 5
            t = new Czas24h(24, 15, 37);
            t.Minuta = 20;
            t.Godzina = 23;
            t.Godzina = 1;
            Console.WriteLine(t);
        }
    }

    public class Czas24h
    {
        private int liczbaSekund;

        public int Sekunda
        {
            get => liczbaSekund - Godzina * 60 * 60 - Minuta * 60;
            set
            {
                if (value < 0 || value > 59)
                    throw new ArgumentException("error");
                liczbaSekund = value + Godzina * 60 * 60 + Minuta * 60;
            }
        }

        public int Minuta
        {
            get => (liczbaSekund / 60) % 60;
            set
            {
                if (value < 0 || value > 59)
                    throw new ArgumentException("error");
                liczbaSekund = Sekunda + Godzina * 60 * 60 + value * 60;
            }
        }

        public int Godzina
        {
            get => liczbaSekund / 3600;
            set
            {
                if (value < 0 || value > 23)
                    throw new ArgumentException("error");
                liczbaSekund = Sekunda + value * 60 * 60 + Minuta * 60;
            }
        }

        public Czas24h(int godzina, int minuta, int sekunda)
        {
            if (godzina > 23 || godzina < 0 || minuta > 59 || minuta < 0 || sekunda > 59 || sekunda < 0)
                throw new ArgumentException("error");
            liczbaSekund = sekunda + 60 * minuta + 3600 * godzina;
        }

        public override string ToString() => $"{Godzina}:{Minuta:D2}:{Sekunda:D2}";
    }
}
