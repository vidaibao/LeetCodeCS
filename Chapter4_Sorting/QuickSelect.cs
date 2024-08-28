using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4_Sorting
{
    internal class QuickSelect
    {
        internal static int Get(int[] arr, int k)
        {
            QuickySelect(arr, 0, arr.Length - 1, k);
            return arr[k - 1];
        }

        private static void QuickySelect(int[] arr, int lower, int upper, int k)
        {
            if (lower >= upper) { return; }

            int pivot = arr[lower];
            int start = lower, stop = upper;
            while (lower < upper)
            {
                while (arr[lower] <= pivot && lower < upper) lower++;
                while (arr[upper] > pivot && lower <= upper) upper--;
                if (lower < upper) { (arr[lower], arr[upper]) = (arr[upper], arr[lower]); }
            }
            (arr[start], arr[upper]) = (arr[upper], arr[start]); // upper is the pivot position
            // continue with sub array contains k
            if (k < upper) // left sub array
                QuickySelect(arr, start, upper - 1, k); // pivot - 1 is the upper for
            if (k > upper) // right sub array
                QuickySelect(arr, upper + 1, stop, k); // pivot + 1 is the lower for
        }
    }
}
