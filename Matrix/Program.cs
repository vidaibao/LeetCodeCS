
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
            //SpiralMatrix4_2326();
            //RotateImage_48();
            //SetMatrixZeroes_73();
            //GameOfLife_289();

        }

        private static void GameOfLife_289()
        {
            int[][] board = [[0, 1, 0], [0, 0, 1], [1, 1, 1], [0, 0, 0]]; // [[0,0,0],[1,0,1],[0,1,1],[0,1,0]]
            //int[][] board = [[0, 1, 0], [0, 0, 1], [1, 1, 1], [0, 0, 0]]; // [[0,0,0],[1,0,1],[0,1,1],[0,1,0]]
            UserPrintResult.Print2dArray(board);
            Console.WriteLine("--------------------");
            GameOfLife(board);
            UserPrintResult.Print2dArray(board);
        }
        static void GameOfLife(int[][] board)
        {
            int m = board.Length; int n = board[0].Length;
            bool[,] flip = new bool[m, n];
            int[] dr = [-1, -1, -1, 1, 1, 1, 0, 0]; // up, up-left, up-right, down, down-left, down-right, left, right : 8 neighbours
            int[] dc = [0, -1, 1, 0, -1, 1, -1, 1];
            //var neighbours = new List<int>();
            Func<int, int, (int, int)> NeighbourOf = (r, c) =>
            {
                int live = 0, dead = 0;
                for (int i = 0; i < 8; i++)
                {
                    int nr = r + dr[i], nc = c + dc[i];
                    if (0 <= nr && nr < m && 0 <= nc && nc < n)
                    {
                        if (board[nr][nc] == 1) live++;
                        else dead++;
                    }
                }
                return (live, dead);
            };

            for (int r = 0; r < m; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    var (live, dead) = NeighbourOf(r, c);
                    if (board[r][c] == 1) // live
                    {
                        if (live < 2 || live > 3) flip[r, c] = true; // under n over-population
                    }
                    else
                    {
                        if (live == 3) flip[r, c] = true;
                    }
                }
            }

            for (int r = 0; r < m; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    if (flip[r, c]) board[r][c] = board[r][c] == 1 ? 0 : 1;
                }
            }
        }



        private static void SetMatrixZeroes_73()
        {
            int[][] matrix = [[0, 1, 2, 0], [3, 4, 5, 2], [1, 3, 1, 5]]; // [[0,0,0,0],[0,4,5,0],[0,3,1,0]]
            //int[][] matrix = [[1, 1, 1], [1, 0, 1], [1, 1, 1]]; // [[1,0,1],[0,0,0],[1,0,1]]
            UserPrintResult.Print2dArray(matrix);
            Console.WriteLine("--------------------");
            SetZeroes(matrix);
            UserPrintResult.Print2dArray(matrix);
        }
        /*Use the first row and first column as markers.
        Traverse the matrix. Whenever a 0 is found, mark the corresponding first row and first column.
        Mark zeros based on the markers.
        Traverse the matrix again, setting elements to 0 if the corresponding row or column is marked.
        Handle the first row and first column separately.
        If there was an original 0 in the first row/column, set the entire first row/column to 0.
        This approach works with constant space, i.e., O(1), except for the markers.*/
        static void SetZeroes(int[][] matrix)
        {
            int m = matrix.Length; int n = matrix[0].Length;
            bool firstRowZero = false, firstColZero = false;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        if (i == 0) firstRowZero = true;
                        if (j == 0) firstColZero = true;
                        matrix[0][j] = 0; matrix[i][0] = 0;
                    }
                }
            }
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (matrix[i][0] == 0 || matrix[0][j] == 0) matrix[i][j] = 0;
                }
            }
            
            if (firstRowZero) Array.Fill(matrix[0], 0);

            if (firstColZero)
            {
                for (int i = 0; i < m; i++) matrix[i][0] = 0;
            }
        }






        private static void RotateImage_48()
        {
            int[][] matrix = [[1, 2, 3], [4, 5, 6], [7, 8, 9]]; // [[7,4,1],[8,5,2],[9,6,3]]
            UserPrintResult.Print2dArray(matrix);
            Console.WriteLine("--------------------");
            Rotate(matrix);
            UserPrintResult.Print2dArray(matrix);
        }
        static void Rotate(int[][] matrix)
        {
            int n = matrix.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    (matrix[i][j], matrix[j][i]) = (matrix[j][i], matrix[i][j]);
                }
            }
            for (int i = 0; i < n; i++)
            {
                Array.Reverse(matrix[i]);
            }
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
