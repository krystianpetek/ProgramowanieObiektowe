using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PudelkoLibrary
{
    public sealed partial class Pudelko
    {
        public double A { get; init; } // dlugosc
        public double B { get; init; } // wysokosc
        public double C { get; init; } // szerokosc
        public UnitOfMeasure Miara { get; init; }
        public Pudelko(double a = 0.1, double b = 0.1, double c = 0.1, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            #region błędy
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentOutOfRangeException();

            if (unit == UnitOfMeasure.meter)
            {
                if (a > 10 || b > 10 || c > 10)
                    throw new ArgumentOutOfRangeException();
            }
            else if (unit == UnitOfMeasure.centimeter)
            {
                if (a > 1000 || b > 1000 || c > 1000)
                    throw new ArgumentOutOfRangeException();
            }
            else if (unit == UnitOfMeasure.milimeter)
            {
                if (a > 10000 || b > 10000 || c > 10000)
                    throw new ArgumentOutOfRangeException();
            }
            #endregion

            if (a == 0 && unit == UnitOfMeasure.meter)
                A = Math.Round(0.1000, 3);
            //else if (a == 0 && unit == UnitOfMeasure.centimeter)
            //    A = Math.Round(10.0, 1);
            //else if (a == 0 && unit == UnitOfMeasure.milimeter)
            //    A = Math.Round(100.0, 0);

            if (b == 0 && unit == UnitOfMeasure.meter)
                B = Math.Round(0.1000, 3);
            //else if (a == 0 && unit == UnitOfMeasure.centimeter)
            //    B = Math.Round(10.0, 1);
            //else if (a == 0 && unit == UnitOfMeasure.milimeter)
            //    B = Math.Round(100.0, 0);

            if (b == 0 && unit == UnitOfMeasure.meter)
                C = Math.Round(0.1000, 3);
            //else if (a == 0 && unit == UnitOfMeasure.centimeter)
            //    C = Math.Round(10.0, 1);
            //else if (a == 0 && unit == UnitOfMeasure.milimeter)
            //    C = Math.Round(100.0, 0);

            if (a > 0 && unit == UnitOfMeasure.meter)
                A = Math.Round(a, 3);
            else if (a > 0 && unit == UnitOfMeasure.centimeter)
                A = Math.Round(a / 100.0, 1);
            else if (a > 0 && unit == UnitOfMeasure.milimeter)
                A = a / 1000.0;

            if (b > 0 && unit == UnitOfMeasure.meter)
                B = Math.Round(b, 3);
            else if (b > 0 && unit == UnitOfMeasure.centimeter)
                B = Math.Round(b / 100.0, 1);
            else if (b > 0 && unit == UnitOfMeasure.milimeter)
                B = b / 1000.0;

            if (c > 0 && unit == UnitOfMeasure.meter)
                C = Math.Round(c, 3);
            else if (c > 0 && unit == UnitOfMeasure.centimeter)
                C = Math.Round(c / 100.0, 1);
            else if (c > 0 && unit == UnitOfMeasure.milimeter)
                C = c / 1000.0;
        }
    }
}
