using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    // Complete the largestRectangle function below.
    // Given an array of heights. 
    static long largestRectangle(int[] h)
    {

        long maxArea = 0;                        

        for (int i = 0; i < h.Length; i++)
        {
            int rectHeight = h[i];
            var width = 1;

            //Scan forward from current location
            for (int w = i + 1; w < h.Length; w++)
            {
                if (h[w] < h[i])
                    break;                                     

                width++;
            }

            //Scan backward from current location
            for (int w = i - 1; w >= 0; w--)
            {
                if (h[w] < h[i])
                    break;

                width++;
            }

            long area = width * rectHeight;
            maxArea = Math.Max(maxArea,area);
        }

        return maxArea;
    }





    static void Main(string[] args)
    {

        int[] h = { 8979, 4570, 6436, 5083, 7780, 3269, 5400, 7579, 2324, 2116 };

        long result = largestRectangle(h);

        //expect : 26152


    }
}
