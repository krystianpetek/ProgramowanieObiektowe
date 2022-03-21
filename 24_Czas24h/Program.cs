using System;

namespace _24_Czas24h
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Czas24h
    {
        private int liczbaSekund;

        public int Sekunda
        {
            get => liczbaSekund - Godzina * 60 * 60 - Minuta * 60;
            set => liczbaSekund = value;
        }

        public int Minuta
        {
            get => (liczbaSekund / 60) % 60;
            // uzupełnij kod - zdefiniuj setters'a
        }

        public int Godzina
        {
            get => liczbaSekund / 3600;
            // uzupełnij kod - zdefiniuj setters'a
        }

        public Czas24h(int godzina, int minuta, int sekunda)
        {
            // uzupełnij kod zgłaszając wyjątek ArgumentException
            // w sytuacji niepoprawnych danych

            liczbaSekund = sekunda + 60 * minuta + 3600 * godzina;
        }

        public override string ToString() => $"{Godzina}:{Minuta:D2}:{Sekunda:D2}";
    }
}
