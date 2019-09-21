using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//A set if puzzles where the solution can involve a moving window...

namespace WhackAMole
{
    class Whack_A_Mole
    {
        static void Main(string[] args)
        {
            int[] data = { 0, 1, 1, 0, 1, 0, 1, 0, 0, 0, 1 };
            int[] data2 = { 0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0, 1, 0 };
            int[] data3 = { 1, 1, 1, 0, 0, 1, 1, 1 ,1 ,1 ,0 , 1, 1, 0, 1, 1};
            var window = 5;
            int maxHole = 0;

            //It's not all sexy and recursive, but it's a lot easier to read.
            //Find the largest sum within a subaray of size "window"
            for (int i = 0; i <= data.Length - window; i++)
            {
                var hole = data.Skip(i).Take(window).Sum();
                maxHole = Math.Max(maxHole, hole);
            }
            
            //Fetch the largest sum of a given sub array of size "window" within the input and return its index
            int index;
            var recResult1 = GetLargestWithIndex(data3, window, out index);
            window = 4;
            recResult1 = LargestWindowSum(data3, window);
            //Fetch the largest sum of two sub arrays of a given size "window" within the input
            var recResult2 = SumTwoLargestOpt(data3, window);
            //Return largest contiguous run
            var recResult3 = GetLargestIsland(data3);
        }

        //Given a window of size "window" find the largest sum in the data set.
        //Recursion.
        static int LargestWindowSum(int[] data, int window, int startIndex = 0)
        {
            if (data == null)
                throw new NullReferenceException("Input data cannot be null...");
            if (data.Length == 0)
                throw new ApplicationException("Input data cannot be empty...");
            
            if (startIndex + window <= data.Length)
            {
                if (startIndex + window < data.Length)
                {
                    return Math.Max(LargestWindowSum(data, window, startIndex + 1), data.Skip(startIndex).Take(window).Sum());
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

        //Find the count of the largest uninterupted run of non zero values in an array.
        //This is the "find the largest island" question. A variant of the "whack a mole" mallet puzzle.
        static int GetLargestIsland(int[] data, int startIndex = 0)
        {
            if (data == null)
                throw new NullReferenceException("Input data cannot be null...");
            if (startIndex >= data.Length)
                throw new IndexOutOfRangeException($"Specified start point {startIndex} too large...");

            if (startIndex < data.Length - 1)
            {
                return Math.Max(GetIslandLength(data,startIndex), GetLargestIsland(data, startIndex + 1));
            }
            else
            {
                return GetIslandLength(data, startIndex);
            }

        }

        //Optimized a bit
        static int GetLargestIslandOpt(int[] data, int startIndex)
        {
            if (data == null)
                throw new NullReferenceException("Input data cannot be null...");
            if (startIndex >= data.Length)
                throw new IndexOutOfRangeException($"Specified start point {startIndex} too large...");

            if (startIndex < data.Length - 1)
            {
                //Optimizaion to advance past measured islands.
                var islandSize = GetIslandLength(data, startIndex);
                var skip = islandSize == 0 ? startIndex + 1 : startIndex + islandSize;

                if (skip < data.Length)
                {
                    return Math.Max(islandSize, GetLargestIsland(data, skip));
                }
                else
                {
                    return islandSize;
                }
            }
            else
            {
                return GetIslandLength(data, startIndex);
            }
        }

        static int GetIslandLength(int[] data, int index)
        {
            if (index >= data.Length)
                throw new IndexOutOfRangeException($"Specified index {index} too large...");

            var endIndex = FindEndOfIsland(data, index);
            return endIndex - index + 1;
        }

        static int FindEndOfIsland(int[] data, int index)
        {
            //All out of dry land
            if (data[index] == 0)
                return index - 1;

            if (index < data.Length - 1)
            {
                return FindEndOfIsland(data, index + 1);
            }
            else
            {
                if (data[index] == 0)
                    return index - 1;
                else
                    return index;
            }
        }
          
        //As the index sweeps across the array, compute the largest 
        //subarrays on either side of the index and sum them.
        //return the largest.
        static int SumTwoLargestOpt(int[] data, int window)
        {
            if (data == null)
                throw new NullReferenceException("Input data cannot be null");

            if (window > data.Length / 2)
                throw new ApplicationException("Search window is too large");

            List<int> allSums = new List<int>();

            for (int i = 0; i <= data.Length - window; i++)
            {
                //Only check when there's enough room on both sides of the index
                if (i > window)
                {
                    var leftSubArray = data.Take(i - 1).ToArray();
                    var rightSubArray = data.Skip(i - 1).ToArray();
                    allSums.Add(LargestWindowSum(leftSubArray, window, 0) + LargestWindowSum(rightSubArray, window, 0));
                }
            }

            return allSums.OrderByDescending(x => x).ToArray()[0];
        }

        static int GetLargestWithIndex(int[] data, int window, out int index, int startIndex = 0)
        {
            if (startIndex + window <= data.Length)
            {
                if (startIndex + window < data.Length)
                {
                    var V1 = GetLargestWithIndex(data, window, out index, startIndex + 1);
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
