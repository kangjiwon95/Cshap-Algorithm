using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace _02.LinkedList
{
    internal class Program
    {
        /*면접 질문 이론만*/
        /******************************************************
		 * 연결 리스트 (Linked List)
		 * 
		 * 데이터를 포함하는 노드들을 연결식으로 만든 자료구조
		 * 노드는 데이터와 이전/다음 노드 객체를 참조하고 있음
		 * 노드가 메모리에 연속적으로 배치되지 않고 이전/다음노드의 위치를 확인
		 ******************************************************/

        //연결 리스트 안쓰는 이유
        // 1. 삽입 ,삭제에서 이득을 못본다
        // 2. 추가 삭제 과정마다 쓰레기값(가비지컬렉터)가 많아 실사용 어렵다
        // 3. 캐시 메모리 적중률이 낮아서 속도면에서 더 느려진다.


        // 리스트 종류
        // 1 단반향 (Singly) 
        // 2 양방향 (Doubly) 
        // 3 환형 (Circuar) 

        //   양방향 구조
        // <연결 리스트 사용 사용>
        public static void LinkedList()
        {
            LinkedList<string> linkedList = new LinkedList<string>();

            // 연결리스트 요소 삽입
            linkedList.AddFirst("0번 앞데이터");
            linkedList.AddFirst("1번 앞데이터");
            linkedList.AddLast("2번 뒤데이터");
            linkedList.AddLast("3번 뒤데이터");

            // 연결리스트 요소 삭제
            linkedList.Remove("1번 앞데이터");

            // 연결리스트 요소 탐색
            LinkedListNode<string> findNode = linkedList.Find("0번 앞데이터");

            // 연결리스트 노드를 통한 노드 참조
            LinkedListNode<string> prevNode = findNode.Previous; // 이전 노드 확인
            LinkedListNode<string> nextNode = findNode.Next;     // 다음 노드 확인

            // 연결리스트 노드를 통한 노드 삽입
            linkedList.AddBefore(findNode, "찾은 노드 앞데이터");
            linkedList.AddAfter(findNode, "찾은 노드 뒤데이터");

            // 연결리스트 노드를 통한 삭제
            linkedList.Remove(findNode);  // 검색한 노드 삭제

        }

        // <LinkedList의 시간복잡도>
        // 접근		탐색		삽입		삭제
        // O(N)		O(N)	O(1)	O(1)

        // llinkedList[20]
        // 연결리스트는 index가 없다

        static void Main(string[] args)
        {

            Console.WriteLine(); 
        }

    }
}
    
