Console.WriteLine("Hello, User! Input the number if elements in the array: ");
// 
int lengthOfInitialArray = int.Parse(Console.ReadLine()!);

// Create array
int[] initialArray = new int[lengthOfInitialArray];

Console.WriteLine("Enter the elements of the array");
for (int i = 0; i < lengthOfInitialArray; i++)
{
    initialArray[i] = int.Parse(Console.ReadLine()!);
}

// Output initial array
Console.WriteLine("Here is your array:");
foreach (int number in initialArray)
{
    Console.Write($"{number} ");
}

Console.WriteLine();

// Get array of unique numbers
int[] result = GetArrayOfUniqueNumbers(initialArray, lengthOfInitialArray);

// Output array of unique numbers
Console.WriteLine("Here is array of unique numbers:");
foreach (int number in result)
{
    Console.Write($"{number} ");
}
// Method for getting an array of unique numbers
int[] GetArrayOfUniqueNumbers(int[] array, int length)
{
    // To add unique numbers to new array and return only relevant number of elements.
    int countOfUniqueNumbers = 0;
    int[] arrayOfUniqueNumbers = new int[length];

    for (int i = 0; i < length; i++)
    {
        if (i == 0)
        {
            arrayOfUniqueNumbers[i] = array[i];
            countOfUniqueNumbers++;
            continue;
        }

        // If the array of unique numbers does not consist of this number add it.
        if (!IfContainsThisNumber(array[i]))  
        {
            arrayOfUniqueNumbers[countOfUniqueNumbers] = array[i];
            countOfUniqueNumbers++;
        }
    }

    // Return only relevant number of elements.
    return arrayOfUniqueNumbers[0..countOfUniqueNumbers];

    // Check if the array of unique numbers already consists of this number.
    bool IfContainsThisNumber(int number)
    {
        for (int i = 0; i < countOfUniqueNumbers; i++)
        {
            if (arrayOfUniqueNumbers[i] == number)
            {
                return true;
            }
        }
        return false;
    }
}