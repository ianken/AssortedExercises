using System;
using System.Collections.Generic;
using System.Linq;

/* The task: given two arrays of integers where each array has the same number of elements
 * and each int has the same number of digits compute the distance between them. 
 * 
 * IE: the minimum number of increments or decrements needed to transform one array into the other.
 * 
 * For this task you need to increment/decrement each digit, not the entire int.
 * 
 * The solution: decompose the arrays of integers into arrays of indvidual single digits. 
 * Compute the absolute difference of each one then sum the results.
 * C# string and conversion utilities makes this easy.
 * 
 * There's undoubtedly a cleaner solution than this.
 */


namespace MinMoves
{
    class MinMoves

    {
        static void Main(string[] args)
        {

            var left = new List<int> { 123, 346 };
            var right = new List<int> { 223, 446 };
            var result = Result.minimumMoves(left, right);
            Console.WriteLine($"Minimum \"moves\" to match integeer lists is {result}");
        }
    }

    class Result
    {
        public static int minimumMoves(List<int> a, List<int> m)
        {

            var count = a.Count();
            var moves = 0;

            for (int index = 0; index < count; index++)
            {
                var left = a[index].ToString();
                var right = m[index].ToString();

                for (int index2 = 0; index2 < left.Length; index2++)
                {
                    moves += Math.Abs(Convert.ToInt32(left[index2]) - Convert.ToInt32(right[index2]));
                }

            }

            return moves;

        }

    }
}
