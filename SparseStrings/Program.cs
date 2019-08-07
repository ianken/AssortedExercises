using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayShiftLeft
{

    //if you assume your left shift will less than or equal to the array size then this can be simpler. 
    //That's what the hacker rank problem allows.
    //This solution allows for arbitrary left shift sizes.  

    class Program
    {
        static void Main(string[] args)
        {
            string[] nd = { "5", "4" }; //Console.ReadLine().Split(' ');

            //array size is n
            int n = Convert.ToInt32(nd[0]);
            //roation count
            int d = Convert.ToInt32(nd[1]);
            //Array of ints
            int[] a = Array.ConvertAll("1 2 3 4 5".Split(' '), aTemp => Convert.ToInt32(aTemp));

            var shiftCount = d % n;

            //Simple:
            for (int i = shiftCount; i < n; i++)
                Console.Write($"{a[i]} ");
            for (int i = 0; i < shiftCount; i++)
                Console.Write($"{a[i]} ");

            //Less simple:
            var newLeft = SubArray(a, shiftCount, n - shiftCount);
            var newRight = SubArray(a, 0, shiftCount);

            var shiftedArray = newLeft.Concat(newRight).ToArray();

            var sb = new StringBuilder();

            foreach (int i in shiftedArray)
            {
                sb.Append($"{i} ");
            }

            Console.WriteLine(sb);


        }

        static T[] SubArray<T>(T[] data, int index, int length)
        {
            var result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }
}
