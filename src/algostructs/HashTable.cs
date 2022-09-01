using System;
using System.Net.Sockets;

namespace algostructs
{
    public class HashTable
    {
        private int _size;
        private List<Tuple<int, int>>[] _table;

        public HashTable(int size)
        {
            _size = size;
            _table = new List<Tuple<int, int>>[_size];
            for(var index = 0; index < _table.Count(); ++index)
            {
                _table[index] = new List<Tuple<int, int>>();
            }
        }

        public int HashFunction(int key)
        {
            return key % _size;
        }

        public void Insert(int key, int value)
        {
            var hash = HashFunction(key);
            var bucket = _table[hash];
            var keyExists = false;
            foreach(var item in bucket)
            {
                if(item.Item1 == key)
                {
                    keyExists = true;
                    break;
                }
            }
            if(!keyExists)
            {
                bucket.Add(Tuple.Create(key, value));
            }            
        }

        public void Remove(int key)
        {
            var hash = HashFunction(key);
            var bucket = _table[hash];
            foreach (var item in bucket)
            {
                if (item.Item1 == key)
                {
                    bucket.Remove(item);
                    break;
                }
            }
        }

        public int? Get(int key)
        {
            var hash = HashFunction(key);
            var bucket = _table[hash];
            foreach (var item in bucket)
            {
                if (item.Item1 == key)
                {
                    return item.Item2;
                }
            }
            return null;
        }

        public bool Contains(int key)
        {
            var hash = HashFunction(key);
            var bucket = _table[hash];
            foreach (var item in bucket)
            {
                if (item.Item1 == key)
                {
                    return true;
                }
            }
            return false;
        }

        public static void test(int size)
        {
            HashTable map = new HashTable(size);

            for(var index = 0; index < size; ++index)
            {
                map.Insert(index, index);
            }

            for (var index = 0; index < size; ++index)
            {
                if(!map.Contains(index))
                {
                    Console.WriteLine("HashTable doesn't contain key {0}", index);
                }
            }

            for (var index = size; index < size*2; ++index)
            {
                map.Insert(index, index);
            }

            for (var index = 0; index < size * 2; ++index)
            {
                if (!map.Contains(index))
                {
                    Console.WriteLine("HashTable doesn't contain key {0}", index);
                }

                if(map.Get(index) != index)
                {
                    Console.WriteLine("HashTable has invalid value for key {0}", index);
                }
            }
        }

    }
}

