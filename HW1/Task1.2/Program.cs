Console.WriteLine("Hello, User! Input 9 integers between 1 and 9: ");

// Replace method removes whitespace if needed
// Substring removes elements if there are more than 9.
string inputNumbers = Console.ReadLine()!.Replace(" ", "").Substring(0, 9);

// To convert string to array of integers.
int[] isbn = new int[9];
Console.Write($"ISBN: ");
for (int i = 0; i < inputNumbers.Length; i++)
{
    isbn[i] = int.Parse(inputNumbers[i].ToString());
    Console.Write($"{isbn[i]} ");
}

Console.WriteLine();
Console.WriteLine($"The check digit: {GetCheckDigit(isbn)}");

string GetCheckDigit(int[] array)
{
    // To increment weight.
    int weight = 10;
    // The sum of the products of digits by the weight of their positions.
    int summ = 0;

    for (int i = 0; i < array.Length; i++)
    {
        summ += array[i] * weight--;
    }

    // Rest from dividing the sum by 11.
    int rest = summ % 11;
    int checkDigit = 11 - rest;

    // Handle the case where the remainder is 0.
    if (checkDigit == 11)
    {
        return "0";
    }

    // If check digit is 10, return 'X'.
    if (checkDigit == 10)
    {
        return "X";
    }

    // Return the check digit as a string.
    return checkDigit.ToString();
}