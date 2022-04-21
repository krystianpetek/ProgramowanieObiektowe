using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer
{
    internal class Program
    {
        public static void Main()
        {
            var sampleCollection = new SampleCollection();
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                sampleCollection[i] = rand.Next();
            }
            for(int i = 0;i < 10;i++)
            {
                Console.WriteLine(sampleCollection[i]);
            }
        
        }

    }
}
