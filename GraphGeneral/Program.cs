

using System.Collections;

namespace GraphGeneral
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Medium
            //NumberOfIsland_200();
            SurroundedRegions_130();

        }

        private static void SurroundedRegions_130()
        {

            char[][] board = [
                                ['O', 'X', 'O', 'O', 'O', 'O', 'O', 'O', 'O'], 
                                ['O', 'O', 'O', 'X', 'O', 'O', 'O', 'O', 'X'], 
                                ['O', 'X', 'O', 'X', 'O', 'O', 'O', 'O', 'X'], 
                                ['O', 'O', 'O', 'O', 'X', 'O', 'O', 'O', 'O'], 
                                ['X', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'X'], 
                                ['X', 'X', 'O', 'O', 'X', 'O', 'X', 'O', 'X'], 
                                ['O', 'O', 'O', 'X', 'O', 'O', 'O', 'O', 'O'], 
                                ['O', 'O', 'O', 'X', 'O', 'O', 'O', 'O', 'O'],
                                ['O', 'O', 'O', 'O', 'O', 'X', 'X', 'O', 'O']
                            ];
            /*
            char[][] board = [
                              ['X','X','X','X'],
                              ['X','O','O','X'],
                              ['X','X','O','X'],
                              ['X','O','X','X']
                            ];
            */
            for (int i = 0; i < board.Length; i++)
                Console.WriteLine(string.Join(", ", board[i]));
            Console.WriteLine("============ Solve(board) ============");
            Solve(board);
            for (int i = 0; i < board.Length; i++)
                Console.WriteLine(string.Join(", ", board[i]));
        }
        static void Solve(char[][] board)
        {
            int rows = board.Length; int cols = board[0].Length;
            var queue = new Queue<KeyValuePair<int,int>>();
            var regions = new List<List<KeyValuePair<int, int>>>();
            int[] dr = [-1, 1, 0, 0]; int[] dc = [0, 0, -1, 1];
            bool[,] memo = new bool[rows, cols];
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if ((board[r][c] == 'X' || memo[r, c]) ||
                        (board[r][c] == 'O' && (r == 0 || r == rows - 1 || c == 0 || c == cols - 1))) continue;

                    var cell = new KeyValuePair<int, int>(r, c);
                    queue.Enqueue(cell);
                    var surroundedCells = new List<KeyValuePair<int, int>>();
                    surroundedCells.Add(cell);
                    memo[r, c] = true; 
                    bool unableBound = false;
                    while (queue.Count > 0)
                    {
                        var ce = queue.Dequeue();
                        for (int i = 0; i < 4; i++)
                        {
                            int row = ce.Key + dr[i]; int col = ce.Value + dc[i];
                            if (board[row][col] == 'O' && (row == 0 || row == rows - 1 || col == 0 || col == cols - 1))
                            {
                                unableBound = true;
                            }
                            else if (1 <= row && row < rows - 1 && 1 <= col && col < cols - 1 && board[row][col] == 'O' && !memo[row, col])
                            {
                                queue.Enqueue(new KeyValuePair<int, int>(row, col));
                                surroundedCells.Add(new KeyValuePair<int, int>(row, col));
                                memo[row, col] = true;
                            }
                        }
                    }
                    if (!unableBound)
                    { 
                        regions.Add(surroundedCells.ToList());
                    }
                    queue.Clear();
                    surroundedCells.Clear();
                }
            }
            // 
            foreach (var cells in regions)
            {
                foreach (var ce in cells)
                {
                    board[ce.Key][ce.Value] = 'X';
                }
            }
        }





        private static void NumberOfIsland_200()
        {
            char[][] grid = [
                              ['1','1','0','0','0'],
                              ['1','1','0','0','0'],
                              ['0','0','1','0','0'],
                              ['0','0','0','1','1']
                            ];
            /*
            char[][] grid = [
                              ['1','1','1','1','0'],
                              ['1','1','0','1','0'],
                              ['1','1','0','0','0'],
                              ['0','0','0','0','0']
                            ];
            */
            Console.WriteLine(NumIslands(grid));
        }
        static int NumIslands(char[][] grid)
        {
            int rows = grid.Length; int cols = grid[0].Length;
            int[] dr = [-1, 1, 0, 0]; int[] dc = [0, 0, -1, 1];
            bool[,] memo = new bool[rows, cols];
            int islands = 0;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (memo[r, c] || grid[r][c] == '0') { continue; }

                    Queue<KeyValuePair<int,int>> queue = new Queue<KeyValuePair<int,int>>();
                    queue.Enqueue(new KeyValuePair<int,int>(r, c));
                    memo[r, c] = true;
                    while (queue.Count > 0)
                    {
                        var point = queue.Dequeue();
                        for (int i = 0; i < 4; i++)
                        {
                            int row = point.Key + dr[i]; int col = point.Value + dc[i];
                            if (0 <= row && row < rows && 0 <= col && col < cols &&
                                grid[row][col] == '1' && !memo[row, col])
                            {
                                queue.Enqueue(new KeyValuePair<int, int>(row, col));
                                memo[row,col] = true;
                            }
                        }
                    }
                    islands++;
                }
            }
            return islands;
        }
    }
}
