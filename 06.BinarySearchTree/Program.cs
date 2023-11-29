using Aspose.Pdf.Operators;
using System.Diagnostics;
using System.Xml.Serialization;

namespace _06._BinarySearchTree
{
    internal class Program
    {
        /**************************************************************************
         * 트리 (Tree)
         * 
         * 계층적인 자료를 나타내는데 자주 사용하는 자료구조
         * 부모노드가 0개 이상의 자식노드들을 가질 수 있음
         * 한 노드에서 출발하여 다시 자기 자신의 노드로 돌아오는 순환구조를 가질 수 없다.
         **************************************************************************/



        /********************************************************************
         * 이진탐색트리 (BinarySearchTree)
         * 
         * 이진속성과 탐색속성을 적용한 트리
         * 이진탐색을 통한 탐색영역을 절반으로 줄여가며 탐색 가능 
         * 이진 : 부모노드는 최대 2개의 자식노드들을 가질 수 있다.
         * 탐색 : 자신만의 노드보다 작은 값을 왼쪽 , 큰 값들은 오른쪽에 위치한다.
         ********************************************************************/


        // <이진탐색트리의 시간복잡도>
        //     접근         탐색          추가         삭제
        //   0(Log n)     0(Log n)     0(Log n)     0(Log n)
       
        //  최악의 경우 
        //      접근         탐색          추가        삭제
        //      0(n)         0(n)         0(n)        0(n)


        // <이진탐색트리의 주의점> ********면접잘문 이론만**********
        // 이진탐색트리의 노드들이 한쪽 자식으로만 추가되는 불균형 발생 가능
        // 이 경우 탐색영역이 절반으로 줄여지지 않기 때문에 시간복잡도 증가
        // 이런한 현상을 막기 위해 자가균형기능을 추가한 트리의 사용이 일반적
        // 자가균형트리는 회전을 이용하여 불균형이 있는 상황을 해결
        // 대표적인 방식으로 Red-Black Tree , AVL Tree 등을 통해 불균형상황을 파악

        public class Monster
        {
            string name;
            int HP;
            int MP;

            public Monster(string name, int HP, int MP)
            {
                this.name = name;
                this.HP = HP;
                this.MP = MP;
            }
        }


        public static void BinarySearchTree()
        {
            SortedSet<int> sortedset = new SortedSet<int>();

            sortedset.Add(0);
            sortedset.Add(3);
            sortedset.Add(4);
            sortedset.Add(1);
            sortedset.Add(2);

            int serach;
            sortedset.TryGetValue(3, out serach);      //탐색시도

            //Key, value 이진탐색트리
            SortedDictionary<string,Monster> sortedDIC = new SortedDictionary<string,Monster>();

            sortedDIC.Add("파이리", new Monster("파이리", 100, 20));
            sortedDIC.Add("꼬부기", new Monster("꼬부기", 200, 10));
            sortedDIC.Add("이상해씨", new Monster("이상해씨", 150, 15));
            sortedDIC.Add("피카츄", new Monster("피카츄", 100, 20));
            // 굉장히 많은 포켓몬스터 700 종

            Monster pikachu;
            sortedDIC.TryGetValue("피카츄", out pikachu);   //탐색시도

            // 인덱서를 통한 탐색
            if (sortedDIC.ContainsKey("피카츄"))
            {
                pikachu = sortedDIC["피카츄"];
            }

            // 이진탐색 검색효율
            int count = 100;
            List<int> list = new List<int>(count);
            SortedSet<int> set = new SortedSet<int>();

            Random random = new Random();
            int rand;
            for (int i = 0; i < count; i++)
            {
                rand = random.Next();
                list.Add(rand);
                set.Add(rand);
            }
            list[count / 2] = -1;
            set.Add(-1);

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            list.Find((x) => x == -1);
            stopwatch.Stop();
            Console.WriteLine("배열 time : {0}", stopwatch.ElapsedTicks);

            stopwatch.Restart();
            int value;
            set.TryGetValue(-1, out value);
            stopwatch.Stop();
            Console.WriteLine("트리 time : {0}", stopwatch.ElapsedTicks);
        }
    


        static void Main(string[] args)
        {

            BinarySearchTree();



        }
    }
}