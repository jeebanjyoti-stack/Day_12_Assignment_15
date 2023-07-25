using System;
using System.Diagnostics;

namespace Day_12_Assignment_15
{
    internal class Program
    {
        //QuickSort
        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        private static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(array, left, right);
                QuickSort(array, left, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, right);
            }
        }

        private static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    Swap(array, i, j);
                }
            }
            Swap(array, i + 1, right);
            return i + 1;
        }

        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        //Merge Sort
        public static void MergeSort(int[] arr)
        {
            MergeSort(arr, 0, arr.Length - 1);
        }

        private static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }



        private static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;
            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];
            Array.Copy(arr, left, leftArray, 0, n1);
            Array.Copy(arr, mid + 1, rightArray, 0, n2);
            int i = 0;
            int j = 0;
            int k = left;
            while (i < n1 && j < n2)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    arr[k] = leftArray[i];
                    i++;
                }
                else
                {
                    arr[k] = rightArray[j];
                    j++;
                }
                k++;
            }
            while (i < n1)
            {
                arr[k] = leftArray[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                arr[k] = rightArray[j];
                j++;
                k++;
            }
        }
        public static void Print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + ",");
            }
            Console.WriteLine("\n");
        }

        static void Main(string[] args)
        {
            int[] array = { 9, -3, 5, 2, 6, 8, -6, 1, 3 };
            Console.WriteLine("Origional Array");
            Print(array);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            QuickSort(array);
            stopwatch.Stop();
            Console.WriteLine("After Quick Sort");
            Print(array);
            Console.WriteLine($"ArraySize {array.Length} Time Taken in Quick Sort {stopwatch.Elapsed.TotalMilliseconds} milliseconds");


            int[] arr = { 9, -3, 5, 2, 6, 8, -6, 1, 3 };
            Console.WriteLine("Origional Array: \n" + string.Join(",", arr));
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            MergeSort(arr);
            stopwatch1.Stop();
            Console.WriteLine("After Merge Sort: \n " + string.Join(",", arr));
            Console.WriteLine($"ArraySize {arr.Length} Time Taken in Merege Sort {stopwatch1.Elapsed.TotalMilliseconds} milliseconds");

            Console.ReadKey();
        }
        
        
    }
}
