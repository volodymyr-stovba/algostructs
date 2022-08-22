using System;

namespace algostructs
{
    public class Stack<T>
    { 
        private T[] _array;
        private int _top_index = -1;
        private int _capacity;

        public bool IsEmpty() => _top_index == -1;
        public bool IsFull() => _top_index + 1 >= _capacity;

        public Stack(int size)
        {
            _capacity = size;
            _array = new T[_capacity];
        }

        public bool Push(T item)
        {
            if (IsFull())
            {
                return false;
            }
            _array[++_top_index] = item;
            return true;
        }

        public bool Pop(out T item)
        {
            item = default;

            if (IsEmpty())
            {
                return false;
            }
            item = _array[_top_index--];
            return true;
        }      

        public bool Peek(out T item)
        {
            item = default;

            if (IsEmpty())
            {
                return false;
            }
            item = _array[_top_index];
            return true;
        }

        public static void test(int size)
        {
            Stack<int> stack = new Stack<int>(size);

            for (var index = 1; index <= size * 2; ++index)
            {
                if (stack.IsFull())
                {
                    break;
                }
                stack.Push(index);
            }

            if (stack.IsEmpty())
            {
                Console.WriteLine("Stack should be not empty");
            }

            if (!stack.IsFull())
            {
                Console.WriteLine("Stack should be full");
            }

            int item;
            if (!stack.Peek(out item))
            {
                Console.WriteLine("Did't peek item");
            }

            if (size != item)
            {
                Console.WriteLine("Peeked item is invalid. Peeked item: {0}, Should be value: {1}", item, size);
            }

            if (stack.IsEmpty())
            {
                Console.WriteLine("Stack should be not empty");
            }

            if (!stack.IsFull())
            {
                Console.WriteLine("Stack should be full");
            }

            for (var index = size; index > 0; --index)
            {
                if (!stack.Pop(out item))
                {
                    Console.WriteLine("Stack is empty, but some items was missed");
                    break;
                }
                if (item != index)
                {
                    Console.WriteLine("Stack order was corrupted. Item: {0}, Check value: {1}", item, index);
                }
            }

            if (!stack.IsEmpty())
            {
                Console.WriteLine("Stack should be empty");
            }

            if (stack.IsFull())
            {
                Console.WriteLine("Stack should be not full");
            }
        }
    }
}

