namespace CommonUtil
{
    public class UserPrintResult
    {
        public static void Print2dArray<T>(T[][] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                Console.WriteLine("Array is empty.");
                return;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(string.Join(", ", arr[i]));
            }
        }
    }
}
