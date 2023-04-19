using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    public class Vector<T> where T : IComparable
    {
        private T[] mArray;
        private int capacity;
        private int size;
        #region 构造函数
        public Vector(int cap = 0)
        {
            capacity = cap;
            size = 0;
            mArray = new T[cap];

            //for(int i = 0; i < size;i++)
            //{
            //    mArray[i] = value;
            //}
        }
        public Vector(T[] array, int lo, int hi)
        {
            CopyFrom(array, lo, hi);
        }
        public Vector(T[] array)
        {
            CopyFrom(array, 0, array.Length);
        }
        public Vector(Vector<T> vector, int lo, int hi)
        {
            CopyFrom(vector.mArray, lo, hi);
        }
        public Vector(Vector<T> vector)
        {
            CopyFrom(vector.mArray, 0, vector.size);
        }
        #endregion

        #region 排序接口

        #region 选择排序
        public void SelectionSort(int lo, int hi)
        {
            if (mArray == null || size <= 1 || hi - lo <= 1) return;
            //未排序部分找到最小值，然后和未排序部分的开头交换，每次遍历确定一个已排序部分元素
            for (int i = lo; i < hi; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < hi; j++)
                {
                    if (mArray[minIndex].CompareTo(mArray[j]) > 0)
                    {
                        minIndex = j;
                    }
                }
                Swap(i, minIndex);
            }
        }
        public void SelectionSort()
        {
            SelectionSort(0, size);
        }
        #endregion
        #region 冒泡排序
        public void BubbleSort(int lo, int hi)
        {
            if (mArray == null || size <= 1 || hi - lo <= 1) return;
            bool isSorted = false;
            while (!isSorted)
            {
                isSorted = true;
                for (int j = 1; j < hi; j++)
                {
                    if (mArray[j - 1].CompareTo(mArray[j]) > 0)
                    {
                        Swap(j - 1, j);
                        isSorted = false; //如果内循环从没进此判断，则一定是已经全部有序了
                    }
                }
                hi--;  //减小未排序规模
            }
        }
        public void BubbleSort()
        {
            BubbleSort(0, size);
        }
        #endregion
        #region 插入排序
        public void InsertionSort(int lo, int hi)
        {
            if (mArray == null || size <= 1 || hi - lo <= 1) return;
            for (int i = lo + 1; i < hi; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (mArray[j].CompareTo(mArray[j - 1]) < 0)
                    {
                        Swap(j, j - 1);
                    }
                }
            }
        }
        public void InsertionSort()
        {
            InsertionSort(0, size);
        }
        #endregion
        #region 归并排序
        public void MergeSort(int lo,int hi)
        {
            //非法情况或者只有一个元素的情况
            if(mArray == null || size<=1) return;
            //Console.WriteLine($"正在调用Mersort({lo},{hi})");
            //递归基
            if (hi - lo <= 1)
            {
                //Console.WriteLine($"Mersort({lo},{hi})得到结果 规模为一时缩减为叶子节点");
                return;
            } 
            int mid = lo + ((hi - lo) >> 1); //注意 >> 优先级较低，必须打括号
            
            MergeSort(lo,mid);
            MergeSort(mid,hi);
            //Console.WriteLine($"Mersort({lo},{hi})开始Merge");
            Merge(lo,hi);
            //Console.WriteLine($"Mersort({lo},{hi})得到结果,完成");
        }
        public void Merge(int lo,int hi)
        {
            T[] temp = new T[hi-lo];
            int p1 = lo;
            int mid = lo + ((hi - lo) >> 1);
            int p2 = mid;

            int tempIndex = 0;
            while(p1<mid && p2< hi)
            {
                if (mArray[p1].CompareTo(mArray[p2]) <= 0)//这里小于等于，相等时先将左侧的数加入tempArr
                {
                    temp[tempIndex++] = mArray[p1++];
                }
                else 
                {
                    temp[tempIndex++] = mArray[p2++];
                }
            }
            while(p1 < mid)
            {
                temp[tempIndex++] = mArray[p1++];
            }
            while(p2 < hi)
            {
                temp[tempIndex++] = mArray[p2++];
            }
            //Console.WriteLine(temp.Length);
            for (int i = 0;i< temp.Length;i++)
            {
                //Console.WriteLine(temp[i]);
                mArray[lo++] = temp[i];
                
            }
        }
        public void MergeSort()
        {
            MergeSort(0, size);
        }
        #endregion
        #region 快速排序
        public void QuickSort(int lo,int hi)
        {
            Console.WriteLine("!!!!" + lo + "  " + hi);
            if (lo >= hi) return; //递归基
            
            T value = mArray[hi-1];
            Partition(value, out int l, out int r);
            //Console.WriteLine($"根据{hi-1}:{mArray[hi-1]}  分区完成 {l},{r}");
                
            QuickSort(lo, l);
            //Console.WriteLine($"[{lo},{l})排序完成");
            QuickSort(r, hi);
            //Console.WriteLine($"[{r},{hi})排序完成");
            
            
        }
        public void QuickSort()
        {
            QuickSort(0,size);
        }

        //将内置的[lo,hi)范围用value划分为左边都是<= 它的数，右边都是大于等于它的数
        public void PartitionSimple(T value)
        {
            //最终[0, p0) <= [p0, size) >
            int p0 = 0; // <= 的末尾位置的开区间 
            int i = 0; //遍历索引
            while(i < size)
            {
                if (mArray[i].CompareTo(value)<=0)
                {
                    Swap(i++,p0++);
                }
                else
                {
                    i++;
                }
            }
            //Console.WriteLine(p0);

        }
        //将内置数组用value划分为左边都是< 它的数，中间都是等于它的数，右边都是大于它的数
        
        public void Partition(T value,out int l,out int r)
        {
            //最终[0,p0) < [p0,p1) == [p1,size) >
            int i = 0;
            int p0 = 0;
            int p1 = size;
            while(i< p1)
            {
                if (mArray[i].CompareTo(value)<0)
                {
                    Swap(p0++, i++);
                }
                else if(mArray[i].CompareTo(value) == 0)
                {
                    i++;
                }
                else
                {
                    Swap(i, --p1);
                }
            }
            l = p0;
            r = p1; 
        }
        #endregion
        #region 逆序对个数
        public int ReverseOrderPairNum()
        {
            T[] temp = mArray;
            int sum =  ReverseOrderPairNum(0,size);
            mArray = temp;
            return sum;
        }
        public int ReverseOrderPairNum(int lo,int hi)
        {
            if (hi - lo <= 1) return 0;
            int mid = lo + ((hi - lo) >> 1);
            int lNum = ReverseOrderPairNum(lo, mid);
            int rNum = ReverseOrderPairNum(mid,hi);
            int mergeNum = MergeReverseOrderPairNum(lo,hi);
            
            return lNum + rNum + mergeNum;
        }

        public int MergeReverseOrderPairNum(int lo,int hi)
        {
            T[] tempArr = new T[hi - lo];
            int mid = lo + ((hi - lo) >> 1);
            int i = 0;
            int p0 = lo; 
            int p1 = mid;
            int sum = 0;
            
            int j = 0;
            while (p0 < mid && p1 < hi)
            {
                if (mArray[p0].CompareTo(mArray[p1]) < 0) //这里严格小于，相等时先将右侧的数加入tempArr
                {
                    sum = sum + (hi - p1);
                    tempArr[i++] = mArray[p0++];
                }
                else
                {
                    tempArr[i++] = mArray[p1++];
                }
            }
            while(p0 < mid) //左边还有数
            {
                tempArr[i++] = mArray[p0++];
            }
            while(p1< hi) //右边还有数
            {
                tempArr[i++] = mArray[p1++];
            }
            while(j < tempArr.Length)
            {
                
                mArray[lo++] = tempArr[j++];
                
            }
            return sum;
        }
        #endregion
        #region 小和问题
        public static int LessSum(int[] rawArr )
        {
            int[] temp = rawArr;
            int sum = LessSum(rawArr,0, rawArr.Length);
            rawArr = temp;
            return sum;
        }
        //在一个数组中，每一个数左边比当前数小的数累加起来，叫做这个数组的小和
        public static int LessSum(int[] rawArr,int lo,int hi)
        {
            //转化为 对每一个数，右边比它大的数的个数 * 自己 就是当前数给总体的小和的贡献
            //转化为类似逆序对的问题
            if (hi - lo <= 1)
            {
                //Console.WriteLine("[" + lo + "," + hi + " )");
                return 0;
            }
            
            int mid = lo + ((hi - lo) >> 1);
            int lNum = LessSum(rawArr, lo, mid);
            int rNum = LessSum(rawArr, mid, hi);
            int mergeNum = MergeLessSum(rawArr,lo, hi);
            //Console.WriteLine("["+lo +"," + hi+ " )"+ lNum + " " + rNum + " " + mergeNum);
            return lNum + rNum + mergeNum;
        }
        public static int MergeLessSum(int[] rawArr,int lo,int hi)
        {
            int[] tempArr = new int[hi - lo];
            int mid = lo + ((hi - lo) >> 1);
            int i = 0;
            int p0 = lo;
            int p1 = mid;
            int sum = 0;

            int j = 0;
            while (p0 < mid && p1 < hi)
            {
                if (rawArr[p0].CompareTo(rawArr[p1]) < 0) //这里严格小于，相等时先将右侧的数加入tempArr
                {
                    sum = sum + (hi - p1) * rawArr[p0];
                    tempArr[i++] = rawArr[p0++];
                }
                else
                {
                    tempArr[i++] = rawArr[p1++];
                }
            }
            while (p0 < mid) //左边还有数
            {
                tempArr[i++] = rawArr[p0++];
            }
            while (p1 < hi) //右边还有数
            {
                tempArr[i++] = rawArr[p1++];
            }
            while (j < tempArr.Length)
            {

                rawArr[lo++] = tempArr[j++];

            }
            return sum;
        }
        #endregion
        #endregion
        #region 查找接口
        //二分查找（前提是数据状况为有序）
        public int BinarySearch(T value, int lo, int hi)
        {
            if (mArray == null || size == 0 || hi - lo == 0) return -1;
            int L = lo;
            int R = hi;
            int mid = L + (R - L) / 2;
            //在[L,R)范围找value,如果一直未找到，最终规模缩减为 0  即[i,i) L = R
            while (L < R) 
            {
                mid = L + (R - L) / 2;
                if (value.CompareTo(mArray[mid]) == 0) //找到则提前返回
                { return mid; }
                else if (mArray[mid].CompareTo(value) < 0) //如果mid处的值比value小,则value只可能在mid的右边
                {
                    L = mid + 1;
                }
                else if (value.CompareTo(mArray[mid]) < 0) //如果value比mid处的值小，则value只可能在mid的左边
                {
                    R = mid;
                }
            }
            return -1; //未找到
        }
        public int BinarySearch(T value)
        {
            return BinarySearch(value, 0, size);
        }

        //找到大于等于value的最小值索引(多个命中元素时，返回秩最小者，未命中时，返回最小的大于value的值)
        public int BinarySearchMinRank(T value, int lo, int hi)
        {
            if (mArray == null || size == 0 || hi - lo == 0) return -1;
            int L = lo;
            int R = hi;
            int mid = 0;
            while (L < R) //目标是 [lo,L)为小于value的数，[R,hi)为大于等于value的数，最终迭代为L == R为大于等于value的最前面位置的数
            {
                mid = L + (R - L) / 2;
                if (mArray[mid].CompareTo(value) < 0) //如果mid处的值比value小,则value只可能在mid的右边 ；实际扩大了小于value的数的范围 
                {
                    L = mid + 1;
                }
                else
                {
                    R = mid;
                }
            }
            return L; //L == R
        }
        public int BinarySearchMinRank(T value)
        {
            return BinarySearchMinRank(value, 0, size);
        }

        //返回符合条件的秩最大者（一般有序插入位置（稳定性））
        public int BinarySearchMaxRank(T value, int lo, int hi)
        {
            if (mArray == null || size == 0 || hi - lo == 0) return -1;
            int L = lo;
            int R = hi;
            int mid = 0;
            while(L < R)  //目标是 [lo,L) 范围为小于等于value的数   [hi,R）范围为 大于value的数 最终L==R为大于value的第一个数索引
            {
                mid = L + (R - L) / 2;
                //value小于mArray[mid]，所以（e<）范围扩大为[mid,hi) 
                if (value.CompareTo(mArray[mid]) < 0) 
                {
                    R = mid;
                }
                //value在右边，所以（<=e）范围扩大为[lo,mid+1)
                else
                {
                    L = mid + 1;
                }
            }
            return L -1; 
        }
        public int BinarySearchMaxRank(T value)
        {
            return BinarySearchMaxRank(value,0,size);
        }
        #endregion
        #region 局部最小值
        //局部最小值问题： 无序数组中，相邻数一定不相等，求数组中的一个局部最小值索引（小于相邻的数） 时间复杂度要求小于O(N)
        //局部最小值： 对于0位置，如果他比1位置的数小，则为局部最小值
        //对于n-1位置，如果他比n-2位置的数小，则为局部最小值
        //对于其余i位置，如果他比i-1位置和i+1位置上的数小，则为局部最小值
        public int LocalMin()
        {
            int index = -1;
            if(mArray == null || size == 0) { 
                return index;
            }
            if (size == 1) { return 0; }

            if (mArray[0].CompareTo(mArray[1]) < 0) { return 0; }
            if (mArray[size-1].CompareTo(mArray[size-2]) < 0) { return 0; }
            int L = 1;
            int R = size - 1;
            int mid = 0;

            while(R-L > 1)//在[L,R)找到符合比i-1位置和i+1位置上的数小的数
            {
                mid = L + (R-L) / 2;
                if (mArray[mid].CompareTo(mArray[mid - 1]) < 0 && mArray[mid].CompareTo(mArray[mid + 1]) < 0  )
                {
                    return mid;
                }
                else if(mArray[mid].CompareTo(mArray[mid - 1]) > 0) //找到比左边的数大的数，则可能区间向左缩减
                {
                    R = mid - 1;
                }
                else if (mArray[mid].CompareTo(mArray[mid + 1]) > 0) //找到比右边的数大的数，则可能区间向左缩减
                {
                    L = mid;
                }

            }

            return R; //规模缩小为1后[i,i+1),结果为R的值或者说L+1的值

        }
        #endregion

        #region 内部工具函数
        //从数组的[lo,hi)区间 copy 到Vector
        void CopyFrom(T[] arr, int lo, int hi)
        {
            capacity = (hi - lo) * 2;
            mArray = new T[capacity];
            size = 0;
            while (lo < hi)
            {
                mArray[size++] = arr[lo++];
            }
        }
        //交换内置数组中的两个位置的数值
        void Swap(int i, int j)
        {
            T element = mArray[i];
            mArray[i] = mArray[j];
            mArray[j] = element;
        }
        
        #endregion


    }
}
