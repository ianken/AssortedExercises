using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] unsortedInt = { 3, 7, 1, 8, 32, 2, 5 };
            var res = SelectionSort(unsortedInt);
            res = MergeSort(unsortedInt);
            res = BubbleSort(unsortedInt);
        }

        static int[] SelectionSort(int[] input)
        {
            int len = input.Length;
            for (int idx1 = 0; idx1 < len - 1; idx1++)
                for (int idx2 = idx1 + 1; idx2 < len; idx2++)
                {
                    if (input[idx2] < input[idx1])
                    {
                        var tmp = input[idx1];
                        input[idx1] = input[idx2];
                        input[idx2] = tmp;
                    }
                }

            return input;
        }

        static int[] BubbleSort(int[] input)
        {
            var sortComplete = false;
            do
            {
                sortComplete = true;
                for (int idx = 0; idx < input.Length - 1; idx++)
                {
                    if (input[idx] > input[idx + 1])
                    {
                        sortComplete = false;
                        var tmp = input[idx];
                        input[idx] = input[idx + 1];
                        input[idx + 1] = tmp;
                    }
                }
            }
            while (!sortComplete);

            return input;
        }

        static int[] MergeSort(int[] input)
        {
            if (input.Length == 1)
                return input;

            int[] left = Helpers.SubArray(input, 0, input.Length / 2);
            int[] right = Helpers.SubArray(input, input.Length / 2, input.Length - input.Length / 2);

            var resLeft = MergeSort(left);
            var resRight = MergeSort(right);

            return Merge(resLeft, resRight);

        }

        static int[] Merge(int[] left, int[] right)
        {
            int[] result = new int[left.Length + right.Length];

            var leftIdx = 0;
            var rightIdx = 0;

            for (int idx1 = 0; idx1 < result.Length; idx1++)
            {

                if (leftIdx < left.Length && rightIdx < right.Length)
                {
                    if (left[leftIdx] > right[rightIdx])
                    {
                        result[idx1] = right[rightIdx];
                        rightIdx++;
                    }
                    else if (left[leftIdx] < right[rightIdx])
                    {
                        result[idx1] = left[leftIdx];
                        leftIdx++;
                    }
                    else //equal, use either.
                    {
                        result[idx1] = left[leftIdx];
                        leftIdx++;
                    }
                }
                else
                {
                    if (rightIdx >= right.Length)
                    {
                        result[idx1] = left[leftIdx];
                        leftIdx++;
                    }
                    else if (leftIdx >= left.Length)
                    {
                        result[idx1] = right[rightIdx];
                        rightIdx++;
                    }
                }
            }

            return result;
        }
    }

    static class Helpers
    {
        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }
}
