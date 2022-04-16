using Time_TimePeriodWithMiliseconds;

namespace ConsoleAppForTestingTimeWithMiliseconds
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            TimeWithMiliseconds czas = new TimeWithMiliseconds("23:06:55:00");
            TimeWithMiliseconds czas1 = new TimeWithMiliseconds(23, 06, 54, 00);
            TimeWithMiliseconds czas2 = new TimeWithMiliseconds(23, 06, 55, 00);
            TimeWithMiliseconds czas3 = new TimeWithMiliseconds(23, 06, 56, 00);
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

            var czasTeraz = DateTime.Now;
            TimeWithMiliseconds x = new TimeWithMiliseconds(czasTeraz.Hour, czasTeraz.Minute, czasTeraz.Second, czasTeraz.Millisecond);

            while (true)
            {
                TimePeriodWithMiliseconds sekunda = new TimePeriodWithMiliseconds(0, 0, 0, 1);
                var g = x.Plus(sekunda);
                Console.WriteLine(g);
                x = new TimeWithMiliseconds(g.Hours, g.Minutes, g.Seconds, g.Miliseconds);
                Thread.Sleep(1);
            }
        }
    }
}