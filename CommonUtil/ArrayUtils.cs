using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtil
{
    public class ArrayUtils
    {
        public static void SwapInArray<T>(T[] arr, int index1, int index2)
        {
            int n = arr.Length;
            if (index1 < 0 || index1 >= n || index2 < 0 || index2 >= n) return;

            T temp = arr[index1];
            arr[index1] = arr[index2]; 
            arr[index2] = temp;
        }
    }
}
