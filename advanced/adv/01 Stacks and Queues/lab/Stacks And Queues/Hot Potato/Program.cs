using System;
using System.Collections;
using System.Collections.Generic;

namespace Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
           var list= new Queue<string> (Console.ReadLine()
                 .Split(" "));
            int step = int.Parse(Console.ReadLine());

            while (list.Count > 1)
            {
                for (int i = 1; i < step; i++)
                {
                String current = list.Dequeue();
                list.Enqueue(current);
                }
            Console.WriteLine("Removed " + list.Dequeue());

            }
                Console.WriteLine("Last is " + list.Peek());
        }

       
    }
}
