using Task42;

RationalNumber rn1 = new RationalNumber(3, 8);
RationalNumber rn2 = new RationalNumber(7, 12);

RationalNumber rn3 = new RationalNumber(3, 8);
RationalNumber rn4 = rn1 / rn2;

// Overriden Equals
Console.WriteLine($"Is {rn1} equals to {rn3}? {rn1.Equals(rn3)}"); // True
Console.WriteLine($"Is {rn1} equals to {rn4}? {rn1.Equals(rn4)}"); // False
Console.WriteLine();

// Redefined arithmetic operators
Console.WriteLine($"{rn1} / {rn2} = {rn4}"); // 9/14
Console.WriteLine();

const int integer = 4;
Console.WriteLine($"Implicit convert {integer} to rational number: {RationalNumber.ImplicitConvertIntToRationalNumber(integer)}"); // 4/1
Console.WriteLine($"Explicit convert {rn1} to double: {RationalNumber.ExplicitConvertToDouble(rn1)}"); // 0.38
Console.WriteLine($"Explicit convert {rn2} to double: {RationalNumber.ExplicitConvertToDouble(rn2)}"); // 0.58
Console.WriteLine();

// Implementation of IComparable<RationalNumber>
Console.WriteLine(rn1.CompareTo(rn3)); // 0
Console.WriteLine(rn1.CompareTo(rn4)); // -1
Console.WriteLine(rn2.CompareTo(rn4)); // -1

