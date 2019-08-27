using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhackAMole
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = { 0, 1, 1, 0, 1, 0, 1, 0, 0, 0, 1 };
            int[] data2 = { 0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0, 1, 0 };
            int[] data3 = { 1, 1, 1, 0, 0, 1, 1, 1 ,1 ,1 ,0 , 0, 0, 0, 1, 1};
            var window = 5;
            int maxHole = 0;

            for (int i = 0; i <= data.Length - window; i++)
            {
                var hole = data.Skip(i).Take(window).Sum();
                int holeIndex;
                if (maxHole < hole)
                {
                    maxHole = hole;
                    holeIndex = i;
                }
            }
            int index;

            //Fetch the largest sum of a given sub array of size "window" within the input
            var recResult1 = GetLargestWithIndex(data3, window, 0, out index);
            //Fetch the largest sum of two sub arrays of a given size "window" within the input
            var recResult2 = SumTwoLargest(data3, window);
        }

        static int GetLargest(int[] data, int window, int startIndex)
        {
            if (data == null)
                throw new NullReferenceException("Input data cannot be null");

            if (startIndex + window <= data.Length)
            {
                if (startIndex + window < data.Length)
                {
                    return Math.Max(GetLargest(data, window, startIndex + 1), data.Skip(startIndex).Take(window).Sum());
                }
                else
                {
                    //at the end
                    return data.Skip(startIndex).Take(window).Sum();
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        static int SumTwoLargest(int[] data, int window)
        {
            if (data == null)
                throw new NullReferenceException("Input data cannot be null");

            if (window > data.Length / 2)
                throw new ApplicationException("Search window is too large");

            List<int> allSums = new List<int>();

            for (int i = 0; i <= data.Length - window; i++)
            {
                if (i > window)
                {
                    //Get largest from "left" of moving window
                    var leftSubArray = data.Take(i - 1).ToArray();
                    allSums.Add(GetLargest(leftSubArray, window, 0) + data.Skip(i).Take(window).Sum());
                }

                if (i + window < data.Length - window)
                {
                    //Get largest from "right" of moving window
                    allSums.Add(GetLargest(data, window, i + window) + data.Skip(i).Take(window).Sum());
                }
            }
            return allSums.OrderByDescending(x => x).ToArray()[0];
        }

        static int GetLargestWithIndex(int[] data, int window, int startIndex, out int index)
        {
            if (startIndex + window <= data.Length)
            {
                if (startIndex + window < data.Length)
                {
                    var V1 = GetLargestWithIndex(data, window, startIndex + 1, out index);
                    var V2 = data.Skip(startIndex).Take(window).Sum();

                    //As we bubble up the stack only set the 
                    //index if where we are is larger than where we've been.
                    if (V2 > V1)
                        index = startIndex;

                    return Math.Max(V1, V2);
                }
                else
                {
                    //at the end
                    index = startIndex;
                    return data.Skip(startIndex).Take(window).Sum();
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
