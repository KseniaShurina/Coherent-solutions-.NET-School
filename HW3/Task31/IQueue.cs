namespace Task31
{
    public interface IQueue<T> where T : struct
    {
        public void Enqueue(T item) { }

        public T Dequeue();

        public bool IsEmpty();
    }
}
