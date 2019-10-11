using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = { 1, 2, 3, 4, 5, 6, 7 };
            string[] dataStrings = { "abc", "ab", "ab", "xyx" };
            string[] queries = { "ab", "gh", "xyx" };

            int[] result = reverseArray(data);
            List<int> resultList = reverseArrayGeneric(data);
            List<string> resultStrings = reverseArrayGeneric(dataStrings);
            result = reverseAdjacentElements(data);
            result = matchingStrings(dataStrings, queries);
        }
        
        //Count the number of occurances of each string in queries  
        static int[] matchingStrings(string[] strings, string[] queries)
        {
            var results = new int[queries.Length];

            var index = 0;

            foreach (string s in queries)
            {
                results[index++] = strings.Where(i => i == s).Count();
            }

            return results;
        }

        //Yes, array and list both have reverse methods...
        //But for whatever reason this is still asked in interviews.
        static int[] reverseArray(int[] a)
        {
            for (int index = 0; index <= (a.Length-1)/2; index++)
            {
                var tmp = a[index];
                a[index] = a[a.Length - index - 1];
                a[a.Length - index - 1] = tmp;
            }

            return a;
        }

        //Note: guidance on MSDN is to use IList to handle generic arrays. 
        //This was an interview question where the interviewer insisted on this method.
        //Even though array has exposed IList since .NET 2.0 :-|
        static void CopyElements<T>(T[] input , T[] output, int count, int sourceStart, int destStart)
        {
            if (input == null || output == null)
            {
                throw new ArgumentNullException("Input and output must not be null");
            }
            if (sourceStart + count > input.Length)
            {
                throw new ArgumentException("Input and count exceed array length");
            }
            if (destStart + count > output.Length)
            {
                throw new ArgumentException("Output and count exceed array length");
            }

            for (int i = sourceStart; i < sourceStart + count; i++)
            {
                output[destStart] = input[i];
                destStart++;
            }
        }

        static List<T> reverseArrayGeneric<T>(IList<T> a)
        {
            for (int index = 0; index <= (a.Count - 1) / 2; index++)
            {
                var tmp = a[index];
                a[index] = a[a.Count - index - 1];
                a[a.Count- index - 1] = tmp;
            }

            return a.ToList();
        }
        
        static int[] reverseAdjacentElements(int[] a)
        {
            for (int index = 0; index <= a.Length - 2 ; index+=2)
            {
                var tmp = a[index];
                a[index] = a[index + 1];
                a[index+1] = tmp;
            }

            return a;

        }

    }
}
