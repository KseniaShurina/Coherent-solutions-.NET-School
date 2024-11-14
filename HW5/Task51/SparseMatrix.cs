using System.Collections;
using System.Text;

namespace Task51
{
    public class SparseMatrix : IEnumerable<long>
    {
        public int NumberOfRows { get; set; }
        public int NumberOfColumns { get; set; }

        private readonly Dictionary<(int, int), long> _notNullElements;

        public long this[int row, int column]
        {
            get
            {
                if (row < 0 || column < 0 || row >= NumberOfRows || column >= NumberOfColumns)
                {
                    throw new IndexOutOfRangeException();
                }

                if (!_notNullElements.ContainsKey((row, column)))
                {
                    return default;
                }
                return _notNullElements[(row, column)];
            }
            set
            {
                if (row < 0 || column < 0 || row >= NumberOfRows || column >= NumberOfColumns)
                {
                    throw new IndexOutOfRangeException();
                }

                // If the value with these coordinates already exists change the value
                if (_notNullElements.ContainsKey((row, column)))
                {
                    _notNullElements.Remove((row, column));
                    _notNullElements.Add((row, column), value);
                }
                _notNullElements[(row, column)] = value;
            }
        }

        // Constructor
        public SparseMatrix(int numberOfRows, int cumberOfColumns)
        {
            if (numberOfRows <= 0) throw new ArgumentOutOfRangeException(nameof(numberOfRows));
            if (cumberOfColumns <= 0) throw new ArgumentOutOfRangeException(nameof(cumberOfColumns));
            NumberOfRows = numberOfRows;
            NumberOfColumns = cumberOfColumns;
            _notNullElements = new Dictionary<(int, int), long>();
        }

        // ToString
        public override string ToString()
        {
            var result = new StringBuilder();
            // Row
            for (int i = 0; i < NumberOfRows; i++)
            {
                // Column
                for (int j = 0; j < NumberOfColumns; j++)
                {
                    result.AppendJoin(' ', this[i, j]);
                }
                result.Append("\n");
            }

            return result.ToString();
        }

        // GetEnumerator
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        // GetEnumerator
        public IEnumerator<long> GetEnumerator()
        {
            // Row
            for (int i = 0; i < NumberOfRows; i++)
            {
                // Column
                for (int j = 0; j < NumberOfColumns; j++)
                {
                    yield return this[i, j];
                }
            }
        }

        // Method returns non-zero elements with itself indexes ordered by column
        public IEnumerable<(int, int, long)> GetNonZeroElements()
        {
            // Column
            for (int j = 0; j < NumberOfColumns; j++)
            {
                //Row
                for (int i = 0; i < NumberOfRows; i++)
                {
                    if (this[i, j] != default)
                    {
                        yield return (i, j, this[i, j]);
                    }
                }
            }
        }

        // Count of values in matrix
        public int GetCount(long x)
        {
            int count = 0;
            if (x == 0)
            {
                return NumberOfRows * NumberOfColumns - _notNullElements.Count;
            }

            foreach (var item in _notNullElements)
            {
                if (_notNullElements.ContainsValue(x) & item.Value == x)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
