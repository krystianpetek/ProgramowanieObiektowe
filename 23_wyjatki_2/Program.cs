using System;

namespace _23_wyjatki_2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string linia1 = Console.ReadLine();
            string linia2 = Console.ReadLine();
            string linia3 = Console.ReadLine();
            try
            {
                long jeden = int.Parse(linia1);
                long dwa = int.Parse(linia2);
                long trzy = int.Parse(linia3);
                string wynik = $"{jeden * dwa * trzy}";
                Console.WriteLine(int.Parse(wynik));
            }
            catch (FormatException)
            {
                Console.WriteLine("format exception, exit");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("argument exception, exit");
            }
            catch (OverflowException)
            {
                Console.WriteLine("overflow exception, exit");
            }
            catch (Exception)
            {
                Console.WriteLine("non supported exception, exit");
            }
        }
    }
}