using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    internal class Program
    {
        static void Main()
        {
            foreach(var item in EvenSequence(5,18))
            {
                Console.WriteLine(item);
            }
        }
        static IEnumerable<int> EvenSequence(int firstNumber, int lastNumber)
        {
            for (int number = firstNumber; number <= lastNumber; number++)
            {
                if(number % 2 == 0)
                yield return number;
            }
        }
    }
}
