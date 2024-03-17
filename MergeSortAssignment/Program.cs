using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSortAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Merge Sort Implementation in C#");

            // Array initialization and method calls will go here
            int[] array = { 12, 11, 13, 5, 6, 7 };

            Console.WriteLine("Original Array:");
            PrintArray(array);

            MergeSort(array, 0, array.Length - 1);

            Console.WriteLine("Sorted Array:");
            PrintArray(array);
        }

        // MergeSort method implementation will go here
        public static void MergeSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                // Find the middle point
                int middle = (left + right) / 2;

                // Sort first and second halves
                MergeSort(array, left, middle);
                MergeSort(array, middle + 1, right);

                // Merge the sorted halves
                Merge(array, left, middle, right);
            }
        }

        // Merge method implementation will go here
        public static void Merge(int[] array, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            // Create temporary arrays
            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            // Copy data to temp arrays leftArray[] and rightArray[]
            for (int i = 0; i < n1; i++)
                leftArray[i] = array[left + i];
            for (int j = 0; j < n2; j++)
                rightArray[j] = array[middle + 1 + j];

            int k = left;
            int x = 0, y = 0;

            // Merge the temp arrays back into array[left..right]
            while (x < n1 && y < n2)
            {
                if (leftArray[x] <= rightArray[y])
                {
                    array[k] = leftArray[x];
                    x++;
                }
                else
                {
                    array[k] = rightArray[y];
                    y++;
                }
                k++;
            }

            // Copy the remaining elements of leftArray[], if there are any
            while (x < n1)
            {
                array[k] = leftArray[x];
                x++;
                k++;
            }

            // Copy the remaining elements of rightArray[], if there are any
            while (y < n2)
            {
                array[k] = rightArray[y];
                y++;
                k++;
            }
        }

        // Helper method to print array elements
        public static void PrintArray(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}