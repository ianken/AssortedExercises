using System;
using System.Collections.Generic;

namespace Stacks2_Undo
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> undoStack = new Stack<string>();
            string buffer = String.Empty;
            var numCommands = Convert.ToInt32(Console.ReadLine());
            var cmdCounter = 0;

            while (cmdCounter < numCommands)
            {
                var cmd = Console.ReadLine().Split(' ');
                var operation = Convert.ToInt32(cmd[0]);
                var data = cmd.Length == 2 ? cmd[1] : null;

                switch (operation)
                {
                    //append string to buffer
                    //Push state to stack beforehand
                    case 1:
                        undoStack.Push(buffer);
                        buffer = buffer + data;
                        break;
                    //Delete the last "data" chacaters from the string
                    //Push state to stack before hand
                    case 2:
                        undoStack.Push(buffer);
                        var trimCount = Convert.ToInt32(data);
                        buffer = buffer.Substring(0,buffer.Length - trimCount);
                        break;
                    //Print the character at index "data"
                    case 3:
                        var printIndex = Convert.ToInt32(data);
                        Console.WriteLine(buffer[printIndex]);
                        break;
                    //Undo the last operation (pop state from stack;
                    case 4:
                        buffer = undoStack.Pop();
                        break;
                }

                cmdCounter++;
            }


        }
    }
}
