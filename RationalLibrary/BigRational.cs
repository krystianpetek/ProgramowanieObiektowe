global using System.Numerics;

namespace RationalLibrary
{
    public readonly partial struct BigRational
    {
        public readonly BigInteger Numerator { get; init; }
        public readonly BigInteger Denominator { get; init; }

        #region stałe

        public static readonly BigRational Zero = new(0);
        public static readonly BigRational One = new(1);
        public static readonly BigRational Half = new(1, 2);

        public static readonly BigRational PositiveInfinity = new(1, 0);
        public static readonly BigRational NegativeInfinity = new(-1, 0);
        public static readonly BigRational NaN = new(0, 0);

        #endregion stałe

        public BigRational(BigInteger numerator, BigInteger denominator)
        {
            Numerator = numerator;
            Denominator = denominator;

            var gcd = BigInteger.GreatestCommonDivisor(numerator, denominator);
            Numerator /= gcd;
            Denominator /= gcd;
            if (Denominator < 0)
            {
                Numerator *= -1;
                Denominator *= -1;
            }
        }

        public BigRational(BigInteger value) : this(0, 1)
        { }

        public BigRational() : this(0, 1)// C#
        { }

        public override string? ToString() => $"{Numerator}/{Denominator}";

        public static BigRational Parse(string value)
        {
            var tab = value.Split('/');
            if (tab.Length != 2)
                throw new FormatException("Za dużo ukośników");
            return new BigRational(BigInteger.Parse(tab[0]), BigInteger.Parse(tab[1]));
        }
    }
}