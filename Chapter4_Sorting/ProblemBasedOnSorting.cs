using CommonUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4_Sorting
{
    internal class ProblemBasedOnSorting
    {
        /* Partition 0 and 1
         Problem: Given an array containing 0s and 1s. Write an algorithms to sort array so that 0s come first followed by 1s. Also find the minimum number of swaps required to sort the array. 
        
        First solution: Start from both end, left will store start index and right will store end index. Traverse left forward till we have 0s value in the array. Then traverse right backward till we have 1s in the end. Then swap the two and follow the same process till left is less than right.
         */
        public static int Partition01(int[] arr)
        {
            int size = arr.Length;
            int left = 0, right = size - 1;
            int swap = 0;

            while (left < right)
            {
                while (arr[left] == 0) left++;
                while (arr[right] == 1) right--;
                if (left < right) {
                    (arr[left], arr[right]) = (arr[right], arr[left]); 
                    swap++; 
                }
            }
            return swap;
        }




        /*
         Partition 0, 1 and 2
        Problem: Given an array containing 0s, 1s and 2s. Write an algorithms to sort array so that 0s come first followed by 1s and then 2s in the end.
        First solution: You can use a counter for 0s, 1s and 2s. Then replace the values in the array. This will take two pass. What if we want to do this in single pass?
        */
        public static void Partition012(int[] arr) // two pass
        {
            int size = arr.Length;
            int[] count = new int[3];
            for (int i = 0; i < size; i++)
            {
                count[arr[i]]++;
            }
            int j = 0;
            for (int i = 0; i < 3; i++)
            {
                for (; count[i] > 0 ; count[i]--)
                {
                    arr[j++] = i;
                }
            }
        }



        /*
        Second solution: The basic approach is to use three index. First left, second right and third to traverse the array. Index left starts form 0, Index right starts from N-1. We traverse the array whenever we find a 0 we swap it with the value at start and increment start. And whenever we finds a 2 we swaps this value with right and decrement right. When traversal is complete and we reach the right then the array is sorted.
         */
        public static void Partition012a(int[] arr) // single pass O(n)
        {
            int i = 0, left = 0, right = arr.Length - 1;

            while (i <= right)
            {
                if (arr[i] == 0)
                {
                    (arr[i], arr[left]) = (arr[left++], arr[i++]);
                }
                else if (arr[i] == 2)
                {
                    (arr[i], arr[right]) = (arr[right--], arr[i]); // i
                }
                else i++;
            }
        }




        /*
         Range Partition
        Problem: Given an array of integer and a range. Write an algorithms to partition array so that values smaller than range come to left, then values under the range followed with values greater than the range.
        First solution: The basic approach is to use three index. First left, second right and third to traverse the array. Index left starts from 0, Index right starts from N-1. We traverse the array whenever we find a value lower than
        range we swap it with the value at start and increment start. And whenever we finds a value greater than range we swaps this value with right and decrement right. When traversal is complete we have the array partitioned about range.
         */
        public static void RangePartition(int[] arr, int lower, int higher) // ???
        {
            int size = arr.Length;
            int i = 0, l = 0, r = size - 1;
            while (i <= r)
            {
                if (arr[i] < lower)
                {
                    (arr[i], arr[l]) = (arr[l++], arr[i++]);
                }
                else if (arr[i] > higher)
                {
                    (arr[i], arr[r]) = (arr[r--], arr[i]);
                }
                else i++;
            }
        }


        /*
         Minimum swaps
        Problem: Minimum swaps required to bring all elements less than given value together at the start of array.
        First solution: Use quick sort kind of technique by taking two index one from start and another from end and try to use the given value as key. Count the number of swaps that is answer.
         */
        internal static int MinimumSwaps(int[] arr, int val)
        {
            int size = arr.Length;
            int start = 0, end = size - 1;
            int swapCount = 0;

            while (start < end)
            {
                if (arr[start] <= val) start++; // stop at larger than val index
                else if (arr[end] > val) end--; // stop at smaller or equals val index
                else
                {
                    (arr[start], arr[end]) = (arr[end], arr[start]); swapCount++; 
                }
            }

            return swapCount;
        }




        /*
         Separate even and odd numbers in List
        Problem: Given an array of even and odd numbers, write a program to separate even numbers from the odd numbers.
        First solution: allocate a separate list, then scan through the given list, and fill even numbers from the start and odd numbers from the end.
        Second solution: Algorithm is as follows.
        1. Initialize the two variable left and right. Variable left=0 and right= size-1.
        2. Keep increasing the left index until the element at that index is even.
        3. Keep decreasing the right index until the element at that index is odd.
        4. Swap the number at left and right index.
        5. Repeat steps 2 to 4 until left is less than right.
         */
        public static void SeperateEvenAndOdd(int[] data)
        {
            int size = data.Length;
            int l = 0, r = size - 1;
            while (l < r)
            {
                if (data[l] % 2 == 0) l++;
                else if (data[r] % 2 == 1) r--;
                else (data[l], data[r]) = (data[r], data[l]);
            }
        }





        /*
         Sort by Order
        Problem: Given two array, sort first array according to the order defined in second array.
        Solution: First the input array is traversed and frequency of values is calculated using HashTable. The order array is traversed and those values which are in original array / hashtable are displayed and removed from hashtable. Then the rest of the values of hashtable is printed to screen.
         */
        public static void SortByOrder(int[] arr,  int[] arr2)
        {
            int size = arr.Length, size2 = arr2.Length;
            var ht = new Dictionary<int, int>();
            for (int i = 0; i < size; i++)
            {
                if (ht.TryGetValue(arr[i], out int value))
                    ht[arr[i]] = value + 1;
                else
                    ht[arr[i]] = 1;
            }

            for (int j = 0; j < size2; j++)
            {
                if (ht.TryGetValue(arr2[j], out int value))
                {
                    for (int k = 0; k < value; k++) Console.Write(arr2[j] + " ");
                    ht.Remove(arr2[j]);
                }
            }

            for (int i = 0; i < size; i++)
            {
                if (ht.TryGetValue(arr[i], out int value))
                {
                    for (int k = 0; k < value; k++) Console.Write(arr[i] + " ");
                    ht.Remove(arr[i]);
                }
            }
        }




        /*
         Array Reduction
        Problem: Element left after reductions. Given an array of positive elements. You need to perform reduction operation. In each reduction operation smallest positive element value is picked and all the elements are subtracted by that value. You need to print the number of elements left after each reduction process.
        Input: [5, 1, 1, 1, 2, 3, 5]
         */
        public static void ArrayReduction(int[] arr) // Total number of reductions ???
        {
            Array.Sort(arr);
            int size = arr.Length;
            int count = 0, sum = 1;

            while (sum > 0)
            {
                sum = 0; int k = 0;
                for (; k < size; k++)
                {
                    if (arr[k] > 0) break;
                }
                int smallest = arr[k];
                for (int i = 0; i < size; i++)
                {
                    arr[i] -= smallest;
                    if (arr[i] > 0)
                    {
                        count++;
                        sum += arr[i];
                    }
                }
                Console.WriteLine(count);
                count = 0;
            }
        }



        /*
         Merge Array
        Problem: Given two sorted arrays. Sort the elements of these arrays so that first half of sorted elements will lie in first array and second half lies in second array. Extra space allowed is O(1).
        
        Solution: The first array will contain smaller part of the sorted output. We traverse the first array. Always compare the value of first array with the first element of the second array. If first array value is small than first element of second array we iterate further. If the first array value is greater than first element of second array. Then copy value of first element of second array into first array. And insert value of first array into second array in sorted order. Second array is always kept sorted so we need to compare only its first element.
        Time complexity will O(M*N) where M is length of first array and N is length of second array.
         */
        public static void Merge(int[] arr1, int size1, int[] arr2, int size2)
        {
            int index = 0;
            while ( index < size1 )
            {
                if (arr1[index] > arr2[0])
                {
                    // arr1[index] ^= arr2[0] ^= arr1[index] ^= arr2[0];
                    // always compare to first element of arr2
                    ArrayUtils.Swap(ref arr1[index++], ref arr2[0]);

                    // after swap arr2 may be unsorted >>> insert into sorted at proper position
                    for (int i = 0; i < size2 - 1; i++)
                    {
                        if (arr2[i] < arr2[i + 1]) break; // 
                        ArrayUtils.Swap(ref arr2[i], ref arr2[i + 1]);
                    }
                }
                else index++;
            }
        }



        /*
         Check Reverse
        Problem: Given an array of integers, find if reversing a sub-array makes the array sorted.
        Solution: In this algorithm start and stop are the boundary of reversed subarray whose reversal makes the whole array sorted.                                                
         */
        public static bool checkReverse(int[] arr)
        {
            int size = arr.Length;
            int start = -1;
            int stop = -1;
            for (int i = 0; i < size - 1; i++)
            {   // not ascending then stop n mark start pointer at i
                if (arr[i] > arr[i + 1]) { start = i; break; }
            }
            if (start == -1)
            {   // ascending array
                return true;
            }
            for (int i = start; i < size - 1; i++)
            {   // not descending then marks end of sub-array
                if (arr[i] < arr[i + 1]) { stop = i; break; }
            }
            if (stop == -1)
            {
                return true;
            }

            // increasing property; ASCENDING
            // after reversal the sub array should fit in the array
            if (arr[start - 1] > arr[stop] || arr[stop + 1] < arr[start])
            {
                return false;
            }
            for (int i = stop + 1; i < size - 1; i++)
            {
                if (arr[i] > arr[i + 1]) return false;
            }
            return true;
        }




        /*
         Union Intersection Sorted
        Problem: Given two unsorted arrays, find union and intersection of these two arrays.
        Solution: Sort both the arrays. Then traverse both the array, when we have common element we add it to intersection list and union list, when we have uncommon elements then we add it only union list.
         */
        private static void UnionIntersectionSorted(int[] arr1, int size1, int[] arr2, int size2)
        {
            int first = 0, second = 0;
            int[] unionArr = new int[size1 + size2];
            int[] interArr = new int[Math.Min(size1, size2)];
            int uIndex = 0, iIndex = 0;

            while (first < size1 && second < size2)
            {
                // common element
                if (arr1[first] == arr2[second])
                {
                    interArr[iIndex++] = arr1[first];
                    unionArr[uIndex++] = arr1[first];
                    first++; second++;
                }
                else if (arr1[first] < arr2[second]) // uncommon >>> small element union from first array
                {
                    unionArr[uIndex++] = arr1[first++];
                }
                else // uncommon
                {
                    unionArr[uIndex++] = arr2[second++];
                }
            }
            // remainder of arr1 OR arr2
            while (first < size1)
            {
                unionArr[uIndex++] = arr1[first++];
            }
            while (second < size2)
            {
                unionArr[uIndex++] = arr2[second++];
            }
            // Print result
            Console.Write("interArr: ");
            UserPrintResult.PrintArray(interArr);
            Console.Write("unionArr: ");
            UserPrintResult.PrintArray(unionArr);
        }

        internal static void UnionIntersectionUnsorted(int[] arr1, int size1, int[] arr2, int size2)
        {
            Array.Sort(arr1);
            Array.Sort(arr2);
            UnionIntersectionSorted(arr1, size1, arr2, size2);
        }
    }
}
