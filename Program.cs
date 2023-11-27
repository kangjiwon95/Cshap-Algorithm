using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;


namespace _01.List
{
    internal class Program
    {
         /******************************************************
 		 * 배열 (Array)
 		 * 
 		 * 연속적인 메모리상에 동일한 타입의 요소를 일렬로 저장하는 자료구조
 		 * 초기화때 정한 크기가 소멸까지 유지됨
 		 * 배열의 요소는 인덱스를 사용하여 직접적으로 엑세스 가능
 		 ******************************************************/

         // <배열의 사용>
         // 접근에 장점이 있는 사용법
         void Array()
         {
            int[] intArray = new int[100];

            // 인덱스를 통한 접근
            intArray[0] = 10;
            int value = intArray[0];
         }

        // <배열의 시간복잡도>
        // 접근     탐색
        // O(1)     O(n)

        /******************************************************
        * 선형리스트 (Linear List)
        * 
        * 런타임 중 크기를 확장할 수 있는 배열기반의 자료구조
        * 배열요소의 갯수를 특정할 수 없는 경우 사용
        ******************************************************/
        // 리스트 사용을 위해
        // using System.Collections.Generic;
        // <리스트 사용법>

        static void List()
         {
            int[] array = new int[20];
            List<string> slist = new List<string>();
            

            /*
             array.Lenght;        
             slist.Count;            
             slist.capacity; */     

            slist.Add("0번 데이터");  // 배열 요소 삽입 list.Add();
            slist.Add("1번 데이터");
            slist.Add("2번 데이터");

            Console.WriteLine(slist[2]);

            slist.Add("3번 데이터");
            Console.WriteLine(slist[3]);

            slist.Remove("1번 데이터"); // 배열 요소 삭제 list.Remove()
            slist.Clear();             // 배열 요소 전부 삭제  list.Clear()
            List<int> intlist = new List<int>();
            intlist.Add(0);
            intlist.Add(1);
            
            slist[0] = "데이터 0";      // 배열 요소 접근
            string value = slist[0];

            bool valus = intlist.Remove(1);

            slist.Contains("2번 데이터");  // 

            slist.Insert(0, "-1번 데이터"); // 해당 배열 요소 앞에 추가 list.Insert()

            Console.WriteLine(slist.Count);

            for (int Z = 0; Z < slist.Count; Z++) 
            {
                Console.WriteLine(slist[1]);
            }

            // <List 시간 복잡도>
            // 접근      탐색     삽입     삭제
            // 0(1)     0(n)     0(n)     0(n)
          


            // 리스트 공간 , 시간 복잡도 검색 공부하기
            // 마이크로 소프트 기술서적(MSDN)에 검색 후 찾아보기
        }



        static void listprint()
        {
            List<int> list = new List<int>();

            //리스트 구현 원리
            for (int i = 0; i < 20; i++)
            {
                list.Add(i);
                Console.WriteLine("{0} 데이터 추가",i);
                Console.WriteLine("리스트의 count : {0}",list.Count);
                Console.WriteLine("리스트의 capacity : {0}",list.Capacity);
                Console.WriteLine();
            }
        }


       
        static void Main(string[] args)
        {
            // List();
            listprint();
        }
    }
}