using System;
using System.Collections.Generic;
using System.Linq;

namespace Set_and_Dictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] read = Console.ReadLine().Split(" ");
                

            var result = new Dictionary<string, int>();


            foreach (string item in read)
            {
                if (result.ContainsKey(item)) {
                    result[item]++;  
                }else { 
                    result[item] = 1;
                } 
            }

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
