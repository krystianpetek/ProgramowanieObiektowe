using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementacjaInterfejsow
{
    internal class Pracownik : IEquatable<Pracownik>, IComparable<Pracownik>
    {
        private string nazwisko;
        private DateTime dataZatrudnienia;
        private decimal wynagrodzenie;

        public Pracownik(string nazwisko, DateTime dataZatrudnienia, decimal wynagrodzenie)
        {
            Nazwisko = nazwisko;
            DataZatrudnienia = dataZatrudnienia;
            Wynagrodzenie = wynagrodzenie;
        }
        public Pracownik() : this("Anonim", DateTime.Now, 0) { }

        public string Nazwisko
        {
            get {
                return nazwisko;
            }
            set
            {
                nazwisko = value.Trim();
            }
        }
        public DateTime DataZatrudnienia { get { return dataZatrudnienia; }
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException();
                else
                    dataZatrudnienia = value;
            }
        }
        public decimal Wynagrodzenie { get { return wynagrodzenie; }
            set {

                if (value < 0) { wynagrodzenie = 0;
                    return;
                }
                wynagrodzenie = value;
            } 
        }
        public double CzasZatrudnienia => Math.Floor((DateTime.Now - DataZatrudnienia).TotalDays/30); 
        
        public override string ToString()
        {
            return $"({Nazwisko}, {DataZatrudnienia.ToShortDateString()} ({CzasZatrudnienia}), {Wynagrodzenie})";
        }

        public bool Equals(Pracownik? other)
        {
            if (other.Nazwisko != this.Nazwisko)
                return false;
            if (other.DataZatrudnienia != this.DataZatrudnienia)
                return false;
            if (other.Wynagrodzenie != this.Wynagrodzenie)
                return false;

            return true;
        }
        public override bool Equals(object? obj)
        {
            return Equals(obj as Pracownik);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Nazwisko, this.DataZatrudnienia, this.Wynagrodzenie);
        }
        public static bool Equals(Pracownik p1, Pracownik p2)
        {
            return p1.Equals(p2);
        }

        public int CompareTo(Pracownik? other)
        {
            int zmienna = 0, wynik = 0;

            zmienna = this.Wynagrodzenie.CompareTo(other.Wynagrodzenie);
            if (zmienna > 0)
                wynik = 1;
            if (zmienna < 0)
                wynik = -1;

            zmienna = this.DataZatrudnienia.CompareTo(other.DataZatrudnienia);
            if (zmienna > 0)
                wynik = 1;
            if (zmienna < 0)
                wynik = -1;

            zmienna = this.Nazwisko.CompareTo(other.Nazwisko);
            if (zmienna > 0)
                wynik = 1;
            if (zmienna < 0)
                wynik = -1;

            return wynik;
        }

        //public int CompareTo(Pracownik other)
        //{
        //    if (other is null) return 1; // w C#: null jest najmniejszą wartością (`this > null`)
        //    if (this.Equals(other)) return 0; //zgodność z Equals (`this == other`)

        //    if (this.Nazwisko != other.Nazwisko)
        //        return this.Nazwisko.CompareTo(other.Nazwisko);

        //    // ponieważ nazwiska równe, porządkujemy wg daty
        //    if (!this.DataZatrudnienia.Equals(other.DataZatrudnienia)) // != zamiast !Equals
        //        return this.DataZatrudnienia.CompareTo(other.DataZatrudnienia);

        //    // ponieważ nazwiska równe i daty równe, porządkujemy wg wynagrodzenia
        //    return this.Wynagrodzenie.CompareTo(other.Wynagrodzenie);
        //}


        public static bool operator == (Pracownik p1, Pracownik p2)
        {
            if (p1.Nazwisko == p2.Nazwisko &&
                p1.DataZatrudnienia == p2.DataZatrudnienia &&
                p1.Wynagrodzenie == p2.Wynagrodzenie)
                return true;
            return false;
        }
        public static bool operator !=(Pracownik p1, Pracownik p2)
        {
            if (p1 == p2)
                return false;
            return true;
        }
    }
    
}
