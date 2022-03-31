using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HierarchiaKlasPojazdow
{
    internal class Samochod : IWodny, ILadowy
    {
        public Samochod()
        {
            
        }

        public int Max => throw new NotImplementedException();

        public int Min => throw new NotImplementedException();

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
