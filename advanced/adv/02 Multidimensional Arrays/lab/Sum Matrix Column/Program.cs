using System;
using System.Linq;

namespace Sum_Matrix_Column
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(", ")
                .Select(int.Parse)
                .ToArray();

            int[,] mArr = new int[sizes[0], sizes[1]];



            for (int i = 0; i < sizes[0]; i++)
            {
                int[] temp = Console.ReadLine().Split(" ")
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < sizes[1]; j++)
                {
                    mArr[i, j] = temp[j];

                }
            }

            for (int i = 0; i < sizes[1]; i++)
            {
            int sum = 0;
                for (int j = 0; j < sizes[0]; j++)
                {
                    sum += mArr[j, i];
                }
                Console.WriteLine(sum);
            }
        }
    }
}
