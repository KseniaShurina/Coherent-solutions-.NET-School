namespace Task2._2.Extensions
{
    internal static class AddExtension
    {
        internal static DiagonalMatrix Add(this DiagonalMatrix matrix1, DiagonalMatrix matrix2)
        {
            if (matrix1 == null)
            {
                throw new ArgumentNullException(nameof(matrix1));
            }
            if (matrix2 == null)
            {
                throw new ArgumentNullException(nameof(matrix2));
            }

            // Find the biggest size between 2 matrices.
            int size = Math.Max(matrix1.Size, matrix2.Size);

            int[] valuesOnDiagonal = new int[size];

            // Adds the values ​​on the diagonal of two matrices.
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    // Indexer check if it's a diagonal element.
                    valuesOnDiagonal[i] += matrix1[i, j] + matrix2[i, j];
                }
            }

            // Return a new DiagonalMatrix with the summed diagonal values.
            return new DiagonalMatrix(valuesOnDiagonal);
        }
    }
}
