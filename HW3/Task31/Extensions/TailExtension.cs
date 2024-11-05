namespace Task31.Extensions
{
    internal static class TailExtension
    {
        /// <summary>
        /// Method returns a new queue consisting of the elements of the original parameter queue minus the first element.
        /// </summary>
        /// <typeparam name="T">The type of elements in the queue</typeparam>
        /// <param name="queue">The original queue</param>
        /// <returns>Returns a new queue consisting of the elements of the original parameter queue minus the first element</returns>
        /// <exception cref="ArgumentNullException">If queue is null</exception>
        internal static IQueue<T> Tail<T>(this Queue<T> queue) where T : struct
        {
            if (queue == null)
            {
                throw new ArgumentNullException(nameof(queue));
            }

            if (queue.IsEmpty())
            {
                return new Queue<T>();
            }

            // Create new queue
            Queue<T> newQueue = new Queue<T>(queue.Capacity);

            bool isFirstElement = true;
            foreach (var item in queue)
            {
                // Skip the first element when copying
                if (isFirstElement)
                {
                    isFirstElement = false;
                    continue;
                }
                newQueue.Enqueue((T)item);
            }

            return newQueue;
        }
    }
}
