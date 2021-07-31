using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(" " , StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var stack = new Stack<int>(nums);
           
            string [] read = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (!read[0].ToLower().Equals("end"))
            {
                switch (read[0].ToLower())
                {
                    case "add":
                        for (int i = 1; i < read.Length; i++)
                        {
                            stack.Push(int.Parse(read[i]));
                        }
                        break;
                    case "remove":
                        int count = int.Parse(read[1]);
                        for (int i = 0; i < count; i++)
                        {
                            if (stack.Count == 0)
                            {
                                break;
                            }
                            stack.Pop();
                        }
                        break;
                 
                }
                read = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            int sum = 0;
           
            while (stack.Count >0)
            {
                sum += stack.Pop();
            }
            Console.WriteLine("Sum: " + sum);
        }
    }
}
