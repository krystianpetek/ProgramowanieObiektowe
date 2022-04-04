using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementacjaInterfejsow
{
    internal class Pracownik
    {
        private string nazwisko;
        private DateTime dataZatrudnienia;
        private decimal wynagrodzenie;
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
                if (value < 0) wynagrodzenie = 0;
            } 
        }
        public override string ToString()
        {
            return $"({Nazwisko}, {DataZatrudnienia}, {Wynagrodzenie})}";
        }
    }
    
}
