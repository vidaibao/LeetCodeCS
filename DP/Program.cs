namespace DP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CountingBits_338(5);
            //PascalTriangle_118(5);
            BestTime2BuyNSellStock_121();

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
