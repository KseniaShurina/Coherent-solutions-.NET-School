Console.WriteLine("Enter 2 integers: ");

Console.WriteLine("Enter first integer:");
int a = int.Parse(Console.ReadLine()!);

Console.WriteLine("Enter second integer:");
int b = int.Parse(Console.ReadLine()!);

Console.Write($"The range of integers from {a} to {b}, which in their duodecimal representation contain exactly two symbols \"A\": ");

int[] array = ArrayOfNumbersFromAtoB(a, b);

foreach (int integer in array)
{
    Console.Write($"{integer} ");
}

int[] ArrayOfNumbersFromAtoB(int a, int b)
{
    // [(b - a) + 1] - Length
    int[] numbers = new int[(b - a) + 1];
    for (int i = 0; i < numbers.Length; i++)
    {
        // all integers in the range from a (inclusive) to b (inclusive)
        numbers[i] = a++;
    }
    //
    int[] result = ReturnDuodecimalValues(numbers);
    return result;
}


int[] ReturnDuodecimalValues(int[] array)
{
    // To store numbers.
    string values = "";
    // To create an array in the future.
    int countOfDuodecimalValues = 0;
    // Count of A .
    int countA = 0;

    // Check if numbers in array contain exactly two symbols "A".
    for (int i = 0; i < array.Length; i++)
    {
        int value = array[i];
        while (value > 0)
        {
            int rest = value % 12;
            if (rest == 10)
            {
                // if the rest is 10 it is A.
                countA++;
                if (countA == 2)
                {
                    countOfDuodecimalValues++;
                    values += $"{array[i]} ";
                }
            }
            // Move on to the next rank.
            value /= 12;
        }

        // Empty the variable for the next number.
        countA = 0;
    }

    string[] arrayOfValues = values.Split(' ');
    int[] result = new int[countOfDuodecimalValues];
    int index = 0;
    foreach (string numbers in arrayOfValues)
    {
        if (numbers != "")
        {
            result[index] = int.Parse(numbers);
            index++;
        }
    }
    // all integers in the range, which in their duodecimal representation contain exactly two symbols "A".
    return result;
}