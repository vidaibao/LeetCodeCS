

namespace Depth_Breadth_FirstSearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CourseSchedule_207();
            CourseSchedule2_210();

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
