using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    #region 单链表Node
    public class Node<T> where T : IComparable
    {
        public T value;
        public Node<T>? next;

        public Node()
        {

        }
        public Node(T value)
        {
            this.value = value;
            next = null;
        }
        //在当前节点后插入元素
        public Node<T> InsertAfter(T value)
        {
            Node<T> newNode = new Node<T>(value); //新节点
            newNode.next = next; //新节点的next字段
            next = newNode; //当前节点的next字段
            return newNode;
            //Node<T> newNodeNext = next;
        }
        public Node<T> InsertAfter(Node<T> newNode )
        {

            newNode.next = next; //新节点的next字段
            next = newNode; //当前节点的next字段
            return newNode;
            //Node<T> newNodeNext = next;
        }

    }
    #endregion
    public class SingleLinkedList<T> where T: IComparable
    {
        
        public Node<T> head; //头节点
        public SingleLinkedList()
        {
            head = new Node<T>();
        }
        #region 插入
        //头插法   
        public Node<T> InsertAsFirst(T e)
        {
            return head.InsertAfter(e);
        }
        //尾插法
        public Node<T> InsertAsLast(T e)
        {
            Node<T>? cur = head;
            Node<T> pre = null;
            while (cur != null) 
            {
                pre = cur;
                cur = cur.next;
            }
            return pre.InsertAfter(e);

        }
        #endregion

        #region 链表相关算法
        //反转链表
        public void Reverse()
        {
            Node<T> cur = head.next;
            Node<T> pre = null;
            Node<T> next = null;

            while (cur != null) 
            {
                next = cur.next;
                cur.next = pre;
                pre = cur;
                cur = next;
            }
            head.next = pre;
        }
        //打印两个有序链表的公共部分
        public void PrintPublic(SingleLinkedList<T> otherList)
        {
            Node<T> cur1 = head.next;
            Node<T> cur2 = otherList.head.next;
            while(cur1 != null && cur2 != null)
            {
                if (cur1.value.Equals(cur2.value))
                {
                    Console.WriteLine(cur1.value);
                    cur1 = cur1.next;
                    cur2 = cur2.next;
                }
                else if(cur1.value.CompareTo(cur2.value) < 0) 
                {
                    cur1 = cur1.next;
                }
                else
                {
                    cur2 = cur2.next;
                }

            }
        }
        #endregion
    }
}
