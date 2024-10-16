// TODO  I have no idea what means indexers in the Task 2.2.

DiagonalMatrix matrix1 = new DiagonalMatrix(1, 2, 3);
DiagonalMatrix matrix2 = new DiagonalMatrix(1, 2, 3);

Console.WriteLine(matrix1.ToString());

int track = matrix1.Track();
Console.WriteLine($"Sum of the matrix elements is: {track}");

bool isEqual = matrix1.Equals(matrix2);
Console.WriteLine($"If {nameof(matrix1)} is equal to {nameof(matrix2)}?: {isEqual}");

public class DiagonalMatrix
{
    public int Size { get; init; }

    private int[] valuesOnDiagonal;

    private int[,] readyMatrix;

    // Numbers are matrix elements located on the diagonal.
    public DiagonalMatrix(params int[]? numbers)
    {
        if (numbers == null || numbers.Length == 0)
        {
            Size = 0;
            int[,] matrix = new int[0, 0];
        }
        else
        {
            Size = numbers.Length;
            int[,] matrix = new int[Size, Size];
            valuesOnDiagonal = numbers;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((i == j) && i < Size)
                    {
                        matrix[i, j] = numbers[i];
                    }
                }
            }
            readyMatrix = matrix;
        }
    }

    // Returns the sum of the matrix elements located on the main diagonal.
    public int Track()
    {
        int sum = 0;
        for (int i = 0; i < readyMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < readyMatrix.GetLength(1); j++)
            {
                if ((i == j) && i < Size)
                {
                    sum += readyMatrix[i, j];
                }
            }
        }

        return sum;
    }

    // Represent two-dimensional array.
    public override string ToString()
    {
        if (Size == 0)
        {
            return base.ToString();
        }

        string result = "";

        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                if ((i == j) && i < Size)
                {
                    result += (this.valuesOnDiagonal[i].ToString());
                }
                else
                {
                    result += "0";
                }

                result += " ";
            }
            result += "\n";
        }

        return result;
    }

    // Check if the one matrix is equal to another matrix.
    public override bool Equals(object? obj)
    {
        if (obj is DiagonalMatrix anotherMatrix)
        {
            for (int i = 0; i < readyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < readyMatrix.GetLength(1); j++)
                {
                    if (anotherMatrix.readyMatrix[i, j] != readyMatrix[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        else
        {
            return base.Equals(obj);
        }
    }
}