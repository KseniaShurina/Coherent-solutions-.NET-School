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

            if (queue.ArrayOfElements.Length == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(queue));
            }

            queue.Dequeue();
            // Decrement newArray length for 1 compared to queue.
            T[] newArray = new T[queue.ArrayOfElements.Length];

            // Fill newArray without first element from queue.
            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = queue.ArrayOfElements[i];
            }

            // Return Queue without first element in array.
            return new Queue<T>(newArray);
        }
    }
}
