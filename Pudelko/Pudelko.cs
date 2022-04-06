using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadaniePudelko
{
    public sealed partial class Pudelko
    {
        public double a { get; init; } // dlugosc
        public double b { get; init; } // wysokosc
        public double c { get; init; } // szerokosc
        public UnitOfMeasure miara {get;init;}
        public Pudelko(double a = 0.1, double b = 0.1, double c = 0.1, UnitOfMeasure miara = UnitOfMeasure.meter)
        {
            if(a <= 0)

            this.a = a;
            this.b = b;
            this.c = c;
            this.miara = miara;
        }

        double CheckMeasure(double number)
        {
            if (miara == UnitOfMeasure.milimeter)
                return number *= 100;
            if (miara == UnitOfMeasure.centimeter)
                return number *= 100;
            return number;
        }
    }
}
