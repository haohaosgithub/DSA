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
        public Vector(T[] array,int lo,int hi)
        {
           CopyFrom(array, lo, hi);  
        }
        public Vector(T[] array)
        {
            CopyFrom(array, 0, array.Length);
        }
        public Vector(Vector<T> vector,int lo,int hi)
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
            SelectionSort(0,size);
        }

        public void BubbleSort(int lo,int hi)
        {
            bool isSorted = false;
            while(!isSorted)
            {
                isSorted = true;
                for(int j = 1; j < hi;j++)
                {
                    if (mArray[j - 1].CompareTo(mArray[j]) >0)
                    {
                        Swap(j-1,j);
                        isSorted = false; //如果内循环从没进此判断，则一定是已经全部有序了
                    }
                }
                hi--;  //减小未排序规模
            }
        }

        public void BubbleSort()
        {
            BubbleSort(0,size);
        }
        
        public void InsertionSort(int lo,int hi) 
        {
            for(int i = lo + 1; i < hi  ;i++)
            {
                for(int j = i;j > 0 ;j--)
                {
                    if (mArray[j].CompareTo(mArray[j-1]) <0)
                    {
                        Swap(j,j-1);
                    }
                }
            }
        }

        public void InsertionSort()
        {
            InsertionSort(0,size);
        }
        #endregion
        #region 查找接口
        /// <summary>
        /// 二分查找：前提是有序
        /// </summary>
        /// <param name="value"></param>
        /// <param name="lo"></param>
        /// <param name="hi"></param>
        /// <returns></returns>
        public int BinarySearch(T value,int lo,int hi)
        {
            int L = lo;
            int R = hi;
            int mid = L + (R - L) / 2;
            while(L< R)
            {
                if (value.CompareTo(mArray[mid]) == 0)
                { return mid; }
                else if (mArray[mid].CompareTo(value) < 0 ) //如果mid处的值比value小,则value只可能在mid的右边
                {
                    L = mid + 1;
                    mid = L + (R - L) / 2;
                }
                else if (value.CompareTo(mArray[mid]) < 0) //如果value比mid处的值小，则value只可能在mid的左边
                {
                    R = mid;
                    mid = L + (R - L) / 2;
                }
            }
            return -1;
        }
        public int BinarySearch(T value)
        {
            return BinarySearch(value,0,size);
        }
        #endregion
        #region 内部工具函数
        //从数组的[lo,hi)区间 copy 到Vector
        void CopyFrom(T[] arr,int lo,int hi)
        {
            capacity = (hi - lo) * 2;
            mArray = new T[capacity];
            size = 0;
            while(lo< hi) 
            {
                mArray[size++] = arr[lo++];
            }
        }
        //交换内置数组中的两个位置的数值
        void Swap(int i,int j)
        {
            T element = mArray[i];
            mArray[i] = mArray[j];
            mArray[j] = element;
        }
        
        #endregion

        
    }
}
