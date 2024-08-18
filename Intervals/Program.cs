using CommonUtil;

namespace Intervals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //SummaryRanges_228();
            //MergeInterval_56();
            MinimumNumberOfArrowsToBurstBalloons_452();

        }

        


        private static void MinimumNumberOfArrowsToBurstBalloons_452()
        {
            
            int[][] points = [[-2147483646, -2147483645], [2147483646, 2147483647]]; // 2
            //int[][] points = [[1, 2], [3, 4], [5, 6], [7, 8]]; // 2
            //int[][] points = [[10, 16], [2, 8], [1, 6], [7, 12]]; // 2
            Console.WriteLine(FindMinArrowShots(points));
        }
        static int FindMinArrowShots(int[][] points)
        {
            if (points.Length <= 1) return points.Length;

            Array.Sort(points, (a, b) => a[1].CompareTo(b[1])); // CompareTo >> issue -
            int arrows = 1;
            int currentEnd = points[0][1];

            for (int i = 1; i < points.Length; i++)
            {
                if (points[i][0] > currentEnd) // NOT overlap, burst
                {
                    arrows++;
                    currentEnd = points[i][1];
                }
            }

            return arrows;
        }







        private static void MergeInterval_56()
        {
            int[][] intervals = [[1, 3], [2, 6], [8, 10], [15, 18]]; // [[1,6],[8,10],[15,18]]
            UserPrintResult.Print2dArray(Merge(intervals));
        }
        static int[][] Merge(int[][] intervals)
        {
            if (intervals.Length == 1)
            {
                return new int[][] { intervals[0] };
            }
            Array.Sort(intervals, (a, b) => a[0] - b[0]);

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





        private static void SummaryRanges_228()
        {
            int[] nums = [0, 1, 2, 4, 5, 7]; // ["0->2","4->5","7"]
            var res = SummaryRanges(nums);
            UserPrintResult.PrintList((List<string>)res);
        }
        static IList<string> SummaryRanges(int[] nums) // 100ms
        {
            if (nums.Length < 1) return new List<string>();

            var res = new List<string>();
            int startIndex = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] + 1 != nums[i]) // break consecutive
                {
                    if (startIndex == i - 1) // 1 element
                        res.Add(nums[startIndex].ToString());
                    else
                       res.Add($"{nums[startIndex]}->{nums[i - 1]}");
                    
                    startIndex = i; // current i
                }
            }

            if (startIndex == nums.Length - 1)
                res.Add(nums[startIndex].ToString());
            else
                res.Add($"{nums[startIndex]}->{nums[nums.Length - 1]}");

            return res;
        }
        static IList<string> SummaryRanges01(int[] nums) // 120ms
        {
            if (nums.Length < 1) return new List<string>();

            var res = new List<string>();
            var li = new List<int>();
            li.Add(nums[0]);

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1] + 1) { li.Add(nums[i]); }
                else
                {
                    if (li.Count == 1)
                    {
                        res.Add(li[0].ToString());
                    }
                    else
                    {
                        res.Add(li[0].ToString() + "->" + li[li.Count - 1].ToString());
                    }
                    li.Clear();
                    li.Add(nums[i]);
                }
            }

            if (li.Count > 0)
            {
                if (li.Count == 1) res.Add(li[0].ToString());
                else
                {
                    res.Add(li[0].ToString() + "->" + li[li.Count - 1].ToString());
                    li.Clear();
                }
            }

            return res;
        }

    }
}
