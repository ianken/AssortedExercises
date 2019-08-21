using System;
using System.Collections.Generic;


public class Node {
    public int val;
    public int max;

    public Node(int val, int max)
    {
        this.val = val;
        this.max = max;
    }
}

/*
 * Input format:
 * First command: number of commands to follow
 * Command list:
 * 1 - push item onto stack, example:
 * 1 23 -> this will push 23 onto the stack
 * 2 -> this will pop the stack
 * 3 -> print the largest value currently stored on the stack.
 * EXAMPLE INPUUT:
 * 4        -> there are four commands following
 * 1 23     -> push "23" into the stack
 * 2        -> POP
 * 1 16     ->Push "16"
 * 3        ->Print the larges value currently on stack : 16
 * OUTPUT:
 * 16
 */
 
class Solution
{
    static void Main(String[] args)
    {
        /*Read input from STDIN. Print output to STDOUT. */
        Stack<Node> values = new Stack<Node>();

        var intputCount = Convert.ToInt32(Console.ReadLine());
        var index = 0;
        int maxVal = 0;

        while (index < intputCount)
        {
            var input = Console.ReadLine();
            index++;

            if (input.Split().Length == 2)
            {
                var val = Convert.ToInt32(input.Split()[1]);

                if (values.Count == 0)
                {
                    maxVal = val;
                }
                else
                {
                    maxVal = val > maxVal ? val : maxVal;
                }

                values.Push(new Node(val,maxVal));

            }
            else if (input == "2")
            {
                values.Pop();
                if (values.Count == 0)
                {
                    maxVal = 0;
                }
                else
                {
                    maxVal = values.Peek().max;
                }
               
            }
            else if (input == "3")
            {
                Console.WriteLine(maxVal);
            }
        }
    }
}
