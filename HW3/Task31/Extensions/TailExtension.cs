namespace Task31.Extensions
{
    internal static class TailExtension<T> where T : struct
    {
        internal static IQueue<T> Tail(Queue<T> queue)
        {
            if (queue == null)
            {
                throw new ArgumentNullException(nameof(queue));
            }

            if (queue.IsEmpty())
            {
                return new Queue<T>();
            }

            // Remove first element in queue
            queue.Dequeue();

            // Create new queue
            Queue<T> newQueue = new Queue<T>(queue.Capacity);

            // Fill newQueue elements from the queue
            foreach (var item in queue)
            {
                newQueue.Enqueue((T)item);
            }

            return newQueue;
        }
    }
}
