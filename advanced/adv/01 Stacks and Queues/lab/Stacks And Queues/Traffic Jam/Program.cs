using System;
using System.Collections.Generic;

namespace Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var qeu = new Queue<string>();
            string read = Console.ReadLine();
            int passedCars = 0;
            while (!read.Equals("end"))
            {

                if (read.Equals("green")){
                    for (int i = 0; i < count; i++)
                    {
                        if (qeu.Count == 0)
                        {
                            break;
                        }
                     Console.WriteLine($"{qeu.Dequeue()} passed!");
                        passedCars++;
                    }
                }
                else
                {
                    qeu.Enqueue(read);
                }
                read = Console.ReadLine();
            }

            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}
