using System;
using System.Linq;

namespace Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int cube = int.Parse(Console.ReadLine());
            int[,] mArr = new int[cube, cube];



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


            string [] read = Console.ReadLine().Split(" ");
            while (!read[0].ToLower().Equals("end")){

                int r = int.Parse(read[1]);
                int c = int.Parse(read[2]);
                if (r>=0 && c>=0 && r<cube && c<cube)
                {
                switch (read[0].ToLower())
                {
                                    case "add":mArr[r, c] = mArr[r, c] + int.Parse(read[3]); break;
                                    case "subtract": mArr[r, c] = mArr[r, c] - int.Parse(read[3]); break;
                    default:
                        break;
                }
                    read = Console.ReadLine().Split(" ");
                    continue;
                }
                    Console.WriteLine("Invalid coordinates");
                read = Console.ReadLine().Split(" ");
            }

            for (int i = 0; i < cube; i++)
            {
                for (int j = 0; j < cube; j++)
                {
                    Console.Write(mArr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
