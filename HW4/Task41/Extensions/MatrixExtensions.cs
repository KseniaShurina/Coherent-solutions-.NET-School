namespace Task41.Extensions
{
    internal static class MatrixExtensions
    {
        /// <summary>
        /// Extension method to add matrices
        /// </summary>
        /// <typeparam name="T">Type of elements in the matrix</typeparam>
        /// <param name="matrix1">First of matrix for adding</param>
        /// <param name="matrix2">Second of matrix for adding</param>
        /// <param name="operation">Delegate that describe how to perform the addition of two elements of type T</param>
        /// <returns>Matrix object</returns>
        /// <exception cref="ArgumentNullException">If one of matrices are null</exception>
        /// <exception cref="ArgumentException">If sizes of matrices are not equal</exception>
        internal static Matrix<T> Add<T>(this Matrix<T> matrix1, Matrix<T> matrix2, Func<T, T, T> operation)
        {
            ArgumentNullException.ThrowIfNull(matrix1);
            ArgumentNullException.ThrowIfNull(matrix2);

            if (matrix1.Size != matrix2.Size)
            {
                throw new ArgumentException("Sizes of matrices are not equal");
            }

            T[] valuesOnDiagonal = new T[matrix1.Size];

            for (int i = 0; i < matrix1.Size; i++)
            {
                // Add the values ​​of two matrices and assign the result to the element located on the diagonal.
                valuesOnDiagonal[i] = operation(matrix1[i, i], matrix2[i, i]);
            }

            // Create new matrix.
            Matrix<T> newMatrix = new Matrix<T>(valuesOnDiagonal);

            // Return a new Matrix with the summed diagonal values.
            return newMatrix;
        }
    }
}

