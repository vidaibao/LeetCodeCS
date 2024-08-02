namespace HashMapping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*========== EASY ============*/
            RansomNote_383();



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
