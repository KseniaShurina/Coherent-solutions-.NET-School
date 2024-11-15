using Task41;
using Task41.Extensions;

Matrix<int> matrix1 = new Matrix<int>(1, 2, 3);
Matrix<int> matrix2 = new Matrix<int>(3, 2, 1);
Console.WriteLine(matrix2);

Matrix<string> matrix3 = new Matrix<string>("ho", "ho", "ho");
Matrix<string> matrix4 = new Matrix<string>("he", "he", "he");
Console.WriteLine(matrix4);

Matrix<double> matrix5 = new Matrix<double>(0.1, 0.7, 0.4);
Console.WriteLine(matrix5);

matrix1[1, 1] = 5;

var subscribe1 = new MatrixTracker<int>(matrix1);
var subscribe2 = new MatrixTracker<string>(matrix3);

try
{
    var result = matrix1.Add(matrix2, ((i, b) => i + b));
    Console.WriteLine(result);
    var result2 = matrix3.Add(matrix4, ((s1, s2) => s1 + s2));
    Console.WriteLine(result2);
}
finally
{
    subscribe1.Undo(matrix1);
    subscribe2.Undo(matrix3);
}

