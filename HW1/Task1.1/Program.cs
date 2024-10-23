Console.WriteLine("Enter 2 integers: ");

Console.WriteLine("Enter first integer:");
int a = int.Parse(Console.ReadLine()!);

Console.WriteLine("Enter second integer:");
int b = int.Parse(Console.ReadLine()!);

Console.Write($"The range of integers from {a} to {b}, which in their duodecimal representation contain exactly two symbols \"A\": ");

int[] array = ReturnDuodecimalValues(a, b);
foreach (int integer in array)
{
    if (integer != 0)
    {
        Console.Write($"{integer} ");
    }
}
int[] ReturnDuodecimalValues(int a, int b)
{
    // Swap values if A greater than B.
    if (a > b)
    {
        (a, b) = (b, a);
    }

    // To create an array in the future.
    int countOfDuodecimalValues = 0;
    // Count of A.
    int countA = 0;

    int[] result = new int[b];

    // Check if numbers in array contain exactly two symbols "A".
    for (int i = a; i < b; i++)
    {
        // Get absolute value.
        int value = Math.Abs(i);
        while (value > 0)
        {
            int rest = value % 12;
            if (rest == 10)
            {
                // if the rest is 10 it is A.
                countA++;
            }
            // Move on to the next rank.
            value /= 12;
        }
        // Check if countA contains only two A, not more.
        if (countA == 2)
        {
            result[countOfDuodecimalValues] = i;
            countOfDuodecimalValues++;
        }
        // Empty the variable for the next number.
        countA = 0;
    }

    return result;
}