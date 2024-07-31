




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
            ValidPalindrome_125();

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
