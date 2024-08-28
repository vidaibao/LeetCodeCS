












namespace Chapter4_Sorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BubbleSort01();
            //InsertionSort01();
            //SelectionSort01();
            //MergeSort01();
            //QuickSort01();
            //QuickSelect01();
            //BucketSort01();
            //ProblemBasedOnSorting01();
            ProblemBasedOnSorting012();
            MinimumSwaps();
            SeparateEvenAndOdd();
            SortByOrder();
            //ArrayReduction01();

        }

        private static void ArrayReduction01()
        {
            int[] array = [5, 1, 1, 1, 2, 3, 5];
            Console.WriteLine(string.Join(", ", array));
            Console.WriteLine("ArrayReduction(array)");
            ProblemBasedOnSorting.ArrayReduction(array);
            Console.WriteLine(string.Join(", ", array));
            Console.WriteLine("--------------------");
            Console.WriteLine();
        }

        private static void SortByOrder()
        {
            int[] arr = [2, 1, 2, 5, 7, 1, 9, 3, 6, 8, 8];
            int[] arr2 = [2, 1, 8, 3];
            Console.WriteLine(string.Join(", ", arr));
            Console.WriteLine(string.Join(", ", arr2));
            Console.WriteLine("SortByOrder(arr, arr2)");
            ProblemBasedOnSorting.SortByOrder(arr, arr2);
            Console.WriteLine();
            Console.WriteLine("--------------------");
            Console.WriteLine();
        }

        private static void SeparateEvenAndOdd()
        {
            int[] array = [1, 21, 2, 20, 3, 19, 4, 18, 5, 17, 6, 16, 7, 15, 8, 14, 9, 13, 10, 12, 11];
            Console.WriteLine(string.Join(", ", array));
            Console.WriteLine("SeparateEvenAndOdd(array)");
            ProblemBasedOnSorting.SeperateEvenAndOdd(array);
            Console.WriteLine(string.Join(", ", array));
            Console.WriteLine("--------------------");
            Console.WriteLine();
        }

        private static void MinimumSwaps()
        {
            int[] array = [1, 21, 2, 20, 3, 19, 4, 18, 5, 17, 6, 16, 7, 15, 8, 14, 9, 13, 10, 12, 11];
            Console.WriteLine(string.Join(", ", array));
            Console.WriteLine("MinimumSwaps(array, 9)");
            Console.WriteLine(ProblemBasedOnSorting.MinimumSwaps(array, 9));
            Console.WriteLine(string.Join(", ", array));
            Console.WriteLine("--------------------");
            Console.WriteLine();
        }

        private static void ProblemBasedOnSorting012()
        {
            int[] array = [0, 1, 1, 0, 1, 2, 1, 2, 0, 0, 0, 1];
            Console.WriteLine(string.Join(", ", array));
            ProblemBasedOnSorting.Partition012(array);
            Console.WriteLine("Partition012(array) 2 pass");
            Console.WriteLine(string.Join(", ", array));
            Console.WriteLine("--------------------");
            Console.WriteLine();
            //
            array = [0, 1, 1, 0, 1, 2, 1, 2, 0, 0, 0, 1];
            Console.WriteLine(string.Join(", ", array));
            ProblemBasedOnSorting.Partition012a(array);
            Console.WriteLine("Partition012a(array) single pass");
            Console.WriteLine(string.Join(", ", array));
            Console.WriteLine("--------------------");
            Console.WriteLine();
            // 
            array = [1, 21, 2, 20, 3, 19, 4, 18, 5, 17, 6, 16, 7, 15, 8, 14, 9, 13, 10, 12, 11];
            // 1, 2, 3, 4, 5, 8, 6, 7, 11, 10, 12, 9, 15, 16, 14, 17, 13, 18, 19, 20, 21 ???
            Console.WriteLine(string.Join(", ", array));
            ProblemBasedOnSorting.RangePartition(array, 9, 12);
            Console.WriteLine("RangePartition(array, 9, 12)");
            Console.WriteLine(string.Join(", ", array));
            Console.WriteLine("--------------------");
            Console.WriteLine();
        }

        private static void ProblemBasedOnSorting01()
        {
            int[] array = [0, 1, 1, 0, 1, 0, 1, 1, 0, 0, 0, 1];
            Console.WriteLine(string.Join(", ", array));
            ProblemBasedOnSorting.Partition01(array);
            Console.WriteLine("Partition01(array)");
            Console.WriteLine(string.Join(", ", array));
            Console.WriteLine("--------------------");
        }

        private static void BucketSort01()
        {
            int[] array = [23, 24, 22, 21, 26, 25, 27, 28, 21, 21];
            Console.WriteLine(string.Join(", ", array));
            BucketSort.Sort(array, 20, 30);
            Console.WriteLine("BucketSort(array, 20, 30)");
            Console.WriteLine(string.Join(", ", array));
        }

        private static void QuickSelect01()
        {
            int[] array = [3, 4, 2, 1, 6, 5, 7, 8, 10, 9];
            Console.WriteLine(string.Join(", ", array));
            Console.WriteLine("QuickSelect.Get(array, 5)");
            Console.WriteLine(QuickSelect.Get(array, 5));
        }

        private static void QuickSort01()
        {
            int[] array = [3, 4, 2, 1, 6, 5, 7, 8, 1, 1];
            Console.WriteLine(string.Join(", ", array));
            QuickSort.Sort(array);
            Console.WriteLine("QuickSort");
            Console.WriteLine(string.Join(", ", array));
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
            int[] array = [5, 1, 8, 2, 7, 3, 6, 4, 9];
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
