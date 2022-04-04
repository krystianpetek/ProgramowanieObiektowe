
namespace RationalLibrary
{
    public readonly partial struct BigRational : IEquatable<BigRational>
    {
        // kazdy struct !TRZEBA! zaimplementować IEquatable, equals, trzeba zdefiniować równość
        public bool Equals(BigRational other)
        {
            // equals nie zgłasza !NIGDY! żadnych wyjątków
            if (IsNaN(this) && IsNaN(other))
                return true;
            if (IsNaN(this) && !IsNaN(other) || !IsNaN(this) && IsNaN(other))
                return false;

            return this.Numerator == other.Numerator && this.Denominator == other.Denominator;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is BigRational other) return Equals(other);

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Numerator, Denominator);
        }

        public static bool operator ==(BigRational left, BigRational right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(BigRational left, BigRational right)
        {
            return !(left == right);
        }
        public static bool IsNaN(BigRational value) => value.Numerator == 0 && value.Denominator == 0;

        public static bool IsInfinity
    }
}
