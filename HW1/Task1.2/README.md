Task 1.2

Let a 10-character ISBN be a unique digital code used to identify a book, with the format: d1d2d3d4d5d6d7d8d9d10. 
The digit d10 is a control digit, calculated according to the condition that the expression:

10 * d1 + 9 * d2 + 8 * d3 + ... + 1 * d10

(the sum of the products of digits by the weight of their positions) must be a multiple of 11.

Create an application that prompts the user for a string of 9 digit characters (these are the first nine digits of the ISBN), 
calculates the check digit, and outputs the resulting ISBN. Do not check the correctness of the user's input - assume that the user 
does not make any errors when entering.

Note 1: The check digit can be equal to 10. In this case, use the symbol 'X' to denote it.
Note 2: You can convert any value to a string using a.ToString().