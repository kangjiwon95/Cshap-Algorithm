using System.Drawing;

namespace _12._Astar
{
    internal class AStar
    {

        /*******************************************************
         * <A-star(A*) 알고리즘>
         * 
         * 다익스트라 알고리즘을 확장하여 만든 최단경로탐색 알고리즘
         * 경로 탐색의 우선순위를 두고 유망한 해부터 우선적으로 탐색
         *******************************************************/
        // F : G + H = 총 예상거리 , 최종점수
        // G : 지금까지 이동한 거리
        // H : 예상 거리
        // H(Heuric Stick) : 길찾기 알고리즘의 효율이 달라진다.
        // 휴리스틱 종류 : 1. 유클리드 거리 (Euclidean distance)
        //                2. 맨해튼 거리   (Manhattan distance)

        // 탐색 우선순위
        // (F == F) F 값이 똑같다면
        // (G >> G) G 값이 더 큰쪽을 먼저 탐색

        const int CostStraight = 10;
        const int CostDiagonal = 14;

        public static Point[] Direction =
        {
                       new Point(  0, +1 ),                 // 상
                       new Point(  0, -1 ),                 // 하
                       new Point( -1,  0 ),                 // 좌
                       new Point( +1,  0 ),                 // 우
                       new Point( -1, +1 ),                 // 좌상
                       new Point( -1, -1 ),                 // 좌하
                       new Point( +1, +1 ),                 // 우상
                       new Point( +1, -1 ),                 // 우하
        };

        public static bool PathFinding(in bool[,] tileMap, in Point start, in Point end, in bool cross, out List<Point> path)
        {
            int ySize = tileMap.GetLength(0);
            int xSize = tileMap.GetLength(1);

            ASNode[,] nodes = new ASNode[ySize, xSize];
            bool[,] visited = new bool[ySize, xSize];
            PriorityQueue<ASNode, int> nextPointPQ = new PriorityQueue<ASNode, int>();

            // 0. 시작 정점을 생성하여 추가
            ASNode startNode = new ASNode(start, new Point(), 0 , Heuristic(start, end));
            nodes[startNode.point.y, startNode.point.x] = startNode;
            nextPointPQ.Enqueue(startNode, startNode.f);

            while (nextPointPQ.Count > 0)
            {
                // 1. 다음으로 탐색할 정점 꺼내기
                ASNode nextNode = nextPointPQ.Dequeue();

                // 2. 방문한 정점은 방문표시
                visited[nextNode.point.y, nextNode.point.x] = true;

                // 3. 다음으로 탐색할 정점이 도착지인 경우
                // 도착했다고 판단해서 경로 반환
                if (nextNode.point.x == end.x && nextNode.point.y == end.y)
                {
                    path = new List<Point>();

                    Point point = end;
                    while(!(point.x == start.x && point.y ==  start.y))
                    {
                        path.Add(point);
                        point = nodes[point.y, point.x].parent;
                    }
                    path.Add(start);

                    path.Reverse();
                    return true;
                }

                // 4. AStar 탐색을 진행
                // 반향 탐색
                for (int i = 0; i < Direction.Length; i++)
                {
                    int x = nextNode.point.x + Direction[i].x;
                    int y = nextNode.point.y + Direction[i].y;

                    // 4-1. 탐색하면 안되는 경우
                    // 맵을 벗어났을 경우
                    if (x < 0 || x >= xSize || y < 0 || y >= ySize)
                        continue;
                    // 탐색할 수 없는 정점일 경우
                    else if (tileMap[y, x] == false)
                        continue;
                    // 이미 방문한 정점일 경우
                    else if (visited[y, x])
                        continue;
                    // 대각선으로 이동이 불가능 지역인 경우
                    else if (i >= 4)
                    {
                        if (!tileMap[y, nextNode.point.x] && !tileMap[nextNode.point.y, x])
                            continue;
                        if (cross && tileMap[y, nextNode.point.x] ^ tileMap[nextNode.point.y, x])
                            continue;
                    }

                    // 4-2. 탐색한 정점 만들기
                    int g = nextNode.g + ((nextNode.point.x == x || nextNode.point.y == y) ? CostStraight : CostDiagonal);
                    int h = Heuristic(new Point(x, y), end);
                    ASNode newNode = new ASNode(new Point(x, y), nextNode.point, g, h);

                    // 4-3. 정점의 갱신이 필요한 경우 새로운 정점으로 할당
                    if (nodes[y, x] == null ||       // 탐색하지 않은 정점이거나
                        nodes[y, x].f > newNode.f)   // 가중치가 높은 정점인 경우
                    {
                        nodes[y, x] = newNode;
                        nextPointPQ.Enqueue(newNode, newNode.f);
                    }
                }
            }

            path = null;
            return false;
        }


        


        // 휴리스틱 (Heuristic) : 최상의 경로를 추정하는 순위 값, 휴리스틱에 의해 경로탐색 효율이 결정된다.
        public static int Heuristic(Point start, Point end)
        {
            int xSize = Math.Abs(start.x - end.x);  // 가로로 가야하는 횟수
            int ySize = Math.Abs(start.y - end.y);  // 세로로 가야하는 횟수

            // 맨해튼 거리   : 직선을 통해 이동하는 거리
            // return CostStraight * (xSize + ySize);

            // 유클리드 거리 : 대작선을 통해 이동하는 거리
            // return CostStraight * (int)Math.Sqrt(xSize * xSize + ySize * ySize)

            // 타일맵용 유클리드 거리 : 직선과 대각선을 통해 이동하는 거리
            int straightCount = Math.Abs(xSize - ySize);
            int diagonalCount = Math.Max(xSize, ySize) - straightCount;
            return CostStraight * straightCount + CostDiagonal * diagonalCount;
        }


        private class ASNode
        {
            public Point point;        // 현재 정점 생성
            public Point parent;       // 현재 정점을 탐색한 정점

            public int g;              // 현재까지의 값, 즉 지금까지 경로 가중치
            public int h;              // 앞으로 예상되는 값, 목표까지 추정 경로 가중치
            public int f;              // f(x) = g(x) +h(x) 도착정점까지의 총 경로 가중치


            public ASNode(Point point, Point parent, int g, int h)
            {
                this.point = point;
                this.parent = parent;
                this.g = g;
                this.h = h;
                this.f = g + h;
            }
        }
        static void Main(string[] args)
        {
            bool[,] tileMap = new bool[9, 9]
            {
                { false, false, false, false, false, false, false, false, false },
                { false,  true,  true,  true, false, false, false,  true, false },
                { false,  true, false,  true, false, false, false,  true, false },
                { false,  true, false,  true,  true,  true,  true,  true, false },
                { false,  true, false,  true, false,  true,  true,  true, false },
                { false,  true, false,  true, false,  true,  true,  true, false },
                { false, false, false, false, false, false, false,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true, false },
                { false, false, false, false, false, false, false, false, false },
            };

            AStar.PathFinding(tileMap, new Point(1, 1), new Point(1, 7), true, out List<Point> path);
            PrintResult(tileMap, path);
        }

        static void PrintResult(in bool[,] tileMap, in List<Point> path)
        {
            char[,] pathMap = new char[tileMap.GetLength(0), tileMap.GetLength(1)];
            for (int y = 0; y < pathMap.GetLength(0); y++)
            {
                for (int x = 0; x < pathMap.GetLength(1); x++)
                {
                    if (tileMap[y, x])
                        pathMap[y, x] = ' ';
                    else
                        pathMap[y, x] = 'X';
                }
            }

            foreach (Point point in path)
            {
                pathMap[point.y, point.x] = '*';
            }

            Point start = path.First();
            Point end = path.Last();
            pathMap[start.y, start.x] = 'S';
            pathMap[end.y, end.x] = 'E';

            for (int i = 0; i < pathMap.GetLength(0); i++)
            {
                for (int j = 0; j < pathMap.GetLength(1); j++)
                {
                    Console.Write(pathMap[i, j]);
                }
                Console.WriteLine();
            }
        }
    }

    public struct Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

}

