using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sort
{
    class SortArray
    {
        public SortArray(int[] Array)
        { }
       public static void BubbleSort(int[] Array)
        {
            for (int i = 0; i < Array.Length; i++)
            {
                for (int j = 0; j < Array.Length - 1; j++)
                {
                    if (Array[j] > Array[j + 1])
                    {
                        int temp = Array[j];
                        Array[j] = Array[j + 1];
                        Array[j + 1] = temp;
                    }
                }
            }
        }
        static void ShakerSort(int[] myint)
        {
            int left = 0,
                right = myint.Length - 1,
                count = 0;

            while (left <= right)
            {
                for (int i = left; i < right; i++)
                {
                    count++;
                    if (myint[i] > myint[i + 1])
                        Swap(myint, i, i + 1);
                }
                right--;

                for (int i = right; i > left; i--)
                {
                    count++;
                    if (myint[i - 1] > myint[i])
                        Swap(myint, i - 1, i);
                }
                left++;
            }
            Console.WriteLine("\nКоличество сравнений = {0}", count.ToString());
        }

        /* Поменять элементы местами */
        static void Swap(int[] myint, int i, int j)
        {
            int glass = myint[i];
            myint[i] = myint[j];
            myint[j] = glass;
        }
        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int cur = array[i];
                int j = i;
                while (j > 0 && cur < array[j - 1])
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = cur;
            }
        }
        public static void SelectionSort(int[] Array)
        {
            for (int i = 0; i < Array.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < Array.Length; j++)
                {
                    if (Array[j] < Array[min])
                    {
                        min = j;
                    }
                }
                int dummy = Array[i];
                Array[i] = Array[min];
                Array[min] = dummy;
                min = i;
            }
        }
        private static void ShellSort(int[] Array)
        {
            int step = Array.Length / 2;
            while (step > 0)
            {
                int i, j;
                for (i = step; i < Array.Length; i++)
                {
                    int value = Array[i];
                    for (j = i - step; (j >= 0) && (Array[j] > value); j -= step)
                        Array[j + step] = Array[j];
                    Array[j + step] = value;
                }
                step /= 2;
            }
        }
        static void Swap(ref int x, ref int y)
        {
            var t = x;
            x = y;
            y = t;
        }

        //метод возвращающий индекс опорного элемента
        static int Partition(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }
        static int[] QuickSort(int[] array)
        {
            return QuickSort(array, 0, array.Length - 1);
        }
        //быстрая сортировка
        public static int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }

        
    }
}
