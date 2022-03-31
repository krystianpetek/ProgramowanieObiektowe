using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HierarchiaKlasPojazdow
{
    internal interface IPojazd
    {
        public abstract void Start();
        public abstract void Stop();
        public int Max { get; }
        public int Min { get; }
    }
}
