
using CommonUtil;

namespace Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //SpiralMatrix_54();
            //SpiralMatrix2_59();
            //SpiralMatrix3_885();
            SpiralMatrix4_2326();

        }

        private static void SpiralMatrix4_2326()
        {
            int m = 3, n = 5;
            int[] values = { 3, 0, 2, 6, 8, 1, 7, 9, 4, 2, 5, 5, 0 };
            ListNode head = new ListNode(values[0]);
            ListNode current = head;

            for (int i = 1; i < values.Length; i++)
            {
                current.next = new ListNode(values[i]);
                current = current.next;
            }

            var res = SpiralMatrix(m, n, head);
            UserPrintResult.Print2dArray(res);
        }
        static int[][] SpiralMatrix(int m, int n, ListNode head)
        {
            int[][] grid = new int[m][];
            for (int i = 0; i < m; i++)
            {
                grid[i] = new int[n]; // init -1
                Array.Fill(grid[i], -1);
            }

            int[] dr = [0, 1, 0, -1]; // right, down, left, up
            int[] dc = [1, 0, -1, 0];
            int r = 0, c = 0;
            int direction = 0;
            ListNode current = head;

            for (int j = 0; j < m * n && current != null; j++)
            {
                grid[r][c] = current.val;
                current = current.next;

                int nr = r + dr[direction];
                int nc = c + dc[direction];

                if (nr < 0 || nr >= m || nc < 0 || nc >= n || grid[nr][nc] != -1) // if rotate then resolve r, c
                {
                    direction = (direction + 1) % 4; // 0123
                    nr = r + dr[direction];
                    nc = c + dc[direction];
                }

                r = nr; c = nc;
            }

            return grid;
        }





        private static void SpiralMatrix3_885()
        {
            int rows = 5, cols = 6, rStart = 1, cStart = 4;
            //int rows = 1, cols = 4, rStart = 0, cStart = 0;
            var res = SpiralMatrixIII(rows, cols, rStart, cStart);
            UserPrintResult.Print2dArray(res);
        }
        static int[][] SpiralMatrixIII(int rows, int cols, int rStart, int cStart)
        {
            int[][] res = new int[rows * cols][];
            int[] dr = [0, 1, 0, -1];// right down left up
            int[] dc = [1, 0, -1, 0];
            int count = 0; int direction = 0; int step = 0;
            int r = rStart, c = cStart;
            res[count++] = new int[] {r, c};

            while (count < rows * cols)
            {
                if (direction == 0 || direction == 2) step++;

                for (int i = 0; i < step; i++)
                {
                    r += dr[direction]; c += dc[direction];
                    if (0 <= r && r < rows && 0 <= c && c < cols) res[count++] = new int[] {r, c};
                }

                direction = (direction + 1) % 4; // 0 1 2 3 change direction
            }

            return res;
        }
        static int[][] SpiralMatrixIII0(int rows, int cols, int rStart, int cStart)
        {
            int[][] res = new int[rows * cols][];
            for (int i = 0; i < res.Length; i++) res[i] = new int[2];

            int numbering = 0; int total = cols * rows;
            int r = rStart, c = cStart;
            int step = 1;
            int top = rStart, bottom = rStart;
            int left = cStart, right = cStart;

            while (numbering < total)
            {
                // left -> right
                right += step;
                while (c <= right)
                {
                    if (c < cols) { res[numbering][0] = r; res[numbering][1] = c++; ++numbering; }
                }
                 c = right;
                // top -> bottom
                bottom += step;
                while (r < bottom)
                {

                }
            }





            return res;
        }
        static int[][] SpiralMatrixIII00(int rows, int cols, int rStart, int cStart)
        {
            int[][] res = new int[rows][];
            for (int i = 0; i < res.Length; i++) res[i] = new int[cols];

            int numbering = 1; int total = cols * rows;
            int  r = rStart, c = cStart;
            int step = 1;
            //int top = 0, bottom = rows - 1;
            //int left = 0, right = cols - 1;
            //bool goingDown = true;
            //res[r][c] = numbering++; c++;
            while (numbering <= total)
            {
                // left -> right
                for (int i = c; i <= c + step; i++)
                {
                    if (0 <= r && r <= rows - 1 && 0 <= i && i <= cols - 1) res[r][i] = numbering++;
                }
                r++; c += step;
                // up -> bottom
                for (int i = r; i <= r + step; i++)
                {
                    if (0 <= i && i <= rows - 1 && 0 <= c && c <= cols - 1) res[i][c] = numbering++;
                }
                r += step; c--;  
                step++;
                // right -> left
                for (int i = c; i >= c - step; i--)
                {
                    if (0 <= r && r <= rows - 1 && 0 <= i && i <= cols - 1) res[r][i] = numbering++;
                }
                r--; c -= step;
                // bottom -> up
                for (int i = r; i <= r - step; i--)
                {
                    if (0 <= i && i <= rows - 1 && 0 <= c && c <= cols - 1) res[i][c] = numbering++;
                }
                r -= step; c++;
                step++;
            }

            return res;
        }






        private static void SpiralMatrix2_59()
        {
            int n = 3;
            var res = GenerateMatrix(n);
            UserPrintResult.Print2dArray(res);
        }
        static int[][] GenerateMatrix(int n)
        {
            int[][] result = new int[n][];
            for (int i = 0; i < n; i++)
            {
                result[i] = new int[n];
            }

            int top = 0, bottom = n - 1;
            int left = 0, right = n - 1;
            int numbering = 1;
            // Clockwise spiral
            while (top <= bottom && left <= right)
            {
                // left - right
                for (int i = left; i <= right; i++)
                {
                    result[top][i] = numbering++;
                }
                top++;
                // top - bottom
                for (int i = top; i <= bottom; i++)
                {
                    result[i][right] = numbering++;
                }
                right--;
                // right - left
                if (top <= bottom) // Avoid duplicate traverse
                {
                    for (int i = right; i >= left; i--)
                    {
                        result[bottom][i] = numbering++;
                    }
                    bottom--;
                }
                // bottom - top
                if (left <= right)
                {
                    for (int i = bottom; i >= top; i--)
                    {
                        result[i][left] = numbering++;
                    }
                    left++;
                }
            }

            return result;
        }






        private static void SpiralMatrix_54()
        {
            int[][] matrix = [[1, 2, 3, 4], [5, 6, 7, 8], [9, 10, 11, 12]]; //[1,2,3,4,8,12,11,10,9,5,6,7]
            //int[][] matrix = [[1, 2, 3], [4, 5, 6], [7, 8, 9]]; //[1,2,3,6,9,8,7,4,5]
            Console.WriteLine(string.Join(", ", SpiralOrder(matrix)));
        }
        /*Để di chuyển theo dạng spiral trong ma trận, bạn có thể sử dụng một vòng lặp while kết hợp với việc kiểm soát các biên của ma trận (trái, phải, trên, dưới).*/
        static IList<int> SpiralOrder(int[][] matrix)
        {
            List<int> result = new List<int>();

            int top = 0, bottom = matrix.Length - 1;
            int left = 0, right = matrix[0].Length - 1;

            while (top <= bottom && left <= right)
            {
                // Traverse left to right
                for (int i = left; i <= right; i++)
                {
                    result.Add(matrix[top][i]);
                }
                top++;

                // Traverse top to bottom
                for (int i = top; i <= bottom; i++)
                {
                    result.Add(matrix[i][right]);
                }
                right--;

                // Traverse right to left
                if (top <= bottom)// Avoid duplicate traverse
                {
                    for (int i = right; i >= left; i--)
                    {
                        result.Add(matrix[bottom][i]);
                    }
                    bottom--;
                }

                // Traverse bottom to top
                if (left <= right)
                {
                    for (int i = bottom; i >= top; i--)
                    {
                        result.Add(matrix[i][left]);
                    }
                    left++;
                }
            }

            return result;
        }
    }
}
