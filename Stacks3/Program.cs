using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks3
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> enqueStack = new Stack<int>();
            Stack<int> deqeueStack = new Stack<int>();

            string buffer = String.Empty;
            var numCommands = Convert.ToInt32(Console.ReadLine());
            var cmdCounter = 0;

            while (cmdCounter < numCommands)
            {
                var cmd = Console.ReadLine().Split(' ');
                var operation = Convert.ToInt32(cmd[0]);
                int data = 0;
                if(cmd.Length == 2)
                    data = Convert.ToInt32(cmd[1]);
       
                switch (operation)
                {
                    //Enqueue item
                    case 1:
                        enqueStack.Push(data);
                        break;
                    //Dequeue item
                    case 2:
                       if(deqeueStack.Count == 0)
                        {
                            while(enqueStack.Count !=0)
                                deqeueStack.Push(enqueStack.Pop());
                        }
                        deqeueStack.Pop();
                        break;
                    //Print Element at front of queue
                    case 3:
                        if(deqeueStack.Count == 0)
                        {
                            while(enqueStack.Count !=0)
                                deqeueStack.Push(enqueStack.Pop());
                        }
                        Console.WriteLine(deqeueStack.Peek());
                        break;
                   
                }

                cmdCounter++;
            }
        }
    }
}
