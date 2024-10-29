using Task2._2;
using Task2._2.Extensions;

DiagonalMatrix matrix1 = new DiagonalMatrix(1, 2, 3, 4);
DiagonalMatrix matrix2 = new DiagonalMatrix(1, 2, 3);
// Indexer
int firs = matrix1[0, 0];
Console.WriteLine($"The first element at coordinates 0.0 is {firs}");
int second = matrix1[1, 1];
Console.WriteLine($"The second element at coordinates 1.1 is {second}");
int third = matrix1[2, 2];
Console.WriteLine($"The third element at coordinates 2.2 is {third}");
// ToString
Console.WriteLine($"{nameof(matrix1)}:");
Console.WriteLine(matrix1.ToString());
// Track
int track = matrix1.Track();
Console.WriteLine($"The sum of values on the diagonal of the {nameof(matrix1)} is: {track}");
// Equals
bool isEqual = matrix1.Equals(matrix2);
Console.WriteLine($"If {nameof(matrix1)} is equal to {nameof(matrix2)}?: {isEqual}");
// Add
Console.WriteLine($"Add of {nameof(matrix1)} and {nameof(matrix2)}:");
Console.WriteLine(AddExtension.Add(matrix1, matrix2));