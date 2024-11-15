namespace Task42
{
    internal sealed class RationalNumber : IComparable<RationalNumber>
    {
        public int Numerator { get; }
        public int Denominator { get; }

        // Constructor
        public RationalNumber(int numerator, int denominator)
        {
            if (denominator == 0) throw new ArgumentException(nameof(denominator));

            int gcd = MathOperations.Gcd(Math.Abs(numerator), Math.Abs(denominator));

            Numerator = numerator / gcd;
            Denominator = Math.Abs(denominator) / gcd;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is RationalNumber rationalNumber)
            {
                if (rationalNumber.Numerator == Numerator || rationalNumber.Denominator == Denominator)
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Numerator, Denominator);
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public int CompareTo(RationalNumber? other)
        {
            ArgumentNullException.ThrowIfNull(other);

            return MathOperations.Lcm(this.Numerator, this.Denominator).CompareTo(MathOperations.Lcm(other.Numerator, other.Denominator));
        }

        // Explicit conversion to double 
        public static double ExplicitConvertToDouble(RationalNumber rationalNumber)
        {
            return Math.Round((double)rationalNumber.Numerator / Math.Abs(rationalNumber.Denominator), 2);
        }

        // Implicit conversion of int to Rational
        public static RationalNumber ImplicitConvertIntToRationalNumber(int value)
        {
            return new RationalNumber(value, 1);
        }

        // +
        public static RationalNumber operator +(RationalNumber a, RationalNumber b)
        {
            var numerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
            var denominator = a.Denominator * b.Denominator;

            return new RationalNumber(numerator, denominator);
        }

        // -
        public static RationalNumber operator -(RationalNumber a, RationalNumber b)
            => new RationalNumber(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator);

        // *
        public static RationalNumber operator *(RationalNumber a, RationalNumber b)
        {
            if (a.Denominator == 0 || b.Denominator == 0)
            {
                throw new ArgumentException("Denominator cant be 0");
            }
            var numerator = a.Numerator * b.Numerator;
            var denominator = a.Denominator * b.Denominator;

            return new RationalNumber(numerator, denominator);
        }

        // /
        public static RationalNumber operator /(RationalNumber a, RationalNumber b)
            => new RationalNumber(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
    }
}
