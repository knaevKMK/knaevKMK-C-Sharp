using System;
using System.Collections.Generic;

namespace Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {

            var parking = new HashSet<string>();
            string[] token = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            while (!token[0].ToLower().Equals("end"))
            {
                switch (token[0].ToLower())
                {

                    case "in":
                        parking.Add(token[1]);
                        break;
                    case "out":
                        parking.Remove(token[1]);
                        break;
                    default:
                        break;
                }

                token = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }

            if (parking.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
                return;
            }
            Console.WriteLine(string.Join(Environment.NewLine, parking));
      }
   }
}
