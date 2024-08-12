
namespace SlidingWindow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MinimumSizeSubarraySum_209();
            //MaximumLengthOfRepeatedSubarray_718();
            //LongestSubstringWithoutRepeatingCharacters_3();
            SubstringWithConcatenationAllWords_30();

        }

        private static void SubstringWithConcatenationAllWords_30()
        {
            //string s = "wordgoodgoodgoodbestword"; string[] words = ["word", "good", "best", "word"];//[]
            string s = "barfoothefoobarman"; string[] words = ["foo", "bar"];//[0,9]
            Console.WriteLine(string.Join(", ", FindSubstring(s, words)));
        }
        static IList<int> FindSubstring(string s, string[] words)
        {
            var result = new List<int>();
            if (s == null || s.Length == 0 || words == null || words.Length == 0)
                return result;

            int wordLength = words[0].Length;
            int wordCount = words.Length;
            int substringLength = wordLength * wordCount;

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
                int left = i, right = i;
                var currentMap = new Dictionary<string, int>();
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
