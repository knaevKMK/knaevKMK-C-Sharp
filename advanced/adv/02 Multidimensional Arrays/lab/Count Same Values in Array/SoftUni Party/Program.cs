using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            var reservation = new HashSet<String>();

            string read = Console.ReadLine();
            while (!read.ToLower().Equals("party"))
            {
                reservation.Add(read);
                read = Console.ReadLine();
            }

            while (!read.ToLower().Equals("end"))
            {
                reservation.Remove(read);
                read = Console.ReadLine();
            }
            string result = $"{reservation.Count}\n";
            if (reservation.Where(gues => char.IsDigit(gues[0])).Count() > 0)
            {
                result += $"{string.Join(Environment.NewLine, reservation.Where(gues => char.IsDigit(gues[0]))).TrimEnd()}\n";
            }

            if (reservation.Where(gues => !char.IsDigit(gues[0])).Count() > 0)
            {
            result+= $"{string.Join(Environment.NewLine, reservation.Where(gues => !char.IsDigit(gues[0])))}";
            }
            Console.WriteLine(result);
                  }
    }
}
