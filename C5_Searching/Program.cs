

using System.Collections;
using System.Diagnostics;

namespace C5_Searching
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BinarySearching_01();
            // Find the missing number in an array
            //FindMissingNumberInArray();
            //FindPairInArray();
            //StockPurchaseSell();
            //Sum3InArray();


        }

        private static void Sum3InArray()
        {
            int[] ints = [10, 7, 12, 5, -6, 1, 4, 6, 9]; int value = 13;
            FindSum3(ints, value);
        }
        /*In given list of n elements, write an algorithm to find three elements in an array whose sum is a given value.
          Hint: Try to do this problem using a brute force approach. Then try to apply the sorting approach along with a brute force approach. Time Complexity is O(n2)
        */
        private static void FindSum3(int[] arr, int value)
        {
            Array.Sort(arr);
            int size = arr.Length;
            for (int i = 0; i < size; i++)
            {
                int val = value - arr[i];
                int l = i + 1; int r = size - 1;
                while (l < r)
                {
                    int sum = arr[l] + arr[r];
                    if (sum == val)
                    {
                        Console.WriteLine($"{arr[i]} + {arr[l]} + {arr[r]} = {value}");
                        return;
                    }
                    else if (sum > val)
                    {
                        r--;
                    }
                    else if (sum < val)
                    {
                        l++;
                    }
                }
            }
            Console.WriteLine("Found nothing!");
        }

        private static void StockPurchaseSell()
        {
            int[] stocks = [ 10, 7, 12, 5, 6, 1, 4, 6, 9 ];
            Console.WriteLine($"Max profit is {MaxProfit(stocks)}");
        }

        /*
         * Keep track of the smallest value seen so far from the start. At each point, we can find the difference
        and keep track of the maximum profit. This is a linear solution.
        Time Complexity is O(n) time. Space Complexity for creating count list is also O(1)*/
        private static int MaxProfit(int[] stocks)
        {
            int size = stocks.Length;
            int buy = 0, sell = 0;
            int curMin = 0;
            int currProfit;
            int maxProfit = 0;
            for (int i = 0; i < size; i++)
            {
                if (stocks[i] < stocks[curMin]) curMin = i;
                currProfit = stocks[i] - stocks[curMin];
                if (currProfit > maxProfit)
                {
                    buy = curMin;
                    sell = i;
                    maxProfit = currProfit;
                }
            }

            Console.WriteLine("Purchase day is- " + buy + " at price " + stocks[buy]);
            Console.WriteLine("Sell day is- " + sell + " at price " + stocks[sell]);
            return maxProfit;
        }

        

        private static void FindPairInArray()
        {
            int[] arr = { 22, 10, 5, 17, 6, 2, 3, 4, 7, 1, 9 };
        }


        private static void FindMissingNumberInArray()
        {
            int[] arr = { 10, 5, 6, 2, 3, 4, 7, 1, 9 }; // 1 - n   // n = 10; arr.Length = 9
            Console.WriteLine($"arr = [{string.Join(", ", arr)}];");
            //FindMissing01(arr);
            //FindMissing02_Hashset(arr);
            //FindMissing03_Counting(arr);
            FindMissing04_InPlace(arr);

        }


        /*
         Find the missing number in an array
        Problem: In given list of n-1 elements, which are in the range of 1 to n.
        There are no duplicates in the array. One of the integer is missing. Find the missing element.
         */
        private static void FindMissing04_InPlace(int[] arr)
        {
            int n = arr.Length;
            int i = 0;
            // Cyclic sort: Place each number at its correct index
            while (i < n)
            {
                // The number at index i should be at index array[i] - 2
                int correctIndex = arr[i] - 1;
                // Swap the number to its correct position if it's within bounds and not already in place
                if (0 <= correctIndex && correctIndex < n && arr[i] != arr[correctIndex])
                {
                    // Swap
                    (arr[correctIndex], arr[i]) = (arr[i], arr[correctIndex]);
                }
                else i++;
            }

        }

        private static void FindMissing03_Counting(int[] arr)
        {
            int max = int.MinValue;
            int min = int.MaxValue;
            foreach (int i in arr) 
            {
                if (i > max) max = i;
                if (i < min) min = i;
            }
            int range = max + 1;
            var ints = new bool[range];
            foreach (int i in arr)
            {
                ints[i] = true;
            }
            for (int i = min; i <= max; i++) // b/c constrain 1 - max
            {
                if (!ints[i])
                {
                    Console.WriteLine(i); return;
                }
            }
            Console.WriteLine("Missing number is not found!");
        }

        private static void FindMissing02_Hashset(int[] arr)
        {
            var ht = new Hashtable();
            foreach (int i in arr) 
            {
                ht.Add(i, true);
            }
            for (int i = 1; i <= arr.Length; i++)
            {
                if (!ht.ContainsKey(i))
                {
                    Console.WriteLine(i); return;
                }
            }
            Console.WriteLine("Missing number is not found!");
        }

        private static void FindMissing01(int[] arr)
        {
            Array.Sort(arr);
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i-1] + 1 != arr[i])
                {
                    Console.WriteLine(i+1); return;
                }
            }
            Console.WriteLine("Missing number is not found!");
        }

        private static void BinarySearching_01()
        {
            int[] ints = { 12, 23, 3, 1, 5, 15, 2, 4 }; int value = 12;
            Console.WriteLine($"ints = [{string.Join(", ", ints)}]; value = {value}");
            Console.WriteLine("BinarySearch(Array.Sort(ints), value)");
            Array.Sort(ints);
            Console.WriteLine(BinarySearchRec(ints, value));
            //Console.WriteLine(BinarySearch(ints, value)); ;
            //Console.WriteLine(string.Join(", ", ints));
        }

        private static bool BinarySearchRec(int[] ints, int value)
        {
            return BinarySearchRecUtil(ints, value, 0, ints.Length - 1);
        }

        private static bool BinarySearchRecUtil(int[] arr, int value, int low, int high)
        {
            if (low > high) return false;

            int mid = (low + high) / 2;
            if (arr[mid] == value)
            {
                return true;
            }
            else if (arr[mid] < value)
            {
                return BinarySearchRecUtil(arr, value, mid + 1, high);
            }
            else
            {
                return BinarySearchRecUtil(arr, value, low, mid - 1);
            }
        }

        private static bool BinarySearch(int[] arr, int val)
        {
            int low = 0, high = arr.Length - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (arr[mid] == val)
                {
                    return true;
                }
                else if (arr[mid] < val)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return false;
        }
    }
}
