using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _01.List
{
    public class MyList<T>
    {
        // 리스트는 원래 크게 만들고 하나씩 추가, 제거하며 메모리를 사용하는 방식
        private const int DefailtCapacity = 20;

        private T[] items;
        private int size;

        public int Count { get { return size; } }
        public int Capacity { get { return items.Length; } }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= size)
                {
                    throw new IndexOutOfRangeException();
                }
                return items[index];
            }
            set
            {
                items[index] = value;
            }
        }

        public MyList()
        {
            items = new T[DefailtCapacity];
            size = 0;
        }

        public void Add(T item)
        {
            if (size >= items.Length)
            {
                Grow();
            }
            items[size] = item;
            size++;
        }

        private void Grow()
        {
            int newCapacity = items.Length * 2;
            T[] newItems = new T[newCapacity];

            for (int i = 0; i < size; i++)
            {
                newItems[i] = items[i];
            }
            items = newItems;

        }

        public void Add1(T item)
        {
            items[size] = item;
            size++;
        }



        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index < 0)
            {
                return false;
            }
            else
            {
                RemoveAt(index);
                return true;
            }
                return false; // TODO : 구현 필요 (보기 에 작업목록에 나오게한다)
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >=size)
            {
                throw new IndexOutOfRangeException();
            }


            size--;
            Array.Copy(items, index + 1, items, index, size - index);

            /* for (int i = index; i < size - index; i++ )
            {
                items[index] = items[index + 1];
            }*/
        }


        public int IndexOf(T item)
        {
            return Array.IndexOf(items, item, 0, size);
        }

    public void Clear()
        {
            items = new T[DefailtCapacity];
            size = 0;
        }

    }
}
