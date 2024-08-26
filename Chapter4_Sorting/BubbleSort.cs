using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4_Sorting
{
    internal class BubbleSort
    {
        public static bool More(int val1, int val2) => val1 > val2;

        public static void Sort(int[] arr)
        {
            int size = arr.Length;
            for (int i = 0; i < size - 1; i++) // pass
            {
                for (int j = 0; j < size - i - 1; j++) // each larger values will be in rightmost position >> no need to traverse. In the first iteration the largest value, in the second iteration the second largest and so on
                {
                    if (More(arr[j], arr[j + 1])) (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                }
            }
        }

        /*When there is, no more swap in one pass of the outer loop the array is already sorted. At this point, we should stop sorting. This sorting improvement in Bubble-Sort is extremely useful when we know that, except few elements rest of the array is already sorted. 
         * In this case, we just need one single pass and the best-case complexity is O(n)*/
        public static void Sort2(int[] arr)
        {
            int size = arr.Length;
            for (int i = 0, swapped = 1; i < size - 1 && swapped == 1; i++)
            {
                swapped = 0;
                for (int j = 0; j < size - i - 1; j++)
                {
                    if (More(arr[j], arr[j + 1]))
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                        swapped = 1;
                    }
                }
            }
        }
    }
}
