using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayString
{
    /**
     * Your RandomizedSet object will be instantiated and called as such:
     * RandomizedSet obj = new RandomizedSet();
     * bool param_1 = obj.Insert(val);
     * bool param_2 = obj.Remove(val);
     * int param_3 = obj.GetRandom();
     */


    class RandomizedSet_381//duplicate allowed
    {
        private Random rand = new Random();
        private List<int> list = new List<int>();
        private Dictionary<int, HashSet<int>> dict = new Dictionary<int, HashSet<int>>();

        public bool Insert(int val)
        {
            var itemExists = dict.ContainsKey(val);

            if (!itemExists)
            {
                dict[val] = new HashSet<int>();
            }

            dict[val].Add(list.Count);
            list.Add(val);

            return !itemExists;
        }

        public bool Remove(int val)
        {
            /*
            Inconsistent Index Removal: When you remove an element from list, you should replace it with the last element of the list to maintain a continuous list without gaps. 
            This ensures that indices in the dictionary remain valid.
             */
            if (!dict.ContainsKey(val)) return false;

            int removeIndex = dict[val].First();
            dict[val].Remove(removeIndex);

            int lastElement = list[list.Count - 1];
            // Move the last element to the place of the element to delete
            list[removeIndex] = lastElement;

            // Update the dictionary
            dict[lastElement].Add(removeIndex);
            dict[lastElement].Remove(list.Count - 1);

            // Remove the last element from the list
            list.RemoveAt(list.Count - 1);

            // If no more instances of val, remove from dict
            if (dict[val].Count == 0) dict.Remove(val);

            return true;
        }

        public int GetRandom()
        {
            return list[rand.Next(0, list.Count)];
        }
    }




    class RandomizedSet_380_01
    {
        private readonly Random rand = new Random();
        private readonly List<int> list = new List<int>();
        private readonly Dictionary<int, int> dict = new Dictionary<int, int>();

        public bool Insert(int val)
        {

            var itemExists = dict.ContainsKey(val);

            if (!itemExists)
            {
                dict.Add(val, list.Count);
                list.Add(val);
            }

            return !itemExists;
        }

        public bool Remove(int val)
        {
            if (!dict.ContainsKey(val)) return false;

            var idx = dict[val];

            var lastItem = list[list.Count - 1];
            dict[lastItem] = idx;
            dict.Remove(val);
            list[idx] = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return true;
        }

        public int GetRandom()
        {
            return list[rand.Next(list.Count)];
        }
    }

    internal class RandomizedSet_380
    {
        HashSet<int> set;
        Random random;
        public RandomizedSet_380()
        {
            set = new HashSet<int>();
            random = new Random();
        }

        public bool Insert(int val)
        {
            return set.Add(val);
        }

        public bool Remove(int val)
        {
            return set.Remove(val);
        }

        public int GetRandom()
        {
            return set.ElementAt(random.Next(set.Count));
        }
    }
}
