using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04._Queue
{
    public class MyQueue<T>
    {
        private const int DefaultCapacity = 4;
        private T[] array;
        private int head;
        private int tail;

        public MyQueue()
        {
            array = new T[DefaultCapacity];
            head = 0;
            tail = 0;
        }

        public int Count
        {
            get
            {
                if (head <= tail)
                {
                    return tail - head;
                }
                else
                {
                    return tail + (array.Length - head);
                }
            }
        }

        public void Enqueue(T item)
        {
            if (IsFull())
            {
                Grow();
            }
            array[tail] = item;
            MoveNext(ref tail);
        }
        public T Dequeue()
        {
            if (!IsEmpty())
            {
                throw new InvalidOperationException();
            }

            T result = array[head];
            MoveNext(ref head);
            return result;
        }
        private void Grow()
        {
            int newCapacity = array.Length * 2;
            T[] newArray = new T[newCapacity];

            int i = 0;
            while (head != tail)
            {
                newArray[i] = array[head];
                i++;
                MoveNext(ref head);
            }

            head = 0;
            tail = Count;

            array = newArray;
        }

        private bool IsFull()
        {
            if (head == 0)
            {
                return tail == array.Length - 1;
            }
            else
            {
                return head == tail + 1;
            }
        }

        private bool IsEmpty()
        {
            return head == tail;
        }

        private void MoveNext(ref int index)
        {
            if (index == array.Length - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
        }
    }
}