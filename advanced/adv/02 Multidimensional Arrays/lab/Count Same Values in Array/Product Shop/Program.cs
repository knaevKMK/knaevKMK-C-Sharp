using System;
using System.Collections.Generic;
using System.Linq;

namespace Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {

            var shops = new Dictionary<string, Dictionary<string, double>>();

            string read = Console.ReadLine();

            while (!read.ToLower().Equals("revision"))
            {
                string[] token = read.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                if (!shops.ContainsKey(token[0]))
                {
                    shops[token[0]] = new Dictionary<string, double>();
                }

                shops[token[0]][token[1]] = double.Parse(token[2]);
                read = Console.ReadLine();
            }

            string[] result = shops
                .OrderBy(shop=>shop.Key)
                .Select(shop => $"{shop.Key}->\n" +
                $"{string.Join(Environment.NewLine, shop.Value.Select(product => $"Product: {product.Key}, Price: {product.Value}"))}")
                .ToArray();
            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
