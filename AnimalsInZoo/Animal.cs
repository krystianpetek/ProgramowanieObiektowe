using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsInZoo
{
    internal class Animal
    {
        public enum TypeEnum { Bird, Mammal }
        public string Name { get; set; }
        public TypeEnum Type { get; set; }
    }
}
