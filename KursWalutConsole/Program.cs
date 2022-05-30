using KursyWalutZNBP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursyWalutConsole
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //if (args.Length <= 0)
            //    return;

            string currencyValid = string.Empty;
            string dataFromValid = string.Empty;
            string dataToValid = string.Empty;

            try { 
             
                var currency = args[0];
                currencyValid = currency;
                var dataFrom = args[1];
                dataFromValid = dataFrom;
                var dataTo = args[2];
                dataToValid = dataTo;
            
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            Class1 clasa = new Class1();
            var wynik = clasa.document();
        }
    }
}
