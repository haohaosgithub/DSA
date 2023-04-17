using DSA;

internal class Program
{
    static void Main(string[] args)
    {
        #region 向量测试
        //Vector<int> v = new Vector<int>();
        int[] array = { 3, 3, 4, 3, 2 };
        Vector<int> v = new Vector<int>(array);
        //v.SelectionSort();
        //v.BubbleSort();
        v.InsertionSort();

        //Console.WriteLine(v.BinarySearch(8));
        Console.WriteLine(v.BinarySearchLargeEq(3));
        #endregion

    }
}
