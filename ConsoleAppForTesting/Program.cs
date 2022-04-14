using Time_TimePeriod;

namespace ConsoleAppForTesting
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Time czas = new Time("23:06:55");
            Time czas1 = new Time(23, 06, 54);
            Time czas2 = new Time(23, 06, 55);
            Time czas3 = new Time(23, 06, 56);
            Console.WriteLine(czas.Equals(czas2));
            Console.WriteLine(czas);
            Console.WriteLine($"\n{czas}\t{czas1}\t{czas2}\t{czas3}");
            Console.WriteLine($"==\t\t{czas == czas1}\t\t{czas == czas2}\t\t{czas == czas3}");
            Console.WriteLine($"!=\t\t{czas != czas1}\t\t{czas != czas2}\t\t{czas != czas3}");
            Console.WriteLine($">\t\t{czas > czas1}\t\t{czas > czas2}\t\t{czas > czas3}");
            Console.WriteLine($">=\t\t{czas >= czas1}\t\t{czas >= czas2}\t\t{czas >= czas3}");
            Console.WriteLine($"<\t\t{czas < czas1}\t\t{czas < czas2}\t\t{czas < czas3}");
            Console.WriteLine($"<=\t\t{czas <= czas1}\t\t{czas <= czas2}\t\t{czas <= czas3}");
            Console.WriteLine();
            TimePeriod okresCzasu = new TimePeriod(23, 59, 59);
            Time czasAktualny = new Time(20, 13, 0);
            Console.WriteLine(czasAktualny + okresCzasu);
            Console.WriteLine(czasAktualny - okresCzasu);

            TimePeriod period = new TimePeriod(47945); // 13:19:05
            Console.WriteLine(period);
            TimePeriod periodFull = new TimePeriod(23, 19, 18);
            Console.WriteLine(periodFull.NumberOfSeconds);
            Console.WriteLine(periodFull);
        }
    }
}