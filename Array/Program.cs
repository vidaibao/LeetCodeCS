
using System.Collections.Generic;

namespace Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //RotateArray_189();
            //RemoveDuplicatesFromeSortedArray_26();
            RemoveDuplicatesFromSortedArray2_80();

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
    }
}
