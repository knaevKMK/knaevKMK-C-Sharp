using efIntroDemo01.Models;
using System;
using System.Linq;

namespace efIntroDemo01
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new SoftUniContext();
            
            string input = ioReLoad();

            while (!input.ToLower().Equals("end"))
            {
                string result ;
                switch (input)
                {
                    case "1": result = getEmployeesFullInformation(dbContext); break;
                    case "2": result = GetEmployeesWithSalaryOver50000(dbContext); break;
                    case "3": result = GetEmployeesFromResearchAndDevelopment(dbContext); break;
                    case "4": result = AddNewAddressToEmployee(dbContext); break;
                    case "5": result =GetEmployeesWithProjects(dbContext); break;
                    case "6": result = AddressesByTown(dbContext); break;
                    default:
                        result = "Bad input";
                        break;
                }

           Console.WriteLine (result);
                input = ioReLoad();
            }
         
          

        }

        private static string AddressesByTown(SoftUniContext dbContext)
        {
            using (var context = new SoftUniContext())
            {
                return string.Join( Environment.NewLine,
                   context.Addresses
                  .OrderByDescending(a => a.Employees.Count())
                  .ThenBy(a=>a.Town.Name)
                  .ThenBy(a=>a.AddressText)
                   .Take(10)
                   .Select(a=>string.Format("{0}, {1} - {2} employees", a.AddressText,a.Town.Name, a.Employees.Count))
                    );

            }
        }

        private static string GetEmployeesWithProjects(SoftUniContext dbContext)
        {
            using (var context = new SoftUniContext()) {
                return  string.Join(Environment.NewLine, context.Employees
                 .Where(e=>e.EmployeesProjects.Any(p=>p.ProjectId!=null))
                    .Take(10)
                    .Select(e=>string.Format("{0} {1} - Manager: {2} {3}{4}"
                    ,e.FirstName
                    ,e.LastName
                    ,e.Manager.FirstName
                    ,e.Manager.LastName
                    ,string.Join("",e.EmployeesProjects.Select(ep=>String.Format("\n--{0} - {1} -{2}"
                        , ep.Project.Name
                        , ep.Project.StartDate
                        , ep.Project.EndDate.ToString() ?? "not finished")))
                    )));
            }
        }

        private static string AddNewAddressToEmployee(SoftUniContext dbContext)
        {
            using (var context = new SoftUniContext())
            {
                var address = new Address();
                address.AddressText = "Vitoska 15";
                address.TownId = 4;

                var employee = dbContext.Employees
                    .FirstOrDefault(e => e.LastName == "Nakov");
                employee.Address = address;
                dbContext.Employees.Update(employee);
                dbContext.SaveChanges();


                return string.Join(Environment.NewLine, dbContext.Employees
                    .OrderByDescending(e=>e.AddressId)
                    .Take(10)
                    .Select(e=>$"{e.Address.AddressText}"));
            }        }

        private static string ioReLoad()
        {
            Console.WriteLine("===================================\n" +
                 "ex_1: Employee Full Information\n" +
                 "ex_2: Employees With Salary Over 50 000\n" +
                 "ex_3: Employees From Department _name\n" +
                 "ex_4: Add New Address To Employee\n" +
                 "ex_5: Employees with Projects\n" +
                 "ex-6: Addresses By Town\n"+
                 "====================================\n" +
                 "Please, enter ex Number: ");

            return Console.ReadLine();
        }

        private static string GetEmployeesFromResearchAndDevelopment(SoftUniContext dbContext) {
            
            using (var context = new SoftUniContext())
            {
            return String.Join(Environment.NewLine,
                 dbContext.Employees
                   .Where(e => e.Department.Name == "Research and Development")
                   .OrderBy(e => e.Salary)
                   .ThenByDescending(e => e.LastName)
                   .Select(employee => $"{employee.FirstName} {employee.LastName} from {employee.Department.Name} - ${employee.Salary:F2}"
                   ));
                 }
        }

        private static string GetEmployeesWithSalaryOver50000(SoftUniContext dbContext)
        {
            using (var context = new SoftUniContext())
            {
                return string.Join(Environment.NewLine,
                dbContext.Employees
                .Where(employee => employee.Salary > 50000)
                .OrderBy(employee => employee.FirstName)
                .Select(employee => $"{employee.FirstName} - {employee.Salary:F2}")
                );
            }
        }

        private static string getEmployeesFullInformation(SoftUniContext dbContext)
        {
            using (var context = new SoftUniContext())
            {
                return string.Join(Environment.NewLine, dbContext.Employees
                     .Select(employee =>
                     $"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}"));

            }
        }

       
    }
}
