using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace _08.AlgorithmTechnic
{
    internal class Recursion
    {
        /***********************************************
         * 재귀 (Recursion)
         *
         *어떤한 것을 정의할때 자기 자신을 참조하는 것
         ***********************************************/
       
        // <재귀 함수 조건>
        // 1. 함수내용 중 자기자신함수를 다시 호출해야함
        // 2. 종료조건이 있어야 함


        int Wrong()
        {
            return 1 + Wrong();     // 무한히 반복
        }


    // <재귀함수 사용>
    // Factorial : 정수를 1이 될 때까지 차감하며 곱한 값
    // ex) 5! = 5 * 4 * 3 * 2 * 1; 
    // 1! = 1; (1 팩토리얼은 1)
    // n! = n * (n-1)!; (n의 팩토리얼은 n * (n-1) !; 이다)

   
        public static int Factorial(int n)
        {
            if (n == 1)
                return 1;

            return n * Factorial(n - 1);

        }

        // 예시 1 - 폴더 삭제
        struct Directory
        {
            public List<Directory> childDir;
        }
        void RemoveDir(Directory directory) 
        { 
            foreach(Directory dir in directory.childDir)
            {
                RemoveDir(dir);
            }
            Console.WriteLine("폴더 내 파일 모두 삭제");
        }

        // 예시 2 - 사내 전체 공지
        





   }
}
