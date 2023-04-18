namespace DSA
{
    /// <summary>
    /// 异或问题
    /// 基础性质： 
    /// 1.相同为0，不同为1 
    /// 2.可以理解为无进位的二进制加法  
    /// 3.满足结合律和交换律
    /// 4.N^N = 0 0 ^N = N
    /// </summary>
    public static class XOR
    {
        //一个数组中 有一种数出现了奇数次，另一种数都出现了偶数次，找到这个数
        public static int FindOnlyOnce(int[] arr)
        {
            int xor = 0;
            foreach (var item in arr) //偶数项全部放一起异或，结果为0，再异或一个数，结果即为这个数
            {
                xor ^= item;
            }
            return xor;
        }

        //一个数组中 有两种数出现了奇数次，另一种数都出现了偶数次，找到这个数
        public static void FindOnlyTwice(int[] arr, out int a, out int b)
        {
            int xor = 0;
            int xor1 = 0;
            foreach (var item in arr) //偶数项全部放一起异或，结果为0，再异或一个数，结果即为两个出现了奇数次异或的数的异或,再进一步，只剩两个数的异或
            {
                xor ^= item;
            }
            //此时可以理解为只剩 1个 i 和一个 j 异或，这个值为xor
            //int rightOne = xor & (~xor + 1); //x 取反+1 相当于将最右边的1左边的所有数取反，此时  x 与取反加一（-x）的唯一共同点是最右边的1，rightOne表示最右边的1，其他位全为0代表的数
            int rightOne = xor & (-xor);
            foreach (var item in arr)
                if ((item & rightOne) == 1) //某一位为1的数的异或，最终由于交换律和结合律，只剩两个数各出现一次，因为该位为1，所以两个数一个在该位为1，一个在该位为0
                {
                    xor1 ^= item;
                }
            a = xor1;
            b = a ^ xor;
        }
    }
}

