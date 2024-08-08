
namespace GraphGeneral
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Medium
            NumberOfIsland_200();

        }






        private static void NumberOfIsland_200()
        {
            char[][] grid = [
                              ['1','1','0','0','0'],
                              ['1','1','0','0','0'],
                              ['0','0','1','0','0'],
                              ['0','0','0','1','1']
                            ];
            /*char[][] grid = [
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
            int count = 0;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (memo[r, c] || grid[r][c] == '0') { continue; }

                    Queue<KeyValuePair<int,int>> queue = new Queue<KeyValuePair<int,int>>();
                    queue.Enqueue(new KeyValuePair<int,int>(r, c));
                    while (queue.Count > 0)
                    {
                        var point = queue.Dequeue();
                        int row = 0; int col = 0;
                        memo[row, col] = true;
                        for (int i = 0; i < 4; i++)
                        {
                            row = point.Key + dr[i]; col = point.Value + dc[i];
                            if (0 <= row && row < rows && 0 <= col && col < cols &&
                                grid[row][col] == '1' && !memo[row, col])
                            {
                                queue.Enqueue(new KeyValuePair<int, int>(row, col));
                                memo[row,col] = true;
                            }
                        }
                    }
                    count++;
                }
            }
            return count;
        }
    }
}
