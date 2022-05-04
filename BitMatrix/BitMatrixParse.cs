using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitMatrixImplementation
{
    public partial class BitMatrix
    {
        public static BitMatrix Parse(string s)
        {

            if (string.IsNullOrWhiteSpace(s))
                throw new ArgumentNullException();
            var splitted = s.Split("\r\n");

            int dlugosc = splitted[0].Length;
            if (splitted.Any(x => x.Length != dlugosc))
                throw new FormatException();
            

            s = string.Join("", splitted);
            if(s.Any(x => x != '1' && x != '0'))
                throw new FormatException();

            var g = s.Select(x => int.Parse(x.ToString()));
            int[] wyjscie = g.ToArray();
            
            return new BitMatrix(splitted.Length, splitted[0].Length, wyjscie);
        }

        public static bool TryParse(string s, out BitMatrix result)
        {
            result = null;
            if (string.IsNullOrWhiteSpace(s))
                return false;
            var splitted = s.Split("\r\n");

            int dlugosc = splitted[0].Length;
            if (splitted.Any(x => x.Length != dlugosc))
                return false;


            s = string.Join("", splitted);
            if (s.Any(x => x != '1' && x != '0'))
                return false;

            var g = s.Select(x => int.Parse(x.ToString()));
            int[] wyjscie = g.ToArray();

            result = new BitMatrix(splitted.Length, splitted[0].Length, wyjscie);
            return true;
        }
    }
}
