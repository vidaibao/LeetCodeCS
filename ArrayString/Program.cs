﻿namespace ArrayString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*========== EASY ============*/
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
            //NumberOfSubstringWithOnly1s_1513();
            //RotateArray_189();

            //RemoveDuplicatesFromeSortedArray_26();
            //RemoveDuplicatesFromSortedArray2_80();
            //MatrixCellsInDistanceOrder_1030();

            /*========== MEDIUM ============*/
            //Integer2Roman_12();
            //JumpGame_55();
            JumpGame2_45();


            /*=========== HARD =============*/
            //IntegerToEnglishWords_273();
        }






        private static void JumpGame2_45()
        {
            int[] nums = [2, 3, 1, 1, 4];
            Console.WriteLine(Jump2(nums));
        }
        /*
         You are given a 0-indexed array of integers nums of length n. You are initially positioned at nums[0].
        Each element nums[i] represents the maximum length of a forward jump from index i. In other words, if you are at nums[i], you can jump to any nums[i + j] where:

        0 <= j <= nums[i] and
        i + j < n
        Return the minimum number of jumps to reach nums[n - 1]. The test cases are generated such that you can reach nums[n - 1].

        Example 1:
        Input: nums = [2,3,1,1,4]
        Output: 2
        Explanation: The minimum number of jumps to reach the last index is 2. Jump 1 step from index 0 to 1, then 3 steps to the last index.
        Example 2:
        Input: nums = [2,3,0,1,4]
        Output: 2

        Constraints:
        1 <= nums.length <= 104
        0 <= nums[i] <= 1000
        It's guaranteed that you can reach nums[n - 1].
         */
        static int Jump2(int[] nums)
        {
            if (nums.Length <= 1) return 0;

            int jumps = 0;
            int currentEnd = 0;
            int farthest = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                farthest = Math.Max(farthest, i + nums[i]);
                if (i == currentEnd) //reach the end of the current jump
                {
                    jumps++;
                    currentEnd = farthest;

                    if (currentEnd >= nums.Length - 1) break;//beyond or at the last index
                }
            }
            return jumps;
        }
        static int Jump200(int[] nums)
        {
            if (nums.Length <= 1) return 0;

            int[] dp = new int[nums.Length];
            dp[0] = 1; // minimum number of jumps to reach nums[0]
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 1; j <= nums[i]; j++)
                {
                    dp[i + j] = Math.Min(dp[i] + 1, dp[i + j]);
                }
            }

            return 0;
        }





        private static void JumpGame_55()
        {
            int[] nums = [3, 2, 1, 0, 4];
            //int[] nums = [2, 3, 1, 1, 4];
            Console.WriteLine(CanJump(nums));
        }
        /*
         You are given an integer array nums. You are initially positioned at the array's first index, and each element in the array represents your maximum jump length at that position.
        Return true if you can reach the last index, or false otherwise.

        Example 1:
        Input: nums = [2,3,1,1,4]
        Output: true
        Explanation: Jump 1 step from index 0 to 1, then 3 steps to the last index.
        Example 2:
        Input: nums = [3,2,1,0,4]
        Output: false
        Explanation: You will always arrive at index 3 no matter what. Its maximum jump length is 0, which makes it impossible to reach the last index.

        Constraints:
        1 <= nums.length <= 104
        0 <= nums[i] <= 105
         */
        static bool CanJump(int[] nums)
        {
            if (nums.Length == 1) return true;
            bool[] dp = new bool[nums.Length + 1];
            dp[0] = true;
            int step = 0;
            for (int i = 0; i < nums.Length && dp[i]; i++)
            {
                step = nums[i];//maximum jump length
                for (int j = 1; j <= step; j++)
                {
                    if (i + j > nums.Length) return true;//reach the last index
                    dp[i + j] = true;
                }
            }

            return dp[nums.Length - 1];
        }



        private static void MatrixCellsInDistanceOrder_1030()
        {
            int rows = 2, cols = 2, rCenter = 0, cCenter = 1;
            var re = AllCellsDistOrder(rows, cols, rCenter, cCenter);
            foreach (var cell in re)
            {
                Console.WriteLine(string.Join(", ", cell));
            }
        }
        static int[][] AllCellsDistOrder(int rows, int cols, int rCenter, int cCenter)
        {
            List<int[]> result = new List<int[]>();
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    result.Add(new int[] { r, c });
                }
            }
            //result.OrderBy( x => Math.Abs(x[0] - rCenter) + Math.Abs(x[1] - cCenter));
            result.Sort((a, b) =>
                                Math.Abs(a[0] - rCenter) + Math.Abs(a[1] - cCenter) -
                                (Math.Abs(b[0] - rCenter) + Math.Abs(b[1] - cCenter))
                        );
            return result.ToArray();
        }



        private static void RemoveDuplicatesFromSortedArray2_80()
        {
            //int[] nums = { 1, 1, 1 }; // 2, nums = [1,1,_]
            int[] nums = { 1, 1, 1, 1, 2, 2, 3 }; // 5, nums = [1,1,2,2,3,_]
            //int[] nums = { 0, 0, 1, 1, 1, 1, 2, 3, 3 }; // 7, nums = [0,0,1,1,2,3,3,_,_]
            Console.WriteLine(RemoveDuplicates2(nums));
            Console.WriteLine(String.Join(", ", nums));
        }

        private static int RemoveDuplicates2(int[] nums)
        {
            const int TWICE = 2;
            // because any duplicates will naturally appear at most twice
            if (nums.Length <= TWICE) return nums.Length;

            // the first two elements can remain as they are.
            int j = TWICE;  // Pointer for the position to place the next valid element

            for (int i = TWICE; i < nums.Length; i++)
            {
                // If it is different, it means the current element can be added without exceeding the allowed duplicates
                if (nums[i] != nums[j - TWICE])
                {
                    nums[j] = nums[i];
                    j++;
                }
            }
            return j;
        }

        static public int RemoveDuplicates2_00(int[] nums)
        {
            const int TWICE = 2; int count = 0;
            int l = 0; int r = 0;
            while (r < nums.Length)
            {
                if (nums[r] == nums[l])
                {
                    r++; count++;
                }
                else if (nums[r] > nums[l])
                {
                    l += Math.Min(count, TWICE);
                    nums[l] = nums[r++];
                    count = 1;
                }
                if (r == nums.Length && count > 1)
                {
                    nums[l + 1] = nums[l];
                }
            }
            return l + Math.Min(count, TWICE);
        }



        private static void RemoveDuplicatesFromeSortedArray_26()
        {
            int[] nums = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            Console.WriteLine(RemoveDuplicates(nums));
            Console.WriteLine(String.Join(", ", nums));
        }
        static int RemoveDuplicates(int[] nums)
        {
            int l = 0; int r = 0;
            while (r < nums.Length)
            {
                if (nums[r] == nums[l]) r++;
                else if (nums[r] > nums[l])
                {
                    nums[++l] = nums[r++];
                }
            }
            return l + 1;
        }



        private static void RotateArray_189()
        {
            //int[] nums = { 1, 2, 3, 4, 5, 6, 7 }; int k = 3;
            int[] nums = { -1, -100, 3, 99 }; int k = 2;
            Rotate(nums, k);
            Console.WriteLine(String.Join(", ", nums));
        }

        private static void Rotate(int[] nums, int k)
        {
            int n = nums.Length;
            k = k % n;
            if (k == 0) return;

            // Reverse the entire array
            Reverse(nums, 0, n - 1);
            // Reverse the first k elements
            Reverse(nums, 0, k - 1);
            // Reverse the remaining elements
            Reverse(nums, k, n - 1);
        }
        private static void Reverse(int[] nums, int start, int end)
        {
            while (start < end)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }
        }

        static void Rotate00(int[] nums, int k)
        {
            int n = nums.Length;
            k = k % n;
            if (k == 0) return;

            int start = 0;
            int prev = 0;
            int temp = 0;
            int next = 0;
            while (start < n)
            {
                int current = start;
                prev = nums[current];
                do
                {
                    next = (current + k) % n;
                    temp = nums[next];
                    nums[next] = prev;
                    prev = temp;
                    current = next;
                } while (current != start);
                start++;
            }

        }


        private static void IntegerToEnglishWords_273()
        {
            int num = 2_147_483_647;//int.MaxValue // 1234567;
            Console.WriteLine(NumberToWords(num));
        }
        static string NumberToWords(int num)
        {
            if (num == 0) return "Zero";

            return ConvertWords(num);
        }

        private static string ConvertWords(int num)
        {
            if (num < 10) return one_to_nine[num];
            else if (num < 20) return two_less_twenty[num];
            else if (num < 100)
            {
                int t = (num / 10) * 10;
                return tens[t] + (num % 10 > 0 ? " " + ConvertWords(num % 10) : "");
            }
            else if (num < 1000)
            {
                return one_to_nine[num / 100] + " Hundred" + (num % 100 > 0 ? " " + ConvertWords(num % 100) : "");
            }
            else if (num < 1_000_000)
            {
                return ConvertWords(num / 1000) + " Thousand" + (num % 1000 > 0 ? " " + ConvertWords(num % 1000) : "");
            }
            else if (num < 1_000_000_000)
            {
                return ConvertWords(num / 1_000_000) + " Million" + (num % 1_000_000 > 0 ? " " + ConvertWords(num % 1_000_000) : "");
            }
            return ConvertWords(num / 1_000_000_000) + " Billion" + (num % 1_000_000_000 > 0 ? " " + ConvertWords(num % 1_000_000_000) : "");
        }
        private static readonly Dictionary<int, string> one_to_nine = new Dictionary<int, string>
        {
            {1, "One"}, {2, "Two"}, {3, "Three"}, {4, "Four"}, {5, "Five"},
            {6, "Six"}, {7, "Seven"}, {8, "Eight"}, {9, "Nine"}
        };

        private static readonly Dictionary<int, string> two_less_twenty = new Dictionary<int, string>
        {
            {10, "Ten"}, {11, "Eleven"}, {12, "Twelve"}, {13, "Thirteen"}, {14, "Fourteen"},
            {15, "Fifteen"}, {16, "Sixteen"}, {17, "Seventeen"}, {18, "Eighteen"}, {19, "Nineteen"}
        };

        private static readonly Dictionary<int, string> tens = new Dictionary<int, string>
        {
            {20, "Twenty"}, {30, "Thirty"}, {40, "Forty"}, {50, "Fifty"}, {60, "Sixty"},
            {70, "Seventy"}, {80, "Eighty"}, {90, "Ninety"}
        };
        static string NumberToWords01(int num)
        {
            if (num == 0) return "Zero";
            // Split billion million thousand hundred twenty ten
            // Split three two one numbers prefix
            //
            int billion = num / 1_000_000_000;
            int million = (num - billion * 1_000_000_000) / 1_000_000;
            int thousand = (num - billion * 1_000_000_000 - million * 1_000_000) / 1_000;
            int remainder = num - billion * 1_000_000_000 - million * 1_000_000 - thousand * 1_000;

            string result = "";
            if (billion > 0)
            {
                result += Three(billion) + " Billion";
            }
            if (million > 0)
            {
                result += (result != "" ? " " : "") + Three(million) + " Million";
            }
            if (thousand > 0)
            {
                result += (result != "" ? " " : "") + Three(thousand) + " Thousand";
            }
            if (remainder > 0)
            {
                result += (result != "" ? " " : "") + Three(remainder);
            }

            return result;
        }
        static string Three(int num)
        {
            string re = "";
            int hundred = num / 100;
            int rest = num - hundred * 100;
            if (hundred > 0 && rest > 0)
            {
                re += one_to_nine[hundred] + " Hundred " + Two(rest);
            }
            else if (hundred <= 0 && rest > 0)
            {
                re += Two(rest);
            }
            else if (hundred > 0 && rest <= 0)
            {
                re += one_to_nine[hundred] + " Hundred";
            }

            return re;
        }
        static string Two(int num)
        {
            if (num == 0) return "";
            else if (num < 10) return one_to_nine[num];
            else if (num < 20) return two_less_twenty[num];
            else if (num < 100)
            {
                int two = (num / 10) * 10;
                int rest = num % 10;
                return tens[two] + (rest > 0 ? " " : "") + one_to_nine[rest];
            }
            return "";
        }






        private static void Integer2Roman_12()
        {
            int num = 1994; // 1 <= num <= 3999
            Console.WriteLine(IntToRoman(num));
        }
        static string IntToRoman(int num)
        {
            string romanNum = "";
            int[] ints = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };//******************************
            string[] romans = new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            for (int i = 0; i < ints.Length && num > 0; i++)
            {
                int k = num / ints[i];
                for (int j = 0; j < k; j++)
                {
                    num -= ints[i]; //*****************
                    romanNum += romans[i];
                }
            }

            return romanNum;
        }
        static string IntToRoman00(int num)
        {
            List<KeyValuePair<int, char>> roman = new();
            roman.Add(new KeyValuePair<int, char>(1000, 'M'));
            roman.Add(new KeyValuePair<int, char>(500, 'D'));
            roman.Add(new KeyValuePair<int, char>(100, 'C'));
            roman.Add(new KeyValuePair<int, char>(50, 'L'));
            roman.Add(new KeyValuePair<int, char>(10, 'X'));
            roman.Add(new KeyValuePair<int, char>(5, 'V'));
            roman.Add(new KeyValuePair<int, char>(1, 'I'));

            string result = "";
            foreach (var r in roman)
            {
                int digit = num / r.Key;
                if (digit > 0)
                {
                    if (r.Value == 'M')
                    {
                        result += new string(r.Value, digit);
                    }
                    else
                    {
                        if (digit <= 3)
                        {
                            result += new string(r.Value, digit);
                        }
                        else if (digit == 4)
                        {
                            result += "IV";
                        }
                        else if (digit == 5)
                        {
                            result += "V";
                        }
                        else if (digit == 6)
                        {
                            result += "VI";
                        }
                        else if (digit == 7)
                        {
                            result += "VII";
                        }
                        else if (digit == 8)
                        {
                            result += "VIII";
                        }
                        else if (digit == 9)
                        {
                            result += "IX";
                        }
                    }


                }
            }
            return "";
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
            Dictionary<string, int> map = new Dictionary<string, int>();
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
                    if (CheckAllFive(word.Substring(l, r - l + 1)))
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
            Dictionary<string, int> map = new Dictionary<string, int>();
            foreach (var w in words)
            {
                if (map.ContainsKey(w))
                    map[w]++;
                else map[w] = 1;
            }
            int count = 0;
            foreach (KeyValuePair<string, int> w in map) // same time with (string w in map.Keys)
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
                if (('a' <= s[i] && s[i] <= 'z') || ('A' <= s[i] && s[i] <= 'Z') || ('0' <= s[i] && s[i] <= '9'))
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

            list.Sort((a, b) => a.Key.Length - b.Key.Length);

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
                if (s[i] != ' ') { count++; flag = true; }
                else if (flag) break;
            }
            return count;
        }
    }
}
