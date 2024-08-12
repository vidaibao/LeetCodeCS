using System.Numerics;

namespace DP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CountingBits_338(5);
            //PascalTriangle_118(5);
            //BestTime2BuyNSellStock_121();
            //BestTime2BuyNSellStock2_122();
            //BestTime2BuyNSellStock3_123();
            MaximumLengthOfRepeatedSubarray_718();

        }

        private static void MaximumLengthOfRepeatedSubarray_718()
        {
            int[] nums1 = [1, 2, 3, 2, 1], nums2 = [3, 2, 1, 4, 7];
            Console.WriteLine(FindLength(nums1, nums2));
        }
        static int FindLength(int[] nums1, int[] nums2)
        {
            int n = nums1.Length;
            int m = nums2.Length;
            int[] dp = new int[m + 1];
            int maxLength = 0;

            for (int i = 1; i <= n; i++)
            {
                for (int j = m; j >= 1; j--)
                {
                    if (nums1[i - 1] == nums2[j - 1])
                    {
                        dp[j] = dp[j - 1] + 1;
                        maxLength = Math.Max(maxLength, dp[j]);
                    }
                    else
                    {
                        dp[j] = 0;
                    }
                }
            }

            return maxLength;
        }


        static int FindLength01(int[] nums1, int[] nums2)
        {
            int n = nums1.Length;
            int m = nums2.Length;
            int[,] dp = new int[n + 1, m + 1];
            int maxLength = 0;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (nums1[i - 1] == nums2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                        maxLength = Math.Max(maxLength, dp[i, j]);
                    }
                }
            }

            return maxLength;
        }

        






        private static void BestTime2BuyNSellStock3_123()
        {
            int[] prices = { 3, 3, 5, 0, 0, 3, 1, 4 };//6
            Console.WriteLine(MaxProfit3(prices));
        }
        /*
         You are given an array prices where prices[i] is the price of a given stock on the ith day.
        Find the maximum profit you can achieve. You may complete at most two transactions.
        Note: You may not engage in multiple transactions simultaneously (i.e., you must sell the stock before you buy again).*/
        static int MaxProfit3(int[] prices)
        {
            if (prices.Length == 0) return 0;

            int n = prices.Length;

            int[] profit_one_transaction = new int[n];
            int[] profit_two_transactions = new int[n];

            // Forward pass to calculate max profit with one transaction
            int minPrice = prices[0];
            for (int i = 1; i < n; i++)
            {
                minPrice = Math.Min(prices[i], minPrice);
                profit_one_transaction[i] = Math.Max(prices[i] - minPrice, profit_one_transaction[i - 1]);
            }

            // Backward pass to calculate max profit with two transactions
            int maxPrice = prices[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                maxPrice = Math.Max(prices[i], maxPrice);
                profit_two_transactions[i] = Math.Max(profit_two_transactions[i + 1], maxPrice - prices[i] + profit_one_transaction[i]);
            }

            return profit_two_transactions[0];
        }


        private static void BestTime2BuyNSellStock2_122()
        {
            int[] prices = { 7, 1, 5, 3, 6, 4 };
            Console.WriteLine(MaxProfit2(prices));
        }
        /*
         You are given an integer array prices where prices[i] is the price of a given stock on the ith day.
        On each day, you may decide to buy and/or sell the stock. You can only hold at most one share of the stock at any time. However, you can buy it then immediately sell it on the same day.
        Find and return the maximum profit you can achieve.
         */
        static int MaxProfit2(int[] prices)
        {
            int totalProfit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                {
                    totalProfit += prices[i] - prices[i - 1];
                }
            }
            return totalProfit;
        }



        private static void BestTime2BuyNSellStock_121()
        {
            int[] prices = { 7, 1, 5, 3, 6, 4 };
            Console.WriteLine(MaxProfit(prices));
        }
        /*
         You are given an array prices where prices[i] is the price of a given stock on the ith day.
        You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.
        Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
         */
        static int MaxProfit(int[] prices)
        {
            /*This approach ensures that we only pass through the array once, resulting in a time complexity of O(n), where n is the length of the prices array. The space complexity is O(1) since we only use a constant amount of extra space*/
            int maxProfit = 0;
            int minPrice = int.MaxValue;//initialized to infinity to ensure that any price in the array will be lower
            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < minPrice)
                {
                    minPrice = prices[i];
                }
                else if (prices[i] - minPrice > maxProfit)
                {
                    maxProfit = prices[i] - minPrice;
                }
            }
            return maxProfit;
        }
        static int MaxProfit00(int[] prices) // time over
        {
            int maxProfit = 0;
            for (int b = 0; b < prices.Length; b++)
            {
                for (int s = b + 1; s < prices.Length; s++)
                {
                    int profit = prices[s] - prices[b];
                    if (profit > maxProfit) maxProfit = profit;
                }
            }
            return maxProfit;
        }



        private static int[] CountingBits_338(int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = 0;
            if (n == 0) { return dp; }
            dp[1] = 1;
            for (int x = 2; x <= n; x++)
            {
                if (x % 2 == 0) // even
                {
                    dp[x] = dp[x / 2];
                }
                else
                {
                    dp[x] = dp[x / 2] + 1; // dp[x] = dp[x / 2] + x % 2;  // x = 1 -> n
                }
            }

            return dp;
        }


        static IList<IList<int>> PascalTriangle_118(int numRows)
        {
            var res = new List<IList<int>>();
            res.Add([1]);
            if (numRows == 1) return res;
            for (int r = 2; r <= numRows; r++)
            {
                var abs = new List<int>();
                abs.Add(0);
                abs.AddRange(res[r - 2]);
                abs.Add(0);
                var solve = new List<int>();
                for (int i = 0; i < abs.Count - 1; i++)
                {
                    solve.Add(abs[i] + abs[i + 1]);
                }
                res.Add(solve);
            }
            return res;
        }
    }
}
