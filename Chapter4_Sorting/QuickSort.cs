using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4_Sorting
{
    internal class QuickSort
    {
        /*• Quick sort is recursive algorithm. In each step, we select a pivot (let us say first element of array).
        • Partition the array into two parts, such that all the elements of the array which are smaller than the pivot should be moved to the left side of array and all the elements that are greater than pivot are at moved the right side of the array.*/
        public static void Sort(int[] arr)
        {
            int size = arr.Length;
            QuickySort(arr, 0, size - 1);
        }
        private static void QuickySort(int[] arr, int lower, int upper)
        {
            if (lower >= upper) return;

            int pivot = arr[lower];
            int start = lower, stop = upper;

            while (lower < upper)
            {
                while (arr[lower] <= pivot && lower < upper) lower++;
                while (arr[upper] > pivot && lower <= upper) upper--;
                if (lower < upper) (arr[lower], arr[upper]) = (arr[upper], arr[lower]); // 
            }
            (arr[start], arr[upper]) = (arr[upper], arr[start]); // upper is the pivot position
            QuickySort(arr, start, upper - 1); // pivot - 1 is the upper for left sub array
            QuickySort(arr, upper + 1, stop); // pivot + 1 is the lower for right sub array
        }
    }
}
