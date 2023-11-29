using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.AlgorithmTechnic
{
    internal class DiviedAndConquer
    {
        /*********************************************************************
         * 분할 정복 (Divied And Conquer)
         *
         * 큰 문제를 작은 문제로 나눠서 푸는 하향식 접근 방식
         * 분할을 통해서 해결하기 쉬운 작은 문제로 나눈 후 정복한 후 병합하는 과정
         ********************************************************************/

        // 예시 - 거듭제곱 계산
        // x^n = x * x * x ...(n번 반복) 
        // x^n = x^(n/2) * x^(n/2)
        int Pow(int x, int n)
        {
            // x^n = x^(n/2) * x^(n/2)
            if (n % 2 == 0)
                return 1;
            int result;
            if (n % 2 == 0)
            {
                result = Pow(x, n / 2);
            }
            else
            {
                result = x * Pow(x, (n - 1) / 2);
            }
            return result * result;
            
            
            /*int result = 1;
            for (int i = 0; i < n; i++)
            {
                result *= x;
            }

            return result;*/
        }

    }
}
