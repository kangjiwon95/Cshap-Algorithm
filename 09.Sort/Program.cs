namespace _09._Sort
{
    internal class Program
    {
        /*************************************************************************
        * <선택 정렬> 
        * 
        * 전체 데이터 중에서 가장 작은 작은 값부터 하나씩 선택해서 앞으로 옮겨주는 정렬
        * 시간복잡도 - 0(n²)
        * 공간복잡도 - 0(1)
        **************************************************************************/
        public static void SelectionSort(List<int> list) 
        {
            for (int i = 0; i < list.Count; i++) 
            {
                int minIndex = i;
                for (int j = i; j < list.Count; j++) 
                {
                    if (list[j] < list[minIndex])
                        minIndex = j;
                }

                Swap(list, minIndex, i);
            }
        }
        
        
        private static void Swap(IList<int> list, int left, int right)
        {
            int temp = list[left];
            list[left] = list[right];
            list[right] = temp;
        }


        /***********************************************************************
         * <삽입정렬>
         * 
         * 데이터를 하나씩 꺼내서 정렬된 자료 중 적합한 위치에 삽입하여 정렬
         * 시간복잡도 - 0(n²)
         * 공간복잡도 - 0(1)
         ***********************************************************************/
        //삽입정렬 예시 
        public static void InsertionSort(IList<int> list) 
        { 
            for (int i = 0; i < list.Count; i++) 
            {
                int Key = list[i];
                int j;
                for (j = i - 1; j >= 0 && Key < list[j]; j-- )
                {
                    list[j + 1] = list[j];
                }
                list[j + 1] = Key;
            }
        }
        


        /***********************************************************************
        * <버블 정렬>
        * 
        * 서로 인접한 데이터를 비교해서 작으면 앞으로, 크면 뒤로 정렬
        * 시간복잡도 - 0(n²)
        * 공간복잡도 - 0(1)
        ***********************************************************************/
        // 버블정렬 예시
        public static void BubbleSort(IList<int> list)
        {
            for(int i = 0;i < list.Count; i++)
            {
                for(int j = 1; j < list.Count; j++)
                {
                    if (list[j -1] > list[j])
                    Swap(list, j - 1, j);
                }
            }
        }
        


        /***********************************************************************
         * <병합 정렬>(MergeSort)
         * 
         * 데이터를 2분할 하여서 정렬 후 병합
         * 분할정복을 통한 정렬 방법
         * 시간복잡도 - 0(nLog-n)
         * 공간복잡도 - 0(n)
         * 시간복잡도를 선택하기 위해 공간복잡도 포기 (메모리 친화도에 따라 다르다)
         ***********************************************************************/
        public static void MergeSort(IList<int> list, int left, int right)
        {
            if (left == right)  return;

            int Mid = (left + right) / 2;

            MergeSort(list, left, Mid);
            MergeSort(list, Mid + 1, right);
            Merge(list, left,Mid, right);
        }
        public static void Merge(IList<int> list,int left,int Mid ,int right) 
        { 
            List<int> sotedlist = new List<int>();
            int leftIndex = left;
            int rightIndex = Mid + 1 ;

            // 분할된 정렬된 List를 병합
            while (leftIndex <= Mid && rightIndex <= right) 
            {
                if (list[leftIndex] < list[rightIndex])
                {
                    sotedlist.Add(list[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    sotedlist.Add(list[rightIndex]);
                    rightIndex++;
                }
            }
            if (leftIndex > Mid)  // 왼쪽 List가 먼저 소진 됐을 경우
            {
                for (int i = rightIndex; i <= right; i++)
                    sotedlist.Add(list[i]);
            }
            else //  오른쪽 List가 먼저 소진 됐을 경우
            {
                for (int i = leftIndex; i <= Mid; i++)
                    sotedlist.Add(list[i]);
            }
            // 정렬된 SortedList를 list 재복사
            for (int i = left;  i <= right; i++)
            {
                list[i] = sotedlist[i - left];
            }
        }


        /***********************************************************************
         * <퀵 정렬>    !!!!!!!!!!!!!!!!!!!!!!!!제일 중요!!!!!!!!!!!!!!!!!!!!!!!!
         * 
         * 하나의 피벗을 기분으로 작은 값과 큰 값을 2분할하여 정렬
         * 시간복잡도 - 평균 0(nLog-n)
         *             최악 0(n²)
         * 공간복잡도 - 0(1)
         ***********************************************************************/
        public static void QuickSort(IList<int> list, int Start, int End) 
        {
            if (Start >= End) return;

            int pivot = Start;
            int left = pivot + 1;
            int right = End;

            while (left <= right) 
            {
                //left 는 pivot 보다 큰 값을 만날때까지
                while (list[left] <= list[pivot] && left < End)
                {
                    left++;
                }
                // right는 pivot 보다 작은 값을 만날때까지
                while (list[right] >= list[pivot] && right > Start)
                {
                    right--;
                }
                if (left < right) // 엇갈리지 않은 상황에서는
                {
                    Swap(list, left, right);     // 왼쪽이랑 오른쪽이랑 변경
                }
                else              // 엇갈렸다면
                {
                    Swap(list,pivot, right);      //피벗이랑 오른쪽이랑 변경
                }
            }

            QuickSort(list, Start, right - 1);
            QuickSort(list, right + 1, End);
        }


        /***********************************************************************************************
         * <힙 정렬>
         * 
         * 힙을 이용하여 우선순위가 가장 높은 요소가 가장 마지막 요소와 교체된 후 제거되는 방법을 이용
         * 배열에서 연속적인 데이터를 사용하지 않기 때문에 캐시 메모리를 효율적으로 사용할 수 없어 상대적으로 느림
         * 시간복잡도 - 평균 0(nLog-n)
         *             최악 0(nLog-n) 
         * 공간복잡도 - 0(1)
         * 캐시 친화도가 나쁘다
         **********************************************************************************************/
        public static void HeapSort(IList<int> list)
        {
            MakeHeap(list);
            for (int i = list.Count - 1; i > 0; i--)
            {
                Swap(list, 0, i);
                Heapify(list, 0, i);
            }
        }

        private static void MakeHeap(IList<int> list)
        {
            for (int i = list.Count / 2 - 1; i >= 0; i--)
            {
                Heapify(list, i, list.Count);
            }
        }

        private static void Heapify(IList<int> list, int index, int size)
        {
            int left = index * 2 + 1;
            int right = index * 2 + 2;
            int max = index;
            if (left < size && list[left] > list[max])
                max = left;
            if (right < size && list[right] > list[max])
                max = right;

            if (max != index)
            {
                Swap(list, index, max);
                Heapify(list, max, size);
            }
        }


        /*******************************************************************************************
         * <인트로 정렬> 
         * 
         * 퀵정렬로 시작하고 시간복잡도가 나빠지면 힙정렬로 전환하고 특정한계치 미만일때 삽입정렬로 바뀐다
         *******************************************************************************************/
        


        static void Main(string[] args)
        {
            Random random = new Random();

            List<int> selectionList = new List<int>();
            List<int> insertionList = new List<int>();
            List<int> bubbleList = new List<int>();
            List<int> mergeList = new List<int>();
            List<int> quickList = new List<int>();
            List<int> heapList = new List<int>();
            List<int> list = new List<int>();

            Console.WriteLine("랜덤 데이터 : ");
            for (int i = 0; i < 20; i++)
            {
                int rand = random.Next() % 100;
                Console.Write(string.Format("{0} ", rand));

                selectionList.Add(rand);
                insertionList.Add(rand);
                bubbleList.Add(rand);
                mergeList.Add(rand);
                quickList.Add(rand);
                heapList.Add(rand);
                list.Add(rand);
            }
            Console.WriteLine();

            Console.WriteLine("선택 정렬 결과 : ");
            SelectionSort(selectionList);
            foreach (int i in selectionList)
            {
                Console.Write(string.Format("{0} ", i));
            }
            Console.WriteLine();

            Console.WriteLine("삽입 정렬 결과 : ");
            InsertionSort(insertionList);
            foreach (int i in insertionList)
            {
                Console.Write(string.Format("{0} ", i));
            }
            Console.WriteLine();

            Console.WriteLine("버블 정렬 결과 : ");
            BubbleSort(bubbleList);
            foreach (int i in bubbleList)
            {
                Console.Write(string.Format("{0} ", i));
            }
            Console.WriteLine();

            Console.WriteLine("병합 정렬 결과 : ");
            MergeSort(mergeList, 0, mergeList.Count - 1);
            foreach (int i in mergeList)
            {
                Console.Write(string.Format("{0} ", i));
            }
            Console.WriteLine();

            Console.WriteLine("퀵 정렬 결과 : ");
            QuickSort(quickList, 0, quickList.Count - 1);
            foreach (int i in quickList)
            {
                Console.Write(string.Format("{0} ", i));
            }
            Console.WriteLine();

            Console.WriteLine("힙 정렬 결과 : ");
            HeapSort(heapList);
            foreach (int i in heapList)
            {
                Console.Write(string.Format("{0} ", i));
            }
            Console.WriteLine();

            Console.WriteLine("인트로 정렬 : ");
            list.Sort();
            foreach (int i in list)        //TODO 정렬법 변경
            {
                Console.Write(string.Format("{0} ",i));
            }
            Console.WriteLine();
        }
    }
}
    
