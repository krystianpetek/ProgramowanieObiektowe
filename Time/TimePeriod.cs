namespace Time_TimePeriod
{
    public readonly struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
        public long NumberOfSeconds { get; init; }
        public long Hours => (NumberOfSeconds / 60) / 60;
        public long Minutes => (NumberOfSeconds / 60) % 60;
        public long Seconds => NumberOfSeconds % 60;

        public TimePeriod(long numOfHours, long numOfMinutes, long numOfSeconds)
        {
            if (numOfHours < 0 || numOfMinutes >= 60 || numOfMinutes < 0 || numOfSeconds >= 60 || numOfSeconds < 0)
                throw new ArgumentOutOfRangeException("Wrong range of time.");

            NumberOfSeconds = (numOfHours * 3600) + (numOfMinutes * 60) + numOfSeconds;
        }

        public TimePeriod(long numOfHours, long numOfMinutes) : this(numOfHours, numOfMinutes, 0) { }

        public TimePeriod() : this(0,0,0) { }

        public TimePeriod(long numberOfSeconds)
        {
            if (numberOfSeconds < 0)
                throw new ArgumentOutOfRangeException("Wrong value of seconds.");

            NumberOfSeconds = numberOfSeconds;
        }

        public TimePeriod(Time t1, Time t2)
        {
            long hours = 0, minutes = 0, seconds = 0;
            if(t1.CompareTo(t2) > 0)
            {
                hours = t1.Hours - t2.Hours;
                minutes = t1.Minutes - t2.Minutes;
                seconds = t1.Seconds - t2.Seconds;
            }
            else if(t1.CompareTo(t2) < 0)
            {

                hours = t2.Hours - t1.Hours;
                minutes = t2.Minutes - t1.Minutes;
                seconds = t2.Seconds - t1.Seconds;
            }

            NumberOfSeconds = (hours * 3600) + (minutes * 60) + seconds;
        }

        public TimePeriod(string timePattern)
        {
            string[] splitTime = timePattern.Split(":");
            if (splitTime.Length != 3)
                throw new ArgumentOutOfRangeException("Wrong data in argument");

            bool parseHours = byte.TryParse(splitTime[0], out byte hours);
            bool parseMinutes = byte.TryParse(splitTime[1], out byte minutes);
            bool parseSeconds = byte.TryParse(splitTime[2], out byte seconds);

            if (!parseHours || !parseMinutes || !parseSeconds)
                throw new ArgumentOutOfRangeException("Invalid argument for parse to Time.");

            if (hours < 0)
                throw new ArgumentOutOfRangeException("Wrong number of hour.");

            if (minutes >= 60 || minutes < 0)
                throw new ArgumentOutOfRangeException("Wrong number of minute.");

            if (seconds >= 60 || seconds < 0)
                throw new ArgumentOutOfRangeException("Wrong number of second.");

            NumberOfSeconds = (hours * 3600) + (minutes * 60) + seconds;
        }

        public override string ToString()
        {
            return $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";
        }

        public int CompareTo(TimePeriod other)
        {
            if (this.NumberOfSeconds > other.NumberOfSeconds)
                return 1;
            else if (this.NumberOfSeconds < other.NumberOfSeconds)
                return -1;
            else 
                return 0;
        }

        public bool Equals(TimePeriod other)
        {
            if (this.NumberOfSeconds == other.NumberOfSeconds)
                return true;
            return false;
        }

        public override bool Equals(object? obj)
        {
            if (obj is TimePeriod)
                return Equals(obj as TimePeriod?);
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Hours, Minutes, Seconds);
        }

        public static bool operator ==(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            return timePeriod1.Equals(timePeriod2);
        }

        public static bool operator !=(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            return !(timePeriod1 == timePeriod2);
        }

        public static bool operator <(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            if (timePeriod1.CompareTo(timePeriod2) < 0)
                return true;
            return false;
        }

        public static bool operator >(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            if (timePeriod1.CompareTo(timePeriod2) > 0)
                return true;
            return false;
        }

        public static bool operator <=(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            if (timePeriod1.CompareTo(timePeriod2) <= 0)
                return true;
            return false;
        }

        public static bool operator >=(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            if (timePeriod1.CompareTo(timePeriod2) >= 0)
                return true;
            return false;
        }

        public TimePeriod Plus(TimePeriod timePeriod)
        {
            return this + timePeriod;
        }

        public static TimePeriod Plus(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            return timePeriod1 + timePeriod2;
        }

        public TimePeriod Minus(TimePeriod timePeriod)
        {
            return this - timePeriod;
        }

        public static TimePeriod Minus(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            return timePeriod1 - timePeriod2;
        }

        public static TimePeriod operator +(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            return new TimePeriod(timePeriod1.NumberOfSeconds + timePeriod2.NumberOfSeconds);
        }

        public static TimePeriod operator -(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            if (timePeriod1.NumberOfSeconds > timePeriod2.NumberOfSeconds)
                return new TimePeriod(timePeriod1.NumberOfSeconds - timePeriod2.NumberOfSeconds);

            else if (timePeriod1.NumberOfSeconds < timePeriod2.NumberOfSeconds)
                return new TimePeriod(timePeriod2.NumberOfSeconds - timePeriod1.NumberOfSeconds);

            else
                return new TimePeriod();
        }
    }
}