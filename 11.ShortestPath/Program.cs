namespace _11.ShortestPath
{
    internal class Program
    {
        /*********************************************************************
        * <최단거리 탐색>
        * 
        * 1. 탐색할려는 정점부터 !!!!가장 최단거리의 정점탐색!!!!
        * 2. 탐색하는 정점을 거쳐서 더 거리가 짧아진 경우 더 짧은 거리로 대체한다
        *********************************************************************/



        /*********************************************************************
         * <다익스트라 알고리즘> (Dijkstra Agorithm)
         * 
         * 특정한 노드에서 출발하여 다른 노드로 가는 각각의 최단경로를 구함
         * 방문하지 않은 노드 중에서 최단 거리가 가장 짧은 노드를 선택 후,
         * 해당 노드를 거쳐 다른 노드로 가는 비용 계산
         * 시간복잡도 - 0(n²)
         *********************************************************************/

        const int INF = 999999;
        public static void Dijkstra(int[,] graph, int start, out bool[] visited, out int[] parent, out int[] distance)
        {
            // 데이터 셋팅
            int size = graph.GetLength(0);
            visited = new bool[size];
            parent = new int[size];
            distance = new int[size];

            for (int i = 0; i < size; i++)
            {
                visited[i] = false;
                parent[i] = -1;
                distance[i] = INF;
            }
            distance[start] = 0;

            for (int i = 0; i < size; i++)
            {
                // 1. 탐색하지 않은 정점 중 가장 가까운 정점부터 탐색
                int minIndex = -1;                // 다음으로 참색할 가장 가까운 정점
                int minCost = INF;                // 가장 가까운 정점 거리
                for (int j = 0; j < size; j++)
                {
                    if (!visited[j] &&            // 탐색하지 않았으면서
                        distance[j] < minCost)    // 가장 가까운 정점
                    {
                        minIndex = j;             // 더 짧은 거리의 정점이 있으면 변경
                        minCost = distance[j];    // 더 짧은 거리의 거리가 있으면 변경
                    }
                }
                if (minIndex < 0)    // 더이상 탐색할 정점이 없는 경우
                    break;           // 더이상 탐색하지 않음

                // 2. 직접연결된 거리보다 거쳐서 더 짧아지면 갱신
                for (var j = 0; j < size; ++j)
                {
                    // c - distance[j] : 목적지까지 직접 연결된 거리
                    // a - distance[minIndex] : 탐색중인 정점까지 거리
                    // b - graph[minInsex,j] : 탐색중인 정점부터 목적지 까지 거리
                    if (distance[j] > distance[minIndex] + graph[minIndex, j])        // 중간지점을 거쳐서 더 짧아지는 경우
                    {
                        distance[j] = distance[minIndex] + graph[minIndex, j];        // 중간지점을 거쳐서 나온 거리를 직접연결된 거리로 갱신
                        parent[j] = minIndex;                                         // 탐색한 정점(부모)을 갱신
                    }
                    visited[minIndex] = true;
                }
            }
        }



        static void Main(string[] args)
        {
            bool[] visited;
            int[] parent;
            int[] distance;

            int[,] graph = new int[8, 8]
            {
                {   0, INF, INF, INF,   1, INF, INF, INF },   // 0
                { INF,   0, INF,   5, INF, INF,   1, INF },   // 1
                { INF, INF,   0, INF,   6, INF,   9, INF },   // 2
                { INF,   5, INF,   0, INF,   4, INF,   9 },   // 3
                {   1, INF,   6, INF,   0, INF,   5,   8 },   // 4
                { INF, INF, INF,   4, INF,   0, INF,   7 },   // 5
                { INF,   1,   9, INF,   5, INF,   0,   2 },   // 6
                { INF, INF, INF,   9,   8,   7,   2,   0 },   // 7
            //     0     1    2    3    4    5    6    7
            };
            Dijkstra(graph, 0, out visited, out parent, out distance);
            PrintDijkstra(distance, parent);
        }



        private static void PrintDijkstra(int[] distance, int[] parent)
        {
            Console.Write("Visited");
            Console.Write("\t");
            Console.Write("distance");
            Console.Write("\t");
            Console.WriteLine("parent");

            for (int i = 0; i < distance.Length; i++)
            {
                Console.Write("{0,3}", i);
                Console.Write("\t");
                if (distance[i] >= INF)
                    Console.Write("INF");
                else
                    Console.Write("{0,3}", distance[i]);
                Console.Write("\t");
                if (parent[i] < 0)
                    Console.WriteLine("  X ");
                else
                    Console.WriteLine("{0,3 }", parent[i]);
            }
        }
    }
}