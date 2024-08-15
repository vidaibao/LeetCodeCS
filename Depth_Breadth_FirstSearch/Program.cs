

using System.Drawing;

namespace Depth_Breadth_FirstSearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //============= EASY =================
            FloodFill_733();




            //============= MEDIUM =================
            //CourseSchedule_207();
            //CourseSchedule2_210();
            //IslandPerimeter_463();
            //MaxAreaOfIsland_695();
            //ColoringABorder_1034();

        }






        private static void FloodFill_733()
        {
            int[][] image = [[1, 1, 1], [1, 1, 0], [1, 0, 1]]; int sr = 1, sc = 1, color = 2;
            var res = FloodFill(image, sr, sc, color);
            foreach ( var r in res )
            {
                Console.WriteLine(string.Join(", ", r));
            }
        }
        static int[][] FloodFill(int[][] image, int sr, int sc, int color)
        {
            int H = image.Length; int W = image[0].Length;
            var visited = new bool[H, W];
            int[] dr = [-1, 1, 0, 0];
            int[] dc = [0, 0, -1, 1];

            var queue = new Queue<(int, int)>();
            queue.Enqueue((sr, sc));
            int originalColor = image[sr][sc];
            image[sr][sc] = color;
            visited[sr, sc] = true;

            while (queue.Count > 0)
            {
                var (r, c) = queue.Dequeue();
                for ( var i = 0; i < 4; i++ )
                {
                    int nr = r + dr[i]; int nc = c + dc[i];
                    if (0 <= nr && nr < H && 0 <= nc && nc < W && image[nr][nc] == originalColor && !visited[nr, nc])
                    {
                        visited[nr, nc] = true;
                        image[nr][nc] = color;
                        queue.Enqueue((nr, nc));
                    }
                }
            }

            return image;
        }






        private static void ColoringABorder_1034()
        {
            int[][] grid = [[1, 1, 1], [1, 1, 1], [1, 1, 1]]; int row = 1, col = 1, color = 2; //[[2,2,2],[2,1,2],[2,2,2]]]
            //int[][] grid = [[1, 2, 2], [2, 3, 2]]; int row = 0, col = 1, color = 3; //[[1,3,3],[2,3,3]]
            //int[][] grid = [[1, 1], [1, 2]]; int row = 0, col = 0, color = 3;// [[3,3],[3,2]]
            var res = ColorBorder(grid, row, col, color);
            foreach ( var r in res )
            {
                Console.WriteLine(string.Join(", ", r));
            }
        }
        static int[][] ColorBorder(int[][] grid, int row, int col, int color)
        {
            int H = grid.Length; int W = grid[0].Length;
            bool[,] visited = new bool[H, W];
            int originalColor = grid[row][col];
            var borderCells = new List<(int, int)>();
            int[] dr = [-1, 1, 0, 0]; 
            int[] dc = [0, 0, -1, 1];

            var queue = new Queue<(int, int)>();
            queue.Enqueue((row, col));
            visited[row, col] = true;

            while ( queue.Count > 0 )
            {
                var (r, c) = queue.Dequeue();
                bool isBorder = false;

                for (int i = 0; i < 4; i++)
                {
                    int nr = r + dr[i]; int nc = c + dc[i];
                    // adjacent to (at least) a square not in the component, or on the boundary of the grid (the first or last row or column).
                    if (nr < 0 || nr >= H || nc < 0 || nc >= W || grid[nr][nc] != originalColor)
                    {
                        isBorder = true;
                    }
                    else if (!visited[nr, nc])
                    {
                        queue.Enqueue((nr, nc));
                        visited[nr, nc] = true;
                    } 
                }

                if (isBorder)
                {
                    borderCells.Add((r, c));
                }
            }

            foreach (var (r, c) in borderCells)
            {
                grid[r][c] = color;
            }

            return grid;
        }
        static int[][] ColorBorder00(int[][] grid, int row, int col, int color)
        {
            int H = grid.Length; int W = grid[0].Length;
            bool[,] memo = new bool[H, W];

            var p = new System.Drawing.Point(col, row);
            var queue = new Queue<System.Drawing.Point>();
            queue.Enqueue(p);
            int pColor = grid[row][col]; memo[row, col] = true;
            int[] dr = [-1, 1, 0, 0]; int[] dc = [0, 0, -1, 1];

            while (queue.Count > 0)
            {
                p = queue.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int r = p.Y + dr[i]; int c = p.X + dc[i];
                    if (0 <= r && r < H && 0 <= c && c < W && grid[r][c] == pColor && !memo[r, c])
                    {
                        queue.Enqueue(new System.Drawing.Point(c, r));
                        memo[r, c] = true;
                        grid[r][c] = color;
                    }
                }
            }

            return grid;
        }






        private static void MaxAreaOfIsland_695()
        {
            int[][] grid = [[0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0], [0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0], [0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0], [0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0], [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0], [0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0]];//6
            Console.WriteLine(MaxAreaOfIsland(grid));
        }
        static int MaxAreaOfIsland(int[][] grid)
        {
            int H = grid.Length; int W = grid[0].Length;
            bool[,] memo = new bool[H, W];
            int[] dr = [-1, 1, 0, 0]; int[] dc = [0, 0, -1, 1];
            int maxArea = 0;

            for (int r = 0; r < H; r++)
            {
                for (int c = 0; c < W; c++)
                {
                    if (grid[r][c] == 0 || memo[r, c]) continue;

                    var p = new Point(c, r);
                    var queue = new Queue<Point>();
                    queue.Enqueue(p);
                    int area = 1;
                    memo[r, c] = true;

                    while (queue.Count > 0)
                    {
                        p = queue.Dequeue();
                        for (int i = 0; i < 4; i++)
                        {
                            int row = p.Y + dr[i];
                            int col = p.X + dc[i];
                            if (0 <= row && row < H && 0 <= col && col < W && grid[row][col] == 1 && !memo[row, col])
                            {
                                area++;
                                memo[row, col] = true;
                                queue.Enqueue(new Point(col, row));
                            }
                        }
                    }
                    if (area > maxArea) { maxArea = area; }
                }
            }

            return maxArea;
        }





        private static void IslandPerimeter_463()
        {
            int[][] grid = [[1]];//4
            //int[][] grid = [[0, 1, 0, 0], [1, 1, 1, 0], [0, 1, 0, 0], [1, 1, 0, 0]];//16
            Console.WriteLine(IslandPerimeter(grid));
        }
        static int IslandPerimeter(int[][] grid)
        {
            int perimeter = 0;
            int[] dr = [-1, 1, 0, 0]; int[] dc = [0, 0, -1, 1];
            int H = grid.Length; int W = grid[0].Length;
            for (int r = 0; r < H; r++)
            {
                for (int c = 0; c < W; c++)
                {
                    //Point p = new Point(c, r);
                    if (grid[r][c] == 0) continue;

                    for (int i = 0; i < 4; i++)
                    {
                        int row = r + dr[i]; int col = c + dc[i];
                        if ((0 <= row && row < H && 0 <= col && col < W && grid[row][col] == 0) ||
                            (row == -1 || row == H || col == -1 || col == W))
                        {
                            perimeter++;
                        }
                    }
                }
            }

            return perimeter;
        }





        private static void CourseSchedule2_210()
        {
            int numCourses = 4; int[][] prerequisites = [[1, 0],[2, 0],[3, 1],[3, 2]];//[0,2,1,3]
            //int numCourses = 2; int[][] prerequisites = [[1, 0]];//[0,1]
            Console.WriteLine(string.Join(", ", FindOrder(numCourses, prerequisites)));
        }
        private static int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            if (numCourses == 1) return new int[] { 0 };

            // Topological Sort
            var order = new List<int>();
            var graph = new List<int>[numCourses];
            int[] indegree = new int[numCourses];
            for (int i = 0; i < numCourses; i++)
                graph[i] = new List<int>();

            foreach (var pre in prerequisites)
            {
                graph[pre[1]].Add(pre[0]);
                indegree[pre[0]]++;//number of prerequisites of the course
            }

            var queue = new Queue<int>(); 
            // NO NEED prerequisites courses to queue
            for (int i = 0; i < numCourses; i++)
            {
                if (indegree[i] == 0) queue.Enqueue(i);
            }

            // BFS
            while (queue.Count > 0)
            {
                int course = queue.Dequeue();
                order.Add(course);

                foreach (var next in graph[course])
                {
                    indegree[next]--;
                    if (indegree[next] == 0)
                    {
                        queue.Enqueue(next);
                    }
                }
            }

            return order.Count == numCourses ? order.ToArray() : new int[0];
        }





        private static void CourseSchedule_207()
        {
            int numCourses = 2;
            int[][] prerequisites = [[1, 0]];
            Console.WriteLine(CanFinish(numCourses, prerequisites));
        }
        static bool CanFinish(int numCourses, int[][] prerequisites)
        {
            if (numCourses == 1 || prerequisites.Length == 0) return true;

            List<int>[] graph = new List<int>[numCourses];
            for (int i = 0; i < numCourses; i++)
            {
                graph[i] = new List<int>();
            }
            // course status: 0 not yet; 1 visiting (cycle); 2 visited but no cycle
            int[] visit = new int[numCourses];

            foreach (var pre in prerequisites)
            {
                graph[pre[1]].Add(pre[0]);
            }

            for (int i = 0; i < numCourses; i++)
            {
                // DFS for checking cycle
                if (HasCycle(i, graph, visit)) return false;
            }

            return true;
        }
        private static bool HasCycle(int course, List<int>[] graph, int[] visit)
        {
            if (visit[course] == 1) return true;
            if (visit[course] == 2) return false;

            visit[course] = 1;//visiting
            foreach (var next in graph[course])
            {
                if (HasCycle(next, graph, visit)) return true;
            }

            visit[course] = 2;//visited
            return false;
        }

    }
}
