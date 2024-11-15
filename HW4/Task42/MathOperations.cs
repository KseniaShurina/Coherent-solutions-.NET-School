namespace Task42
{
    internal static class MathOperations
    {
        // Greatest common divisor
        internal static int Gcd(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        internal static int Lcm(int a, int b)
        {
            return a + b / Gcd(a, b);
        }
    }
}
