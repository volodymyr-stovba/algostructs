using System;
namespace algostructs.List
{
    public class CircularDoublyLinkedList<T>
    {
        public class Node<D>
        {
            public D data;
            public Node<D>? prev;
            public Node<D>? next;

            public Node(D data)
            {
                this.data = data;
                prev = null;
                next = null;
            }
        }

        private Node<T>? _last;

        public Node<T>? Last => _last;

        public bool IsEmpty() => _last == null;

        public CircularDoublyLinkedList()
        {
        }

        public Node<T> PushFront(T data)
        {
            var newNode = new Node<T>(data);

            if (_last == null) // push first item
            {
                _last = newNode;
                newNode.prev = _last;
                newNode.next = _last;
            }
            else // push to front
            {
                newNode.next = _last.next;
                newNode.next.prev = newNode;
                
                _last.next = newNode;
                newNode.prev = _last;
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
                _last.next.next.prev = _last;            
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
                newNode.prev = newNode;
            }
            else
            {
                newNode.next = _last.next;
                _last.next = newNode;

                newNode.prev = _last;                               
                newNode.next.prev = newNode;

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
                _last.prev.next = _last.next;
                _last.next.prev = _last.prev;

                _last = _last.prev;
            }

            return true;
        }

        public Node<T>? Next(Node<T> currentNode)
        {
            return currentNode.next;
        }

        public static void test(int size)
        {
            CircularDoublyLinkedList<int> list = new CircularDoublyLinkedList<int>();

            for (var index = 1; index <= size; ++index)
            {
                list.PushFront(index);
            }

            if (list.IsEmpty())
            {
                Console.WriteLine("CircularDoublyLinkedList should be not empty");
            }

            for (var index = 1; index <= size; ++index)
            {
                list.RemoveFront();
            }

            if (!list.IsEmpty())
            {
                Console.WriteLine("CircularDoublyLinkedList should be empty");
            }
        }
    }
}

