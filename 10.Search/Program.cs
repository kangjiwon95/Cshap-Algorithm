using System.IO;

namespace _10.Search
{
    internal class Program
    {
        /********************************************************** 
         * <순차탐색>
         * 
         * 정렬이 안되어있는 자료구조에서 순차적으로 찾고자 하는 데이터를 탐색
         * 시간복잡도 0(n)
         **********************************************************/
        public static int SequentialSearch(IList<int> list , int item)
        { 
            for (int i = 0; i < list.Count; i++) 
            { 
                if (item == list[i])
                    return i;
            }
            return -1;
        }


        /********************************************************** 
        * <이진 탐색>
        * 
        * 정렬이 되어있는 자료구조에서 2분할을 통해 데이터를 탐색
        * 시간복잡도 0(Logn)
        **********************************************************/
        public static int BinarySearch(IList<int> list, int item)
        {
            int low = 0;
            int high = list.Count - 1;

            while (low <= high) 
            { 
                int middle = (low + high) / 2;

                if(item > list[middle])
                    low = middle + 1;
                else if (item < list[middle])
                    high = middle - 1;
                else
                    return middle;
            }
            return -1;
        }



        /********************************************************** 
        * <깊이 우선 탐색 (DFS : Depht-Fiest Search)>
        * 
        * 그래프의 분기를 만났을 때 최대한 깊이 내려간 뒤,
        * 더이상 깊이 갈 곳이 없을 경우 다음 분기를 탐색
        * 븐할 정복을 통해서 구성
        * 스택을 이용해서 구현
        * 최단경로 우선 아닐수 있다
        **********************************************************/
        public static void DFS(bool[,]graph , int start, out bool[] visited, out int[] parent)
        {
            // boll[,] graph = new bool[2,7]   
            //            GetLenght(0) = 2         앞자리
            //            GetLenght(1) = 7         뒷자리
            visited = new bool[graph.GetLength(0)];
            parent = new int[graph.GetLength(0)];

            for (int i = 0; i < graph.GetLength(0) ; i++)
            {
                visited[i] = false;
                parent[i] = -1;
            }

            SearchNode(graph, start, visited, parent);
        }
        private static void SearchNode(bool[,] graph, int start, bool[] visited, int[] parent)
        {
            visited[start] = true;
            for (int i = 0;i < graph.GetLength(0);i++)
            {
                if (graph[start, i] && // 연결되어 있는 정점  &&
                        !visited[i])   // 방문한적 없는 정점
                {
                    parent[i] = start;   
                    SearchNode(graph, i, visited, parent); 
                }
            }
        }


        // 스택으로 DFS 구현
         public static void DFS2(bool[,] graph, int start, out bool[] visited, out int[] parent)
        {
            visited = new bool[graph.GetLength(0)];
            parent = new int[graph.GetLength(0)];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                visited[i] = false;
                parent[i] = -1;
            }
            Stack<int> dfsStack = new Stack<int>();
            dfsStack.Push(start);
            visited[start] = true;

            while (dfsStack.Count > 0)
            {
                start = dfsStack.Peek();
                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if (!visited[i] && graph[start, i])
                    {
                        dfsStack.Push(i);
                        visited[i] = true;
                        parent[i] = start;
                        break;
                    }
                    if (i == graph.GetLength(0) - 1)
                        dfsStack.Pop();
                }

            }
        }


        /********************************************************** 
        * <너비 우선 탐색 (BFS : Breadth-First Search)>
        * 
        * 그래프의 분기를 만났을 때 모든 분기를 한번씩 탐색한 뒤,
        * 다음 깊이를 탐색하는 방식
        * 큐를 이용하여 구현
        * 반드시 최단경로
        **********************************************************/
        public static void BFS(bool[,] graph, int start, out bool[] visited, out int[] parent)
        {
            visited = new bool[graph.GetLength(0)];
            parent = new int[graph.GetLength(0)];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                visited[i] = false;
                parent[i] = -1;
            }
            Queue<int> bfsQueue = new Queue<int>();

            bfsQueue.Enqueue(start);
            while(bfsQueue.Count > 0) 
            {
                int next = bfsQueue.Dequeue();
                visited[next] = true;

                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if (graph[next, i] &&
                            !visited[i])
                    {
                        parent[i] = next;
                        bfsQueue.Enqueue(i);
                    }
                }
            }
        }





        static void Main(string[] args)
        {
            
        }
    }
}