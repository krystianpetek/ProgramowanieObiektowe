using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Time czas = new Time("11:06:15");
            Console.WriteLine(czas.ToString());

            TimePeriod period = new TimePeriod(47945); // 13:19:05
            Console.WriteLine(period);
            TimePeriod periodFull = new TimePeriod(23, 19, 18);
            Console.WriteLine(periodFull.NumberOfSeconds);
            Console.WriteLine(periodFull);
        }
    }
}
