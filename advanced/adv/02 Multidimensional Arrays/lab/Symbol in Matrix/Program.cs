using System;
using System.Linq;

namespace Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int cube = int.Parse(Console.ReadLine());
            char[,] mArr = new char[cube, cube];



            for (int i = 0; i < cube; i++)
            {
                string temp = Console.ReadLine();
             
                for (int j = 0; j < cube; j++)
                {
                    mArr[i, j] = temp[j];

                }
            }

            char find = Console.ReadLine()[0];

            for (int i = 0; i < cube; i++)
            {

                for (int j = 0; j < cube; j++)
                {
                    if (find==mArr[i,j])
                    {
                        Console.WriteLine($"({i}, {j})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{find} does not occur in the matrix");
        }
    }
}
