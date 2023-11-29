using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Diagnostics;
using System.Collections;

namespace _02.LinkedList
{

    // 양방향 리스트
    public class MyLinkedListNode<T>
    {
        public MyLinkedListNode<T> prev;
        public MyLinkedListNode<T> next;
        public T item;

        public MyLinkedListNode(T Item)
        {
            
            this.prev = null;
            this.next = null;
            this.Item = item;
        }

        public  MyLinkedListNode(MyLinkedListNode<T> prev, MyLinkedListNode<T> next, T Item)
        {
            this.prev = prev;
            this.next = next;
            this.Item = item;
        }

        public MyLinkedListNode<T> Prev { get { return prev; } }
        public MyLinkedListNode<T> Next { get { return next; } }
        public T Item { get { return item; } set { Item = value; } }
    }

    
   
    public class MyLinkedList<T>
    {
        private MyLinkedListNode<T> head;
        private MyLinkedListNode<T> tail;
        private int count;
        
        public MyLinkedList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public MyLinkedListNode<T> AddFirst(T value)
        {
            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>( value );
            if (count > 0 ) // 다른노드가 있었던 상황
            {
                newNode.next = this.head;
                this.head = newNode;
                head = newNode;
            }  
            else // 처음 추가하는 상황 == 노드가 하나도 없던 상황
            {
                head = newNode;
                tail = newNode;
            }
            count++;

            return newNode;
        }

        public MyLinkedListNode<T> AddLast(T value)
        {
            MyLinkedListNode<T> newNode = new MyLinkedListNode<T> (value);
            if (count > 0 ) // 다른노드가 있었던 상황
            {
                newNode.next = this.tail;
                this.tail = newNode;
                tail = newNode;
            }
            else  // 처음 추가하는 상황 == 노드가 하나도 없던 상황
            {
                head = newNode;
                tail = newNode;
            }
                  
            count++;

            return newNode;
        }

        public MyLinkedListNode<T> Find(T value)
        {
            MyLinkedListNode<T> current = head;
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            
            while (current != null)
            {
                if (comparer.Equals(current.Item,value))
                {
                    return current;
                }
                else
                {
                    current = current.next;
                }
            }
            return null;
        }

        public bool Remove(T value)
        {
            MyLinkedListNode<T> findNode = Find(value);
            if ( findNode == null )  // 못찾았음 == 연결리스트에 해당 데이터가 없었음 
            { 
                return false;
            }
            else
            {
                if( findNode.prev != null )  // 이전노드가 있었을 때
                {
                    findNode.prev.next = findNode.next; // 이전노드의 다음노드를 찾은 노드 다음으로
                }
                else // 이전노드가 없었을 때 == 가장 앞 노드였을 때
                {
                    head = findNode.next;   // 새로운 헤드를 찾은 노드 다음으로
                }
                if (findNode.next != null)  // 다음노드가 있었을 때
                {
                    findNode.next.prev = findNode.prev; // 다음노드의 이전노드를 찾은 노드 이전으로
                }
                else // 다음노드가 없었을 때 == 가장 뒷 노드였을 때
                {
                    tail = findNode.prev;
                }
                count--;

                return true;   // 그림판으로 그려서 설명 해보기
            }
        }

        public MyLinkedListNode<T> AddBefore(MyLinkedListNode<T> node, T value)
        {
            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>(value);
            if (node != head)
            {
                node.prev.next = newNode;
                newNode.prev = node.prev;
            }
            else
            {
                head = newNode;
            }
            
            newNode.next = node;
            node.prev = newNode;

            count++;

            return newNode;
        }

        public MyLinkedListNode<T> AddAfter(MyLinkedListNode<T> node, T value)
        {
            MyLinkedListNode<T> newNode = new MyLinkedListNode<T> ( value );
            if (node != tail)
            {
               node.next.prev = newNode;
                newNode.next = node.next;
            }
            else
            {
                tail = newNode;
            }

            newNode.prev = node;
            node.next = newNode;

            count++;

            return newNode;
        }

        public void Remove(MyLinkedListNode<T> node)
        {
            if (node.prev != null)
            {
                node.prev.next = node.next;
            }
            else
            {
                head = node.next;
            }
            if (node.next != null)
            {
                node.next.prev = node.prev;
            }
            else
            {
                tail = node.prev;
            }

            count--;
        }
        public MyLinkedListNode<T> First { get { return head; } }
        public MyLinkedListNode<T> Last { get { return tail; } }
        public int Count { get { return count; } }
    }
}
