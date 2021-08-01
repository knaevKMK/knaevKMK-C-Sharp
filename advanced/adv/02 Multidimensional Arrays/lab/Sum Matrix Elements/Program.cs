using System;
using System.Linq;

namespace Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(", ")
                .Select(int.Parse)
                .ToArray();

            int[,] mArr = new int[sizes[0], sizes[1]];



            int sum = 0;
            for (int i = 0; i < sizes[0]; i++)
            {
                int[] temp = Console.ReadLine().Split(", ")
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < sizes[1]; j++)
                {
                    mArr[i, j] = temp[j];
                    sum += temp[j];
                }
            }

            Console.WriteLine($"{sizes[0]}\n{sizes[1]}\n{sum}");
          


        }
    }
}
