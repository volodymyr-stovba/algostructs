using System;
using System.Drawing;

namespace algostructs.Queue
{
    public class Deque<T>
    {
        private int _front_index = -1;
        private int _rear_index = 0;
        private T[] _array;
        private int _capacity;

        public bool IsEmpty() => _front_index == -1;

        public bool IsFull() => _front_index == 0 && _rear_index == _capacity - 1 // front index on begin and rear index on end of the array
                                || _front_index == _rear_index + 1; // Rear and front indexes  are neighbors

        public Deque(int size)
        {
            _capacity = size;
            _array = new T[_capacity];
        }

        public bool InsertFront(T item)
        {
            if(IsFull())
            {
                return false;
            }

            if (_front_index == - 1) // insert first item
            {
                _front_index = 0; // one item inserted with same index
                _rear_index = 0;
            }
            else if(_front_index == 0) // move to end of the array
            {
                _front_index = _capacity - 1;
            }
            else
            {
                --_front_index;
            }

            _array[_front_index] = item;

            return true;
        }

        public bool InsertRear(T item)
        {
            if (IsFull())
            {
                return false;
            }

            if (_front_index == -1) // insert first element
            {
                _front_index = 0; // one item inserted with same index
                _rear_index = 0;
            }
            else if(_rear_index == _capacity - 1) // move to begin of the array
            {
                _rear_index = 0;
            }
            else
            {
                ++_rear_index;
            }

            _array[_rear_index] = item;

            return true;
        }

        public bool DeleteFront()
        {
            if (IsEmpty())
            {
                return false;
            }

            if (_front_index == _rear_index) // remove last element
            {
                _front_index = -1; // set empty state
                _rear_index = -1;
            }
            else if (_front_index == _capacity - 1) // move to begin of the array
            {
                _front_index = 0;
            }
            else
            {
                ++_front_index;
            }

            return true;
        }

        public bool DeleteRear()
        {
            if (IsEmpty())
            {
                return false;
            }

            if (_front_index == _rear_index) // remove last element
            {
                _front_index = -1; // set empty state
                _rear_index = -1;
            }
            else if (_rear_index == 0) // move to end of the array
            {
                _rear_index = _capacity - 1;
            }
            else
            {
                --_rear_index;
            }

            return true;
        }

        public bool Front(out T item)
        {
            item = default;
            if (IsEmpty())
            {
                return false;
            }

            item = _array[_front_index];

            return true;
        }

        public bool Rear(out T item)
        {
            item = default;

            if(IsEmpty() || _rear_index == -1)
            {
                return false;
            }

            item = _array[_rear_index];

            return true;
        }

        internal static void test1(int size)
        {
            Deque<int> queue = new Deque<int>(size);

            for (var index = 1; index <= size * 2; ++index)
            {
                if (queue.IsFull())
                {
                    break;
                }
                queue.InsertFront(index);
            }

            if (queue.IsEmpty())
            {
                Console.WriteLine("Deque should be not empty");
            }

            if (!queue.IsFull())
            {
                Console.WriteLine("Deque should be full");
            }

            int item;

            for (var index = 1; index <= size; ++index)
            {
                if (!queue.Rear(out item))
                {
                    Console.WriteLine("Deque is empty, but some items was missed");
                    break;
                }

                if (item != index)
                {
                    Console.WriteLine("Deque order was corrupted. Item: {0}, Check value: {1}", item, index);
                }

                if (!queue.DeleteRear())
                {
                    Console.WriteLine("Deque is empty, but some items was missed");
                    break;
                }
            }

            if (!queue.IsEmpty())
            {
                Console.WriteLine("Deque should be empty");
            }

            if (queue.IsFull())
            {
                Console.WriteLine("Deque should be not full");
            }
        }

        internal static void test2(int size)
        {
            Deque<int> queue = new Deque<int>(size);

            for (var index = 1; index <= size * 2; ++index)
            {
                if (queue.IsFull())
                {
                    break;
                }
                queue.InsertRear(index);
            }

            if (queue.IsEmpty())
            {
                Console.WriteLine("Deque should be not empty");
            }

            if (!queue.IsFull())
            {
                Console.WriteLine("Deque should be full");
            }

            int item;

            for (var index = 1; index <= size; ++index)
            {
                if (!queue.Front(out item))
                {
                    Console.WriteLine("Deque is empty, but some items was missed");
                    break;
                }

                if (item != index)
                {
                    Console.WriteLine("Deque order was corrupted. Item: {0}, Check value: {1}", item, index);
                }

                if (!queue.DeleteFront())
                {
                    Console.WriteLine("Deque is empty, but some items was missed");
                    break;
                }
            }

            if (!queue.IsEmpty())
            {
                Console.WriteLine("Deque should be empty");
            }

            if (queue.IsFull())
            {
                Console.WriteLine("Deque should be not full");
            }
        }

        public static void test(int size)
        {
            test1(size);
            test2(size);           
        }
    }
}

