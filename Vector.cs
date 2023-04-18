using System;
using System.Collections.Generic;
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

        //找到大于等于value的最小值索引
        public int BinarySearchLargeEq(T value, int lo, int hi)
        {
            if (mArray == null || size == 0 || hi - lo == 0) return -1;
            int L = lo;
            int R = hi;
            int mid = 0;
            while (L < R) //按照二分查找，在[L,R)范围找大于等于value的值的最左边，最终规模缩减为 0 L==R
            {
                mid = L + (R - L) / 2;
                if (mArray[mid].CompareTo(value) < 0) //如果mid处的值比value小,则value只可能在mid的右边 
                {
                    L = mid + 1;
                }
                else if (value.CompareTo(mArray[mid]) <= 0) //如果value比mid处的值小或相等，则value只可能在mid的左边，继续向左寻找
                {
                    R = mid;
                }
            }
            return L; //L == R
        }
        public int BinarySearchLargeEq(T value)
        {
            return BinarySearchLargeEq(value, 0, size);
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
