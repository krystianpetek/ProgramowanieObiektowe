using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PudelkoLibrary
{
    public sealed partial class Pudelko :IFormattable, IEnumerable, IEquatable<Pudelko>
    {
        public double A { get; init; } // dlugosc
        public double B { get; init; } // wysokosc
        public double C { get; init; } // szerokosc
        public UnitOfMeasure Miara { get; init; }
        public Pudelko(double? a = null, double? b = null, double? c = null,UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            double aNotNull=0, bNotNull=0, cNotNull=0;
            #region METRY
            if (unit == UnitOfMeasure.meter)
            {
                if (a != null)
                    aNotNull = Math.Round((double)a, 3, MidpointRounding.ToZero);
                else
                    aNotNull = Math.Round(0.1000,3);
                
                if (b != null)
                    bNotNull = Math.Round((double)b,3,MidpointRounding.ToZero);
                else
                    bNotNull = Math.Round(0.1000,3);
                
                if (c != null)
                    cNotNull = Math.Round((double)c, 3, MidpointRounding.ToZero);
                else
                    cNotNull = Math.Round(0.1000,3);
            }
            #endregion
            #region CENTYMETRY
            if (unit == UnitOfMeasure.centimeter)
            {
                if (a != null)
                    aNotNull = Math.Round( ((double)a/100) , 3, MidpointRounding.ToZero);
                else
                    aNotNull = Math.Round(0.1000, 3);

                if (b != null)
                    bNotNull = Math.Round(((double)b/100), 3, MidpointRounding.ToZero);
                else
                    bNotNull = Math.Round(0.1000, 3);

                if (c != null)
                    cNotNull = Math.Round(((double)c/100), 3, MidpointRounding.ToZero);
                else
                    cNotNull = Math.Round(0.1000, 3);
            }
            #endregion
            #region MILIMETRY
            if (unit == UnitOfMeasure.milimeter)
            {
                if (a != null)
                    aNotNull = Math.Round( ((double)a/1000), 3, MidpointRounding.ToZero);
                else
                    aNotNull = Math.Round(0.1000, 3);

                if (b != null)
                    bNotNull= Math.Round(((double)b/1000), 3, MidpointRounding.ToZero);
                else
                    bNotNull = Math.Round(0.1000, 3);

                if (c != null)
                    cNotNull = Math.Round(((double)c/1000), 3, MidpointRounding.ToZero);
                else
                    cNotNull = Math.Round(0.1000, 3);
            }
            #endregion
            #region BŁEDY
            if (aNotNull <= 0 || bNotNull <= 0 || cNotNull <= 0)
                throw new ArgumentOutOfRangeException();

            if (aNotNull > 10.000 || bNotNull > 10.000 || cNotNull > 10.000)
                throw new ArgumentOutOfRangeException();
            
            #endregion
            A = aNotNull;
            B = bNotNull;
            C = cNotNull;
        }
        
        public override string ToString()
        {
            return this.ToString("m");
        }

        public string ToString(string? format)
        {
            return this.ToString(format, CultureInfo.CurrentCulture);
        }

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            char multiplicationSign = '\u00D7';
            string wynik = "";
            if (format == null || format == String.Empty)
                format = "m";
            if (format == "m")
                return $"{A:F3} m {multiplicationSign} {B:F3} m {multiplicationSign} {C:F3} m";
            else if (format == "cm")
                return $"{A * 100:F1} cm {multiplicationSign} {B * 100:F1} cm {multiplicationSign} {C * 100:F1} cm";
            else if (format == "mm")
                return $"{A * 1000:F0} mm {multiplicationSign} {B * 1000:F0} mm {multiplicationSign} {C * 1000:F0} mm";
            else
                throw new FormatException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Equals(Pudelko? other)
        {
            throw new NotImplementedException();
        }
    }
}
