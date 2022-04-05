using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementacjaInterfejsow
{
    internal class WgCzasuZatrudnieniaPotemWgWynagrodzeniaComparer : IComparer<Pracownik>
    {
        public int Compare(Pracownik? x, Pracownik? y)
        {
            int zmienna = 0, wynik = 0;
            zmienna = x.Wynagrodzenie.CompareTo(y.Wynagrodzenie);
            if (zmienna > 0)
                wynik = 1;
            if (zmienna < 0)
                wynik = -1;

            zmienna = x.CzasZatrudnienia.CompareTo(y.CzasZatrudnienia);
            if (zmienna > 0)
                wynik = 1;
            if (zmienna < 0)
                wynik = -1;

            return wynik;
        }

        public static int PorownywaczDelegat(Pracownik x, Pracownik y)
        {
            int zmienna = 0, wynik = 0;

            zmienna = x.Wynagrodzenie.CompareTo(y.Wynagrodzenie);
            if (zmienna > 0)
                wynik = 1;
            if (zmienna < 0)
                wynik = -1;

            zmienna = x.Nazwisko.CompareTo(y.Nazwisko);
            if (zmienna > 0)
                wynik = 1;
            if (zmienna < 0)
                wynik = -1;

            zmienna = x.CzasZatrudnienia.CompareTo(y.CzasZatrudnienia);
            if (zmienna > 0)
                wynik = 1;
            if (zmienna < 0)
                wynik = -1;

            return wynik;
        }
    }
}
