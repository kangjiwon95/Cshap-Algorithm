using System.Collections;

namespace _07._Dictionary
{
    internal class Program
    {
        /****************************************************************************
        * 해시테이블 (HashTable)
        * 
        * 키 값을 해시함수의 해싱하여 해시테이블의 특정 위치로 직접 엑세스하도록 만든 방식
        * 해시 : 임의의 길이를 가진 데이터를 고정된 길이를 가진 데이터로 매핑
        *****************************************************************************/


        // <해시테이블의 시간복잡도> (공간을 포기하고 시간을 선택)
        // 	탐색			삽입			삭제
        // 	O(1)		O(1)		O(1)
        


        // <해시의 조건>
        // 키 값을 해시함수를 통해 처리한 결과가 항상 동일한 값이어야 한다.


        // <해시테이블 주의점 - 충돌>
        // 해시함수가 서로 다른 입력 값에 대해 동일한 해시테이블 주소를 반환하는 것
        // 모든 입력 값에 대해 고유한 해시 값을 만드는 것은 불가능하며 충돌은 피할 수 없음
        // 대표적인 충돌 해결방안으로 체이닝과 개방주소법이 있음


        // <충돌해결방안 - 체이닝>
        // 해시 충돌이 발생하면 연결리스트로 데이터들을 연결하는 방식
        // 장점 : 해시테이블에 자료가 많아지더라도 성능저하가 적음
        // 단점 : 해시테이블 외 추가적인 저장공간이 필요


        // <충돌해결방안 - 개방주소법>
        // 해시 충돌이 발생하면 다른 빈 공간에 데이터를 삽입하는 방식
        // 장점 : 추가적인 저장공간이 필요하지 않음, 삽입삭제시 오버헤드가 적음
        // 단점 : 해시테이블에 자료가 많아질수록 성능저하가 많음
        // 해시 충돌시 선형탐색, 제곱탐색, 이중해시 등을 통해 다른 빈 공간을 선정한다.
        // 해시테이블의 공간 사용률이 높을 경우 성능저하가 발생하므로 재해싱  과정을 진행한다
        // 공간사용률 약 70% 이상부터 충돌횟수가 늘어나 성능저하가 발생
        // 재해싱 : 해시테이블의 크기를 늘리고 테이블 내의 모든 데이터를 다시 해싱


        public class Monster
        {
            
            public string name;

            public Monster(string name) 
            {
                
                this.name = name;
            }
        }
        public static void Test()
        {
            Hashtable ht = new Hashtable();
            ht.Add("꼬부기", new Monster("꼬부기"));
            ht.Add(123, new Monster("파이리"));
            ht.Add(3.2f, "문자열");

            Monster m = (Monster)ht[123];  //형변환 필수
            
            HashSet<Monster> set = new HashSet<Monster>();
            set.Add(new Monster("파이리"));
            

            Dictionary<string, Monster> dic = new Dictionary<string, Monster>(); //이 과정을 추천
            // dic.Add(123, new Monster("파이리"));  자료형 일반화로 string만 가능        
            dic.Add("파이리", new Monster("파이리"));
            dic.Add("꼬부기", new Monster("꼬부기"));
            dic.Add("이상해씨", new Monster("이상해씨"));
            // 데이터가 많아도 빠르게 탐색이 가능하다.

            Monster d = dic["꼬부기"];
            if(dic.ContainsKey("파이리"))
            {

            }
            

           // dic.Remove("파이리"); // 가능하긴 하나 효율이 안좋다

            

        }

        static void Main(string[] args)
        {
            

            // 배열 : 크기가 정해진 자료집합 ex) 장비창
            int[] array = new int[5];


            // 리스트 : 크기가 유동적인 자료집합 (접근도 좋고, 삽입삭제도 좋은편) ex) 유동적인 자료집합
            List<int> list = new List<int>();


            // 해시테이블 : 탐색이 빠른 자료집합 ex) 대규모 자료 저장소 -> 초대규모 (데이터베이스)
            Hashtable ht;
            HashSet<int> set;
            Dictionary<int, Monster> dic;


            // <상황 용도에 따라>
            // 스택 : 선입후출의 용도가 필요할 때 자료집합  ex) 실행취소, 명령수집, UI
            Stack<int> stack = new Stack<int>();

            // 큐 : 선입선출의 용도가 필요할 때 자료집합  ex) 대기열, 진행순서
            Queue<int> queue = new Queue<int>();

            // 우선순위 큐 : 기준에 따라 먼저 처리할 필요가 있을 때 자료집합
            // ex) 가중치에 따른 처리 순서
            PriorityQueue<string, int> pq = new PriorityQueue<string, int>();


            // <C# 특징상 상대적으로 많이 사용하진 않지만 이론적으로 중요한 자료구조>
            // 연결리스트
            // 이진탐색트리

        }
    }
}