using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time
{
    public readonly struct Time : IEquatable<Time>, IComparable<Time>
    {
        public byte Hours { get; init; }
        public byte Minutes { get; init; }
        public byte Seconds { get; init; }
        public Time(byte hours, byte minutes, byte seconds)
        {
            if (hours >= 24 || hours < 0)
                throw new ArgumentOutOfRangeException("zakres godzin od 00 do 23");
            Hours = hours;
            if (minutes >= 60 || minutes < 0)
                throw new ArgumentOutOfRangeException("zakres minut od 0 do 60");
            Minutes = minutes;
            if (seconds >= 60 || seconds < 0 )
                throw new ArgumentOutOfRangeException("zakres sekund od 0 do 60");
            Seconds = seconds;
        }
        public Time(byte hours, byte minutes) : this(hours, minutes, 0) { }
        public Time(byte hours) : this(hours, 0, 0) { }
        public Time() : this(0, 0, 0) { }
        public Time(string timePattern)
        {
            string[] splitTime = timePattern.Split(":");
            if (splitTime.Length < 2)
                throw new FormatException("Błę");
            
            byte? hours = byte.Parse(splitTime[0]);
            byte? minutes = byte.Parse(splitTime[1]);
            byte? seconds = byte.Parse(splitTime[2]);

            if (hours >= 24 || hours is null)
                throw new ArgumentOutOfRangeException("zakres godzin od 00 do 23");
            Hours = (byte)hours;
            
            if (minutes >= 60 || minutes is null)
                throw new ArgumentOutOfRangeException("zakres minut od 0 do 60");
            Minutes = (byte)minutes;

            if (seconds >= 60 || seconds is null)
                throw new ArgumentOutOfRangeException("zakres sekund od 0 do 60");
            Seconds = (byte)seconds;
        }
        
        public override string ToString()
        {
            return $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";
        }

        public bool Equals(Time other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            return this.Equals(obj as Time?);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(Time other)
        {
            throw new NotImplementedException();
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
            // implementancja
            return new Time();
        }
        public static Time operator -(Time time, TimePeriod period)
        {
            // implementacja
            return new Time();
        }
    }
}
