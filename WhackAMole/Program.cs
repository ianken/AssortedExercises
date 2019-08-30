using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//A set if puzzles where the solution can involve a moving window...

namespace WhackAMole
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = { 0, 1, 1, 0, 1, 0, 1, 0, 0, 0, 1 };
            int[] data2 = { 0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0, 1, 0 };
            int[] data3 = { 1, 1, 1, 0, 0, 1, 0, 1 ,0 ,1 ,0 , 1, 1, 0, 1, 1};
            var window = 5;
            int maxHole = 0;

            //It's not all sexy and recursive, but it's a lot easier to read.
            //Find the largest sum within a subaray of size "window"
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
            
            //Fetch the largest sum of a given sub array of size "window" within the input and return its index
            int index;
            var recResult1 = GetLargestWithIndex(data3, window, 0, out index);
            //Fetch the largest sum of two sub arrays of a given size "window" within the input
            var recResult2 = SumTwoLargest(data3, window);
            //Return largest contiguous run
            var recResult3 = GetLargestIsland(data3, 0);

            int[] dta = { 33, 11, 44, 11, 55 };
            int[] windows = { 1, 2, 3, 4, 5 };

            int[] dta2 = { 1, 2, 3, 4, 5 };
            int[] windows2 = { 1, 2, 3, 4, 5 };

            int[] dta3 = { 176641, 818878, 590130, 846132, 359913, 699520, 974627, 806346, 343832, 619769, 760242, 693331, 832192, 775549, 353117, 23950, 496548, 183204, 971799, 393071, 727476, 351337, 811496, 24595, 417701, 664960, 745806, 538176, 230403, 942316, 21481, 605695, 598531, 651683, 558460, 583357, 530911, 721611, 308228, 724620, 429167, 909353, 330152, 116815, 986067, 713467, 906132, 428600, 927889, 567272, 647109, 992614, 747948, 192884, 879696, 262543, 782487, 829272, 470060, 427956, 751730, 597177, 870616, 754791, 421830, 11676, 425656, 841955, 693419, 462693, 245403, 192649, 750201, 180732, 17450, 44723, 527618, 174579, 515786, 444844, 210843, 563425, 809540, 752036, 608529, 748313, 667439, 255643, 387412, 320353, 704213, 755272, 267902, 657989, 651762, 325654, 582887, 382501, 715426, 897450 };
            int[] windows3 = { 29, 78, 96, 89,  81, 17, 50, 34, 8, 17, 58, 7, 65, 59, 3, 58, 80, 31, 21, 12, 87, 19, 6, 70, 60, 98, 55, 27, 67, 94, 57, 69, 14, 66, 52, 73, 62, 73, 30, 77, 38, 23, 15, 63, 25, 72, 89, 91, 25, 38, 88, 22, 48, 79, 71, 33, 72, 21, 26, 59, 100, 43, 77, 81, 55, 44, 43, 2, 42, 48, 1, 30, 33, 71, 94, 58, 34, 93, 58, 27, 92, 91, 83, 47, 61, 34, 25, 88, 37, 90, 3, 95, 5, 68, 39, 40, 71, 56, 89, 4 };

            var result = solve(dta, windows);

        }

        //Lot of recursion. People like this. Sometimes it makes sense. ;-)

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

        //Find the count of the largest uninterupted run of non zero values in an array.
        //This is the "find the largest island" question. A variant of the "whack a mole" mallet puzzle.
        
        static int GetLargestIsland(int[] data, int startIndex)
        {
            if (data == null)
                throw new NullReferenceException("Input data cannot be null...");
            if (startIndex >= data.Length)
                throw new IndexOutOfRangeException($"Specified start point {startIndex} too large...");

            if (startIndex < data.Length-1)
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

            var endIndex = GetLargestIslandBoundFromIndex(data, index);
            return endIndex - index + 1;
        }
        
        static int GetLargestIslandBoundFromIndex(int[] data, int index)
        {
            //All out of dry land
            if (data[index] == 0)
                return index - 1;

            if (index < data.Length-1)
            {
                return GetLargestIslandBoundFromIndex(data, index + 1);
            }
            else
            {
                if (data[index] == 0)
                    return index - 1;
                else
                    return index;
            }
        }

        //Given two "mallets" what's the largest number of "moles" you can smoosh?
        //A hybrid of the iterative and recursive moving window solution. 
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


        //Not fast enough for Hackerrank.
        //Sliding window minimum of maxes.
        static int[] solve(int[] arr, int[] queries)
        {
            List<int> results = new List<int>();

            foreach (int i in queries)
            {
                results.Add(MinRecursive(arr, i, 0));
            }

            return results.ToArray(); ;
        }

        //Sliding window using queue in parallel.
        //Still not fast enough.

        static int[] solve2(int[] arr, int[] queries)
        {
            int[] results = new int[queries.Length];

            Parallel.ForEach(queries, (i, state, index) =>
                {
                    Queue<int> slidingWindow = new Queue<int>();
                    Stack<int> progress = new Stack<int>();

                    for (int idx = 0; idx < arr.Length; idx++)
                    {
                        slidingWindow.Enqueue(arr[idx]);

                        if (slidingWindow.Count == i)
                        {
                        //save value
                        progress.Push(slidingWindow.Max());
                        slidingWindow.Dequeue();
                        }
                    }
                    results[index] = progress.Min();
                }
                );
            return results;
        }


        static int MinIterative(int[] data, int window, int startIndex)
        {
            var min = int.MaxValue;

            while (startIndex + window <= data.Length)
            {
                var currentMax = data.Skip(startIndex).Take(window).Max();
                min = Math.Min(min, currentMax);
                startIndex++;
            }

            return min;

        }

        static int MinRecursive(int[] data, int window, int startIndex)
        {
            var currentMax = data.Skip(startIndex).Take(window).Max();

            if (startIndex + window < data.Length)
            {
                return Math.Min(MinRecursive(data, window, startIndex + 1), currentMax);
            }
            else
            {
                //at the end
                return currentMax;
            }
        }

    }
}
