using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer
{
    internal class SampleCollection : ISampleCollection
    {
        private int[] array = new int[100];
        public int this[int index] { get => array[index]; set => array[index] = value; }
    }
}
