using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOfTheWeek
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DayOfTheWeek days = new DayOfTheWeek();
            foreach(var item in days)
            {
                Console.WriteLine(item + " ");
            }
        }
        
    }
}
