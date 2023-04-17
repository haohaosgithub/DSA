using System;
using System.Collections.Generic;
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
        public Vector(int cap = 0,int size = 0)
        {
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
        public void SelectionSort(int lo,int hi)
        {
            for(int i = lo;i<hi;i++) 
            {
                int minIndex = i;
                for(int j = i+1;j < hi;j++)
                {
                    //if (mArray[minIndex].CompareTo(mArray[j]) > 0 )
                    if (mArray[j].CompareTo(mArray[minIndex]) < 0)
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
