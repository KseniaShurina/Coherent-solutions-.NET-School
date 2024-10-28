using System.Collections;

namespace Task31
{
    public class Queue<T> : IQueue<T> where T : struct
    {
        public T[] ArrayOfElements;

        // Constructor to create empty queue.
        public Queue()
        {
            ArrayOfElements = [];
        }

        // Constructor to add element to the queue.
        public Queue(params T[] arrayOfElements)
        {
            ArgumentNullException.ThrowIfNull(arrayOfElements);
            ArrayOfElements = arrayOfElements;
        }

        // To iterate elements in a loop.
        public IEnumerator GetEnumerator() => ArrayOfElements.GetEnumerator();

        // Add a new item to the end of the queue.
        public void Enqueue(T item)
        {
            // Increment newArray length for 1 compared to array.
            T[] newArray = new T[ArrayOfElements.Length + 1];

            for (int i = 0; i < ArrayOfElements.Length; i++)
            {
                // Move elements to new array
                newArray[i] = ArrayOfElements[i];
            }

            newArray[^1] = item;

            ArrayOfElements = newArray;
        }

        // Remove first element in queue and return it.
        public T Dequeue()
        {
            if (IsEmpty())
            {
                return default(T);
                //throw new IndexOutOfRangeException(nameof(ArrayOfElements));
            }

            // Save first item to variable.
            var firstItem = ArrayOfElements![0];

            // Decrement newArray length for 1 compared to array.
            T[] newArray = new T[ArrayOfElements.Length - 1];

            // Fill newArray without first element from array.
            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = ArrayOfElements[i + 1];
            }

            ArrayOfElements = newArray;

            // Return removed item from array.
            return firstItem;
        }

        // Check queue for null or empty.
        public bool IsEmpty()
        {
            if (ArrayOfElements?.Length == 0)
            {
                return true;
            }
            return false;
        }
    }
}
