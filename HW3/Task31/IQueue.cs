namespace Task31
{
    // IEnumerable<T> allows foreach to be used with types that implement this interface.
    public interface IQueue<T> : IEnumerable<T>
    {
        public void Enqueue(T item) { }

        public T Dequeue();

        public bool IsEmpty();
    }
}
