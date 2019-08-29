using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{

    static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        //This can be solved with circular queue but the test cases on hackerrank all have solutions, so you don't need to do that.

        int n = Convert.ToInt32(Console.ReadLine());

        var fuel = 0;
        var startPoint = 0;

        for (int i = 0; i <= n; i++)
        {
            var input = Console.ReadLine().Split(' ');
            var gas = Convert.ToInt32(input[0]);
            var distance = Convert.ToInt32(input[1]);
            fuel += gas - distance;
            if (fuel < 0)
            {
                //Out of "gas." Try from next station.
                startPoint = i + 1;
                fuel = 0;
            }
        }

        //textWriter.WriteLine(result);
        Console.WriteLine(startPoint);
        //textWriter.Flush();
        //textWriter.Close();
    }
}
