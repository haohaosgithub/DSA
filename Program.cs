﻿using DSA;
using System;
using System.Runtime.InteropServices;
using System.Xml.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        #region 向量测试
        //Vector<int> v = new Vector<int>();

        //int[] array = { 1,3,4,2,5 };
        //Vector<int> v = new Vector<int>(array);
        //v.HeapSort();
        //v.SelectionSort();
        //v.BubbleSort();
        //v.InsertionSort();
        //v.MergeSort();

        //Console.WriteLine(v.BinarySearch(8));
        //Console.WriteLine(v.BinarySearchMinRank(2));
        //Console.WriteLine(v.LocalMin());
        //v.PatitionSimple(5);
        //v.Patition(5,out int a,out int b);
        //Console.WriteLine(a + " " + b);
        //v.QuickSort();
        //Console.WriteLine("逆序对个数" +v.ReverseOrderPairNum());
        //Console.WriteLine("数组的小和" + Vector<int>.LessSum(array));
        //Console.WriteLine("ok");
        #endregion
        #region 异或问题测试
        //int[] xorarr = { 1,1,1,1,2,3,3};
        //Console.WriteLine(XOR.FindOnlyOnce(xorarr));
        //int[] xorarr2 = { 1, 1, 1, 2, 2, 3, 4, 4 };
        //XOR.FindOnlyTwice(xorarr2,out int a,out int b);
        //Console.WriteLine(a + " " + b);
        #endregion
        #region 链表测试
        //SingleLinkedList<int> list = new SingleLinkedList<int>();
        //list.InsertAsLast(1);
        //list.InsertAsLast(2);
        //list.InsertAsLast(3);
        //list.InsertAsLast(4);
        //list.InsertAsLast(5);

        //SingleLinkedList<int> otherList = new SingleLinkedList<int>();
        //otherList.InsertAsLast(1);
        //otherList.InsertAsLast(2);
        //otherList.InsertAsLast(3);
        //otherList.InsertAsLast(4);
        //otherList.InsertAsLast(5);
        //list.InsertAsFirst(1);
        //list.InsertAsFirst(2);
        //list.InsertAsFirst(3);
        //list.InsertAsFirst(4);
        //list.InsertAsFirst(5);
        //list.Reverse();
        //list.PrintPublic(otherList);
        //Node<int> cur = list.head.next;
        //while (cur != null)
        //{
        //    Console.WriteLine(cur.value);
        //    cur = cur.next;
        //}

        //SingleLinkedList<int> list = new SingleLinkedList<int>();
        //list.InsertAsLast(1);
        //Node<int> node = new Node<int>(2);
        //list.InsertAsLast(node);
        //list.InsertAsLast(3);
        //list.InsertAsLast(4);
        //list.InsertAsLast(5);


        //list.Partation(3);
        //Console.WriteLine(list.IsPalindrome());

        SingleLinkedList<int> list = new SingleLinkedList<int>();
        Node<int> node1 = new Node<int>(1);
        list.InsertAsLast(node1);
        Node<int> node2 = new Node<int>(2);
        list.InsertAsLast(node2);
        Node<int> node3 = new Node<int>(3);
        list.InsertAsLast(node3);
        Node<int> node4 = new Node<int>(4);
        list.InsertAsLast(node4);
        Node<int> node5 = new Node<int>(5);
        list.InsertAsLast(node5);

        SingleLinkedList<int> list2 = new SingleLinkedList<int>();
        //Node<int> node1 = new Node<int>(1);
        //list.InsertAsLast(node1);
        //Node<int> node2 = new Node<int>(2);
        //list.InsertAsLast(node2);
        list2.InsertAsLast(node3);
        
        list2.InsertAsLast(node4);
        
        list2.InsertAsLast(node5);


        Node<int> node = list.IsIntersectingNoLoop(list2);
        Console.WriteLine(node.value);
        Node<int> cur = list.head.next;
        while (cur != null)
        {
            Console.WriteLine(cur.value);
            cur = cur.next;
        }
        #endregion


    }
}
