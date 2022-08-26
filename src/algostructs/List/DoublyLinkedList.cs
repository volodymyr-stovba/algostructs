using System;
using System.Threading;

namespace algostructs.List
{
    public class DoublyLinkedList<T>
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

        private Node<T>? _head;

        public Node<T>? Head => _head;

        public bool IsEmpty() => _head == null;

        public DoublyLinkedList()
        {

        }

        public Node<T> PushFront(T data)
        {
            var newNode = new Node<T>(data);
            if (_head != null)
            {
                _head.prev = newNode;
            }
            newNode.next = _head;
            _head = newNode;
            return newNode;
        }

        public bool RemoveFront()
        {
            if (_head == null)
            {
                return false;
            }
            if(_head.next != null)
            {
                _head.next.prev = null;
            }
            _head = _head.next;
            return true;
        }

        public bool Remove(Node<T>? currentNode)
        {
            if(currentNode == null)
            {
                return false;
            }

            if(currentNode == _head)
            {
                RemoveFront();
            }
            else
            {
                if (currentNode.next != null)
                {
                    currentNode.next.prev = currentNode.prev;
                }

                if (currentNode.prev != null)
                {
                    currentNode.prev.next = currentNode.next;
                }
            }

            return true;
        }

        public Node<T>? Next(Node<T> currentNode)
        {
            return currentNode.next;
        }

        internal static void test1(int size)
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();

            for (var index = 1; index <= size; ++index)
            {
                list.PushFront(index);
            }

            if (list.IsEmpty())
            {
                Console.WriteLine("DoublyLinkedList should be not empty");
            }

            for (var index = 1; index <= size; ++index)
            {
                list.RemoveFront();
            }

            if (!list.IsEmpty())
            {
                Console.WriteLine("DoublyLinkedList should be empty");
            }
        }

        internal static void test2(int size)
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();

            for (var index = 1; index <= size; ++index)
            {
                list.PushFront(index);
            }

            var currentNode = list.Head;

            for (var index = size; index > 0; --index)
            {
                if (currentNode == null)
                {
                    Console.WriteLine("DoublyLinkedList missed some items");
                    break;
                }

                if (currentNode.data != index)
                {
                    Console.WriteLine("DoublyLinkedList order was corrupted. Item: {0}, Check value: {1}", currentNode.data, index);
                }

                currentNode = list.Next(currentNode);
            }
        }

        internal static void test3(int size)
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();

            for (var index = 1; index <= size; ++index)
            {
                list.PushFront(index);
            }

            var currentNode = list.Head;

            for (var index = 1; index <= size/2; ++index)
            {                
                list.Remove(currentNode);
                currentNode = list.Next(currentNode);
            }            

            for (var index = size/2; index > 0; --index)
            {
                if (currentNode == null)
                {
                    Console.WriteLine("DoublyLinkedList missed some items");
                    break;
                }

                if (currentNode.data != index)
                {
                    Console.WriteLine("DoublyLinkedList order was corrupted. Item: {0}, Check value: {1}", currentNode.data, index);
                }

                currentNode = list.Next(currentNode);
            }
        }

        public static void test(int size)
        {
            test1(size);
            test2(size);
            test3(size);
        }
    }

}

