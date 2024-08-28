using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4_Sorting
{
    internal class MergeSort
    {
        public static void Sort(int[] arr)
        {
            int size = arr.Length;
            int[] tempArray = new int[size];
            MergeSrt(arr, tempArray, 0, size - 1);
        }

        private static void MergeSrt(int[] arr, int[] tempArray, int lowerIndex, int upperIndex)
        {
            if (lowerIndex >= upperIndex) return;

            int middleIndex = (upperIndex + lowerIndex) / 2;

            MergeSrt(arr, tempArray, lowerIndex, middleIndex);
            MergeSrt(arr, tempArray, middleIndex + 1, upperIndex);
            Merge(arr, tempArray, lowerIndex, middleIndex, upperIndex);
        }

        private static void Merge(int[] arr, int[] tempArray, int lowerIndex, int middleIndex, int upperIndex)
        {
            int lowerStart = lowerIndex;
            int lowerStop = middleIndex;
            int upperStart = middleIndex + 1;
            int upperStop = upperIndex;
            int count = lowerIndex;

            while (lowerStart <= lowerStop && upperStart <= upperStop)
            {
                if (arr[lowerStart] < arr[upperStart])
                {
                    tempArray[count++] = arr[lowerStart++];
                }
                else {
                    tempArray[count++] = arr[upperStart++];
                }
            }
            
            while (lowerStart <= lowerStop)
            {
                tempArray[count++] = arr[lowerStart++];
            }
            
            while (upperStart <= upperStop)
            {
                tempArray[count++] = arr[upperStart++];
            }

            for (int i = lowerIndex; i <= upperIndex; i++)
            {
                arr[i] = tempArray[i];
            }
        }
    }
}
