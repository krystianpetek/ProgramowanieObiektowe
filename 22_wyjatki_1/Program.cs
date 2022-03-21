using System;

namespace _22_wyjatki_1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// Oblicza obwód trójkąta dowolnego dla zadanych długości boków, zaokrąglając wynik do podanej liczby cyfr po przecinku
        /// </summary>
        /// <param name="a">długość pierwszego boku, liczba całkowita nieujemna</param>
        /// <param name="b">długość drugiego boku, liczba całkowita nieujemna</param>
        /// <param name="c">długość trzeciego boku, liczba całkowita nieujemna</param>
        /// <param name="precision">dokładność obliczeń (zaokrąglenie), liczba cyfr po przecinku (od 2 do 8)</param>
        /// <returns>obwód trójkąta obliczone z zadaną dokładnością</returns>
        /// <exception cref="ArgumentOutOfRangeException">z komunikatem "wrong arguments",
        ///     gdy <c>precision</c> jest poza przedziałem od 2 do 8 lub którakolwiek z długości jest ujemna</exception>
        /// <exception cref="ArgumentException">z komunikatem "object not exist", gdy trójkąta nie można utworzyć</exception>
        /// <remarks>dopuszczamy trójkąt o pokrywających się bokach lub o wszystkich bokach o długości 0</remarks>
        public static double TrianglePerimeter(int a, int b, int c, int precision = 2)
        {
            if (a < 0 || b < 0 || c < 0 || precision > 8 || precision < 2)
                throw new ArgumentOutOfRangeException("wrong arguments");
            if (a + b < c || a + c < b || b + c < a)
                throw new ArgumentException("object not exist");

            return Math.Round(a * 1.0 + b * 1.0 + c * 1.0, precision);
        }
    }
}