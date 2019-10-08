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
