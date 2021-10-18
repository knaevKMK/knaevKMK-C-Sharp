using System;
using System.Collections.Generic;

namespace DemoAppConsole
{
    
    class Program
    {
        static void Main(string[] args)
        {
            int i = 3;
            int j = 2;
            func1(ref i);
            func2(out j);
            Console.WriteLine(i + " " + j);

        }
        static void func1(ref int num)
        {
            num = num + num;
        }
        static void func2(out int num)
        {
            num = num * num;
        }
    }

}
