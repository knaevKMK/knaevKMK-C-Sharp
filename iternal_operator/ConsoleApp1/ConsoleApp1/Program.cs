namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            // object[] args
            Result<List<string>> _result =
                new object[] {true, new List<string> { "1", "2", "3" },"Data retrieved",new List<ErrorEnum> ()};
            Console.WriteLine("Array Args:\n\t" + _result.ToString() + "\n");

            //  TEntityViewModel->data
            Result<List<string>> result = new List<string> { "1", "2", "3" };
            Console.WriteLine("Return Data:\n\t" + result.ToString() + "\n");

            // succeded->bool 
            Result<object> result1 = true;
            Console.WriteLine("Sucessed->bool:\n\t" + result1.ToString() + "\n");

            //Error->List<EnumError>
            Result<object> result2 = new List<ErrorEnum> { ErrorEnum.UNSuccededAdd, ErrorEnum.UNSuccededSave }; ;
            Console.WriteLine("Error->List<EnumError>: \n\t" + result2.ToString() + "\n");

            //Message->string
            Result<object> result3 = "error msg";
            Console.WriteLine("Message->string: \n\t" + result3.ToString() + "\n");
        }
    }




}
