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

        public TimePeriod(long numOfHours, long numOfMinutes) : this(numOfHours, numOfMinutes, 0)
        {
        }

        public TimePeriod(long numberOfSeconds)
        {
            if (numberOfSeconds < 0)
                throw new ArgumentOutOfRangeException("Wrong value of seconds.");

            NumberOfSeconds = numberOfSeconds;
        }

        public TimePeriod(Time t1, Time t2)
        {
            throw new NotImplementedException();
        }

        public TimePeriod(string timefromstring)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";
        }

        public int CompareTo(TimePeriod other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(TimePeriod other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static TimePeriod operator ==(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            throw new NotImplementedException();
        }

        public static TimePeriod operator !=(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            throw new NotImplementedException();
        }

        public static TimePeriod operator <(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            throw new NotImplementedException();
        }

        public static TimePeriod operator >(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            throw new NotImplementedException();
        }

        public static TimePeriod operator <=(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            throw new NotImplementedException();
        }

        public static TimePeriod operator >=(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            throw new NotImplementedException();
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
            // implementancja
            return new TimePeriod();
        }

        public static TimePeriod operator -(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            // implementacja
            return new TimePeriod();
        }
    }
}