using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] read = Console.ReadLine()
                  .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var stack = new Stack<string>(read.Reverse());

            int result = int.Parse(stack.Pop());
            while (stack.Count != 0)
            {
                switch (stack.Pop())
                {
                    case "-": result -= int.Parse(stack.Pop()); break;
                    case "+": result += int.Parse(stack.Pop()); break;
                }

            }
            Console.WriteLine(result);
        }
    }
}
