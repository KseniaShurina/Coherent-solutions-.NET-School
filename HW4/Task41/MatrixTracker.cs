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
                var m = _changesDictionary.Peek();
                matrix[m.Column, m.Row] = m.OldValue;
            }
        }

        private bool IsEmpty()
        {
            if (_changesDictionary.Count == 0)
            {
                return true;
            }
            return false;
        }
    }
}
