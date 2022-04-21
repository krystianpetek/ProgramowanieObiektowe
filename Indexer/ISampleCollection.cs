using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer
{
    internal interface ISampleCollection
    {
        public int this[int index]
        {
            get;
            set;
        }
    }
}
