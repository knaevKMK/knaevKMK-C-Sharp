using System;
using System.Linq;

namespace Square_With_Maximum_Sum
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
                int[] temp = Console.ReadLine().Split(", ")
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < sizes[1]; j++)
                {
                    mArr[i, j] = temp[j];
                   
                }
            }

            int[] result = new int[3];
            result[0] = int.MinValue;

            for (int i = 0; i < sizes[0] - 1; i++)
            {
                for (int j = 0; j < sizes[1] - 1; j++)
                {

                    int currentSum = mArr[i, j] + mArr[i + 1, j]
                        + mArr[i, j + 1] + mArr[i + 1, j + 1];
                    if (result[0] < currentSum)
                    {
                       result[1] = i;
                        result[2] = j;
                        result[0] = currentSum;
                    }
                }
            }

                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine($"{mArr[result[1]+i,result[2]]} {mArr[result[1] + i, result[2]+1 ]}");
                }
                Console.WriteLine(result[0]);
            }
            
    }
}
