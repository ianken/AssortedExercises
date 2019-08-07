using System.Collections.Generic;
using System.Linq;
using System;

class Result
{

    /*
     * Complete the 'rollTheString' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. INTEGER_ARRAY roll
     */

    public static string rollTheString(string s, List<int> roll)
    {
        char[] charArray = s.ToCharArray();

        roll = roll.OrderByDescending(r => r).ToList();
        int rollIndex = 0;
        int rollCount = 0;

        for (int charIndex = charArray.Length - 1; charIndex >= 0; charIndex--)
        {
            while (rollIndex < roll.Count)
            {
                if (charIndex >= roll[rollIndex])
                {
                    break;
                }

                rollCount++;
                rollIndex++;
            }
            charArray[charIndex] = rollChar(charArray[charIndex], rollCount);
        }

        return new string(charArray);
    }

    public static char rollChar(char c, int count)
    {

        return (char)(((c - 'a' + count) % 26) + 'a');

    }
}

class Solution
{
    public static void Test(string expected, string input, IEnumerable<int> roll)
    {
        string result = Result.rollTheString(input, roll.ToList());

        if (result != expected)
        {
            throw new Exception($"Expected:'{expected}', Actual:'{result}'.");
        }
    }


    public static void Main(string[] args)
    {


        Test("abcabc", "abcabc", new int[0]);
        Test("abcabc", "abcabc", new int[0]);
        Test("azzzzz", "zzzzzz", new int[] { 1 });
        Test("cdebcd", "abcabc", new int[] { 6, 3 });
        Test("efgcde", "abcabc", new int[] { 6, 6, 3, 3 });
        Test("eeebbc", "abcabc", new int[] { 1, 2, 3, 4 });
        Test("eeebbc", "abcabc", new int[] { 4, 3, 2, 1 });
        Test("efecbc", "abcabc", new int[] { 4, 2, 2, 4 });
        Test("uvwxyz", "abcdef", Enumerable.Repeat(6, 20));
        Test("xyzabc", "abcdef", Enumerable.Repeat(6, 23));
        Test("zbcabc", "abcabc", Enumerable.Repeat(1, 25));
        Test("abcabc", "abcabc", Enumerable.Repeat(1, 26));
        Test("abcabc", "abcabc", Enumerable.Repeat(1, 26 * 100000));

        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        //string s = Console.ReadLine();

        //int rollCount = Convert.ToInt32(Console.ReadLine().Trim());

        //List<int> roll = new List<int>();

        //for (int i = 0; i < rollCount; i++)
        //{
        //    int rollItem = Convert.ToInt32(Console.ReadLine().Trim());
        //    roll.Add(rollItem);
        //}

        //string result = Result.rollTheString(s, roll);

        //textWriter.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
    }
}
