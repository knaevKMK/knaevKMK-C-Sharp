using System;
using System.Collections.Generic;
using System.Linq;

namespace Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string read = Console.ReadLine();
              

           

            var stack = new Stack<int>();
            for (int i = 0; i < read.Length; i++)
            {
                if (read[i].Equals('(')){
                     //Console.WriteLine(i);
                    stack.Push(i);
                }else if (read[i].Equals(')')){
                 
                            int lastBracket = stack.Pop();
                    //Console.WriteLine(lastBracket);
                            for (int z = lastBracket; z <= i; z++)
                            {
                                Console.Write(read[z]);
                            }
                    Console.WriteLine();
                }
                             }
        }
    }
}
