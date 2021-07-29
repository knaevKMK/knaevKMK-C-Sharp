using System;
using System.Globalization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //======================================================
            //ex_13

            var startDate = DateTime.ParseExact(Console.ReadLine(),
                "d.M.yyyy", CultureInfo.InvariantCulture);
            var endtDate = DateTime.ParseExact(Console.ReadLine(),
              "d.M.yyyy", CultureInfo.InvariantCulture);
            var holidaysCount = 0;
            for (var i = startDate; i <= endtDate;i= i.AddDays(1))
            {
                if (i.DayOfWeek == DayOfWeek.Saturday || i.DayOfWeek == DayOfWeek.Sunday)
                {
                    holidaysCount++;
                }
            }
            Console.WriteLine(holidaysCount);
            //======================================================
            //ex_12
            /*    int num = int.Parse(Console.ReadLine());
                while (num%2!=0 )
                {
                    Console.WriteLine("Please write an even number.");
                    num = int.Parse(Console.ReadLine());
                }
                if (num   < 0)
                {
                    num *= -1;
                }
                Console.WriteLine($"The number is: {num}");*/

            //======================================================
            //ex_11
            /* int num = int.Parse(Console.ReadLine());
             int m = int.Parse(Console.ReadLine());
             if (m > 10)
             {
                 Console.WriteLine($"{num} X {m} = {num * m}");
                 return;
             }

             for (int i = m; i <=10 ; i++)
             {
                 Console.WriteLine($"{num} X {i} = {num * i}");
             }*/

            //======================================================
            //ex_10
            /*  int n = int.Parse(Console.ReadLine());

              for (int i = 1; i <=10; i++)
              {
                  Console.WriteLine($"{n} X {i} = {n*i}");
              }*/

            //======================================================
            //ex_9
            /*  int n = int.Parse(Console.ReadLine());
              int sum = 0;
              int i = 1;
              while(n != 0){

                  if (i % 2 != 0) {
                      Console.WriteLine(i);
                      sum += i;
                      n--;
                  }
                  i++;
              }
              Console.WriteLine($"Sum: {sum}");
  */
            //======================================================
            //ex_8
            /*       for (int i = 3; i <=100; i+=3)
                   {

                           Console.WriteLine(i);
                              }*/

            //======================================================
            //ex_7
            /*  String day = Console.ReadLine().ToLower();
              int age = int.Parse(Console.ReadLine());
              int price = -1;
              switch (day) {
                  case "weekday":
                      if ((0 <= age && age <= 18) || (64 < age && age <= 122))
                      {
                          price = 12;
                      }
                      else if (18 < age && age <= 64)
                      {
                          price = 18;
                      }
                      break;
                  case "weekend": 
                      if ((0 <= age && age <= 18) || (64 < age && age <= 122))
                      {
                          price = 15;
                      }
                      else if (18 < age && age <= 64)
                      {
                          price = 20;
                      } break;
                  case "holiday":
                      if (0 <= age && age <= 18)
                      {
                          price = 5;
                      }
                      else if (18 < age && age <= 64)
                      {
                          price = 12;
                      }
                      else if (64 < age && age <= 122)
                      {
                          price = 10;
                      }
                          break;
              }
              Console.WriteLine(price == -1 ? "Error!" : $"{price}$");
  */
            //======================================================
            //ex_6
            /* switch (Console.ReadLine())
             {
                 case "England":
                 case "USA":
                     Console.WriteLine("English");
                     break;
                 case "Spain":
                 case "Argentina":
                 case "Mexico":
                     Console.WriteLine("Spanish");
                     break;
                 default: Console.WriteLine("unknown"); break;

             }*/
            //======================================================
            //ex_5
            /* string result =null;
             switch (Console.ReadLine())
             {
                 case "1": result = "January"; break;
                 case "2": result = "February"; break;
                 case "3": result = "March"; break;
                 case "4": result = "April"; break;
                 case "5": result = "May"; break;
                 case "6": result = "June"; break;
                 case "7": result = "July"; break;
                 case "8": result = "August"; break;
                 case "9": result = "September"; break;
                 case "10": result = "October"; break;
                 case "11": result = "November"; break;
                 case "12": result = "December"; break;
                 default: result="Error!"; break;
             }

             Console.WriteLine(result);
 */
            //======================================================
            //ex_4
            /*  int hour = int.Parse(Console.ReadLine());
              if (hour < 0 || hour > 23) {
                  return;
              }
              int min = int.Parse(Console.ReadLine());
              if(min<0 || min > 59)
              {
                  return;
              }

              min += 30;
              if (min > 59)
              {
                  min -=60;
                  hour++;
              }
              if (hour > 23)
              {
                  hour -= 24;
              }
              Console.WriteLine("{0}:{1:D2}", hour, min);
  */
            //===============================
            //ex_3
            /*          if (double.Parse(Console.ReadLine()) >= 3.00)
                      {
                          Console.WriteLine("Passed!");
                          return;
                      }
                      Console.WriteLine("Failed!");
          */
            //======================================================
            //ex_2 parse
            /*          if (double.Parse(Console.ReadLine()) >= 3.00)
                      {
                          Console.WriteLine("Passed!");
                      }
          */
            //============================================
            // ex_1
            /*String name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            double grade = double.Parse(Console.ReadLine());

            Console.Write($"Name: {name} , Age: {age}, ");
            Console.WriteLine("Grade: {0:F2}", grade);
*/
        }

    }
}
