using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{
    static void Main(String[] args)
    {
        uint n = 5;

        uint[] v = { 6, 9, 3, 5, 2, };

        Stack<uint> s = new Stack<uint>();

        long max = 0;

        for (int i = 0; i < n; i++)
        {
            while (s.Any())
            {
                uint c = s.Peek() ^ v[i];

                if (c >= max)
                {
                    max = c;
                }

                if (v[i] < s.Peek())
                {
                    Console.WriteLine($"The next smaller value after {s.Peek()} is {v[i]}");
                    s.Pop();
                }
                else
                {
                    break;
                }
            }

            s.Push(v[i]);
        }

        Console.WriteLine(max);
    }
}
