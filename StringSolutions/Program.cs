




using System;
using System.Collections;

namespace StringSolutions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LengthOfTheLastWord_58();
            //ExcelSheetColumnTitle_168();
            //ExcelSheetColumnNumber_171();
            //CellInRangeExcelSheet_2194();
            //LongestCommonPrefix_14();
            //Find1OccurrenceInString_28();
            //ValidPalindrome_125();
            //IsSubsequence_392();
            //NumberOfMatchingSubsequences_792();
            //CountVowelSubstringsOfAString_2062();//HashSet
            NumberOfSubstringWithOnly1s_1513();

        }




        private static void NumberOfSubstringWithOnly1s_1513()
        {
            string s = "0110111";
            Console.WriteLine(NumSub(s));
        }
        // Given a binary string s, return the number of substrings with all characters 1's. Since the answer may be too large, return it modulo 109 + 7.
        static public int NumSub(string s)
        {
            long result = 0;
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == '1')
                {
                    long counter = 0;
                    while (i < s.Length && s[i] == '1')
                    {
                        counter += 1;
                        i += 1;
                    }
                    result += counter * (counter + 1) / 2;
                    i -= 1;
                }
            }
            return (int)(result % 1_000_000_007);
        }
        static int NumSub02(string s)
        {
            int count = 0; int result = 0; int mod = 1_000_000_007;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '1')
                {
                    count++;
                    result = (result + count) % mod;
                }
                else
                {
                    count = 0;
                }
            }
            return result;
        }
        static int NumSub01(string s)
        {
            Dictionary<string,int> map = new Dictionary<string, int>();
            int step = 1;
            for (int i = 0; i < s.Length; i += step)
            {
                string currentOne = ""; 
                for (int j = i; j < s.Length && s[j] == '1'; j++)
                {
                    currentOne += s[j];
                }
                if (currentOne != "")
                {
                    if (map.ContainsKey(currentOne))
                        map[currentOne]++;
                    else
                        map.Add(currentOne, 1);
                    
                    step = currentOne.Length;
                }
                else
                {
                    step = 1;
                }
            }
            
            // 
            int number = 0; int result = 0; int mod = 1_000_000_007;
            // Each segment of length k contributes k×(k + 1) substrings
            foreach (var ones in map.Keys)
            {
                int k = ones.Length; //1
                number = k * (k + 1) / 2 * map[ones];
                result += number % mod;
            }
            return result;
        }

        static int NumSub00(string s)
        {
            int num = 0;
            for (int n = 1; n <= s.Length; n++)
            {
                string ones = new string('1', n);
                for (int i = 0; i < s.Length; i++)
                {
                    string currentOne = "";
                    for (int j = i; j < s.Length && s[j] == '1'; j++)
                    {
                        currentOne += s[j];
                        if (currentOne.Length == ones.Length) num++;
                    }
                }
            }

            return num % 1_000_000_007;
        }



        private static void CountVowelSubstringsOfAString_2062()
        {
            string word = "cuaieuouac";
            //string word = "aeiouu";
            Console.WriteLine(CountVowelSubstrings(word));
        }
        static int CountVowelSubstrings(string word)
        {
            int count = 0;
            HashSet<char> vowels = new HashSet<char> { 'a', 'i', 'u', 'e', 'o' };
            for (int i = 0; i < word.Length; i++)
            {
                if (vowels.Contains(word[i]))
                {
                    HashSet<char> currentVowels = new HashSet<char>();
                    for (int j = i; j < word.Length && vowels.Contains(word[j]); j++) // conditions
                    {
                        currentVowels.Add(word[j]);
                        if (currentVowels.Count == 5) count++; // All vowels found
                    }
                }
            }
            return count;
        }
        static int CountVowelSubstrings00(string word)
        {
            if (!CheckAllFive(word)) return 0;

            int count = 0;
            string vowel = "aeiou";
            int r = 0; int l = 0; 
            bool flag = false;
            while (r < word.Length)
            {
                char key = word[r];
                if (vowel.Contains(key))
                {
                    r++; flag = true;
                }
                else
                {
                    r++;
                    if (flag) l = r;
                    else l++;
                    flag = false;
                }
                if (r < word.Length && r - l + 1 >= 5)
                {
                    if (CheckAllFive(word.Substring(l, r-l+1)))
                    {
                        count++;
                    }
                }
            }
            
            return count;
        }
        static bool CheckAllFive(string s)
        {
            string vowel = "aeiou";
            for (int i = 0; i < vowel.Length; i++)
            {
                if (!s.Contains(vowel[i])) return false;
            }
            return true;
        }





        private static void NumberOfMatchingSubsequences_792()
        {
            string s = "qlhxagxdqh";
            string[] words = ["qlhxagxdq", "qlhxagxdq", "lhyiftwtut", "yfzwraahab"];
            //string s = "abcde";
            //string[] words = ["a", "bb", "acd", "ace"];
            Console.WriteLine(NumMatchingSubseq(s, words));
        }
        static int NumMatchingSubseq(string s, string[] words)
        {
            Dictionary<string,int> map = new Dictionary<string,int>();
            foreach (var w in words)
            {
                if (map.ContainsKey(w))
                    map[w]++;
                else map[w] = 1;
            }
            int count = 0;
            foreach (KeyValuePair<string,int> w in map) // same time with (string w in map.Keys)
            {
                if (IsSubsequence(w.Key, s)) count += w.Value;
            }
            return count;
        }




        private static void IsSubsequence_392()
        {
            string s = "abc", t = "dahbgdc";
            Console.WriteLine(IsSubsequence(s, t));
        }
        static bool IsSubsequence(string s, string t)
        {
            //if (t.Length < s.Length) return false;
            //else if (t.Length == 0 || s.Length == 0) return true;
            //else if (t.Length == s.Length) return t == s;

            int pt = 0; int ps = 0;
            while (pt < t.Length && ps < s.Length)
            {
                if (s[ps] == t[pt]) ps++;
                pt++;
            }
            return ps == s.Length;
        }



        private static void ValidPalindrome_125()
        {
            string s = "0P";
            //string s = "A man, a plan, a canal: Panama";
            Console.WriteLine(IsPalindrome(s));
        }
        static bool IsPalindrome(string s)
        {
            if (s.Length == 1) return true;

            //var ss = s.ToCharArray();
            string re = "";
            for (int i = 0; i < s.Length; i++)
            {
                if ( ('a' <= s[i] && s[i] <= 'z') || ('A' <= s[i] && s[i] <= 'Z') || ('0' <= s[i] && s[i] <= '9'))
                //if (char.IsLetter(ss[i]))
                {
                    //if (char.IsDigit(ss[i]))
                    re += char.ToLower(s[i]);
                }
            }

            return re == new string(re.Reverse().ToArray());
            //int r = 0; int l = re.Length - 1;
            //while (r < l)
            //{
            //    if (re[r++] != re[l--]) return false;
            //}

            //return true;
        }



        private static void Find1OccurrenceInString_28()
        {
            string haystack = "abc", needle = "c";
            //string haystack = "sadbutsad", needle = "sad";
            Console.WriteLine(StrStr(haystack, needle));
        }
        static int StrStr(string haystack, string needle)
        {
            int n = haystack.Length;
            int m = needle.Length;
            int p1 = 0;
            while (p1 <= n - m)
            {
                string buff = haystack.Substring(p1, m);
                if (buff == needle) return p1;
                p1++; 
            }
            return -1;
        }

        private static void LongestCommonPrefix_14()
        {
            string[] strs = ["flower", "flower", "flower", "flower"];
            //string[] strs = ["flower", "flow", "flight"];
            //string[] strs = ["dog", "racecar", "car"];
            Console.WriteLine(LongestCommonPrefix(strs));
        }
        static string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 1) return strs[0];

            string pre = strs[0]; bool flag = false;
            for (int j = 0; j < pre.Length; j++)
            {
                for (int i = 1; i < strs.Length; i++)
                {
                    if (j == strs[i].Length || pre[j] != strs[i][j])// w < pre OR <>
                    {
                        return pre.Substring(0, j);
                    }
                }
            }
            return pre;
        }
        static string LongestCommonPrefix00(string[] strs)//misunderstand
        {
            string wovels = "aiueo";
            Dictionary<string, int> prefix = new Dictionary<string, int>(); 
            for (int i = 0; i < strs.Length; i++)
            {
                for (int j = 0; j < strs[i].Length; j++)
                {
                    if (wovels.Contains(strs[i][j]))
                    {
                        string pre = strs[i].Substring(0, j);
                        if (pre != "")
                        {
                            if (prefix.ContainsKey(pre))
                                prefix[pre]++;
                            else
                                prefix[pre] = 1;
                            break;
                        }
                    }
                }
                
            }

            var list = prefix.ToList().FindAll(x => x.Value > 1);

            if (list.Count == 0) { return ""; }

            list.Sort( (a, b) =>  a.Key.Length - b.Key.Length );
            
            return list.First().Key;
        }

        private static void CellInRangeExcelSheet_2194()
        {
            string s = "K1:L2";
            Console.WriteLine(string.Join(", ", CellsInRange(s)));
        }
        static IList<string> CellsInRange(string s)
        {
            List<string> res = new List<string>();
            for (int c = s[0]; c <= s[3]; c++)
            {
                for (int r = s[1]; r <= s[4]; r++)
                {
                    string ss = "" + (char)c + (char)r;
                    res.Add(ss);
                }
            }
            return res;
        }



        private static void ExcelSheetColumnNumber_171()
        {
            //string title = "FXSHRXW";
            string title = "ZY";
            Console.WriteLine(TitleToNumber(title));
        }
        static int TitleToNumber(string columnTitle)
        {
            int result = 0;
            for (int i = 0; i < columnTitle.Length; i++)
            {
                int n = columnTitle[i] - 'A' + 1;
                result = result * 26 + n;
            }
            return result;
        }



        private static void ExcelSheetColumnTitle_168()
        {
            int n = 701; // ZY
            Console.WriteLine(ConvertToTitle(n));
        }
        static string ConvertToTitle(int columnNumber)
        {
            string result = string.Empty;
            while (columnNumber > 0)
            {
                columnNumber--;
                int remainder = columnNumber % 26;
                result = (char)('A' + remainder) + result;
                columnNumber /= 26;
            }
            return result;
        }



        private static void LengthOfTheLastWord_58()
        {
            string s = "   fly me   to   the moon  ";
            Console.WriteLine(LengthOfLastWord(s));
        }
        static int LengthOfLastWord(string s)
        {
            //var w = s.Split(' ');
            //for (int i = w.Length - 1; i >= 0; i--)
            //{
            //    if (w[i] != "") return w[i].Length;
            //}
            //return 0;
            //s = s.TrimEnd(); // 30% time; 55 >> 40
            int count = 0; bool flag = false;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] != ' ') {count++; flag = true;}
                else if (flag) break;
            }
            return count;
        }
    }
}
