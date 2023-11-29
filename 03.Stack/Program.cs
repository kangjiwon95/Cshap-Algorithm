namespace _03.Stack
{
    internal class Program
    {
         /******************************************************
		 * 스택 (Stack)
		 * 
		 * 선입후출(FILO), 후입선출(LIFO) 방식의 자료구조
		 * 가장 최신 입력된 순서대로 처리해야 하는 상황에 이용
		 ******************************************************/
        public static void Stack()
        {
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < 10; i++) 
            {
                stack.Push(i);             // 입력순서 : 0, 1, 2, 3, 4, 5, 6, 7, 8, 9
            }
            while (stack.Count > 0) 
            {
                int value = stack.Pop();
                Console.WriteLine(value); // 출력순서 : 9, 8, 7, 6, 5, 4, 3, 2, 1, 0
            }
        }
        


        static void Main(string[] args)
        {
           
        }
    }
}