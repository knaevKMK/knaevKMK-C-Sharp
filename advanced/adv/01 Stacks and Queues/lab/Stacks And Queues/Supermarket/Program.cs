using System;
using System.Collections.Generic;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            var que = new Queue<string>();
            string input = Console.ReadLine();

            while (!input.ToLower().Equals("end"))
            {
                if (input.Equals("Paid"))
                {
                    Console.WriteLine(String.Join(Environment.NewLine, que.ToArray()));
                    que.Clear();
                }
                else
                {
                que.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{que.Count} people remaining.");
        }
    }
}
