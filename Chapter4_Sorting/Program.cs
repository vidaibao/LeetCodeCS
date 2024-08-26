



namespace Chapter4_Sorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BubbleSort01();
            //InsertionSort01();
            //SelectionSort01();
            MergeSort01();

        }

        private static void MergeSort01()
        {
            int[] array = [3, 4, 2, 1, 6, 5, 7, 8, 1, 1];
            MergeSort.Sort(array);
            Console.WriteLine("MergeSort");
            Console.WriteLine(string.Join(", ", array));
        }

        private static void SelectionSort01()
        {
            int[] array = [9, 1, 8, 2, 7, 3, 6, 4, 5];
            SelectionSort.Sort(array);
            Console.WriteLine("SelectionSort");
            Console.WriteLine(string.Join(", ", array));
            array = [9, 1, 8, 2, 7, 3, 6, 4, 5];
            SelectionSort.Sort2(array);
            Console.WriteLine("SelectionSort2 Front");
            Console.WriteLine(string.Join(", ", array));
        }

        private static void InsertionSort01()
        {
            int[] array = [9, 1, 8, 2, 7, 3, 6, 4, 5];
            InsertionSort.Sort(array);
            Console.WriteLine("InsertionSort");
            Console.WriteLine(string.Join(", ", array));
        }

        private static void BubbleSort01()
        {
            int[] array = new int[] { 9, 1, 8, 2, 7, 3, 6, 4, 5 };
            BubbleSort.Sort(array);
            Console.WriteLine(string.Join(", ", array));
            Console.WriteLine("--------- Improved BubbleSort ----------");
            int[] array2 = [9, 1, 8, 2, 7, 3, 6, 4, 5];
            BubbleSort.Sort2(array2);
            Console.WriteLine(string.Join(", ", array2));
        }
    }
}
