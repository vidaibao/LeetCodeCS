using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4_Sorting
{
    internal class SelectionSort
    {
        public static void Sort(int[] arr)
        {   // sorted array is created backward
            int size = arr.Length;
            int max, temp;
            for (int i = 0; i < size - 1; i++) // decides the number of times the inner loop will iterate
            {
                max = 0;
                for (int j = 1; j < size - 1 - i; j++)
                {
                    if (arr[j] > arr[max]) max = j; // caculate the place (index) of the max
                }
                temp = arr[size - 1 - i]; // place max at the end of the array
                arr[size - 1 - i] = arr[max];
                arr[max] = temp;
            }
        }

        public static void Sort2(int[] arr)
        {   // sorted array is created from front
            int size = arr.Length;
            for (int i = 0; i < size - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < size; j++)
                {
                    if (arr[j] < arr[min]) min = j;
                }
                (arr[i], arr[min]) = (arr[min], arr[i]);
            }
        }
    }
}
