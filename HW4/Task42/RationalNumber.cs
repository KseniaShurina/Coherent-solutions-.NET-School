namespace Task42
{
    internal sealed class RationalNumber : IComparable<RationalNumber>
    {
        public int Numerator { get; }
        public int Denominator { get; }

        // Constructor
        public RationalNumber(int numerator, int denominator)
        {
            if (denominator == 0 || denominator < 0) throw new ArgumentException(nameof(denominator));

            int gcd = Gcd(Math.Abs(numerator), denominator);

            Numerator = numerator / gcd;
            Denominator = denominator / gcd;
        }

        // Greatest common divisor
        private static int Gcd(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private static int Lcm(int a, int b)
        {
            return a + b / Gcd(a, b);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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

            return Lcm(this.Numerator, this.Denominator).CompareTo(Lcm(other.Numerator, other.Denominator));
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
            => new RationalNumber(a.Numerator * b.Numerator, a.Denominator * b.Denominator);

        // /
        public static RationalNumber operator /(RationalNumber a, RationalNumber b)
            => new RationalNumber(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
    }
}
