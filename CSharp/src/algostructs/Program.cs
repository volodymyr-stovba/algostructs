
using algostructs.List;
using algostructs.Queue;

namespace algostructs
{
    class algostructs
    { 
        static void Main()
        {
            int size = 10;
            Stack<int>.test(size);
            Queue<int>.test(size);
            CircularQueue<int>.test(size);
            Deque<int>.test(size);
            LinkedList<int>.test(size);
            DoublyLinkedList<int>.test(size);
            CircularLinkedList<int>.test(size);
            CircularDoublyLinkedList<int>.test(size);
            HashSet.test(size);
            HashTable.test(size);
        }
    }
}
