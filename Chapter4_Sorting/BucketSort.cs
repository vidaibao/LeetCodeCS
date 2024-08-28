using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4_Sorting
{
    internal class BucketSort
    {
        internal static void Sort(int[] array, int lowerRange, int upperRange)
        {
            int size = array.Length;
            int range = upperRange - lowerRange;
            int[] count = new int[range];

            for (int i = 0; i < size; i++)
            {
                count[array[i] - lowerRange]++; // occur counting
            }

            int j = 0;
            for (int i = 0; i < range; i++)
            {
                for (; count[i] > 0; count[i]--)
                {
                    array[j++] = i + lowerRange;
                }
            }
        }
    }
}
