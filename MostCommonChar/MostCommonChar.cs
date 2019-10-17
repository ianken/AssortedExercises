
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
            string text = "hello world";

            char result = Result.maximumOccurringCharacter(text);

            Console.WriteLine($"Most common character is: {result}");

            string text2 = "hello world";
            result = Result.maximumOccurringCharacterFast(text2);
        }
    }

    class Result
    {
        public static char maximumOccurringCharacter(string text)
        {
            var maxcount = 0;
            char result = ' ';
            var found = new List<char>();

            foreach (char c in text)
            {
                //Only count if it's new.
                if (!found.Contains(c))
                {
                    var count = text.Count(t => t == c);
                    found.Add(c);

                    if (count > maxcount)
                    {
                        maxcount = count;
                        result = c;
                    }
                }
            }

            return result;

        }

        //Hash implmentation. 
        public static char maximumOccurringCharacterFast(string text)
        {
            var maxcount = 0;
            char result = ' ';
            var found = new short[char.MaxValue];
            
            foreach (char c in text)
            {
                found[c]++;

                if (found[c] > maxcount)
                {
                    maxcount = found[c];
                    result = c;
                }
            }

            
            return result;
        }

    }
}
