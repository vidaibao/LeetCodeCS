

namespace TwoPointers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MoveZeroes_283();
            ApplyOperationsArray_2460();


            //TrappingRainWater_42();

        }

        private static void ApplyOperationsArray_2460()
        {
            int[] nums = [1, 2, 2, 1, 1, 0];
            Console.WriteLine(string.Join(", ", ApplyOperations(nums)));
        }
        static int[] ApplyOperations(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] == nums[i+1])
                {
                    nums[i] *= 2;
                    nums[i+1] = 0;
                }
            }
            MoveZeroes(nums);
            return nums;
        }





        private static void MoveZeroes_283()
        {
            int[] nums = [0, 1, 0, 3, 12];
            Console.WriteLine(string.Join(", ",nums));
            Console.WriteLine("MoveZeroes(nums)");
            MoveZeroes(nums);
            Console.WriteLine(string.Join(", ",nums));
        }
        static void MoveZeroes(int[] nums)
        {
            if (nums.Length == 1) return;

            int nonZeroIndex = 0;//pointer 1
            for (int i = 0; i < nums.Length; i++)//pointer 2
            {
                if (nums[i] != 0)
                {
                    nums[nonZeroIndex++] = nums[i];
                }
            }
            for (int i = nonZeroIndex; i < nums.Length; i++)
            {
                nums[i] = 0;
            }
        }
        static void MoveZeroes01(int[] nums)
        {
            if (nums.Length == 1) return;

            int l = 0; int r = 0;
            while (l < nums.Length)
            {
                if (nums[l] == 0)
                {
                    r = l + 1;
                    while (r < nums.Length)
                    {
                        if (nums[r] != 0) { nums[l] = nums[r]; nums[r] = 0; break; }
                        r++;
                    }
                }
                l++;
            }
        }





        private static void TrappingRainWater_42()
        {
            int[] height = [0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1];
            Console.WriteLine(Trap_2Pointers(height));
        }
        private static int Trap_2Pointers(int[] height)//O(n)
        {
            if (height.Length == 1) return 0;

            int left = 0, right = height.Length - 1;
            int leftMax = 0, rightMax = 0;
            int waterTrapped = 0;
            // Two pointers
            while (left < right)
            {
                if (height[left] < height[right])
                {
                    if (height[left] >= leftMax)
                    {
                        leftMax = height[left];
                    }
                    else
                    {
                        waterTrapped += leftMax - height[left];
                    }
                    left++;
                }
                else
                {
                    if (height[right] >= rightMax)
                    {
                        rightMax = height[right];
                    }
                    else
                    {
                        waterTrapped += rightMax - height[right];
                    }
                    right--;
                }
            }

            return waterTrapped;
        }
    }
}
