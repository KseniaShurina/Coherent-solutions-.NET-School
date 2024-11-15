using System.Reflection;

namespace Task41
{
    /// <summary>
    /// Subscribe matrix to the event.
    /// </summary>
    /// <typeparam name="T">Type of elements in the matrix</typeparam>
    internal class MatrixTracker<T>
    {
        private readonly Matrix<T> _matrix;
        private readonly Stack<MatrixChangedEventArgs<T>> _changesDictionary = new Stack<MatrixChangedEventArgs<T>>();

        public MatrixTracker(Matrix<T> matrix)
        {
            _matrix = matrix;
            _matrix.ElementChanged += ElementChanged;
        }

        private void ElementChanged(object? sender, MatrixChangedEventArgs<T> e)
        {
            ArgumentNullException.ThrowIfNull(sender);
            ArgumentNullException.ThrowIfNull(e);

            _changesDictionary.Push(e);
        }

        // Undo last change in the matrix.
        public void Undo(Matrix<T> matrix)
        {
            ArgumentNullException.ThrowIfNull(matrix);

            if (!IsEmpty())
            {
                // To ensure a matrix subscribes again even an exception will be occured.
                try
                {
                    _matrix.ElementChanged -= ElementChanged;
                    // Pop() - Removes change from dictionary.
                    var m = _changesDictionary.Pop();
                    matrix[m.Column, m.Row] = m.OldValue;
                }
                finally
                {
                    _matrix.ElementChanged += ElementChanged;
                }
            }
        }

        private bool IsEmpty()
        {
            return _changesDictionary.Count == 0;
        }
    }
}
