namespace Task2._2
{
    internal class DiagonalMatrix
    {
        //To get the size of the matrix.
        public int Size { get; init; }

        // Private array that stores only the diagonal elements of the matrix.
        private int[] _valuesOnDiagonal = null!;

        // Indexer to access elements of the matrix.
        internal int this[int i, int j]
        {
            get
            {
                if (i != j || i < 0 || j < 0 || i >= Size & j >= Size)
                {
                    return 0;
                }

                return _valuesOnDiagonal[i];
            }
        }

        internal DiagonalMatrix(params int[]? numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                Size = 0;
            }
            else
            {
                Size = numbers.Length;
                _valuesOnDiagonal = numbers;
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
                return base.ToString();
            }

            string result = "";

            // Loop over rows and columns to build the string representation of the matrix.
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    // Check if it's a diagonal element.
                    if ((i == j) && i < Size)
                    {
                        result += (this._valuesOnDiagonal[i].ToString());
                    }
                    else
                    {
                        result += "0";
                    }

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
                return true;
            }
            else
            {
                return false;
            }
        }

        // Method to add two diagonal matrices.
        internal DiagonalMatrix Addition(DiagonalMatrix matrix)
        {
            int size = 0;

            // Resize the smaller matrix if the sizes are different
            if (Size > matrix.Size)
            {
                Array.Resize(ref matrix._valuesOnDiagonal, Size);
                size = Size;
            }
            else if(matrix.Size > Size)
            {
                Array.Resize(ref _valuesOnDiagonal, matrix.Size);
                size = matrix.Size;
            }
            
            int[] newMatrix = new int[size];

            // Add elements of the two matrices.
            for (int i = 0; i < size; i++)
            {
                newMatrix[i] = matrix._valuesOnDiagonal[i] + _valuesOnDiagonal[i];
            }

            return new DiagonalMatrix(newMatrix);
        }
    }
}
