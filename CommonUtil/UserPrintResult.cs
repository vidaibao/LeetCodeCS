namespace CommonUtil
{
    public class UserPrintResult
    {
        public static void Print2dArray<T>(T[][] arr, string delimit = ", ")
        {
            if (arr == null || arr.Length == 0)
            {
                Console.WriteLine("Array is empty.");
                return;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(string.Join(delimit, arr[i]));
            }
        }

        public static void PrintArray<T>(T[] arr, string delimit = ", ")
        {
            Console.WriteLine(string.Join(delimit, arr));
        }

        public static void PrintList<T>(List<T> list)
        {
            foreach (T item in list) Console.WriteLine(item);
        }
    }
}
