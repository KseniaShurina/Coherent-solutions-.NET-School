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
        private int _head; // First index
        private int _tail; // Last index
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
            _head = 0;
            _tail = 0;
            _size = 0;
        }

        // Constructor to add element to the queue.
        public Queue(params T[] arrayOfElements)
        {
            ArgumentNullException.ThrowIfNull(arrayOfElements);
            _capacity = arrayOfElements.Length + 5;
            _size = arrayOfElements.Length;

            _arrayOfElements = new T[_capacity];
            Array.Copy(arrayOfElements, _arrayOfElements, _size);
            _head = 0;
            _tail = _size % _capacity; // Устанавливаем _tail в конец добавленных элементов
        }

        // Add a new item to the end of the queue.
        public void Enqueue(T item)
        {
            if (_size == _capacity)
            {
                // Throw an exception when max. capacity reached.
                throw new ArgumentOutOfRangeException(nameof(_arrayOfElements));
            }

            _arrayOfElements![_tail] = item;
            // Move the index along the array. As soon as the index reaches the end of the array, the index becomes 0 again.
            _tail = (_tail + 1) % Capacity;
            _size++;
        }

        // Remove first element in queue and return it.
        public T Dequeue()
        {
            if (IsEmpty())
            {
                // Throw an exception when min. size reached.
                throw new ArgumentOutOfRangeException(nameof(_arrayOfElements));
            }

            // Save first item.
            var firstItem = _arrayOfElements![_head];
            // Releases the reference to the object (if T is RT), allowing the GC to clean up the memory. For VT, this simply resets the cell's value.
            _arrayOfElements[_head] = default(T);
            // Move the index along the array. As soon as the index reaches the end of the array, the index becomes 0 again.
            _head = (_head + 1) % Capacity;
            // Reducing the queue size.
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

        // Implementation of the non-generic IEnumerable interface.
        // For compatibility with foreach and with old code that doesn't know the type of elements inside the collection.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // This method returns an IEnumerator<T> that allows you to iterate over elements of a particular type T.
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _size; i++)
            {
                yield return _arrayOfElements![(_head + i) % Capacity];
            }
        }
    }
}
