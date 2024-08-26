

using CommonUtil;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;

namespace SolveExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Example_1_32();
            //IndexArray_1_34();
            //Sort1toN_1_36();

            //------------ RECUSIVE -------------
            //PrintBase16Integer_149();
            //HanoiTower_150();
            //GreatestCommonDivisor_151();
            //AllPermutationsOfIntegerList_153();
            //BinarySearchUseRecursion_154();

        }


        // Given an array of integers in increasing order, you need to find if some particular value is present in array using recursion
        private static void BinarySearchUseRecursion_154()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.WriteLine(BinarySearchRecursive(arr, 0, arr.Length - 1, 6));
            Console.WriteLine(BinarySearchRecursive(arr, 0, arr.Length - 1, 16));
        }

        private static int BinarySearchRecursive(int[] arr, int l, int r, int val)
        {
            if (l > r) return -1;

            int mid = (l + r) / 2;
            if (arr[mid] == val)
            {
                return mid;
            }
            else if (arr[mid] < val)
            {
                return BinarySearchRecursive(arr, mid + 1, r, val);
            }
            else //if (arr[mid] > val)
            {
                return BinarySearchRecursive(arr, l, mid - 1, val);
            }
            //return -1;
        }




        private static void AllPermutationsOfIntegerList_153()
        {
            int size = 4;
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = i;
            }
            GetPermutation(arr, 0, size);
        }
        // Analysis: In permutation method at each recursive call number at index, “i” is swapped with all the numbers that are right of it. Since the number is swapped with all the numbers in its right one by one it will produce all the permutation possible.
        private static void GetPermutation(int[] arr, int i, int length)
        {
            if (length == i)
            {
                UserPrintResult.PrintArray(arr);
                return;
            }
            
            for (int j = i; j < length; j++)
            {
                (arr[i], arr[j]) = (arr[j], arr[i]);
                GetPermutation(arr, i + 1, length);
                (arr[i], arr[j]) = (arr[j], arr[i]);
            }
        }




        private static void GreatestCommonDivisor_151()
        {
            int m = 9, n = 627;
            Console.WriteLine(GCD(m, n));
        }

        private static int GCD(int m, int n)
        {
            if (m < n)
            {
                return GCD(n, m);
            }
            if (m % n == 0)
            {
                return n;
            }
            return GCD(n, m % n); // Euclid’s algorithm is used to find gcd. GCD(n, m) == GCD(m, n mod m).
        }



        private static void HanoiTower_150()
        {
            int num = 4;
            Console.WriteLine("The sequence of moves involved in the Tower of Hanoi are:\n");
            TowerOfHanoi(num, 'A', 'C', 'B');
        }
        // Analysis: If we want to move N disks from source to destination, then we first move N-1 disks from source to temp, and then move the lowest Nth disk from source to destination.Then it will move N-1 disks from temp to destination.
        public static void TowerOfHanoi(int num, char src, char dst, char temp)
        {
            if (num < 1) return;
            TowerOfHanoi(num - 1, src, temp, dst);
            Console.WriteLine("Move disk " + num + " from peg " + src + " to peg " + dst);
            TowerOfHanoi(num - 1, temp, dst, src);
        }



        private static void PrintBase16Integer_149()
        {
            int n = 456123;
            PrintInt(n);
        }
        private static void PrintInt(int n)
        {
            string conversion = "0123456789ABCDEF";
            int baseValue = 16;
            char digit = (char)(n % baseValue);
            n /= baseValue;
            if (n != 0)
            {
                PrintInt(n);
            }
            Console.Write(conversion[digit]);
        }

        /*Problem: Given an array of length N. It contains unique elements from 1 to N. Sort the elements of the array.*/
        private static void Sort1toN_1_36()
        {
            int[] arr2 = new int[] { 8, 5, 6, 1, 9, 3, 2, 7, 4, 10 };
            UserPrintResult.PrintArray(arr2);
            Console.WriteLine("Sort1toN(arr2);");
            Sort1toN(arr2);
            UserPrintResult.PrintArray(arr2);
        }
        // First solution: For each index value pick the element and then put it into its proper place and the element which is in its proper position then pick it and repeat the process again
        private static void Sort1toN(int[] arr2)
        {
            for (int i = 0; i < arr2.Length; i++)
            {
                /* swaps to move elements in proper position.*/
                while (arr2[i] != i + 1)
                {
                    int temp = arr2[i];
                    arr2[i] = arr2[temp - 1];
                    arr2[temp - 1] = temp;
                }
            }
        }

        private static void IndexArray_1_34()
        {
            int[] arr2 = new int[] { 8, -1, 6, 1, 9, 3, 2, 7, 4, -1 };
            int size = arr2.Length;
            UserPrintResult.PrintArray(arr2);
            //Console.WriteLine("IndexArray(arr2, size);");
            //IndexArray(arr2, size);
            //UserPrintResult.PrintArray(arr2);
            Console.WriteLine("IndexArray2(arr2, size);");
            IndexArray2(arr2, size);
            UserPrintResult.PrintArray(arr2);
        }

        private static void IndexArray(int[] arr, int size)
        {
            for (int i = 0; i < size; i++)
            {
                int curr = i;
                int value = -1;
                /* swaps to move elements in proper position.*/
                while (arr[curr] != -1 && arr[curr] != curr)
                {
                    int temp = arr[curr];
                    arr[curr] = value;
                    value = curr = temp;
                }
                /* check if some swaps happened. */
                if (value != -1)
                {
                    arr[curr] = value;
                }
            }
        }
        public static void IndexArray2(int[] arr, int size)
        {
            int temp;
            for (int i = 0; i < size; i++)
            {
                while (arr[i] != -1 && arr[i] != i)
                {
                    /* swap arr[i] and arr[arr[i]] */
                    temp = arr[i];
                    arr[i] = arr[temp];
                    arr[temp] = temp;
                }
            }
        }

        private static void Example_1_32()
        {
            int[] arr2 = new int[] { 8, 1, 2, 3, 4, 5, 6, 4, 2 };
            UserPrintResult.PrintArray(arr2);
            Console.WriteLine("WaveArray(arr2);");
            WaveArray(arr2);
            UserPrintResult.PrintArray(arr2);
            Console.WriteLine("WaveArray2(arr2);");
            WaveArray2(arr2);
            UserPrintResult.PrintArray(arr2);
        }
        /*Problem: Given an array, arrange its elements in wave form such that odd elements are lesser then its neighbouring even elements.*/
        // Sort the array then swap ith and i+1th index value so the array will form a wave
        public static void WaveArray(int[] arr)
        {
            int size = arr.Length;
            Array.Sort(arr);
            for (int i = 0; i < size - 1; i += 2)
            {
                (arr[i], arr[i + 1]) = (arr[i + 1], arr[i]);
            }
        }
        // Compare even index values with its neighbour odd index values and swap if odd index is not smaller than even index.
        private static void WaveArray2(int[] arr)
        {
            int size = arr.Length;
            /* Odd elements are lesser then even elements. */
            for (int i = 1; i < size; i += 2)
            {
                if ((i - 1) >= 0 && arr[i] > arr[i - 1])
                {
                    (arr[i], arr[i - 1]) = (arr[i - 1], arr[i]);
                }
                if ((i + 1) < size && arr[i] > arr[i + 1])
                {
                    (arr[i], arr[i + 1]) = (arr[i + 1], arr[i]);
                }
            }
        }
    }
}
