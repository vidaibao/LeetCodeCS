
namespace HashMapping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*========== EASY ============*/
            //RansomNote_383();
            IsomorphicString_205();


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
