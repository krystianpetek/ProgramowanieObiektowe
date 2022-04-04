using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metody_Rozszerzajace
{
    public static class Utility
    {
        public static int WordCount(string napis)
        {
            return napis.Split(" ", StringSplitOptions.RemoveEmptyEntries).Length;
        }
        
        public static int WordCount(string napis, params char[] delimiters)
        {
            return napis.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static int WordCountExtended(this string napis)
        {
            return napis.Split(" ", StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static int WordCountExtended(this string napis, params char[] delimiters)
        {
            return napis.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static string BezSamoglosek(this string napis)
        {

        }

    }
}
