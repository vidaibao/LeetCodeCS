using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtil
{
    public class ArrayUtils
    {
        public static void Swap<T>(T[] arr, int index1, int index2)
        {
            int n = arr.Length;
            if (index1 < 0 || index1 >= n || index2 < 0 || index2 >= n) return;

            T temp = arr[index1];
            arr[index1] = arr[index2]; 
            arr[index2] = temp;
        }

        public static void Swap<T>(ref T value1, ref T value2)
        {
            T temp = value1;
            value1 = value2;
            value2 = temp;
        }

    }
}
