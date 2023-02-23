using System;
using System.Drawing;

namespace algostructs
{
    public class CircularQueue<T>
    {
        private int _front_index = -1;
        private int _rear_index = -1;
        private T[] _array;
        private int _capacity;

        public bool IsEmpty() => _front_index == -1;
        public bool IsFull() => _rear_index == _capacity - 1 || _front_index == _rear_index + 1;

        public CircularQueue(int size)
        {
            _capacity = size;
            _array = new T[_capacity];
        }

        public bool Enqueue(T item)
        {
            if (IsFull())
            {
                return false;
            }
            if (IsEmpty())
            {
                _front_index = 0;
            }
            _rear_index = (_rear_index + 1) % _capacity;
            _array[_rear_index] = item;
            return true;
        }

        public bool Dequeue(out T? item)
        {
            item = default;

            if (IsEmpty())
            {
                return false;
            }

            item = _array[_front_index];

            if (_front_index >= _rear_index)
            {
                _rear_index = -1;
                _front_index = -1;
            }
            else
            {
                _front_index = (_front_index + 1) % _capacity;
            }
            return true;
        }

        public bool Peek(out T? item)
        {
            item = default;

            if (IsEmpty())
            {
                return false;
            }
            item = _array[_front_index];
            return true;
        }

        public static void test(int size)
        {
            CircularQueue<int> queue = new CircularQueue<int>(size);

            for (var index = 1; index <= size * 2; ++index)
            {
                if (queue.IsFull())
                {
                    break;
                }
                queue.Enqueue(index);
            }

            if (queue.IsEmpty())
            {
                Console.WriteLine("Circular Queue should be not empty");
            }

            if (!queue.IsFull())
            {
                Console.WriteLine("Circular Queue should be full");
            }

            int item;
            if (!queue.Peek(out item))
            {
                Console.WriteLine("Did't peek item");
            }

            if (1 != item)
            {
                Console.WriteLine("Peeked item is invalid. Peeked item: {0}, Should be value: {1}", item, size);
            }

            if (queue.IsEmpty())
            {
                Console.WriteLine("Circular Queue should be not empty");
            }

            if (!queue.IsFull())
            {
                Console.WriteLine("Circular Queue should be full");
            }

            for (var index = 1; index <= size; ++index)
            {
                if (!queue.Dequeue(out item))
                {
                    Console.WriteLine("Circular Queue is empty, but some items was missed");
                    break;
                }
                if (item != index)
                {
                    Console.WriteLine("Circular Queue order was corrupted. Item: {0}, Check value: {1}", item, index);
                }
            }

            if (!queue.IsEmpty())
            {
                Console.WriteLine("Circular Queue should be empty");
            }

            if (queue.IsFull())
            {
                Console.WriteLine("Circular Queue should be not full");
            }

            for (var index = 1; index <= size*2; ++index)
            {
                if (queue.IsFull())
                {
                    break;
                }
                queue.Enqueue(index);
            }

            for (var index = 1; index < size / 2; ++index)
            {
                if (queue.IsEmpty())
                {
                    break;
                }
                queue.Dequeue(out item);
            }

            for (var index = 1; index <= size * 2; ++index)
            {
                if (queue.IsFull())
                {
                    break;
                }
                queue.Enqueue(index);
            }

            for (var index = size / 2; index <= size; ++index)
            {
                if (queue.IsEmpty())
                {
                    break;
                }
                queue.Dequeue(out item);

                if (item != index)
                {
                    Console.WriteLine("Circular Queue order was corrupted. Item: {0}, Check value: {1}", item, index);
                }
            }

            for (var index = 1; index <= size; ++index)
            {
                if (queue.IsEmpty())
                {
                    break;
                }
                queue.Dequeue(out item);

                if (item != index)
                {
                    Console.WriteLine("Circular Queue order was corrupted. Item: {0}, Check value: {1}", item, index);
                }
            }

        }
    }
}

