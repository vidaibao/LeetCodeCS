
namespace Sorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MergeSortedArray_88();
            //SquaresSortedArray_977();
            //IntervalListIntersections_986();
            //MergeInterval_56();
            InsertInterval_57();

        }

        private static void InsertInterval_57()
        {
            int[][] intervals = { new int[] { 1, 2 }, new int[] { 3, 5 }, new int[] { 6, 7 }, new int[] { 8, 10 }, new int[] { 12, 16 } };
            int[] newIntervals = { 4, 8 };
            var res = Insert(intervals, newIntervals);
            PrintInts2(res);
        }
        static int[][] Insert(int[][] intervals, int[] newInterval)
        {
            if (intervals.Length == 0) return new int[][] { newInterval };

            List<int[]> result = new List<int[]>();
            int i = 0;
            while (i < intervals.Length && intervals[i][1] < newInterval[0])
            {
                result.Add(intervals[i++]);
            }
            if (i == intervals.Length)
            {
                result.Add(newInterval);// last
                return result.ToArray();
            }
            // overlap AND first
            int[] prev = newInterval;
            while (i < intervals.Length && intervals[i][0] <= newInterval[1])
            {
                prev[0] = Math.Min(intervals[i][0], prev[0]);
                prev[1] = Math.Max(intervals[i][1], prev[1]);
                i++;
            }
            result.Add(prev);
            while (i < intervals.Length)
            {
                result.Add(intervals[i++]);
            }
            return result.ToArray();
        }
        static int[][] Insert00(int[][] intervals, int[] newInterval)
        {
            if (intervals.Length == 0) return new[] { newInterval };
            List<int[]> result = new List<int[]>();
            int[] prev = newInterval;
            for (int i = 0; i < intervals.Length; i++)
            {
                int[] current = intervals[i];
                int start = Math.Max(prev[0], current[0]);
                int end = Math.Min(prev[1], current[1]);
                if (start <= end) // overlap
                {
                    result.Add(new int[] { Math.Min(prev[0], current[0]), Math.Max(prev[1], current[1]) });
                    prev[0] = Math.Min(prev[0], current[0]);
                    prev[1] = Math.Max(prev[1], current[1]);
                }
                else if (current[0] > prev[1])
                {
                    result.Add(prev);
                    result.Add(current);
                }
                else
                {
                    result.Add(current);
                }
            }

            return result.ToArray();
        }



        private static void MergeInterval_56()
        {
            var intervals = new int[][] { new int[] { 1, 3}, new int[] { 2, 6}, new int[] { 8, 10}, new int[] { 15, 18}};
            //var intervals = new int[][] { new int[] { 1, 4 }, new int[] { 5, 6 } };
            var res = Merge(intervals);
            PrintInts2(res);
        }

        private static int[][] Merge(int[][] intervals)
        {
            if (intervals.Length == 1)
            {
                return new int[][] { intervals[0] };
            }
            //Array.Sort(intervals, (a, b) => a[0] - b[0]);

            List<int[]> result = new List<int[]>();
            result.Add(intervals[0]);
            for (int i = 1; i < intervals.Length; i++)
            {
                int[] cur = intervals[i];
                int[] last = result[result.Count - 1];
                if (cur[0] <= last[1]) // overlap
                {
                    result[result.Count - 1][1] = Math.Max(cur[1], last[1]);
                }
                else
                {
                    result.Add(cur);
                }
            }
            return result.ToArray();
        }

        static int[][] Merge00(int[][] intervals)
        {
            var res = new List<int[]>();
            //intervals.OrderBy(x => x[0]);
            if (intervals.Length == 1)
            {
                res.Add(intervals[0]);
                return res.ToArray();
            }
            int[] a = intervals[0];
            res.Add(a);
            for (int i = 1; i < intervals.Length; i++)
            {
                //int[] a = temp;
                int[] b = intervals[i];
                int low = Math.Max(a[0], b[0]);
                int hi = Math.Min(a[1], b[1]);
                if (low <= hi) // overlap
                {
                    res.RemoveAt(res.Count - 1);
                    int[] temp = new int[] { Math.Min(a[0], b[0]), Math.Max(a[1], b[1]) };
                    res.Add(temp);
                    //a = b;
                }
                else
                {
                    res.Add(a);
                    res.Add(b);
                    //a = b;
                }
                a = b;
            }
            return res.ToArray();
        }



        private static void IntervalListIntersections_986()
        {
            int[][] firstList = new int[][] {
                                                new int[] { 0, 2 },
                                                new int[] { 5, 10 },
                                                new int[] { 13, 23 },
                                                new int[] { 24, 25 }
                                            };
            int[][] secondList = new int[][] { new int[] { 1, 5 }, new int[] { 8, 12 }, new int[] { 15, 24 }, new int[] { 25, 26 } };
            // [[1,2],[5,5],[8,10],[15,23],[24,24],[25,25]]
            
            var res = IntervalIntersection(firstList, secondList);
            foreach (var re in res)
            {
                Console.WriteLine(String.Join(", ", re));
            }
        }
        private static int[][] IntervalIntersection(int[][] firstList, int[][] secondList)
        {
            int p1 = 0; int p2 = 0;
            var res = new List<int[]>();
            while (p1 < firstList.Length && p2 < secondList.Length) 
            {
                var first = firstList[p1]; var second = secondList[p2];
                int start = Math.Max(first[0], second[0]);
                int end = Math.Min(first[1], second[1]);
                if (start <= end)
                {
                    res.Add(new int[] { start, end });
                }
                if (first[1] < second[1])
                    p1++;
                else
                    p2++;
            }
            return res.ToArray();
        }
        private static int[] Intersections(int[] first, int[] second)
        {
            var res = new List<int>();
            int p1 = 0, p2 = 0;
            while (p1 < first.Length && p2 < second.Length)
            {
                if (first[p1] == second[p2])
                {
                    res.Add(p1); p1++; p2++;
                }
                else if (first[p1] < second[p2])
                {
                    p1++;
                }
                else if (first[p1] > second[p2])
                {
                    p2++;
                }
            }

            return res.ToArray();
        }



        // Given an integer array nums sorted in non-decreasing order, return an array of the squares of each number sorted in non-decreasing order.
        private static void SquaresSortedArray_977()
        {
            //int[] nums = { -4, -1, 0, 3, 10 }; //[0,1,9,16,100]
            int[] nums = { -7, -3, 2, 3, 11 }; //[4,9,9,49,121]
            var res = SortedSquares(nums);
            Console.WriteLine(String.Join(", ", res));
        }

        private static int[] SortedSquares(int[] nums)
        {
            int[] res = new int[nums.Length];
            int l = 0; int r = nums.Length - 1; int i = r;
            while (l <= r)
            {
                double l2 = Math.Pow(nums[l], 2);
                double r2 = Math.Pow(nums[r], 2);
                if (l2 > r2)
                {
                    res[i] = (int)l2;
                    l++;
                }
                else
                {
                    res[i] = (int)r2;
                    r--;
                }
                i--;
            }
            return res;
        }
        private static int[] SortedSquares00(int[] nums)
        {
            var re = new List<int>();
            // find min-positive-number index
            int i = 0;
            for (; i < nums.Length; i++)
            {
                if (nums[i] >= 0) break;
            }
            re.Add((int)Math.Pow(nums[i], 2));
            int l = i - 1; int r = i + 1;
            while (l >= 0 && r < nums.Length)
            {
                double l2 = Math.Pow(nums[l], 2);
                double r2 = Math.Pow(nums[r], 2);
                if (l2 < r2)
                {
                    re.Add((int)l2);
                    l--;
                }
                else
                {
                    re.Add((int)r2);
                    r++;
                }
            }
            while (l >= 0) re.Add((int)Math.Pow(nums[l--], 2));
            while (r < nums.Length) re.Add((int)Math.Pow(nums[r++], 2));

            return re.ToArray();
        }




        private static void MergeSortedArray_88()
        {
            int m = 0; int[] nums1 = { 0, 0, 0, 0, 0 } ;
            int n = 5; int[] nums2 = { 1, 2, 3, 4, 5 };
            Merge(nums1, m, nums2, n);
            Console.WriteLine(String.Join(", ", nums1));
        }
        static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int p1 = m - 1; int p2 = n - 1; int p = m + n - 1;
            while (p1 >= 0 && p2 >= 0)
            {
                if (nums1[p1] > nums2[p2])
                {
                    nums1[p] = nums1[p1--];
                }
                else
                {
                    nums1[p] = nums2[p2--];
                }
                p--;
            }
            if (p2 >= 0)
            {
                for (int i = p2; i >= 0; i--)
                {
                    nums1[p--] = nums2[i];
                }
            }
        }


        //
        static void PrintInts2(int[][] nums)
        {
            foreach (int[] num in nums)
            {
                Console.WriteLine(String.Join(", ", num));
            }
        }
    }
}
