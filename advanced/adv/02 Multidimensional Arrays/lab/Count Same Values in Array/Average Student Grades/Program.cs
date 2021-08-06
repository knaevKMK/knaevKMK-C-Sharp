using System;
using System.Collections.Generic;
using System.Linq;

namespace Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            var result = new Dictionary<string, List<double>>();
            for (int i = 0; i < rows; i++)
            {
                string[] token = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (!result.ContainsKey(token[0]))
                {
                    result[token[0]] = new List<double>();
                }
                    result[token[0]].Add(double.Parse(token[1]));
            }

            foreach (var item in result)
            {
                Console.WriteLine(
                    $"{item.Key} -> {string.Join(" ", item.Value.Select(g=>$"{g:f2}").ToArray())} (avg: {item.Value.Average():0.00})"
                    );
            }
        }
    }
}
