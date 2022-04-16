namespace Time_TimePeriodWithMiliseconds
{
    /// <summary>
    /// Struktura <c>TimeWithMiliseconds</c> opisuje punkt w czasie w przedziale od 00:00:00 - 23:59:59
    /// </summary>
    public readonly struct TimeWithMiliseconds : IEquatable<TimeWithMiliseconds>, IComparable<TimeWithMiliseconds>
    {
        /// <summary>
        /// Reprezentuje liczbę godzin w czasie, pole jest tylko do odczytu.
        /// </summary>
        public int Hours { get; init; }

        /// <summary>
        /// Reprezentuje liczbę minut w czasie, pole jest tylko do odczytu.
        /// </summary>
        public int Minutes { get; init; }

        /// <summary>
        /// Reprezentuje liczbę sekund w czasie, pole jest tylko do odczytu.
        /// </summary>
        public int Seconds { get; init; }

        /// <summary>
        /// Reprezentuje liczbę milisekund w czasie, pole jest tylko do odczytu.
        /// </summary>
        public int Miliseconds { get; init; }

        /// <summary>
        /// Konstruktor przyjmuje 4 argumenty reprezentacji czasu tj. hours, minutes, seconds, miliseconds
        /// </summary>
        /// <param name="hours">Parametr hours reprezentuje liczbę godzin w punkcie czasu</param>
        /// <param name="minutes">Parametr minutes reprezentuje liczbę minut w punkcie czasu</param>
        /// <param name="seconds">Parametr seconds reprezentuje liczbę sekund w punkcie czasu</param>
        /// <param name="seconds">Parametr seconds reprezentuje liczbę milisekund w punkcie czasu</param>
        /// <exception cref="ArgumentOutOfRangeException">Wyrzuca wyjątek w przypadku złych wartości godziny, z poza zakresu</exception>
        public TimeWithMiliseconds(int hours, int minutes, int seconds, int miliseconds)
        {
            if (hours >= 24 || hours < 0)
                throw new ArgumentOutOfRangeException("Wrong number of hour.");
            Hours = hours;
            if (minutes >= 60 || minutes < 0)
                throw new ArgumentOutOfRangeException("Wrong number of minute.");
            Minutes = minutes;
            if (seconds >= 60 || seconds < 0)
                throw new ArgumentOutOfRangeException("Wrong number of second.");
            Seconds = seconds;
            if (miliseconds >= 1000 || miliseconds < 0)
                throw new ArgumentOutOfRangeException("Wrong number of second.");
            Miliseconds = miliseconds;
        }

        /// <summary>
        /// Konstruktor przyjmuje 3 argumenty reprezentacji czasu tj. hours, minutes, seconds.
        /// </summary>
        /// <param name="hours">Parametr hours reprezentuje liczbę godzin w punkcie czasu</param>
        /// <param name="minutes">Parametr minutes reprezentuje liczbę minut w punkcie czasu</param>
        /// <param name="seconds">Parametr seconds reprezentuje liczbę sekund w punkcie czasu</param>
        /// <exception cref="ArgumentOutOfRangeException">Wyrzuca wyjątek w przypadku złych wartości godziny, z poza zakresu</exception>
        public TimeWithMiliseconds(int hours, int minutes, int seconds) : this(hours, minutes, seconds, 0)
        {
        }

        /// <summary>
        /// Konstruktor przyjmuje 2 argumenty reprezentacji czasu tj. hours, minutes.
        /// </summary>
        /// <param name="hours">Parametr hours reprezentuje liczbę godzin w punkcie czasu</param>
        /// <param name="minutes">Parametr minutes reprezentuje liczbę minut w punkcie czasu</param>
        public TimeWithMiliseconds(int hours, int minutes) : this(hours, minutes, 0, 0)
        {
        }

        /// <summary>
        /// Konstruktor przyjmuje 1 argument reprezentacji czasu tj. hours.
        /// </summary>
        /// <param name="hours">Parametr hours reprezentuje liczbę godzin w punkcie czasu</param>
        public TimeWithMiliseconds(int hours) : this(hours, 0, 0, 0)
        {
        }

        /// <summary>
        /// Konstruktor domyślny reprezentacji czasu, przyjmuje wszystkie wartości default.
        /// </summary>
        public TimeWithMiliseconds() : this(0, 0, 0, 0)
        {
        }

        /// <summary>
        /// Konstruktor tworzy obiekt TimeWithMiliseconds parsując argument czas ze <c>String</c>'a
        /// </summary>
        /// <param name="timePattern">Parametr timePattern reprezentuje czas, lecz w formie string'a</param>
        /// <exception cref="FormatException">Wyrzuca wyjątek w momencie wprowadzenia złych danych, niemożliwych do Parsowania</exception>
        /// <exception cref="ArgumentOutOfRangeException">Wyrzuca wyjątek w przypadku złych wartości godziny, z poza zakresu</exception>
        public TimeWithMiliseconds(string timePattern)
        {
            string[] splitTime = timePattern.Split(":");
            if (splitTime.Length != 4)
                throw new ArgumentOutOfRangeException("Wrong data in argument");

            bool parseHours = int.TryParse(splitTime[0], out int hours);
            bool parseMinutes = int.TryParse(splitTime[1], out int minutes);
            bool parseSeconds = int.TryParse(splitTime[2], out int seconds);
            bool parseMiliseconds = int.TryParse(splitTime[3], out int miliseconds);

            if (!parseHours || !parseMinutes || !parseSeconds || !parseMiliseconds)
                throw new ArgumentOutOfRangeException("Invalid argument for parse to TimeWithMiliseconds.");

            if (hours >= 24 || hours < 0)
                throw new ArgumentOutOfRangeException("Wrong number of hour.");
            Hours = hours;

            if (minutes >= 60 || minutes < 0)
                throw new ArgumentOutOfRangeException("Wrong number of minute.");
            Minutes = minutes;

            if (seconds >= 60 || seconds < 0)
                throw new ArgumentOutOfRangeException("Wrong number of second.");
            Seconds = seconds;

            if (miliseconds >= 1000 || miliseconds < 0)
                throw new ArgumentOutOfRangeException("Wrong number of second.");
            Miliseconds = miliseconds;
        }

        /// <summary>
        /// Tekstowa reprezentacja punktu w czasie TimeWithMiliseconds, zwraca zewnętrzną reprezentacje czasu w formie string'a
        /// </summary>
        /// <returns>Zwraca zewnętrzną reprezentacje TimeWithMiliseconds</returns>
        public override string ToString()
        {
            return $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}:{Miliseconds:D2}";
        }

        /// <summary>
        /// Sprawdza czy obiekt TimeWithMiliseconds instancje i przekazany obiekt przez parametr są sobie równe
        /// </summary>
        /// <param name="other">Obiekt porównywany z instancją typu TimeWithMiliseconds, reprezentuje punkt w czasie</param>
        /// <returns>Zwraca wartość logiczną sprawdzającą czy obiekty są sobie równe</returns>
        public bool Equals(TimeWithMiliseconds other)
        {
            if (this.Hours != other.Hours)
                return false;
            if (this.Minutes != other.Minutes)
                return false;
            if (this.Seconds != other.Seconds)
                return false;
            if (this.Miliseconds != other.Miliseconds)
                return false;
            return true;
        }

        /// <summary>
        /// Sprawdza czy obiekt TimeWithMiliseconds instancji i przekazany obiekt przez parametr są sobie równe
        /// </summary>
        /// <param name="other">Obiekt porównywany z instancją, reprezentuje punkt w czasie</param>
        /// <returns>Zwraca wartość logiczną sprawdzającą czy obiekty są sobie równe</returns>
        public override bool Equals(object? obj)
        {
            if (obj is TimeWithMiliseconds)
                return Equals(obj as TimeWithMiliseconds?);
            return false;
        }

        /// <summary>
        /// Służy jako domyślna funkcja skrótu
        /// </summary>
        /// <returns>Zwraca wartość int, zawierającą obliczoną funkcję skrótu obiektu</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Hours, Minutes, Seconds, Miliseconds);
        }

        /// <summary>
        /// Porównuje obiekt TimeWithMiliseconds instancji i przekazany obiekt w parametrze, zwraca wartość:
        /// <list type="table">
        /// <term>1</term> <description>gdy obiekt instancji jest większy niż obiekt przekazany w parametrze</description><br/>
        /// <term>0</term> <description>gdy obiekt instancji jest równy obiektowi przekazanemu w parametrze</description><br/>
        /// <term>-1</term> <description>gdy obiekt instancji jest mniejszy niż obiekt przekazany w parametrze</description>
        /// </list></summary>
        /// <param name="other">Obiekt porównywany typu TimeWithMiliseconds</param>
        /// <returns>Zwraca wartość pomiędzy 1, 0 lub -1</returns>
        public int CompareTo(TimeWithMiliseconds other)
        {
            if (this.Hours > other.Hours)
                return 1;
            else if (this.Hours == other.Hours)
            {
                if (this.Minutes > other.Minutes)
                    return 1;
                else if (this.Minutes == other.Minutes)
                {
                    if (this.Seconds > other.Seconds)
                        return 1;
                    else if (this.Seconds == other.Seconds)
                    {
                        if (this.Miliseconds > other.Miliseconds)
                            return 1;
                        if (this.Miliseconds == other.Miliseconds)
                            return 0;
                    }
                    return -1;
                }
                return -1;
            }
            return -1;
        }

        /// <summary>
        /// Sprawdza czy obiekty TimeWithMiliseconds przekazane przez parametr są sobie równe
        /// </summary>
        /// <param name="time1">obiekt typu TimeWithMiliseconds time1, reprezentuje punkt w czasie</param>
        /// <param name="time2">obiekt typu TimeWithMiliseconds time2, reprezentuje punkt w czasie</param>
        /// <returns>Zwraca wartość logiczną sprawdzającą czy obiekty są sobie równe</returns>
        public static bool operator ==(TimeWithMiliseconds time1, TimeWithMiliseconds time2)
        {
            if (time1.Equals(time2))
                return true;
            return false;
        }

        /// <summary>
        /// Sprawdza czy obiekty TimeWithMiliseconds przekazane przez parametr są różne
        /// </summary>
        /// <param name="time1">obiekt typu TimeWithMiliseconds time1, reprezentuje punkt w czasie</param>
        /// <param name="time2">obiekt typu TimeWithMiliseconds time2, reprezentuje punkt w czasie</param>
        /// <returns>Zwraca wartość logiczną sprawdzającą czy obiekty są różne</returns>
        public static bool operator !=(TimeWithMiliseconds time1, TimeWithMiliseconds time2)
        {
            if (time1 == time2)
                return false;
            return true;
        }

        /// <summary>
        /// Sprawdza czy obiekt TimeWithMiliseconds t1 jest mniejszy od TimeWithMiliseconds t2
        /// </summary>
        /// <param name="time1">obiekt typu TimeWithMiliseconds time1, reprezentuje punkt w czasie</param>
        /// <param name="time2">obiekt typu TimeWithMiliseconds time2, reprezentuje punkt w czasie</param>
        /// <returns>Zwraca wartość logiczną sprawdzającą czy TimeWithMiliseconds t1 jest mniejszy od TimeWithMiliseconds t2</returns>
        public static bool operator <(TimeWithMiliseconds time1, TimeWithMiliseconds time2)
        {
            if (time1.CompareTo(time2) < 0)
                return true;
            return false;
        }

        /// <summary>
        /// Sprawdza czy obiekt TimeWithMiliseconds t1 jest większy od TimeWithMiliseconds t2
        /// </summary>
        /// <param name="time1">obiekt typu TimeWithMiliseconds time1, reprezentuje punkt w czasie</param>
        /// <param name="time2">obiekt typu TimeWithMiliseconds time2, reprezentuje punkt w czasie</param>
        /// <returns>Zwraca wartość logiczną sprawdzającą czy TimeWithMiliseconds t1 jest większy od TimeWithMiliseconds t2</returns>
        public static bool operator >(TimeWithMiliseconds time1, TimeWithMiliseconds time2)
        {
            if (time1.CompareTo(time2) > 0)
                return true;
            return false;
        }

        /// <summary>
        /// Sprawdza czy obiekt TimeWithMiliseconds t1 jest mniejszy bądź róny TimeWithMiliseconds t2
        /// </summary>
        /// <param name="time1">obiekt typu TimeWithMiliseconds time1, reprezentuje punkt w czasie</param>
        /// <param name="time2">obiekt typu TimeWithMiliseconds time2, reprezentuje punkt w czasie</param>
        /// <returns>Zwraca wartość logiczną sprawdzającą czy TimeWithMiliseconds t1 jest mniejszy bądź róny TimeWithMiliseconds t2</returns>
        public static bool operator <=(TimeWithMiliseconds time1, TimeWithMiliseconds time2)
        {
            if (time1.CompareTo(time2) <= 0)
                return true;
            return false;
        }

        /// <summary>
        /// Sprawdza czy obiekt TimeWithMiliseconds t1 jest większy bądź równy TimeWithMiliseconds t2
        /// </summary>
        /// <param name="time1">obiekt typu TimeWithMiliseconds time1, reprezentuje punkt w czasie</param>
        /// <param name="time2">obiekt typu TimeWithMiliseconds time2, reprezentuje punkt w czasie</param>
        /// <returns>Zwraca wartość logiczną sprawdzającą czy TimeWithMiliseconds t1 jest większy bądź równy TimeWithMiliseconds t2</returns>
        public static bool operator >=(TimeWithMiliseconds time1, TimeWithMiliseconds time2)
        {
            if (time1.CompareTo(time2) >= 0)
                return true;
            return false;
        }

        /// <summary>
        /// Dodaje do instancji czasu TimeWithMiliseconds, obiekt przekazany przez parametr typu TimePeriodWithMiliseconds, określoną jednostkę czasu
        /// </summary>
        /// <param name="period">obiekt typu TimePeriodWithMiliseconds reprezentuje okres czasu</param>
        /// <returns>Zwraca obiekt typu TimeWithMiliseconds sumującą punkt w czasie i okres czasu typu TimePeriodWithMiliseconds</returns>
        public TimeWithMiliseconds Plus(TimePeriodWithMiliseconds period)
        {
            return this + period;
        }

        /// <summary>
        /// Dodaje do obiektu TimeWithMiliseconds przekazany przez parametr obiekt TimePeriodWithMiliseconds. Dodaje okres czasu do punktu w czasie.
        /// </summary>
        /// <param name="time">obiekt typu TimeWithMiliseconds time, reprezentuje punkt w czasie</param>
        /// <param name="period">obiekt typu TimePeriodWithMiliseconds reprezentuje okres czasu</param>
        /// <returns>Zwraca obiekt typu TimeWithMiliseconds sumującą punkt w czasie i okres czasu typu TimePeriodWithMiliseconds</returns>
        public static TimeWithMiliseconds Plus(TimeWithMiliseconds time, TimePeriodWithMiliseconds period)
        {
            return time + period;
        }

        /// <summary>
        /// Odejmuje od instancji czasu TimeWithMiliseconds, obiekt przekazany przez parametr typu TimePeriodWithMiliseconds, określoną jednostkę czasu.
        /// </summary>
        /// <param name="period">obiekt typu TimePeriodWithMiliseconds, reprezentuje okres czasu</param>
        /// <returns>Zwraca obiekt typu TimeWithMiliseconds odejmujący okres czasu typu TimePeriodWithMiliseconds od punkcie w czasie typu TimeWithMiliseconds</returns>
        public TimeWithMiliseconds Minus(TimePeriodWithMiliseconds period)
        {
            return this - period;
        }

        /// <summary>
        /// Odejmuje od obiektu TimeWithMiliseconds przekazany przez parametr obiekt TimePeriodWithMiliseconds. Odejmuje okres czasu od punktu w czasie.
        /// </summary>
        /// <param name="time">obiekt typu TimeWithMiliseconds time, reprezentuje punkt w czasie</param>
        /// <param name="period">obiekt typu TimePeriodWithMiliseconds reprezentuje okres czasu</param>
        /// <returns>Zwraca obiekt typu TimeWithMiliseconds odejmujący okres czasu typu TimePeriodWithMiliseconds od punkcie w czasie typu TimeWithMiliseconds</returns>
        public static TimeWithMiliseconds Minus(TimeWithMiliseconds time, TimePeriodWithMiliseconds period)
        {
            return time - period;
        }

        /// <summary>
        /// Dodaje do obiektu TimeWithMiliseconds przekazany przez parametr obiekt TimePeriodWithMiliseconds. Dodaje okres czasu do punktu w czasie.
        /// </summary>
        /// <param name="time">obiekt typu TimeWithMiliseconds time, reprezentuje punkt w czasie</param>
        /// <param name="period">obiekt typu TimePeriodWithMiliseconds reprezentuje okres czasu</param>
        /// <returns>Zwraca obiekt typu TimeWithMiliseconds sumującą punkt w czasie i okres czasu typu TimePeriodWithMiliseconds</returns>
        public static TimeWithMiliseconds operator +(TimeWithMiliseconds time, TimePeriodWithMiliseconds period)
        {
            long sumOfMiliseconds = (time.Miliseconds + period.Miliseconds);
            long miliseconds = (sumOfMiliseconds % 1000);

            long sumOfSeconds = (time.Seconds + period.Seconds);
            long seconds = (sumOfSeconds % 60);
            long sumOfMinutes = (sumOfSeconds / 60) + time.Minutes + period.Minutes;
            long minutes = (sumOfMinutes % 60);
            long sumOfHours = (sumOfMinutes / 60) + time.Hours + period.Hours;
            long hours = (sumOfHours % 24);

            return new TimeWithMiliseconds((int)hours, (int)minutes, (int)seconds, (int)miliseconds);
        }

        /// <summary>
        /// Odejmuje od obiektu TimeWithMiliseconds przekazany przez parametr obiekt TimePeriodWithMiliseconds. Odejmuje okres czasu od punktu w czasie.
        /// </summary>
        /// <param name="time">obiekt typu TimeWithMiliseconds time, reprezentuje punkt w czasie</param>
        /// <param name="period">obiekt typu TimePeriodWithMiliseconds reprezentuje okres czasu</param>
        /// <returns>Zwraca obiekt typu TimeWithMiliseconds odejmujący okres czasu typu TimePeriodWithMiliseconds od punkcie w czasie typu TimeWithMiliseconds</returns>
        public static TimeWithMiliseconds operator -(TimeWithMiliseconds time, TimePeriodWithMiliseconds period)
        {
            long sumOfMiliseconds = (time.Miliseconds - period.Miliseconds);
            long miliseconds = (sumOfMiliseconds % 1000);

            long sumOfSeconds = (time.Seconds - period.Seconds) + 60;
            long seconds = (sumOfSeconds % 60);

            long sumOfMinutes = time.Minutes - period.Minutes - ((time.Seconds - period.Seconds < 0) ? 1 : 0) + 60;
            bool decyzja = time.Minutes - period.Minutes - ((time.Seconds - period.Seconds < 0) ? 1 : 0) < 0;
            long minutes = (sumOfMinutes % 60);
            long sumOfHours = time.Hours - period.Hours - (decyzja ? 1 : 0) + 24;
            long hours = (sumOfHours % 24);

            return new TimeWithMiliseconds((int)hours, (int)minutes, (int)seconds);
        }
    }
}