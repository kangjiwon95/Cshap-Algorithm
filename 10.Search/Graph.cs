using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Search
{
    internal class Graph
    {

        /*************************************************************************** 
        * <트리와 그래프 차이점>
        * 
        * 트리는 순환 구조를 갖고있지 않지만 그래프는 순환구조를 갖고있다.
        * 트리는 계층형 자료구조 라면 그래프는 정점의 집합과 간선의 집합을 결합한 자료구조
        ****************************************************************************/

        /******************************************************************** 
        * <그래프>  (Graph)
        * 
        * 정점의 모음과 이 정점을 잇는 간선의 모음의 결합
        * 한 노드에서 출발하여 다시 자기 자신의 노드로 돌아오는 순환구조를 가진다.
        * 간선의 방향성에 따라 단반향 그래프, 양방향 그래프가 있다.
        * 간선의 가중치에 따라 연결 그래프, 가중치 그래프가 있다.
        *********************************************************************/


        /********************************************************** 
        * <인접행렬 그래프>
        * 
        * 그래프 내의 각 정점의 연결관게를 나타내는 행렬
        * 2차원 배열을 [출발정점,도착정점] 으로 표현
        * 장점 : 연결여부 접근이 빠름 - 시간복잡도 : 0(1)
        * 단점 : 메모리 사용량이 많음 - 공간복잡도 : 0(n²)
        **********************************************************/
        // 예시
        public void MartixGraph()
        {
            bool[,] graph = new bool[5, 5];

            graph[0, 3] = true;
            graph[1, 4] = true;
            graph[4, 1] = true;

            bool isConnected = graph[1, 2];

            //예시 - 양방향 연결 그래프
            // 대각선을 기준으로 대칭이다
            bool[,] MartixGraph1 = new bool[5, 5]
            {
                { false, false, false, false,  true },      // 0번 정점은 4번정점과 연결
		        { false, false,  true, false, false },      // 1번 정점은 2번정점과 연결
		     	{ false,  true, false,  true, false },      // 2번 정점은 1번 정점, 3번정점과 연결
		    	{ false, false,  true, false,  true },      // 3번 정점은 2번 정점, 4번정점과 연결
		    	{  true, false, false,  true, false },      // 4번 정점은 0번 정점, 3번정점과 연결 
            };


            const int INF = int.MaxValue;
            // 예시 - 단방향 가중치 그래프 (단절은 최대값으로 표현)
            int[,] matrixGraph2 = new int[5, 5]
            {
               {   0, 132, INF, INF,  16 },
               {  12,   0, INF, INF, INF },
               { INF,  38,   0, INF, INF },
               { INF,  12, INF,   0,  54 },
               { INF, INF, INF, INF,   0 },
            };

        }


        /********************************************************** 
        * <인접리스트 그래프>
        * 
        * 그래프 내의 각 정점의 인접 관계를 표현하는 리스트
        * 인접한 간선만을 리스트에 추가하여 관리
        * 장점 : 메모리 사용량이 적음  - 공간복잡도 : 0(n)
        * 단점 : 인접여부를 확인하기 위해 리스트 탐색이 필요 - 시간복잡도 : 0(n)
        **********************************************************/
        // 예시
        List<List<int>> listGraph1;             // 연결 그래프
        List<List<(int, int)>> listGraph2;      // 가중치 그래프
        public void CreateGraph()
        {
            List<List<int>> listGraph = new List<List<int>>();

            for (int i = 0; i < 5; i++) 
            { 
                listGraph.Add(new List<int>());
            }
            listGraph1[0].Add(1); // 0번 정점에 1번 정점이 연결
            listGraph1[1].Add(0); // 1번 정점에 0번 정점이 연결
            listGraph1[1].Add(3); // 1번 정점에 3번 정점이 연결
            listGraph1[2].Add(0); // 2번 정점에 0번 정점이 연결
            listGraph1[2].Add(1); // 2번 정점에 1번 정점이 연결 
            listGraph1[2].Add(4); // 2번 정점에 4번 정점이 연결
            listGraph1[3].Add(1); // 3번 정점에 1번 정점이 연결
            listGraph1[4].Add(3); // 4번 정점에 3번 정점이 연결
        }
    }
}
