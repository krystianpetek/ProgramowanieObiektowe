namespace Time_TimePeriodWithMiliseconds
{
    /// <summary>
    /// Struktura <c>TimePeriodWithMiliseconds</c> reprezentuje długość odcinka w czasie (odległość między dwoma punktami czasowymi, czas trwania)
    /// </summary>
    public readonly struct TimePeriodWithMiliseconds : IEquatable<TimePeriodWithMiliseconds>, IComparable<TimePeriodWithMiliseconds>
    {
        /// <summary>
        /// Reprezentuje godzinę w sekundach, pole jest tylko do odczytu.
        /// </summary>
        public long NumberOfMiliseconds { get; init; }

        /// <summary>
        /// Reprezentuje liczbę godzin w czasie, pole jest tylko do odczytu.
        /// </summary>
        public long Hours => (NumberOfMiliseconds / 60) / 60;

        /// <summary>
        /// Reprezentuje liczbę minut w czasie, pole jest tylko do odczytu.
        /// </summary>
        public long Minutes => (NumberOfMiliseconds / 60) % 60;

        /// <summary>
        /// Reprezentuje liczbę sekund w czasie, pole jest tylko do odczytu.
        /// </summary>
        public long Seconds => NumberOfMiliseconds % 60;

        /// <summary>
        /// Reprezentuje liczbę milisekund w czasie, pole jest tylko do odczytu.
        /// </summary>
        public long Miliseconds => NumberOfMiliseconds % 1000;

        /// <summary>
        /// Konstruktor przyjmuje 3 argumenty reprezentacji odcinka czasu tj. godzina, minuta, sekunda, milisekunda.
        /// </summary>
        /// <param name="numOfHours">Parametr <c>numOfHours</c> reprezentuje liczbę godzin w odcinku czasu</param>
        /// <param name="numOfMinutes">Parametr <c>numOfMinutes</c> reprezentuje liczbę minut w odcinku czasu</param>
        /// <param name="numOfSeconds">Parametr <c>numOfSeconds</c> reprezentuje liczbę sekund w odcinku czasu</param>
        /// <param name="numOfMiliseconds">Parametr <c>numOfSeconds</c> reprezentuje liczbę milisekund w odcinku czasu</param>
        /// <exception cref="ArgumentOutOfRangeException">Wyrzuca wyjątek w przypadku złych wartości godziny, z poza zakresu minut i sekund</exception>
        public TimePeriodWithMiliseconds(long numOfHours, long numOfMinutes, long numOfSeconds, long numOfMiliseconds)
        {
            if (numOfHours < 0 || numOfMinutes >= 60 || numOfMinutes < 0 || numOfSeconds >= 60 || numOfSeconds < 0 || numOfMiliseconds < 0 || numOfMiliseconds >= 1000)
                throw new ArgumentOutOfRangeException("Wrong range of time.");

            NumberOfMiliseconds = (numOfHours * 3600000) + (numOfMinutes * 60000) + (numOfSeconds * 6000) + numOfMiliseconds;
        }

        /// <summary>
        /// Konstruktor przyjmuje 3  argumenty reprezentacji odcinka czasu tj. godzina, minuta, sekunda.
        /// </summary>
        /// <param name="numOfHours">Parametr <c>numOfHours</c> reprezentuje liczbę godzin w odcinku czasu</param>
        /// <param name="numOfMinutes">Parametr <c>numOfMinutes</c> reprezentuje liczbę minut w odcinku czasu</param>
        public TimePeriodWithMiliseconds(long numOfHours, long numOfMinutes, long numOfSeconds) : this(numOfHours, numOfMinutes, numOfSeconds, 0) { }

        /// <summary>
        /// Konstruktor przyjmuje 2 argumenty reprezentacji odcinka czasu tj. godzina, minuta.
        /// </summary>
        /// <param name="numOfHours">Parametr <c>numOfHours</c> reprezentuje liczbę godzin w odcinku czasu</param>
        /// <param name="numOfMinutes">Parametr <c>numOfMinutes</c> reprezentuje liczbę minut w odcinku czasu</param>
        public TimePeriodWithMiliseconds(long numOfHours, long numOfMinutes) : this(numOfHours, numOfMinutes, 0, 0) { }

        /// <summary>
        /// Konstruktor domyślny reprezentacji odcinka czasu. Wszystkie wartości default czyli 0.
        /// </summary>
        public TimePeriodWithMiliseconds() : this(0, 0, 0) { }

        /// <summary>
        /// Konstruktor przyjmuje 1 argument reprezentacji czasu tj. sekundy. Przykładowo argument 3600 tworzy obiekt TimePeriodWithMiliseconds o wartości 1 godzina, 0 minut, 0 sekund
        /// </summary>
        /// <param name="numberOfSeconds">Parametr <c>numberOfSeconds</c> reprezentuje liczbę godzin w odcinku czasu</param>
        /// <exception cref="ArgumentOutOfRangeException">Wyrzuca wyjątek w przypadku podania wartości z poza zakresu, tj, wartości ujemnych</exception>
        public TimePeriodWithMiliseconds(long numberOfSeconds)
        {
            if (numberOfSeconds < 0)
                throw new ArgumentOutOfRangeException("Wrong value of seconds.");

            NumberOfMiliseconds = numberOfSeconds;
        }

        /// <summary>
        /// Konstruktor tworzy obiekt typu TimePeriodWithMiliseconds, o wartościach różnicy czasu Time t1 i t2
        /// </summary>
        /// <param name="t1">Argument typu <c>Time</c> przyjmuje punkt w czasie t1</param>
        /// <param name="t2">Argument typu <c>Time</c> przyjmuje punkt w czasie t2</param>
        public TimePeriodWithMiliseconds(TimeWithMiliseconds t1, TimeWithMiliseconds t2)
        {
            long hours = 0, minutes = 0, seconds = 0, miliseconds = 0;
            if (t1.CompareTo(t2) > 0)
            {
                hours = t1.Hours - t2.Hours;
                minutes = t1.Minutes - t2.Minutes;
                seconds = t1.Seconds - t2.Seconds;
                miliseconds = t1.Miliseconds - t2.Miliseconds;
            }
            else if (t1.CompareTo(t2) < 0)
            {
                hours = t2.Hours - t1.Hours;
                minutes = t2.Minutes - t1.Minutes;
                seconds = t2.Seconds - t1.Seconds;
                miliseconds = t2.Miliseconds - t1.Miliseconds;
            }

            NumberOfMiliseconds = (hours * 3600) + (minutes * 60) + seconds + miliseconds;
        }

        /// <summary>
        /// Konstruktor tworzy obiekt TimePeriodWithMiliseconds parsując argument czas ze <c>String</c>'a
        /// </summary>
        /// <param name="timePattern">Parametr timePattern reprezentuje czas, lecz w formie string'a</param>
        /// <exception cref="FormatException">Wyrzuca wyjątek w momencie wprowadzenia złych danych, niemożliwych do parsowania</exception>
        /// <exception cref="ArgumentOutOfRangeException">Wyrzuca wyjątek w przypadku złych wartości godziny, z poza zakresu</exception>
        public TimePeriodWithMiliseconds(string timePattern)
        {
            string[] splitTime = timePattern.Split(":");
            if (splitTime.Length != 4)
                throw new ArgumentOutOfRangeException("Wrong data in argument");

            bool parseHours = int.TryParse(splitTime[0], out int hours);
            bool parseMinutes = int.TryParse(splitTime[1], out int minutes);
            bool parseSeconds = int.TryParse(splitTime[2], out int seconds);
            bool parseMiliseconds = int.TryParse(splitTime[3], out int miliseconds);

            if (!parseHours || !parseMinutes || !parseSeconds || !parseMiliseconds)
                throw new ArgumentOutOfRangeException("Invalid argument for parse to Time.");

            if (hours < 0)
                throw new ArgumentOutOfRangeException("Wrong number of hour.");

            if (minutes >= 60 || minutes < 0)
                throw new ArgumentOutOfRangeException("Wrong number of minute.");

            if (seconds >= 60 || seconds < 0)
                throw new ArgumentOutOfRangeException("Wrong number of second.");

            if (miliseconds >= 1000 || miliseconds < 0)
                throw new ArgumentOutOfRangeException("Wrong number of second.");

            NumberOfMiliseconds = (hours * 3600) + (minutes * 60) + seconds + miliseconds;
        }

        /// <summary>
        /// Tekstowa reprezentacja odcinka czasu TimePeriodWithMiliseconds, zwraca zewnętrzną reprezentacje czasu w formie string'a
        /// </summary>
        /// <returns>Zwraca zewnętrzną reprezentacje TimePeriodWithMiliseconds</returns>
        public override string ToString()
        {
            return $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}:{Miliseconds:D2}";
        }

        /// <summary>
        /// Porównuje obiekt TimePeriodWithMiliseconds instancji i przekazany obiekt w parametrze, zwraca wartość:
        /// <list type="table">
        /// <term>1</term> <description>gdy obiekt instancji jest większy niż obiekt przekazany w parametrze</description><br/>
        /// <term>0</term> <description>gdy obiekt instancji jest równy obiektowi przekazanemu w parametrze</description><br/>
        /// <term>-1</term> <description>gdy obiekt instancji jest mniejszy niż obiekt przekazany w parametrze</description>
        /// </list></summary>
        /// <param name="other">Obiekt porównywany typu TimePeriodWithMiliseconds</param>
        /// <returns>Zwraca wartość pomiędzy 1, 0 lub -1</returns>
        public int CompareTo(TimePeriodWithMiliseconds other)
        {
            if (this.NumberOfMiliseconds > other.NumberOfMiliseconds)
                return 1;
            else if (this.NumberOfMiliseconds < other.NumberOfMiliseconds)
                return -1;
            else
                return 0;
        }

        /// <summary>
        /// Sprawdza czy obiekt instancji TimePeriodWithMiliseconds i przekazany obiekt przez parametr są sobie równe
        /// </summary>
        /// <param name="other">Obiekt porównywany z instancją typu TimePeriodWithMiliseconds, reprezentuje odcinek czasu</param>
        /// <returns>Zwraca wartość logiczną sprawdzającą czy obiekty są sobie równe</returns>
        public bool Equals(TimePeriodWithMiliseconds other)
        {
            if (this.NumberOfMiliseconds == other.NumberOfMiliseconds)
                return true;
            return false;
        }

        /// <summary>
        /// Sprawdza czy obiekt instancji TimePeriodWithMiliseconds i przekazany obiekt przez parametr są sobie równe
        /// </summary>
        /// <param name="obj">Obiekt porównywany z instancją typu TimePeriodWithMiliseconds, reprezentuje odcinek czasu</param>
        /// <returns>Zwraca wartość logiczną sprawdzającą czy obiekty są sobie równe</returns>
        public override bool Equals(object? obj)
        {
            if (obj is TimePeriodWithMiliseconds)
                return Equals(obj as TimePeriodWithMiliseconds?);
            return false;
        }

        /// <summary>
        /// Służy jako domyślna funkcja skrótu
        /// </summary>
        /// <returns>Zwraca wartość int, zawierającą obliczoną funkcję skrótu obiektu</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Hours, Minutes, Seconds);
        }

        /// <summary>
        /// Sprawdza czy obiekty TimePeriodWithMiliseconds przekazane przez parametr są sobie równe
        /// </summary>
        /// <param name="timePeriod1">obiekt typu TimePeriodWithMiliseconds timePeriod1, reprezentuje odcinek czasu</param>
        /// <param name="timePeriod2">obiekt typu TimePeriodWithMiliseconds timePeriod1, reprezentuje odcinek czasu</param>
        /// <returns>Zwraca wartość logiczną sprawdzającą czy obiekty są sobie równe</returns>
        public static bool operator ==(TimePeriodWithMiliseconds timePeriod1, TimePeriodWithMiliseconds timePeriod2)
        {
            return timePeriod1.Equals(timePeriod2);
        }

        /// <summary>
        /// Sprawdza czy obiekty TimePeriodWithMiliseconds przekazane przez parametr są różne
        /// </summary>
        /// <param name="timePeriod1">obiekt typu TimePeriodWithMiliseconds timePeriod1, reprezentuje odcinek czasu</param>
        /// <param name="timePeriod2">obiekt typu TimePeriodWithMiliseconds timePeriod1, reprezentuje odcinek czasu</param>
        /// <returns>Zwraca wartość logiczną sprawdzającą czy obiekty są różne</returns>
        public static bool operator !=(TimePeriodWithMiliseconds timePeriod1, TimePeriodWithMiliseconds timePeriod2)
        {
            return !(timePeriod1 == timePeriod2);
        }

        /// <summary>
        /// Sprawdza czy obiekt TimePeriodWithMiliseconds timePeriod1 jest mniejszy od TimePeriod2
        /// </summary>
        /// <param name="timePeriod1">obiekt typu TimePeriodWithMiliseconds timePeriod1, reprezentuje odcinek czasu</param>
        /// <param name="timePeriod2">obiekt typu TimePeriodWithMiliseconds timePeriod2, reprezentuje odcinek czasu</param>
        /// <returns>Zwraca wartość logiczną sprawdzającą czy TimePeriodWithMiliseconds timePeriod1 jest mniejszy od TimePeriodWithMiliseconds timePeriod2</returns>
        public static bool operator <(TimePeriodWithMiliseconds timePeriod1, TimePeriodWithMiliseconds timePeriod2)
        {
            if (timePeriod1.CompareTo(timePeriod2) < 0)
                return true;
            return false;
        }

        /// <summary>
        /// Sprawdza czy obiekt TimePeriodWithMiliseconds timePeriod1 jest większy od TimePeriod2
        /// </summary>
        /// <param name="timePeriod1">obiekt typu TimePeriodWithMiliseconds timePeriod1, reprezentuje odcinek czasu</param>
        /// <param name="timePeriod2">obiekt typu TimePeriodWithMiliseconds timePeriod1, reprezentuje odcinek czasu</param>
        /// <returns>Zwraca wartość logiczną sprawdzającą czy Time t1 jest większy od Time t2</returns>
        public static bool operator >(TimePeriodWithMiliseconds timePeriod1, TimePeriodWithMiliseconds timePeriod2)
        {
            if (timePeriod1.CompareTo(timePeriod2) > 0)
                return true;
            return false;
        }

        /// <summary>
        /// Sprawdza czy obiekt TimePeriodWithMiliseconds timePeriod1 jest mniejszy lub równy od TimePeriod2
        /// </summary>
        /// <param name="timePeriod1">obiekt typu TimePeriodWithMiliseconds timePeriod1, reprezentuje odcinek czasu</param>
        /// <param name="timePeriod2">obiekt typu TimePeriodWithMiliseconds timePeriod2, reprezentuje odcinek czasu</param>
        /// <returns>Zwraca wartość logiczną sprawdzającą czy TimePeriodWithMiliseconds timePeriod1 jest mniejszy lub równy od TimePeriodWithMiliseconds timePeriod2</returns>

        public static bool operator <=(TimePeriodWithMiliseconds timePeriod1, TimePeriodWithMiliseconds timePeriod2)
        {
            if (timePeriod1.CompareTo(timePeriod2) <= 0)
                return true;
            return false;
        }

        /// <summary>
        /// Sprawdza czy obiekt TimePeriodWithMiliseconds timePeriod1 jest większy lub równy od TimePeriod2
        /// </summary>
        /// <param name="timePeriod1">obiekt typu TimePeriodWithMiliseconds timePeriod1, reprezentuje odcinek czasu</param>
        /// <param name="timePeriod2">obiekt typu TimePeriodWithMiliseconds timePeriod2, reprezentuje odcinek czasu</param>
        /// <returns>Zwraca wartość logiczną sprawdzającą czy TimePeriodWithMiliseconds timePeriod1 jest większy lub równy od TimePeriodWithMiliseconds timePeriod2</returns>
        public static bool operator >=(TimePeriodWithMiliseconds timePeriod1, TimePeriodWithMiliseconds timePeriod2)
        {
            if (timePeriod1.CompareTo(timePeriod2) >= 0)
                return true;
            return false;
        }

        /// <summary>
        /// Dodaje do instancji czasu TimePeriodWithMiliseconds, obiekt przekazany przez parametr typu TimePeriodWithMiliseconds, określoną jednostkę czasu
        /// </summary>
        /// <param name="timePeriod">obiekt typu TimePeriodWithMiliseconds reprezentuje okres czasu</param>
        /// <returns>Zwraca obiekt typu TimePeriodWithMiliseconds sumujący odcinki czasu TimePeriodWithMiliseconds</returns>
        public TimePeriodWithMiliseconds Plus(TimePeriodWithMiliseconds timePeriod)
        {
            return this + timePeriod;
        }

        /// <summary>
        /// Dodaje do instancji czasu TimePeriodWithMiliseconds, obiekt przekazany przez parametr typu TimePeriodWithMiliseconds, określoną jednostkę czasu
        /// </summary>
        /// <param name="timePeriod1">obiekt typu TimePeriodWithMiliseconds reprezentuje okres czasu</param>
        /// <param name="timePeriod2">obiekt typu TimePeriodWithMiliseconds reprezentuje okres czasu</param>
        /// <returns>Zwraca obiekt typu TimePeriodWithMiliseconds sumujący odcinki czasu TimePeriodWithMiliseconds</returns>
        public static TimePeriodWithMiliseconds Plus(TimePeriodWithMiliseconds timePeriod1, TimePeriodWithMiliseconds timePeriod2)
        {
            return timePeriod1 + timePeriod2;
        }

        /// <summary>
        /// Odejmuje do instancji czasu TimePeriodWithMiliseconds, obiekt przekazany przez parametr typu TimePeriodWithMiliseconds, określoną jednostkę czasu
        /// </summary>
        /// <param name="timePeriod">obiekt typu TimePeriodWithMiliseconds reprezentuje okres czasu</param>
        /// <returns>Zwraca obiekt typu TimePeriodWithMiliseconds odejmujący odcinki czasu TimePeriodWithMiliseconds</returns>
        public TimePeriodWithMiliseconds Minus(TimePeriodWithMiliseconds timePeriod)
        {
            return this - timePeriod;
        }

        /// <summary>
        /// Odejmuje do instancji czasu TimePeriodWithMiliseconds, obiekt przekazany przez parametr typu TimePeriodWithMiliseconds, określoną jednostkę czasu
        /// </summary>
        /// <param name="timePeriod1">obiekt typu TimePeriodWithMiliseconds reprezentuje okres czasu</param>
        /// <param name="timePeriod2">obiekt typu TimePeriodWithMiliseconds reprezentuje okres czasu</param>
        /// <returns>Zwraca obiekt typu TimePeriodWithMiliseconds odejmujący odcinki czasu TimePeriodWithMiliseconds</returns>
        public static TimePeriodWithMiliseconds Minus(TimePeriodWithMiliseconds timePeriod1, TimePeriodWithMiliseconds timePeriod2)
        {
            return timePeriod1 - timePeriod2;
        }

        /// <summary>
        /// Dodaje do instancji czasu TimePeriodWithMiliseconds, obiekt przekazany przez parametr typu TimePeriodWithMiliseconds, określoną jednostkę czasu
        /// </summary>
        /// <param name="timePeriod1">obiekt typu TimePeriodWithMiliseconds reprezentuje okres czasu</param>
        /// <param name="timePeriod2">obiekt typu TimePeriodWithMiliseconds reprezentuje okres czasu</param>
        /// <returns>Zwraca obiekt typu TimePeriodWithMiliseconds sumujący odcinki czasu TimePeriodWithMiliseconds</returns>
        public static TimePeriodWithMiliseconds operator +(TimePeriodWithMiliseconds timePeriod1, TimePeriodWithMiliseconds timePeriod2)
        {
            return new TimePeriodWithMiliseconds(timePeriod1.NumberOfMiliseconds + timePeriod2.NumberOfMiliseconds);
        }

        /// <summary>
        /// Odejmuje do instancji czasu TimePeriodWithMiliseconds, obiekt przekazany przez parametr typu TimePeriodWithMiliseconds, określoną jednostkę czasu
        /// </summary>
        /// <param name="timePeriod1">obiekt typu TimePeriodWithMiliseconds reprezentuje okres czasu</param>
        /// <param name="timePeriod2">obiekt typu TimePeriodWithMiliseconds reprezentuje okres czasu</param>
        /// <returns>Zwraca obiekt typu TimePeriodWithMiliseconds odejmujący odcinki czasu TimePeriodWithMiliseconds</returns>
        public static TimePeriodWithMiliseconds operator -(TimePeriodWithMiliseconds timePeriod1, TimePeriodWithMiliseconds timePeriod2)
        {
            if (timePeriod1.NumberOfMiliseconds > timePeriod2.NumberOfMiliseconds)
                return new TimePeriodWithMiliseconds(timePeriod1.NumberOfMiliseconds - timePeriod2.NumberOfMiliseconds);
            else if (timePeriod1.NumberOfMiliseconds < timePeriod2.NumberOfMiliseconds)
                return new TimePeriodWithMiliseconds(timePeriod2.NumberOfMiliseconds - timePeriod1.NumberOfMiliseconds);
            else
                return new TimePeriodWithMiliseconds();
        }

        /// <summary>
        /// Operator mnożenia mnoży godzinę z okresu czasu, o mnożnik podany po operatorze
        /// </summary>
        /// <param name="timePeriod">Obiekt typu TimePeriodWithMiliseconds reprezentuje okres czasu</param>
        /// <param name="iloraz">Mnożnik godzin</param>
        /// <returns></returns>
        public static TimePeriodWithMiliseconds operator *(TimePeriodWithMiliseconds timePeriod, int iloraz)
        {
            return new TimePeriodWithMiliseconds(timePeriod.Hours * iloraz, timePeriod.Minutes, timePeriod.Seconds);
        }
    }
}