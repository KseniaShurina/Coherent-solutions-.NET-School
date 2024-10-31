using System.Collections;

namespace Task31
{
    internal class Queue<T> : IQueue<T> where T : struct
    {
        public int Capacity
        {
            get => _capacity;
            private set => _capacity = value;
        }

        private T[]? _arrayOfElements = null!;
        private int _size;
        private int _capacity;

        // Constructor to create queue with capacity.
        public Queue(int capacity = 10)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }
            _capacity = capacity;
            _arrayOfElements = new T[_capacity];
        }

        // Constructor to add element to the queue.
        public Queue(params T[] arrayOfElements)
        {
            ArgumentNullException.ThrowIfNull(arrayOfElements);
            _capacity = arrayOfElements.Length + 5;
            _size = arrayOfElements.Length;

            _arrayOfElements = new T[_capacity];
            Array.Copy(arrayOfElements, _arrayOfElements, _size);
        }

        // To iterate elements in a loop.
        public IEnumerator GetEnumerator() => _arrayOfElements!.GetEnumerator();

        // Add a new item to the end of the queue.
        public void Enqueue(T item)
        {
            if (_size == _capacity)
            {
                throw new ArgumentOutOfRangeException(nameof(_arrayOfElements));
            }

            _arrayOfElements![_size] = item;
            _size++;
        }

        // Remove first element in queue and return it.
        public T Dequeue()
        {
            if (IsEmpty())
            {
                return default(T);
            }

            // Save first item to variable.
            var firstItem = _arrayOfElements![0];

            // Decrement newArray length for 1 compared to array.
            T[] newArray = new T[_capacity];

            // Fill newArray without first element from array.
            for (int i = 0; i < _capacity - 1; i++)
            {
                newArray[i] = _arrayOfElements[i + 1];
            }

            _arrayOfElements = newArray;
            _size--;
            // Return removed item from array.
            return firstItem;
        }

        // Check queue for null or empty.
        public bool IsEmpty()
        {
            if (_size <= 0)
            {
                return true;
            }
            return false;
        }

        public void Foreach()
        {
            if (_size <= 0)
            {
                throw new ArgumentNullException(nameof(_arrayOfElements));
            }

            for (int i = 0; i < _size; i++)
            {
                Console.Write($"{_arrayOfElements![i]} ");
            }
        }
    }
}
