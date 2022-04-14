namespace Time_TimePeriod
{
    public readonly struct Time : IEquatable<Time>, IComparable<Time>
    {
        public byte Hours { get; init; }
        public byte Minutes { get; init; }
        public byte Seconds { get; init; }

        public Time(byte hours, byte minutes, byte seconds)
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
        }

        public Time(byte hours, byte minutes) : this(hours, minutes, 0)
        {
        }

        public Time(byte hours) : this(hours, 0, 0)
        {
        }

        public Time() : this(0, 0, 0)
        {
        }

        public Time(string timePattern)
        {
            string[] splitTime = timePattern.Split(":");
            if (splitTime.Length < 2)
                throw new FormatException("Wrong format data in argument");

            bool parseHours = byte.TryParse(splitTime[0], out byte hours);
            bool parseMinutes = byte.TryParse(splitTime[1], out byte minutes);
            bool parseSeconds = byte.TryParse(splitTime[2], out byte seconds);

            if (!parseHours || !parseMinutes || !parseSeconds)
                throw new FormatException("Invalid argument for parse to Time.");

            if (hours >= 24 || hours < 0)
                throw new ArgumentOutOfRangeException("Wrong number of hour.");
            Hours = hours;

            if (minutes >= 60 || minutes < 0)
                throw new ArgumentOutOfRangeException("Wrong number of minute.");
            Minutes = minutes;

            if (seconds >= 60 || seconds < 0)
                throw new ArgumentOutOfRangeException("Wrong number of second.");
            Seconds = seconds;
        }

        public override string ToString()
        {
            return $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";
        }

        public bool Equals(Time other)
        {
            if (this.Hours != other.Hours)
                return false;
            if (this.Minutes != other.Minutes)
                return false;
            if (this.Seconds != other.Seconds)
                return false;
            return true;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Time)
                return Equals(obj as Time?);
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Hours, Minutes, Seconds);
        }

        public int CompareTo(Time other)
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
                    if (this.Seconds == other.Seconds)
                        return 0;
                    return -1;
                }
                return -1;
            }
            return -1;
        }

        public static bool operator ==(Time time1, Time time2)
        {
            if (time1.Equals(time2))
                return true;
            return false;
        }

        public static bool operator !=(Time time1, Time time2)
        {
            if (time1 == time2)
                return false;
            return true;
        }

        public static bool operator <(Time time1, Time time2)
        {
            if (time1.CompareTo(time2) < 0)
                return true;
            return false;
        }

        public static bool operator >(Time time1, Time time2)
        {
            if (time1.CompareTo(time2) > 0)
                return true;
            return false;
        }

        public static bool operator <=(Time time1, Time time2)
        {
            if (time1.CompareTo(time2) <= 0)
                return true;
            return false;
        }

        public static bool operator >=(Time time1, Time time2)
        {
            if (time1.CompareTo(time2) >= 0)
                return true;
            return false;
        }

        public Time Plus(TimePeriod period)
        {
            return this + period;
        }

        public static Time Plus(Time time, TimePeriod period)
        {
            return time + period;
        }

        public Time Minus(TimePeriod period)
        {
            return this - period;
        }

        public static Time Minus(Time time, TimePeriod period)
        {
            return time - period;
        }

        public static Time operator +(Time time, TimePeriod period)
        {
            long sumOfSeconds = (time.Seconds + period.Seconds);
            byte seconds = (byte)(sumOfSeconds % 60);
            long sumOfMinutes = (sumOfSeconds / 60) + time.Minutes + period.Minutes;
            byte minutes = (byte)(sumOfMinutes % 60);
            long sumOfHours = (sumOfMinutes / 60) + time.Hours + period.Hours;
            byte hours = (byte)(sumOfHours % 24);

            return new Time(hours, minutes, seconds);
        }

        public static Time operator -(Time time, TimePeriod period)
        {
            long sumOfSeconds = (time.Seconds + period.Seconds);
            byte seconds = (byte)Math.Abs(sumOfSeconds % 60);
            long sumOfMinutes = (sumOfSeconds / 60) + time.Minutes + period.Minutes;
            byte minutes = (byte)Math.Abs(sumOfMinutes % 60);
            long sumOfHours = (sumOfMinutes / 60) + time.Hours + period.Hours;
            byte hours = (byte)Math.Abs(sumOfHours % 24);

            return new Time(hours, minutes, seconds);
        }
    }
}