using System;
using System.Collections.Generic;
using System.Linq;

namespace Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                  .Split(" ")
                  .Select(int.Parse)
                  .ToArray();
            var que = new Queue<int>();
            foreach (var num in nums)
            {
                if (num % 2 == 0)
                {
                    que.Enqueue(num);
                }
            }

            Console.WriteLine(String.Join(", ", que.ToArray()));
        }
    }
}
