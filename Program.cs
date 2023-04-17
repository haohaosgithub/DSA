using DSA;

internal class Program
{
    static void Main(string[] args)
    {
        #region 向量测试
        //Vector<int> v = new Vector<int>();
        int[] array = { 3, 1, 4, 5, 2 };
        Vector<int> v = new Vector<int>(array);
        //v.SelectionSort();
        v.BubbleSort();
        Console.WriteLine("hello");
        #endregion

    }
}
