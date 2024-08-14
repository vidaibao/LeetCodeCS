



namespace HashMapping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*========== EASY ============*/
            //RansomNote_383();
            //IsomorphicString_205();
            //ValidAnagrams_242();
            //GroupAnagrams_49();
            FindResultantArrayAfterRemovingAnagrams_2273();

        }






        private static void FindResultantArrayAfterRemovingAnagrams_2273()
        {
            //string[] words = ["a", "b", "a"];//["a","b","a"]
            //string[] words = ["a", "b", "c", "d", "e"];
            string[] words = ["abba", "baba", "bbaa", "cd", "cd"];
            Console.WriteLine(string.Join(", ", RemoveAnagrams(words)));
        }
        /*
         * In one operation, select any index i such that 0 < i < words.length and words[i - 1] and words[i] are anagrams, and delete words[i] from words. Keep performing this operation as long as you can select an index that satisfies the conditions.
         */
        static IList<string> RemoveAnagrams(string[] words)
        {
            var res = new List<string>();

            string previous = string.Empty;
            for (int i = 0; i < words.Length; i++)
            {
                string sortedStr = new string(words[i].OrderBy(c => c).ToArray());

                if (sortedStr != previous)
                {
                    res.Add(words[i]);
                    previous = sortedStr;
                }
            }

            return res;
        }
        static IList<string> RemoveAnagrams01(string[] words)
        {
            var map = new Dictionary<string, IList<int>>();

            for (int i = 0; i < words.Length; i++)
            {
                string sortedStr = new string(words[i].OrderBy(c => c).ToArray());
                if (map.TryGetValue(sortedStr, out IList<int> li))
                {
                    li.Add(i);
                }
                else
                {
                    map[sortedStr] = new List<int>();
                    map[sortedStr].Add(i);
                }
            }
            // remove continuous anagrams
            foreach (var kvp in map)
            {
                var key = kvp.Key;
                var li = kvp.Value;
                var lis = new List<int>();
                for (int i = 0; i < li.LongCount(); i++)
                {
                    if (i == 0 || li[i] != li[i-1] + 1)
                    {
                        lis.Add(li[i]);
                    }
                }
                map[key] = lis;
            }

            var res = new List<string>();
            foreach (var i in map.SelectMany(p => p.Value).OrderBy(x => x).ToList()) 
            {
                res.Add(words[i]);
            }

            return res;
        }
        static IList<string> RemoveAnagrams00(string[] words)//194/201 passed
        {
            var map = new Dictionary<string, string>();
            foreach (string word in words)
            {
                string sortedStr = new string(word.OrderBy(c => c).ToArray());
                if (!map.ContainsKey(sortedStr))
                    map[sortedStr] = word;
            }
            return map.Values.ToArray();
        }





        private static void GroupAnagrams_49()
        {
            string[] strs = ["eat", "tea", "tan", "ate", "nat", "bat"];//[["bat"],["nat","tan"],["ate","eat","tea"]]
            var res = GroupAnagrams(strs);
            foreach (var re in res)
            {
                Console.WriteLine(string.Join(", ", re));
            }
        }
        static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var map = new Dictionary<string, IList<string>>();

            foreach (var str in strs)
            {
                string sortedStr = new string(str.OrderBy(c => c).ToArray());
                if (!map.ContainsKey(sortedStr))
                    map[sortedStr] = new List<string>();
                map[sortedStr].Add(str);
            }

            return map.Values.ToList();
        }





        private static void ValidAnagrams_242()
        {
            string s = "anagram", t = "nagaram";
            Console.WriteLine(IsAnagram(s, t));
        }
        static bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;

            var mapS = new Dictionary<char, int>();
            var mapT = new Dictionary<char, int>();
            
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (!mapS.ContainsKey(c))
                    mapS[c] = 0;
                mapS[c]++;
                c = t[i];
                if (!mapT.ContainsKey(c))
                    mapT[c] = 0;
                mapT[c]++;
            }

            int required = mapS.Count;
            int matches = 0;
            foreach (char c in mapS.Keys)
            {
                if (mapT.TryGetValue(c, out int value))
                    if (mapS[c] == value) matches++;
            }

            return matches == required;
        }





        private static void IsomorphicString_205()
        {
            string s = "foo", t = "bar";
            //string s = "paper", t = "title";
            //string s = "egg", t = "add";
            Console.WriteLine(IsIsomorphic(s, t));
        }
        /*
         Để kiểm tra xem hai chuỗi có đẳng cấu hay không, chúng ta có thể sử dụng hai từ điển (hoặc mảng) để ánh xạ các ký tự của chuỗi s với chuỗi t và ngược lại. Trong quá trình duyệt qua các ký tự của hai chuỗi:

        Kiểm tra xem ký tự tại vị trí hiện tại của chuỗi s đã có ánh xạ với ký tự tương ứng của chuỗi t chưa.
        Nếu đã có nhưng ánh xạ không khớp, chuỗi không đẳng cấu.
        Nếu chưa có ánh xạ, thiết lập ánh xạ giữa ký tự của s và t.
        Thực hiện tương tự cho ánh xạ ngược từ t sang s.
         */
        static bool IsIsomorphic(string s, string t)
        {
            var mapST = new Dictionary<char, char>();
            var mapTS = new Dictionary<char, char>();

            for (int i = 0; i < s.Length; i++)
            {
                char charS = s[i]; 
                char charT = t[i];

                if (mapST.ContainsKey(charS))
                {
                    if (mapST[charS] != charT) return false;
                }
                else
                    mapST[charS] = charT;

                if (mapTS.ContainsKey(charT))
                {
                    if (mapTS[charT] != charS) return false;
                }
                else
                    mapTS[charT] = charS;
            }
            return true;
        }
        static bool IsIsomorphic00(string s, string t)
        {
            string t2 = t;
            var map = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++) 
            {
                char c = s[i], old = t[i];
                if (!map.ContainsKey(c))
                    map[c] = 0;
                map[c]++;

                if (map[c] == 1) t2 = t2.Replace(old, c);
            }

            return s == t2;
        }





        private static void RansomNote_383()
        {
            string ransomNote = "aa", magazine = "aab";
            Console.WriteLine(CanConstruct(ransomNote, magazine));
        }
        /*
         Given two strings ransomNote and magazine, return true if ransomNote can be constructed by using the letters from magazine and false otherwise.
        Each letter in magazine can only be used once in ransomNote.

        Example 1:
        Input: ransomNote = "a", magazine = "b"
        Output: false
        Example 2:
        Input: ransomNote = "aa", magazine = "ab"
        Output: false
        Example 3:
        Input: ransomNote = "aa", magazine = "aab"
        Output: true

        Constraints:
        1 <= ransomNote.length, magazine.length <= 105
        ransomNote and magazine consist of lowercase English letters.
         */
        static bool CanConstruct(string ransomNote, string magazine)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            foreach (char c in magazine)
            {
                if (map.ContainsKey(c))
                    map[c]++;
                else
                    map[c] = 1;
            }
            foreach (char c in ransomNote)
            {
                if (map.ContainsKey(c) && map[c] > 0)
                    map[c]--;
                else
                    return false;
            }
            return true;
        }
    }
}
