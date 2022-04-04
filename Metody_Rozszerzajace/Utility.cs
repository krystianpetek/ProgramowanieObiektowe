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

        // zadanie 1
        public static string BezSamoglosek(this string napis)
        {
            string[] tab = napis.Split('a', 'e', 'i', 'o', 'u', 'y', 'ą', 'ę');
            string wynik = string.Empty;
            foreach (var x in tab)
                wynik += x;
            return wynik;
        }

        // zadanie 2
        public static bool IsNumeric(this string napis)
        {
            return int.TryParse(napis, out int result);
        }

        // zadanie 3
        public static string Dump(this List<int> lista)
        {
            string result = "{";
            for (int i = 0; i < lista.Count; i++)
            {
                if (i == lista.Count - 1)
                    result += $"{lista[i]}" + "}";
                else
                {
                    result += $"{lista[i]}, ";
                }
            }
            return result;
        }

        // zadanie 4
        public static void PrintLn<T>(this IEnumerable<T> enumerator)
        {
            foreach (var x in enumerator)
                Console.WriteLine(x);
        }

        // zadanie 5 - mediana
        public static double Mediana(this IEnumerable<int> listaPosortowana)
        {
            var x = listaPosortowana.ToArray();
            var query = listaPosortowana.Count() / 2;
            if (listaPosortowana.Count() % 2 == 0)
            {
                var jeden = x[query - 1];
                var dwa = x[query];
                return jeden + dwa / 2;
            }
            return x[query];
        }

        // zadanie 6
        public static bool Between<T>(this T mid, T lower, T upper) where T : IComparable<T>
        {
            var wynik1 = mid.CompareTo(lower);
            var wynik2 = upper.CompareTo(mid);

            if (wynik1 == -1 || wynik2 == -1)
                return false;
            return true;
        }

        // zadanie 7
        public static bool BetterBetween<T>(this T mid, T lower, T upper, Comparison<T> comparison)
        {
            var wynik1 = comparison.Invoke(mid, lower);
            var wynik2 = comparison.Invoke(upper, mid);
            if (wynik1 == -1 || wynik2 == -1)
                return false;
            return true;
        }
    }
}