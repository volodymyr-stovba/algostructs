using System;
using System.Collections.Generic;
using System.Reflection;

namespace algostructs
{
    public class LinkedList<T>
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

        private Node<T>? _head;

        public Node<T>? Head => _head;

        public bool IsEmpty() => _head == null;

        public LinkedList()
        {
            _head = null;
        }        

        public Node<T> PushFront(T data)
        {
            var newNode = new Node<T>(data);
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
            _head = _head.next;
            return true;
        }

        public Node<T>? Next(Node<T> currentNode)
        {
            return currentNode.next;
        }

        public Node<T>? AddAfter(Node<T>? currentNode, T data)
        {
            if(currentNode == null)
            {
                return null;
            }
            var newNode = new Node<T>(data);
            var next = currentNode.next;
            currentNode.next = newNode;
            newNode.next = next;
            return newNode;
        }

        public bool RemoveAfter(Node<T>? currentNode)
        {
            if (IsEmpty() || currentNode == null)
            {
                return false;
            }

            if(currentNode.next == null)
            {
                return false;
            }

            var nodeToRemove = currentNode.next;
            currentNode.next = nodeToRemove.next;

            return true;
        }

        internal static void test1(int size)
        {
            LinkedList<int> list = new LinkedList<int>();

            for (var index = 1; index <= size; ++index)
            {
                list.PushFront(index);
            }

            if (list.IsEmpty())
            {
                Console.WriteLine("LinkedList should be not empty");
            }

            for (var index = 1; index <= size; ++index)
            {
                list.RemoveFront();
            }

            if (!list.IsEmpty())
            {
                Console.WriteLine("LinkedList should be empty");
            }
        }

        internal static void test2(int size)
        {
            LinkedList<int> list = new LinkedList<int>();

            for (var index = 1; index <= size; ++index)
            {
                list.PushFront(index);
            }

            var currentNode = list.Head;

            for (var index = size; index > 0; --index)
            {
                if(currentNode == null)
                {
                    Console.WriteLine("LinkedList missed some items");
                    break;
                }

                if(currentNode.data != index)
                {
                    Console.WriteLine("LinkedList order was corrupted. Item: {0}, Check value: {1}", currentNode.data, index);
                }

                currentNode = list.Next(currentNode);
            }
        }

        internal static void test3(int size)
        {
            LinkedList<int> list = new LinkedList<int>();

            for (var index = 1; index <= size; ++index)
            {
                list.PushFront(index);
            }

            for (var index = 1; index <= size / 2; ++index)
            {
                list.RemoveFront();
            }

            var currentNode = list.Head;

            for (var index = size / 2; index > 0; --index)
            {
                if (currentNode == null)
                {
                    Console.WriteLine("LinkedList missed some items");
                    break;
                }

                if (currentNode.data != index)
                {
                    Console.WriteLine("LinkedList order was corrupted. Item: {0}, Check value: {1}", currentNode.data, index);
                }

                currentNode = list.Next(currentNode);
            }
        }

        internal static void test4(int size)
        {
            LinkedList<int> list = new LinkedList<int>();

            var lastNode = list.Head;

            for (var index = 1; index <= size; ++index)
            {
                list.PushFront(index);

                if (index == 1)
                {
                    lastNode = list.Head;
                }
            }

            if (lastNode == null)
            {
                Console.WriteLine("LinkedList middle node is null");
            }

            var insertedAfterNode = lastNode;

            for (var index = 1; index <= size; ++index)
            {
                var newNode = list.AddAfter(lastNode, index);
                lastNode = newNode;
            }

            var currentNode = list.Head;

            for (var index = size; index > 0; --index)
            {
                if (currentNode == null)
                {
                    Console.WriteLine("LinkedList missed some items");
                    break;
                }

                if (currentNode.data != index)
                {
                    Console.WriteLine("LinkedList order was corrupted. Item: {0}, Check value: {1}", currentNode.data, index);
                }

                currentNode = list.Next(currentNode);
            }

            for (var index = 1; index < size; ++index)
            {
                if (currentNode == null)
                {
                    Console.WriteLine("LinkedList missed some items");
                    break;
                }

                if (currentNode.data != index)
                {
                    Console.WriteLine("LinkedList order was corrupted. Item: {0}, Check value: {1}", currentNode.data, index);
                }

                currentNode = list.Next(currentNode);
            }

            for (var index = 1; index <= size; ++index)
            {
                list.RemoveAfter(insertedAfterNode);
            }

            currentNode = list.Head;

            var indexForWhile = size;
            while(currentNode != null)
            {
                if (currentNode.data != indexForWhile)
                {
                    Console.WriteLine("LinkedList order was corrupted. Item: {0}, Check value: {1}", currentNode.data, indexForWhile);
                }
                --indexForWhile;
                currentNode = list.Next(currentNode);
            }        
        }

        public static void test(int size)
        {
            test1(size);
            test2(size);
            test3(size);
            test4(size);
        }
    }
}

