using System;
using System.Collections.Generic;
using System.Linq;

namespace Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            var continents = new Dictionary<string, Dictionary<string, List<string>>>();
            for (int i = 0; i < count; i++)
            {
                string[] read = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (!continents.ContainsKey(read[0]))
                {
                    continents[read[0]] = new Dictionary<string, List<string>>();
                }

                if (!continents[read[0]].ContainsKey(read[1]))
                {
                    continents[read[0]][read[1]] = new List<string>();
                }

                continents[read[0]][read[1]].Add(read[2]);
            }

            foreach (var continent in continents)
            {
                Console.WriteLine($"{continent.Key}:\n" +
                    $"{string.Join(Environment.NewLine, continent.Value.Select(country=>$" {country.Key} -> {string.Join(", ", country.Value)}"))}");
            }
        }
     }
}
