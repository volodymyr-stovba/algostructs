using System;
using System.Threading;

namespace algostructs.List
{
    public class CircularLinkedList<T>
    {

        public class Node<D>
        {
            public D data;
            public Node<D>? next;

            public Node(D data)
            {
                this.data = data;
                next = null;
            }
        }

        private Node<T>? _last;

        public Node<T>? Last => _last;

        public bool IsEmpty() => _last == null;

        public CircularLinkedList()
        {

        }

        public Node<T> PushFront(T data)
        {
            var newNode = new Node<T>(data);

            if (_last == null)
            {
                _last = newNode;
                newNode.next = _last;
            }
            else
            {
                newNode.next = _last.next;
                _last.next = newNode;
            }
            return newNode;
        }

        public bool RemoveFront()
        {
            if (_last == null)
            {
                return false;
            }

            if (_last == _last.next)
            {
                _last = null;
            }
            else
            {
                _last.next = _last.next.next;
            }

            return true;
        }


        public Node<T> PushBack(T data)
        {
            var newNode = new Node<T>(data);

            if (_last == null)
            {
                _last = newNode;
                newNode.next = _last;
            }
            else
            {
                newNode.next = _last.next;
                _last.next = newNode;
                _last = newNode;
            }
            return newNode;
        }

        public bool RemoveBack()
        {
            if (_last == null)
            {
                return false;
            }

            if (_last == _last.next)
            {
                _last = null;
            }
            else
            {
                _last = _last.next;
            }

            return true;
        }

        public static void test(int size)
        {
            CircularLinkedList<int> list = new CircularLinkedList<int>();

            for (var index = 1; index <= size; ++index)
            {
                list.PushFront(index);
            }

            if (list.IsEmpty())
            {
                Console.WriteLine("CircularLinkedList should be not empty");
            }

            for (var index = 1; index <= size; ++index)
            {
                list.RemoveFront();
            }

            if (!list.IsEmpty())
            {
                Console.WriteLine("CircularLinkedList should be empty");
            }
        }
    }
}

