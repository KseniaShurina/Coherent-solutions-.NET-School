Task 4.2.

Create a sealed, immutable class to represent a rational number, that is, a number of the form n/m, where n is an integer and m is a natural number.

To do:
1.A rational number must be stored as an irreducible fraction. For example, the number 2/6 should be stored as Numerator = 1, Denominator = 3.
2.Define a constructor in the class that takes the Numerator and Denominator of a rational number as parameters. If Denominator = 0, an exception is thrown.
3.Override the Equals() and ToString() methods in the class.
4.Implement the IComparable<T> interface in the class.
5.Redefine the arithmetic operators +, -, * and / in the class.
6.Override in the class the method for explicitly casting a rational number to a double and the method for implicitly casting an int value to a rational number.