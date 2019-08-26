using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks3
{
    class Program
    {

        //This is an implmentation of the "waiter" problem from hackerrank.
        //It is easily one of the most poorly stated puzzle questions I've encountered on the site. 

        static int[] waiter(int[] number, int q)
        {

            Stack<int>[] aStacks = new Stack<int>[q+1];
            Stack<int>[] bStacks = new Stack<int>[q+1];
                      
            //allocate stacks
            for (int index = 0; index <= q; index++)
            {
                aStacks[index] = new Stack<int>();
                bStacks[index] = new Stack<int>();
            }
            
            //Populate intial stack
            foreach (int i in number)
            {
                aStacks[0].Push(i);
            }

            for (int index = 1; index <= q; index++)
            {
                var stack = aStacks[index - 1];

                while (stack.Count != 0)
                {
                    var plateValue = stack.Pop();

                    //Sorting values divisuble by prime numbers 
                    //into set of stacks based on the interation.
                    //Output stacks start at "1"
               
                    if (plateValue % GetPrime(index) == 0)
                    {
                        bStacks[index].Push(plateValue);
                    }
                    else
                    {
                        aStacks[index].Push(plateValue);
                    }
                }
            }

            var output = new List<int>();

            //Dump bStacks 
            foreach (Stack<int> s in bStacks)
            {
                while (s.Count != 0)
                {
                    output.Add(s.Pop());
                }
            }

            //Dump aStacks 
            foreach (Stack<int> s in aStacks)
            {
                while (s.Count != 0)
                {
                    output.Add(s.Pop());
                }
            }

            return output.ToArray();
        }

        static void Main(string[] args)
        {

            int[] data = {3,3,4,4,9};

            var result = waiter(data, 2);

        }

        //Slow and dirty. Could use lookup table...
        public static int GetPrime(int n)
        {
            List<int> primes = new List<int>();
            primes.Add(2);
            int nextPrime = 3;
            while (primes.Count < n)
            {
                int sqrt = (int)Math.Sqrt(nextPrime);
                bool isPrime = true;
                for (int i = 0; primes[i] <= sqrt; i++)
                {
                    if (nextPrime % primes[i] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primes.Add(nextPrime);
                }
                nextPrime += 2;
            }
            return primes.Last();
        }
    }
}
