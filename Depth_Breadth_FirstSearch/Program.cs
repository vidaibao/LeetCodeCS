

using System.Drawing;

namespace Depth_Breadth_FirstSearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //============= EASY =================
            //FloodFill_733();




            //============= MEDIUM =================
            //CourseSchedule_207();
            //CourseSchedule2_210();
            //IslandPerimeter_463();
            //MaxAreaOfIsland_695();
            //ColoringABorder_1034();
            //MaximumNumberOfFishInAGrid_2658();
            //SnakesAndLadders_909();
            RemoveInvalidParentheses_301();

        }

        private static void RemoveInvalidParentheses_301()
        {
            string s = "(a)())()"; // ["(a())()","(a)()()"]
            //string s = "()())()"; // ["(())()","()()()"]
            //string s = ")("; // [""]
            //string s = "))("; // [""]
            var res = RemoveInvalidParentheses_DFS(s);
            //var res = RemoveInvalidParentheses(s);
            Console.WriteLine(string.Join(", ", res));
        }
        /*Given a string s that contains parentheses and letters, remove the minimum number of invalid parentheses to make the input string valid.
        Return a list of unique strings that are valid with the minimum number of removals. You may return the answer in any order.*/
        static IList<string> RemoveInvalidParentheses_DFS(string s)
        {
            var result = new HashSet<string>();
            int leftRem = 0, rightRem = 0;

            // First, find out how many left and right parentheses need to be removed
            foreach (var c in s)
            {
                if (c == '(')
                {
                    leftRem++;
                }
                else if (c == ')')
                {
                    if (leftRem > 0)
                    {
                        leftRem--;
                    }
                    else
                    {
                        rightRem++;
                    }
                }
            }

            // Call the recursiveDFS helper function
            DFS(s, 0, leftRem, rightRem, result);

            return new List<string>(result);
        }
        private static void DFS(string s, int start, int leftRem, int rightRem, HashSet<string> result)
        {
            // If no more parentheses need to be removed, check if the string is valid
            if (leftRem == 0 && rightRem == 0)
            {
                if (IsValidDFS(s)) result.Add(s);
                return;
            }

            // Iterate through the string and try removing each parenthesis
            for (int i = 0; i < s.Length; i++)
            {
                // Avoid duplicate removals
                if (i != start && s[i] == s[i - 1]) continue;

                // If it's a parenthesis, try to remove it
                if (s[i] == '(' || s[i] == ')')
                {
                    string next = s.Substring(0, i) + s.Substring(i + 1);

                    // Recurse
                    if (rightRem > 0 && s[i] == ')')
                    {
                        DFS(next, i, leftRem, rightRem - 1, result);
                    }
                    else if (leftRem > 0 && s[i] == '()')
                    {
                        DFS(next, i, leftRem - 1, rightRem, result);
                    }
                }
            }
        }
        private static bool IsValidDFS(string s)
        {
            int stack = 0;
            foreach (char c in s)
            {
                if (c == '(')
                {
                    stack++;
                }
                else if (c == ')')
                {
                    if (stack == 0) return false;
                    stack--;
                }
            }
            return stack == 0;
        }

        static IList<string> RemoveInvalidParentheses_DFS00(string s) // error Gemini
        {
            var result = new List<string>();
            Remove(s, 0, 0, 0, result);
            return result;
        }
        private static void Remove(string s, int start, int last_i, int last_j, IList<string> res)
        {
            for (int stack = 0, i = start; i < s.Length; ++i)
            {
                if (s[i] == '(') stack++;
                else if (s[i] == ')') stack--;
                if (stack >= 0) continue; // valid
                for (int j = last_j; j <= i; ++j)
                    if (s[j] == ')' && (j == last_j || s[j - 1] != ')'))
                        Remove(s.Substring(0, j) + s.Substring(j + 1), i, i, j, res);
                return;
            }
            string reversed = new string(s.Reverse().ToArray());
            if (start == 0) reversed = new string(reversed.Reverse().ToArray());
            if (res.Contains(reversed)) return;
            res.Add(reversed);
        }

        static IList<string> RemoveInvalidParentheses_BFS(string s)
        {
            var result = new List<string>();
            if (string.IsNullOrEmpty(s)) return new List<string> { "" };

            var queue = new Queue<string>();
            var visited = new HashSet<string>();
            queue.Enqueue(s);
            visited.Add(s);
            bool foundValid = false;

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                //var levelVisited = new HashSet<string>();
                for (int i = 0; i < levelSize; i++)
                {
                    string current = queue.Dequeue();
                    if (IsValid(current))
                    {
                        result.Add(current);
                        foundValid = true;
                    }
                    if (foundValid) continue;

                    // Generate all possible states
                    for (int j = 0; j < current.Length; j++)
                    {
                        if (current[j] != '(' && current[j] != ')') continue;
                        string next = current.Substring(0, j) + current.Substring(j + 1);
                        if (!visited.Contains(next))
                        {
                            queue.Enqueue(next);
                            visited.Add(next);
                        }
                    }
                }
                if (foundValid) break; // Stop BFS when the first valid string is found
            }

            return result;
        }

        // Helper function to check if a string is valid
        private static bool IsValid(string s)
        {
            int stack = 0; // ^-^
            foreach (char c in s)
            {
                if (c == '(') stack++;
                if (c == ')') stack--;
                if (stack < 0) return false; // More closing brackets than opening
            }
            return stack == 0;
        }
        static IList<string> RemoveInvalidParentheses_BFS00(string s) // (a()) IsValid00 method
        {
            var result = new List<string>();
            if (string.IsNullOrEmpty(s) || s.Length <= 1)  return result;

            var queue = new Queue<string>();
            var visited = new HashSet<string>(); // track visited strings and avoid processing the same string multiple times
            queue.Enqueue(s);
            visited.Add(s);
            bool foundValid = false;

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                //var levelVisited = new HashSet<string>();
                for (int i = 0; i < levelSize; i++)
                {
                    string current = queue.Dequeue();
                    if (IsValid(current))
                    {
                        result.Add(current);
                        foundValid = true;
                    }
                    if (foundValid) continue;

                    // Generate all possible states
                    for (int j = 0; j < current.Length; j++)
                    {
                        //if (current[j] != '(' && current[j] != ')') continue;
                        if (char.IsLetter(current[j])) continue; // ( and ) are not considered letters
                        string next = current.Substring(0, j) + current.Substring(j + 1);
                        if (next != "" && !visited.Contains(next))
                        {
                            queue.Enqueue(next);
                            visited.Add(next);
                        }
                    }
                }
                if (foundValid) break; // Stop BFS when the first valid string is found
            }

            return result;
        }

        private static bool IsValid00(string s) // got error when checking )( ??? 
        {
            if (s == null || s.Length <= 1) return false;

            var stack = new Stack<char>();
            foreach (char c in s)
            {
                if (c == '(')
                    stack.Push(c);
                else
                {
                    if (stack.Count == 0) return false; // more close than openning parentheses
                    char top = stack.Pop();
                    if (c == ')' && top != '(')
                        return false;
                }
            }
            return stack.Count == 0;
        }






        private static void SnakesAndLadders_909()
        {
            int[][] board = [[-1, -1, -1, -1, -1, -1], [-1, -1, -1, -1, -1, -1], [-1, -1, -1, -1, -1, -1], [-1, 35, -1, -1, 13, -1], [-1, -1, -1, -1, -1, -1], [-1, 15, -1, -1, -1, -1]]; // 4
            Console.WriteLine(SnakesAndLadders(board));
        }
        static int SnakesAndLadders(int[][] board)
        {
            int n = board.Length;
            var linearBoard = new int[n * n + 1];
            var visited = new bool[n * n + 1];
            int idx = 1; 
            bool leftToRight = true;

            // Convert 2D to 1D array
            for (int r = n - 1; r >= 0; r--)
            {
                if (leftToRight)
                {
                    for (int c = 0; c < n; c++)
                        linearBoard[idx++] = board[r][c];
                }
                else
                {
                    for (int c = n - 1; c >= 0; c--)
                        linearBoard[idx++] = board[r][c];
                }
                leftToRight = !leftToRight;
            }

            idx = 1;
            var queue = new Queue<int>();
            queue.Enqueue(idx);
            visited[idx] = true;
            int moves = 0;

            // BFS to find the shortest path to the last square
            while (queue.Count > 0)
            {
                int size = queue.Count; // possible each move
                for (int i = 0; i < size; i++)
                {
                    int curr = queue.Dequeue();
                    if (curr == n*n) return moves;
                    for (int dice = 1; dice <= 6; dice++) // 6-sided die roll
                    {
                        // next with a label in the range [curr + 1, min(curr + 6, n2)]
                        int next = curr + dice;
                        if (next > n*n) continue;
                        if (linearBoard[next] != -1) next = linearBoard[next];
                        if (!visited[next])
                        {
                            visited[next] = true;
                            queue.Enqueue(next);
                        }
                    }
                }
                moves++;
            }

            return -1;
        }
        static int SnakesAndLadders00(int[][] board)
        {
            int n = board.Length;
            var visited = new bool[n, n];
            int[] dr = [0, -1, 0, -1], dc = [1, 0, -1, 0]; // right up left up 
            int[] direct = new int[n * n + 1]; // first move is to right
            //int count = 1, direction = 0, step = 0; 
            int rStart = n - 1, cStart = 0;

            for (int r = n - 1; r >= 0; r--)
            {
                for (int c = 0; c < n; c++)
                {

                }
            }

            /*
            while (count <= n * n)
            {
                if (direction == 0 || direction == 2) step = n - 1;
                else step = 1;

                for (int i = 0; i < step; i++)
                {
                    



                }



                direction = (direction + 1) % 4;
                count++;
            }
            */
            var queue = new Queue<(int, int)>();
            queue.Enqueue((rStart, cStart));
            visited[rStart, cStart] = true;
            while (queue.Count > 0)
            {
                var (r, c) = queue.Dequeue();
                //int nr = r + dr[direction]; int nc = c + dc[direction];


            }




            return 0;
        }






        private static void MaximumNumberOfFishInAGrid_2658()
        {
            int[][] grid = [[0, 2, 1, 0], [4, 0, 0, 3], [1, 0, 0, 4], [0, 3, 2, 0]];
            Console.WriteLine(FindMaxFish(grid));
        }
        static int FindMaxFish(int[][] grid)
        {
            int maxFish = 0, fish = 0;
            int H = grid.Length, W = grid[0].Length;
            bool[,] visited = new bool[H, W];
            int[] dr = [-1, 1, 0, 0]; // up down left right
            int[] dc = [0, 0, -1, 1];

            for (int r = 0; r < H; r++)
            {
                for (int c = 0; c < W; c++)
                {
                    if (visited[r, c] || grid[r][c] == 0) { continue; }

                    var queue = new Queue<(int,int)>();
                    queue.Enqueue((r, c));
                    fish = grid[r][c];
                    visited[r, c] = true;

                    while (queue.Count > 0)
                    {
                        var (row, col) = queue.Dequeue();
                        for (int i = 0; i < 4; i++)
                        {
                            int nr = row + dr[i]; int nc = col + dc[i];
                            if (0 <= nr && nr < H && 0 <= nc && nc < W && !visited[nr, nc] && grid[nr][nc] != 0)
                            {
                                queue.Enqueue((nr, nc));
                                visited[nr, nc] = true;
                                fish += grid[nr][nc];
                            }
                        }
                    }

                    if (fish > maxFish) maxFish = fish;
                }
            }

            return maxFish;
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
