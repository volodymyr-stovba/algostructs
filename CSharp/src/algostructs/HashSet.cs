using System;
namespace algostructs
{
    public class HashSet
    {
        private bool[] _table = new bool[(int)Math.Pow(10,6)];

        public HashSet()
        {

        }

        public void Add(int key)
        {
            var index = HashFunction(key);
            _table[index] = true;
        }

        public void Remove(int key)
        {
            var index = HashFunction(key);
            _table[index] = false;
        }

        public bool Contains(int key)
        {
            var index = HashFunction(key);
            return _table[index];
        }

        private int HashFunction(int key)
        {
            return key;
        }

        public static void test(dynamic size)
        {
            var set = new HashSet();

            for(var index = 0; index < size; ++index)
            {
                set.Add(index);
            }

            for (var index = 0; index < size; ++index)
            {
                if (!set.Contains(index))
                {
                    Console.WriteLine("HashSet doesn't contain key {0}", index);
                }
            }

            for (var index = size; index < size*2; ++index)
            {
                if (set.Contains(index))
                {
                    Console.WriteLine("HashSet shouldn't contain key {0}", index);
                }
            }

            for (var index = 0; index < size; ++index)
            {
                set.Remove(index);
            }

            for (var index = 0; index < size; ++index)
            {
                if (set.Contains(index))
                {
                    Console.WriteLine("HashSet shouldn't contain key {0}", index);
                }
            }
        }
    }
}

