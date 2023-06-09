﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    #region 单链表Node
    public class SingleLinkedListNode<T> where T : IComparable
    {
        public T value;
        public SingleLinkedListNode<T>? next;

        public SingleLinkedListNode()
        {

        }
        public SingleLinkedListNode(T value)
        {
            this.value = value;
            next = null;
        }
        //在当前节点后插入元素
        public SingleLinkedListNode<T> InsertAfter(T value)
        {
            SingleLinkedListNode<T> newNode = new SingleLinkedListNode<T>(value); //新节点
            newNode.next = next; //新节点的next字段
            next = newNode; //当前节点的next字段
            return newNode;
            //Node<T> newNodeNext = next;
        }
        public SingleLinkedListNode<T> InsertAfter(SingleLinkedListNode<T> newNode )
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
        
        public SingleLinkedListNode<T> head; //头节点
        public SingleLinkedList()
        {
            head = new SingleLinkedListNode<T>();
        }
        #region 插入
        //头插法   
        public SingleLinkedListNode<T> InsertAsFirst(T e)
        {
            return head.InsertAfter(e);
        }
        public SingleLinkedListNode<T> InsertAsFirst(SingleLinkedListNode<T> node)
        {
            return head.InsertAfter(node);
        }
        //尾插法
        public SingleLinkedListNode<T> InsertAsLast(T e)
        {
            SingleLinkedListNode<T>? cur = head;
            SingleLinkedListNode<T> pre = null;
            while (cur != null) 
            {
                pre = cur;
                cur = cur.next;
            }
            return pre.InsertAfter(e);

        }
        public SingleLinkedListNode<T> InsertAsLast(SingleLinkedListNode<T> node)
        {
            SingleLinkedListNode<T>? cur = head;
            SingleLinkedListNode<T> pre = null;
            while (cur != null)
            {
                pre = cur;
                cur = cur.next;
            }
            return pre.InsertAfter(node);
        }
        #endregion

        #region 链表相关算法(重要技巧，快慢指针，额外数据结构（如哈希表，Vector等））

        //反转链表
        public void Reverse()
        {
            SingleLinkedListNode<T> cur = head.next;
            SingleLinkedListNode<T> pre = null;
            SingleLinkedListNode<T> next = null;

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
            SingleLinkedListNode<T> cur1 = head.next;
            SingleLinkedListNode<T> cur2 = otherList.head.next;
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
        //判断是否是回文
        public bool IsPalindrome(bool useStack = false)
        {
            if (useStack)
            {
                Stack<T> stack = new Stack<T>();
                SingleLinkedListNode<T> cur = head.next;
                while (cur != null)
                {
                    stack.Push(cur.value);
                    cur = cur.next;
                }
                cur = head.next;
                while (cur != null)
                {
                    T value = stack.Pop();
                    if (!value.Equals(cur.value))
                        return false;
                    cur = cur.next;
                }
                return true;
            }
            else
            {
                if (head.next == null || head.next.next == null) return true;
                SingleLinkedListNode<T> slow = head;
                SingleLinkedListNode<T> fast = head;
                
                while (fast!= null && fast.next != null) //对应奇和偶的情况（偶包含了奇）,slow走到中点
                {
                    slow = slow.next;
                    fast = fast.next.next;
                }
                
                //将后半部分逆序
                SingleLinkedListNode<T> cur = slow;
                SingleLinkedListNode<T> next = null;
                SingleLinkedListNode<T> pre = null;
                while(cur != null)
                {
                    next = cur.next;
                    cur.next = pre;
                    pre = cur;
                    cur = next;
                }
                SingleLinkedListNode<T> afterHead = pre; //后半部分的第一个节点(逆序后，即最右侧节点）
                
                bool res = true; //分别遍历并比较 -> <-
                slow = head.next;
                while(slow!= null)
                {
                    if(!slow.value.Equals(pre.value))
                    {
                        res = false; 
                        break;
                    }
                    slow = slow.next;
                    pre = pre.next;
                }

                cur = afterHead; //恢复原链表结构
                pre = null;
                next = null;
                while(cur != null)
                {
                    next = cur.next;
                    cur.next = pre;
                    pre = cur;
                    cur = next;
                      
                }
                return res;

            }
        }
        //链表Partation
        public void Partation(int v)
        {
            SingleLinkedListNode<T> smallHead = new SingleLinkedListNode<T>();
            SingleLinkedListNode<T> equalHead = new SingleLinkedListNode<T>();
            SingleLinkedListNode<T> bigHead = new SingleLinkedListNode<T>();
            SingleLinkedListNode<T> s = smallHead;
            SingleLinkedListNode<T> e = equalHead;
            SingleLinkedListNode<T> b = bigHead;
            SingleLinkedListNode<T> cur = head.next;
            while(cur != null)
            {
                if(cur.value.CompareTo(v) < 0)
                {
                    s.next = cur;
                    s = cur;
                }
                else if(cur.value.CompareTo(v) > 0)
                {
                    b.next = cur;
                    b = cur;
                }
                else
                {
                    e.next = cur;
                    e = cur;
                }
                cur = cur.next;
                
            }
            if(s!= null)
            {
                s.next = equalHead.next;
            }
            if(e!=null)
            {
                e.next = bigHead.next;
            }
           
        }
        //判断链表是否有环，有则返回环的入口节点，没有则返回null
        //从第一个节点出发，慢走一步，快走两步
        //第一次相遇后，快/慢指针回到表头，两个指针开始同时走一步，第一次遇到的时候便是入环节点
        public SingleLinkedListNode<T> IsLoop()
        {
            if (head.next == null || head.next.next == null || head.next.next.next == null) return null; //三个节点一下一定无环
            SingleLinkedListNode<T> slow = head.next.next;
            SingleLinkedListNode<T> fast = head.next.next.next;
            while(slow != fast)
            {
                if(fast.next == null || fast.next.next == null)
                {
                    return null;
                }
                slow = slow.next;
                fast = fast.next.next;
            }

            slow = head.next;
            while (slow != fast)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }
        //两个无环链表是否相交
        public SingleLinkedListNode<T> IsIntersectingNoLoop(SingleLinkedList<T> otherList)
        {
            int size1 = 0;
            int size2 = 0;
            SingleLinkedListNode<T> cur = head.next;
            SingleLinkedListNode<T> cur2 = otherList.head.next;
            while (cur.next != null)
            {
                ++size1;
                cur = cur.next;
            }
            cur2 = otherList.head.next;
            while(cur2.next != null)
            {
                ++size2;

                cur2 = cur2.next;
            }
            if (cur != cur2) return null;
            int delta = size1 - size2 > 0 ? size1 - size2:size2-size1 ;
            cur = size1 - size2 > 0 ? head.next : otherList.head.next;
            cur2 = size1 - size2 <= 0 ? head.next : otherList.head.next;

            while (delta > 0) 
            {
                --delta;
                cur = cur.next;
            }
            //while(cur != cur2) //应该不需要这个逻辑，之前已经得到交点为cur
            //{
            //    cur = cur.next;
            //    cur2 = cur2.next;
            //}
            return cur;
        }
        //两个有环链表是否相交
        public SingleLinkedListNode<T> IsIntersectingTwoLoop(SingleLinkedList<T> otherList)
        {
            SingleLinkedListNode<T> enterNode1 = IsLoop();
            SingleLinkedListNode<T> enterNode2 = otherList.IsLoop();
            if(enterNode1 == enterNode2) //情况1：入口节点相同
            {
                int size1 = 0;
                int size2 = 0;
                SingleLinkedListNode<T> cur = head.next;
                SingleLinkedListNode<T> cur2 = otherList.head.next;
                while (cur.next != enterNode1)
                {
                    ++size1;
                    cur = cur.next;
                }
                cur2 = otherList.head.next;
                while (cur2.next != enterNode2)
                {
                    ++size2;

                    cur2 = cur2.next;
                }
                
                int delta = size1 - size2 > 0 ? size1 - size2 : size2 - size1;
                cur = size1 - size2 > 0 ? head.next : otherList.head.next;
                cur2 = size1 - size2 <= 0 ? head.next : otherList.head.next;

                while (delta > 0)
                {
                    --delta;
                    cur = cur.next;
                }
                while (cur != cur2)
                {
                    cur = cur.next;
                    cur2 = cur2.next;
                }
                return cur;
            }
            else
            {
                SingleLinkedListNode<T> cur = enterNode1.next;
                while(cur != enterNode1) 
                {
                    if(cur == enterNode2) //情况2：入环节点不同,均为第一个相交节点
                    {
                        return enterNode1;
                    }
                    cur = cur.next;
                }
                //情况3：不相交
                return null;
            }
            

        }
        #endregion
    }
}
