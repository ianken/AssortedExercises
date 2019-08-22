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

    static string isBalanced(string s)
    {
        var charStack = new Stack<char>();
        var input = s.ToCharArray();
        var leftChars = "[{(";
        foreach (char c in input)
        {
            if (leftChars.Contains(c))
                charStack.Push(c);
            else
            {
                switch (c)
                {
                    case '}':
                        if (charStack.Count == 0 || charStack.Peek() != '{')
                            return ("NO");
                        else
                            charStack.Pop();
                        break;
                    case ']':
                        if (charStack.Count == 0 || charStack.Peek() != '[')
                            return ("NO");
                        else
                            charStack.Pop();
                        break;
                    case ')':
                        if (charStack.Count == 0 || charStack.Peek() != '(')
                            return ("NO");
                        else
                            charStack.Pop();
                        break;
                }
            }

        }
        
        return charStack.Count != 0 ? "NO" : "YES";
    }

    static void Main(string[] args)
    {
        string result = isBalanced("{[][()]}");
    }
}
