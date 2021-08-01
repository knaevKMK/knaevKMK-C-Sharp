using System;
using System.Linq;

namespace Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int cube = int.Parse(Console.ReadLine());
            int[,] mArr = new int[cube,cube];



            for (int i = 0; i < cube; i++)
            {
                int[] temp = Console.ReadLine().Split(" ")
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < cube; j++)
                {
                    mArr[i, j] = temp[j];

                }
            }

            int sum = 0;

            for (int i = 0; i < cube; i++)
            {
                sum += mArr[i, i];
            }

            Console.WriteLine(sum);
        }
    }
}
