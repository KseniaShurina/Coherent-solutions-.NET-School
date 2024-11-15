namespace Task41
{
    internal class Matrix<T>
    {
        //To get the size of the matrix.
        public int Size
        {
            get => _valuesOnDiagonal?.Length ?? 0;
            private set { }
        }

        // Private array that stores only the diagonal elements of the matrix.
        private readonly T[] _valuesOnDiagonal = null!;

        // Event
        public event EventHandler<MatrixChangedEventArgs<T>>? ElementChanged;

        // Indexer to access elements of the matrix.
        public T this[int i, int j]
        {
            get
            {
                if (i < 0 || j < 0 || i >= Size & j >= Size) throw new IndexOutOfRangeException(nameof(i));

                if (i == j)
                {
                    return _valuesOnDiagonal[i];
                }

                return default(T)!;
            }
            set
            {
                if (IsValidIndex(i, j))
                {
                    T oldValue = _valuesOnDiagonal[i];

                    if (!oldValue!.Equals(value))
                    {
                        _valuesOnDiagonal[i] = value;
                        ElementChanged?.Invoke(this, new MatrixChangedEventArgs<T>(i, j, oldValue, value));
                    }
                }
            }
        }

        // Constructor
        public Matrix()
        {
            Size = 0;
            _valuesOnDiagonal = new T[Size];
        }

        // Constructor
        public Matrix(int size)
        {
            if (size < 0) throw new ArgumentException("Negative value", nameof(size));
            Size = size;
            _valuesOnDiagonal = new T[size];
        }

        // Constructor
        public Matrix(params T[]? numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                Size = 0;
            }
            else
            {
                Size = numbers.Length;
                // Array.Copy ensures that _valuesOnDiagonal is independently of numbers. Any modification will not affect to _valuesOnDiagonal.
                _valuesOnDiagonal = new T[numbers.Length];
                Array.Copy(numbers, _valuesOnDiagonal, numbers.Length);
            }
        }

        private bool IsValidIndex(int i, int j)
        {
            return i != j || i < 0 || j < 0 || i >= Size & j >= Size;
        }

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
                    result += this[i, j];

                    result += " ";
                }
                // Add a newline after each row.
                result += "\n";
            }

            return result;
        }
    }
}
