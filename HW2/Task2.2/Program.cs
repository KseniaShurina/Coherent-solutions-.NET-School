using Task2._2;

DiagonalMatrix matrix1 = new DiagonalMatrix(1, 2, 3, 4);
DiagonalMatrix matrix2 = new DiagonalMatrix(1, 2, 3);

int firs = matrix1[0, 0];
Console.WriteLine($"The first element at coordinates 0.0 is {firs}");
int second = matrix1[1, 1];
Console.WriteLine($"The second element at coordinates 1.1 is {second}");
int third = matrix1[2, 2];
Console.WriteLine($"The third element at coordinates 2.2 is {third}");

Console.WriteLine($"{nameof(matrix1)}:");
Console.WriteLine(matrix1.ToString());

int track = matrix1.Track();
Console.WriteLine($"Sum of the matrix elements is: {track}");

bool isEqual = matrix1.Equals(matrix2);
Console.WriteLine($"If {nameof(matrix1)} is equal to {nameof(matrix2)}?: {isEqual}");

Console.WriteLine($"Addition of {nameof(matrix1)} and {nameof(matrix2)}:");
var matrix3 = matrix1.Addition(matrix2);
Console.WriteLine(matrix3);

