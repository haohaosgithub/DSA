using DSA;
using System.Runtime.InteropServices;

internal class Program
{
    static void Main(string[] args)
    {
        #region 向量测试
        //Vector<int> v = new Vector<int>();
        //int[] array = { 4,3,2,4 };
        //Vector<int> v = new Vector<int>(array);
        //v.SelectionSort();
        //v.BubbleSort();
        //v.InsertionSort();

        //Console.WriteLine(v.BinarySearch(8));
        //Console.WriteLine(v.BinarySearchLargeEq(3));
        //Console.WriteLine(v.LocalMin());
        #endregion
        #region 异或问题测试
        //int[] xorarr = { 1,1,1,1,2,3,3};
        //Console.WriteLine(XOR.FindOnlyOnce(xorarr));
        int[] xorarr2 = { 1, 1, 1, 1, 2, 2, 2, 3, 4, 4 };
        XOR.FindOnlyTwice(xorarr2,out int a,out int b);
        Console.WriteLine(a + " " + b);
        #endregion
    }
}
