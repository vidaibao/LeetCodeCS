
namespace SlidingWindow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MinimumSizeSubarraySum_209();

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
