namespace Task2._2
{
    internal sealed class DiagonalMatrix
    {
        //To get the size of the matrix.
        public int Size { get; }

        // Private array that stores only the diagonal elements of the matrix.
        private readonly int[] _valuesOnDiagonal = null!;

        // Indexer to access elements of the matrix.
        public int this[int i, int j]
        {
            get
            {
                if (IsValidIndex(i, j))
                {
                    return _valuesOnDiagonal[i];

                }
                return 0;
            }
            set
            {
                if (IsValidIndex(i, j))
                {
                    _valuesOnDiagonal[i] = value;
                }
            }
        }

        private bool IsValidIndex(int i, int j)
        {
            if (i != j || i < 0 || j < 0 || i >= Size & j >= Size)
            {
                return false;
            }
            return true;
        }

        public DiagonalMatrix(params int[]? numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                Size = 0;
            }
            else
            {
                Size = numbers.Length;
                // Array.Copy ensures that _valuesOnDiagonal is independently of numbers. Any modification will not affect to _valuesOnDiagonal.
                _valuesOnDiagonal = new int[Size];
                Array.Copy(numbers, _valuesOnDiagonal, numbers.Length);
            }
        }

        // Returns the sum of the matrix elements located on the main diagonal.
        public int Track()
        {
            return _valuesOnDiagonal.Sum();
        }

        // Represent two-dimensional format.
        public override string ToString()
        {
            if (Size == 0)
            {
                return string.Empty;
            }

            string result = "";

            // Loop over rows and columns to build the string representation of the matrix.
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    // Indexer check if it's a diagonal element.
                    result += this[i, j].ToString();

                    result += " ";
                }
                // Add a newline after each row.
                result += "\n";
            }

            return result;
        }

        // Method check if the one matrix is equal to another matrix.
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }

            // Check if the object is a DiagonalMatrix.
            if (obj is DiagonalMatrix anotherMatrix)
            {
                // If the sizes are different, the matrices are not equal.
                if (anotherMatrix.Size != Size)
                {
                    return false;
                }

                // Compare each element on the diagonal.
                for (int i = 0; i < _valuesOnDiagonal.Length; i++)
                {
                    if (_valuesOnDiagonal[i] != anotherMatrix._valuesOnDiagonal[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
