Console.WriteLine("Hello, User! Input 9 integers between 1 and 9: ");

// Replace method removes whitespace if needed
string inputNumbers = Console.ReadLine()!.Replace(" ", "");

// to convert string to array of integers
int length = inputNumbers.Length;
int[] isbn = new int[length];
// to set the index for each number in the new array when the string is iterated
int index = 0;

foreach (char number in inputNumbers)
{
    // convert char to int
    isbn[index] = int.Parse(number.ToString());
    index++;
}

Console.WriteLine(GetCheckDigit(isbn));

string GetCheckDigit(int[] array)
{
    // to increment weight
    int weight = 10;
    // the sum of the products of digits by the weight of their positions
    int summ = 0;

    for (int i = 0; i < array.Length; i++)
    {
        summ += array[i] * weight--;
    }

    // Rest from dividing the sum by 11
    int rest = summ % 11;
    int checkDigit = 11 - rest;

    if (checkDigit == 10)
    {
        return "X";
    }

    // Return the check digit as a string
    return checkDigit.ToString();
}