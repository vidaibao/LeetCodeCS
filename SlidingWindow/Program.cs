
namespace SlidingWindow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MinimumSizeSubarraySum_209();
            //MaximumLengthOfRepeatedSubarray_718();
            //LongestSubstringWithoutRepeatingCharacters_3();
            //SubstringWithConcatenationAllWords_30();
            //MinimumWindowSubstring_76();
            SlidingWindowMaximum_239();

        }

        private static void SlidingWindowMaximum_239()
        {
            //int[] nums = [1]; int k = 1;
            int[] nums = [1, 3, -1, -3, 5, 3, 6, 7]; int k = 3;
            Console.WriteLine(string.Join(", ", MaxSlidingWindow(nums, k)));
        }
        static int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums.Length == 1 || k == 1) return nums;

            int n = nums.Length;
            int[] result = new int[n - k + 1];
            var deque = new LinkedList<int>();//retrieve INDEX numbers

            for (int i = 0; i < n; i++)
            {
                // remove indice outbounded k range
                if (deque.Count > 0 && deque.First.Value < i - k + 1) deque.RemoveFirst();
                //remove all element less than current element
                while (deque.Count > 0 && nums[deque.Last.Value] < nums[i]) deque.RemoveLast();

                deque.AddLast(i);

                if (i >= k - 1)
                    result[i - k + 1] = nums[deque.First.Value];
            }

            return result;
        }
        static int[] MaxSlidingWindow00(int[] nums, int k)// time limit exceeded; 47/51 passed
        {
            if (nums.Length == 1 || k == 1) return nums;

            var res = new List<int>();
            var queue = new Queue<int>();
            int i = 0;
            int n = nums.Length;
            int max = int.MinValue;
            while (i < n)
            {
                if (nums[i] > max)
                {
                    max = nums[i];
                    queue.Enqueue(nums[i]);
                }

                if (i >= k - 1)
                {
                    res.Add(max);
                    int leftNum = queue.Dequeue();
                    if (leftNum == max) { max = queue.Max(); }
                }
                i++;
            }

            return res.ToArray();
        }






        private static void MinimumWindowSubstring_76()
        {
            string s = "ADOBECODEBANC", t = "ABC";
            Console.WriteLine(MinWindow(s, t));
        }
        static string MinWindow(string s, string t)
        {
            int minLen = int.MaxValue;
            int minLeft = 0;
            int n = s.Length, m = t.Length;
            var tMap = new Dictionary<char, int>();
            foreach (char c in t)
            {
                if (!tMap.ContainsKey(c))
                    tMap[c] = 0;
                tMap[c]++;
            }

            int required = tMap.Count;
            int formed = 0;
            int left = 0, right = 0;
            var currentMap = new Dictionary<char, int>();
            while (right < n)
            {
                char c = s[right];
                if (!currentMap.ContainsKey(c))
                    currentMap[c] = 0;
                currentMap[c]++;

                if (tMap.ContainsKey(c) && tMap[c] == currentMap[c]) formed++;

                while (left <= right && formed == required)
                {
                    c = s[left];
                    if (right - left + 1 < minLen)
                    {
                        minLen = right - left + 1;
                        minLeft = left;
                    }
                    currentMap[c]--;//if this c in tMap and currentMap >>> required condition have to reduce
                    if (tMap.ContainsKey(c) && currentMap[c] < tMap[c]) formed--;
                    left++;
                }
                right++;
            }

            return minLen == int.MaxValue ? "" : s.Substring(minLeft, minLen);
        }
        static string MinWindow00(string s, string t)// Time limit excceed; 265/268 test cases passed
        {
            string res = string.Empty;
            int minRes = int.MaxValue;
            int m = s.Length, n = t.Length;
            var mapT = new Dictionary<char, int>();
            for (int i = 0; i < n; i++)
            {
                if (!mapT.ContainsKey(t[i]))
                    mapT[t[i]] = 0;
                mapT[t[i]]++;
            }

            int left = 0; 
            for (int right = n - 1; right < m; )// substring length at least >= n
            {
                string subStr = s.Substring(left, right - left + 1);
                int count = 0;
                var currentMap = new Dictionary<char, int>();

                for (int j = 0; j < subStr.Length; j++)
                {
                    if (mapT.ContainsKey(subStr[j]))
                    {
                        if (!currentMap.ContainsKey(subStr[j]))
                            currentMap[subStr[j]] = 0;
                        currentMap[subStr[j]]++;
                        //same key-value
                        if (mapT[subStr[j]] == currentMap[subStr[j]]) count++;
                    }
                }
                // window substring OK >> adjust left pointer
                if (mapT.Count == count)
                    //if (AreDictionariesEqual(mapT, currentMap))
                {
                    if (subStr.Length < minRes)
                    {
                        minRes = subStr.Length;
                        res = subStr;
                    }
                    left++;
                }
                else// not ok >>> extend right pointer
                {
                    right++;
                }
            }

            return res;
        }
        static bool AreDictionariesEqual(Dictionary<char, int> map1, Dictionary<char, int> map2)
        {
            // Kiểm tra số lượng phần tử
            if (map1.Count != map2.Count)
                return false;

            // Kiểm tra từng khóa và giá trị
            foreach (var kvp in map1)
            {
                char key = kvp.Key;
                int value = kvp.Value;

                // Kiểm tra xem khóa có tồn tại trong map2 không và giá trị có bằng nhau không
                if (!map2.ContainsKey(key) || map2[key] != value)
                    return false;
            }

            return true;
        }





        private static void SubstringWithConcatenationAllWords_30()
        {
            //string s = "wordgoodgoodgoodbestword"; string[] words = ["word", "good", "best", "word"];//[]
            string s = "barfoothefoobarman"; string[] words = ["foo", "bar"];//[0,9]
            Console.WriteLine(string.Join(", ", FindSubstring(s, words)));
        }
        /*
         You are given a string s and an array of strings words. All the strings of words are of the same length.
        A concatenated string is a string that exactly contains all the strings of any permutation of words concatenated.
        For example, if words = ["ab","cd","ef"], then "abcdef", "abefcd", "cdabef", "cdefab", "efabcd", and "efcdab" are all concatenated strings. "acdbef" is not a concatenated string because it is not the concatenation of any permutation of words.
        Return an array of the starting indices of all the concatenated substrings in s. You can return the answer in any order.

        Ý tưởng giải quyết:
        Để giải quyết bài toán này, ta có thể sử dụng kỹ thuật Sliding Window kết hợp với HashMap. Ý tưởng là dịch chuyển một cửa sổ qua chuỗi s, kiểm tra xem tại mỗi vị trí dịch chuyển liệu chuỗi con từ vị trí đó có phải là một sự liên kết của tất cả các từ trong danh sách words hay không.

        Cách tiếp cận:
        Chuẩn bị: Tính tổng chiều dài của tất cả các từ trong words và chiều dài của từng từ riêng lẻ. Sử dụng một HashMap để lưu số lần xuất hiện của mỗi từ trong words.

        Duyệt qua chuỗi: Sử dụng kỹ thuật Sliding Window để duyệt qua các chuỗi con của s với độ dài bằng tổng chiều dài của các từ. Tại mỗi vị trí dịch chuyển, chia chuỗi con thành các từ con và so sánh số lần xuất hiện của từng từ với HashMap.

        Kết quả: Nếu tất cả các từ trong chuỗi con xuất hiện đúng số lần như trong words, thì vị trí bắt đầu của chuỗi con này là một kết quả hợp lệ. >>> No need permutations of words

        Độ phức tạp:
        Thời gian: O(n * m * l), với n là độ dài của chuỗi s, m là số lượng từ trong words, và l là độ dài của mỗi từ. Đây là độ phức tạp của vòng lặp dịch chuyển cửa sổ và so sánh từng từ trong cửa sổ với từ điển wordMap.
        Không gian: O(m * l) để lưu trữ wordMap và currentMap.
         */
        static IList<int> FindSubstring(string s, string[] words)
        {
            var result = new List<int>();
            if (s == null || s.Length == 0 || words == null || words.Length == 0)
                return result;

            int wordLength = words[0].Length;
            int wordCount = words.Length;

            // Create a map of the words and their frequencies
            var wordMap = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (!wordMap.ContainsKey(word))
                    wordMap[word] = 0;
                wordMap[word]++;
            }

            // Sliding window on each possible starting index within the word length
            for (int i = 0; i < wordLength; i++)
            {
                int left = i, right = i;//control sliding window
                var currentMap = new Dictionary<string, int>();//number of occurencies of word in current window
                int count = 0;

                while (right + wordLength <= s.Length)
                {
                    string word = s.Substring(right, wordLength);
                    right += wordLength;

                    if (wordMap.ContainsKey(word))
                    {
                        if (!currentMap.ContainsKey(word))
                            currentMap[word] = 0;
                        currentMap[word]++;

                        if (currentMap[word] <= wordMap[word])
                            count++;
                        else
                        {
                            while (currentMap[word] > wordMap[word])
                            {
                                string leftWord = s.Substring(left, wordLength);
                                left += wordLength;
                                currentMap[leftWord]--;
                                if (currentMap[leftWord] < wordMap[leftWord])
                                    count--;
                            }
                        }
                        //chuỗi con hiện tại là một sự kết hợp hợp lệ của tất cả các từ trong words, ta thêm left vào danh sách kết quả.
                        if (count == wordCount)
                            result.Add(left);
                    }
                    else
                    {
                        currentMap.Clear();
                        count = 0;
                        left = right;
                    }
                }
            }
            return result;
        }

        static List<List<string>> GetPermutations(string[] words)
        {
            var result = new List<List<string>>();
            Permute(words, 0, result);
            return result;
        }

        private static void Permute(string[] words, int start, List<List<string>> result)
        {
            if (start == words.Length)
            {
                result.Add(new List<string>(words));
            }
            else
            {
                for (int i = start; i < words.Length; i++)
                {
                    //Swap(ref words[start], ref words[i]);
                    (words[start], words[i]) = (words[i], words[start]);
                    Permute(words, start + 1, result);
                    //Swap(ref words[start], ref words[i]); // Backtrack
                    (words[start], words[i]) = (words[i], words[start]);
                }
            }
        }





        private static void LongestSubstringWithoutRepeatingCharacters_3()
        {
            string s = "abcabcbb";
            Console.WriteLine(LengthOfLongestSubstring(s));
        }
        static int LengthOfLongestSubstring(string s)
        {
            //if (s.Length <= 1) return s.Length;
            int n = s.Length;
            int maxLen = 0;
            int left = 0;
            var set = new HashSet<int>();

            for (int right = 0; right < n; right++)
            {
                while (set.Contains(s[right]))
                {
                    set.Remove(s[left]); left++;
                }
                set.Add(s[right]);
                maxLen = Math.Max(maxLen, right - left + 1);
            }

            return maxLen;
        }
        static int LengthOfLongestSubstring00(string s)
        {
            if (s.Length <= 1) return s.Length;

            Func<string, bool> IsDuplicate = (str) =>
            {
                HashSet<char> set = new HashSet<char>();

                for (int j = 0; j < str.Length; j++)
                {
                    if (!set.Add(str[j]))  return true; 
                }
                return false;
            };

            int maxLen = 0;
            int left = 0;
            for (int i = 1; i <= s.Length; i++)
            {
                int len = i;
                if (left + len > s.Length) break;
                string temp = s.Substring(left, len);
                
                while (IsDuplicate(temp) && left + len < s.Length)
                {
                    left++;
                    temp = s.Substring(left, len);
                }
                if (left + len <= s.Length) maxLen = Math.Max(maxLen, len);

            }


            return maxLen;
        }





        private static void MaximumLengthOfRepeatedSubarray_718()
        {
            int[] nums1 = [1, 2, 3, 2, 1], nums2 = [3, 2, 1, 4, 7];
            Console.WriteLine(FindLength(nums1, nums2));
        }
        static int FindLength(int[] nums1, int[] nums2)
        {
            int n = nums1.Length;
            int m = nums2.Length;
            int maxLength = 0;

            // Trượt nums1 qua nums2
            for (int i = 0; i < n; i++)
            {
                int len = Math.Min(m, n - i);
                int maxLenForWindow = MaxLength(nums1, nums2, i, 0, len);
                maxLength = Math.Max(maxLength, maxLenForWindow);
            }

            // Trượt nums2 qua nums1
            for (int j = 0; j < m; j++)
            {
                int len = Math.Min(n, m - j);
                int maxLenForWindow = MaxLength(nums1, nums2, 0, j, len);
                maxLength = Math.Max(maxLength, maxLenForWindow);
            }

            return maxLength;
        }
        private static int MaxLength(int[] nums1, int[] nums2, int i, int j, int len)
        {
            int maxLen = 0;
            int currentLen = 0;
            for (int k = 0; k < len; k++)
            {
                if (nums1[i + k] == nums2[j + k])
                {
                    currentLen++;
                    maxLen = Math.Max(maxLen, currentLen);
                }
                else
                {
                    currentLen = 0;
                }
            }
            return maxLen;
        }




        private static void MinimumSizeSubarraySum_209()
        {
            //int target = 15; int[] nums = [1, 2, 3, 4, 5 ];//5
            //int target = 11; int[] nums = [1, 2, 3, 4, 5 ];//3
            //int target = 7; int[] nums = [1, 1, 1, 1, 1, 1];
            int target = 7; int[] nums = [2, 3, 1, 2, 4, 3];
            Console.WriteLine(MinSubArrayLen(target, nums));
        }
        static int MinSubArrayLen(int target, int[] nums)
        {
            int windowSum = 0;
            int minLen = int.MaxValue;
            int left = 0;

            for (int right = 0; right < nums.Length; right++)
            {
                windowSum += nums[right];

                while (windowSum >= target)
                {
                    if (right - left + 1 < minLen) minLen = right - left + 1;
                    windowSum -= nums[left];
                    left++;
                }
            }

            return minLen == int.MaxValue ? 0 : minLen;
        }
        static int MinSubArrayLen000(int target, int[] nums)
        {
            //prefix Sum
            int[] preSum = new int[nums.Length];
            preSum[0] = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                preSum[i] = preSum[i-1] + nums[i];
            }

            int winSum = 0;
            int winSize = 1;
            while (winSize <= nums.Length)
            {
                // solve first window sum
                winSum = preSum[winSize - 1];

                if (winSum >= target) { return winSize; }
                // move window
                for (int i = winSize; i < nums.Length; i++)
                {
                    winSum = (preSum[i] - preSum[i - winSize]);
                    if (winSum >= target) { return winSize; }
                }
                winSize++; winSum = 0;
            }
            return 0;
        }
        static int MinSubArrayLen00(int target, int[] nums)// time
        {
            int winSum = 0;
            int winSize = 1;
            while (winSize <= nums.Length)
            {
                for (int i = 0; i < winSize; i++)
                {
                    winSum += nums[i];
                }
                if (winSum >= target) { return winSize; }
                // move window
                for (int i = winSize; i < nums.Length; i++)
                {
                    //if (winSum - nums[i - 1] + nums[i + winSize] >= target) return winSize; 
                    winSum += nums[i] - nums[i - winSize];
                    if (winSum >= target) {return winSize; }
                }
                winSize++; winSum = 0;
            }
            return 0;
        }

    }
}
