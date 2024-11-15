namespace Task41
{
    /// <summary>
    /// Class for passing information about the changed matrix.
    /// </summary>
    /// <typeparam name="T">Type of elements in the matrix</typeparam>
    public class MatrixChangedEventArgs<T> : EventArgs
    {
        public int Row { get; private set; }
        public int Column { get; private set; }
        public T OldValue { get; private set; }
        public T NewValue { get; private set; }

        public MatrixChangedEventArgs(int row, int column, T oldValue, T newValue)
        {
            Row = row;
            Column = column;
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}
