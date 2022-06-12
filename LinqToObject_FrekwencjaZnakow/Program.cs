using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObject_FrekwencjaZnakow
{
    internal class Program
    {
        public static void Main()
        {
            var t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                var input = Console.ReadLine(); //"Ala ma 2 koty, As to Ali pies!";
                var inputFormat = Console.ReadLine(); // "first 3 byfreq asc byletter asc";

                if (input == null || inputFormat == null)
                    return;

                var inputSplit = inputFormat.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                
                var order = inputSplit[0] == nameof(Program.Order.first) ? 1 : 2;
                var n = inputSplit[1];
                var frequencyFirst = inputSplit[2] == nameof(Program.Frequency.byfreq) ? 1 : 2;
                var sortFirst = inputSplit[3] == nameof(Program.Sort.asc) ? 1 : 2;
                var frequencySecond = 0;
                var sortSecond = 0;
                
                if (inputSplit.Length > 4)
                {
                    frequencySecond = inputSplit[4] == nameof(Program.Frequency.byfreq) ? 1 : 2;
                    sortSecond = inputSplit[5] == nameof(Program.Sort.asc) ? 1 : 2;
                }

                var result = input
                    .Where(query => char.IsLetter(query))
                    .Select(query => char.ToLower(query))
                    .ToList().GroupBy(query => query)
                    .Select(group => new
                    {
                        key = group.Key, value = group.Count()
                    })
                    .OrderBy(q => q.key);
                                
                if (frequencyFirst == 1)
                {
                    switch (sortFirst)
                    {
                        case 1:
                            result = result.OrderBy(query => query.value);
                            break;
                        case 2:
                            result = result.OrderByDescending(query => query.value);
                            break;
                    }
                }
                
                if (frequencyFirst == 2)
                {
                    switch (sortFirst)
                    {
                        case 1:
                            result = result.OrderBy(query => query.key);
                            break;
                        case 2:
                            result = result.OrderByDescending(query => query.key);
                            break;
                    }
                }
                
                if (frequencySecond == 1)
                {
                    switch (sortSecond)
                    {
                        case 1:
                            result = result.ThenBy(query => query.value);
                            break;
                        case 2:
                            result = result.ThenByDescending(query => query.value);
                            break;
                    }
                }
                
                if (frequencySecond == 2)
                {
                    switch (sortSecond)
                    {
                        case 1:
                            result = result.ThenBy(query => query.key);
                            break;
                        case 2:
                            result = result.ThenByDescending(query => query.key);
                            break;
                    }
                }

                if (order == 1)
                {
                    foreach (var query in result.Take(int.Parse(n)))
                        Console.WriteLine(query.key + " " + query.value);
                }

                if (order == 2)
                {
                   foreach (var query in result.TakeLast(int.Parse(n)))
                       Console.WriteLine(query.key + " " + query.value);
                }
            Console.WriteLine();
            }

        }

        public enum Order {
            first = 1,last = 2
        }

        public enum Frequency
        {
            byfreq = 1, byletter = 2
        }

        public enum Sort
        {
            asc = 1, desc = 2 
        }
    }
}
