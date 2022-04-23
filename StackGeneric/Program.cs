using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGeneric
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> theStack = new Stack<int>();

            for (int number = 0; number <= 9; number++)
            {
                theStack.Push(number);
            }
            
            foreach(var number in theStack)
            {
                Console.Write(number);
            }
            Console.WriteLine();

            foreach (var number in theStack.BottomToTop)
            {
                Console.Write(number);
            }
            Console.WriteLine();

            foreach (var number in theStack.TopToBottom)
            {
                Console.Write(number);
            }
            Console.WriteLine();

            foreach (var number in theStack.TopToN(73))
            {
                Console.Write(number);
            }
            Console.WriteLine();
        }
    }
}
