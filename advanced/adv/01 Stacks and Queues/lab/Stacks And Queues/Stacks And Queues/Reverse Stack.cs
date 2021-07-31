using System;
using System.Collections.Generic;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            string read = Console.ReadLine();
            var stack = new Stack<char>();
            foreach (var ch in read)
            {
                stack.Push(ch);
            }
            while (stack.Count > 0) {
                Console.Write(stack.Pop());
            }
        }
    }
}
