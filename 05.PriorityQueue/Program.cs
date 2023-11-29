namespace _05._PriorityQueue
{
    internal class Program
    {
         /******************************************************
		 * 우선순위 큐 - 힙 (Heap)
		 * 
		 * 부모 노드가 항상 자식노드보다 우선순위가 높은 속성을 만족하는 트리기반의 자료구조
		 * 많은 자료 중 우선순위가 가장 높은 요소를 빠르게 가져오기 위해 사용
		 ******************************************************/
        public static void PQ()
        {
            Queue<string> queue = new Queue<string>();

            queue.Enqueue("슬라임");
            queue.Enqueue("드래곤");            //일반 큐의 입출력 방식
            queue.Enqueue("오크");
            queue.Enqueue("고블린");
            while (queue.Count > 0) 
            {
                string monsterName = queue.Dequeue();
                Console.WriteLine(monsterName);
            }

            PriorityQueue<string, int> pq = new PriorityQueue<string, int>();

            pq.Enqueue("슬라임", 5);
            pq.Enqueue("드래곤", 100);
            pq.Enqueue("오크", 20);                    //우선순위 큐의 입출력 방식
            pq.Enqueue("고블린", 50);

            while (pq.Count > 0) 
            { 
                string monsterName = pq.Dequeue();
                Console.WriteLine(monsterName);
            }

            // <우선순위 큐의 시간복잡도>
            // 최우선순위 데이터 확인       추가         삭제
            //       0(1)               0(Log N)     0(Log N)

            // 배열 기반이었을 경우
            // 최우선순위 데이터 확인       추가         삭제
            //        0(1)                0(N)         0(N)

            PriorityQueue<string, int> pq2 = new PriorityQueue<string, int>();

            pq.Enqueue("슬라임", -1 * 5);
            pq.Enqueue("드래곤", -1 * 100);
            pq.Enqueue("오크", -1 * 20);
            pq.Enqueue("고블린", -1 * 50);          // 역순 출력은 -1 * 는 식으로 많이쓴다

            while (pq.Count > 0)
            {
                string monsterName = pq.Dequeue();  
                Console.WriteLine(monsterName);     
            }
        }






        static void Main(string[] args)
        {
            PQ();
        }
    }
}