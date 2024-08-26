using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4_Sorting
{
    internal class InsertionSort
    {
        public static bool More(int val1, int val2) => val1 > val2;
        public static void Sort(int[] arr)
        {
            int size = arr.Length;
            int j, temp;
            for (int i = 1; i < size; i++) // pick the value we want to insert into the sorted array in left
            {
                temp = arr[i];
                for (j = i; j > 0 && More(arr[j-1], temp); j--) // comparison using the more() function
                {
                    arr[j] = arr[j-1]; // shifted to the right
                }
                arr[j] = temp; // the proper position of the temp value
            }
        }

    }
}
