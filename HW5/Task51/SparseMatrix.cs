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
                if (IsValidIndexes(row, column))
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
                if (IsValidIndexes(row, column))
                {
                    throw new IndexOutOfRangeException();
                }

                if (value == 0 || this[row, column] != 0)
                {
                    _notNullElements.Remove((row, column));
                }

                _notNullElements[(row, column)] = value;
            }
        }

        private bool IsValidIndexes(int row, int column)
        {
            return row < 0 || column < 0 || row >= NumberOfRows || column >= NumberOfColumns;
        }

        // Constructor
        public SparseMatrix(int numberOfRows, int cumberOfColumns)
        {
            if (numberOfRows <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfRows));
            }

            if (cumberOfColumns <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(cumberOfColumns));
            }

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
            var nonZeroElements = _notNullElements.Where(i => i.Value != 0)
                .Select(i => (i.Key.Item1, i.Key.Item2, i.Value)).OrderBy(i => i.Item2).ToArray();
        
            return nonZeroElements;
        }

        // Count of values in matrix
        public int GetCount(long x)
        {
            if (x == 0)
            {
                return NumberOfRows * NumberOfColumns - _notNullElements.Count;
            }

            var count = _notNullElements.Count(i => i.Value == x);

            return count;
        }
    }
}
