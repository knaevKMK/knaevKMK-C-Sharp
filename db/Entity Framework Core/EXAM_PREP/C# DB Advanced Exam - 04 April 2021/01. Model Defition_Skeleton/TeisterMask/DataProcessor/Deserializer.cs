namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static object JsonConert { get; private set; }

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            List<String> result = new List<string>();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProjectDto[]), new XmlRootAttribute("Projects"));

            using StringReader stringReader = new StringReader(xmlString);


            ImportProjectDto[] importProjectDtos = (ImportProjectDto[])xmlSerializer.Deserialize(stringReader);

            foreach (var projectDto in importProjectDtos)
            {

                try
                {
                    if (!IsValid(projectDto))
                    {
                        throw new Exception();
                    }


                    DateTime openDate= GetOpenDate(projectDto.OpenDate, "dd/MM/yyyy");
                    DateTime? dueDate = GetDueDate(projectDto.DueDate, "dd/MM/yyyy");

                   

                    Project project = new Project {
                        Name = projectDto.Name,
                        OpenDate = openDate,
                        DueDate = dueDate
                    };

                    GetTasks(result, project.Tasks, projectDto.Tasks);

                    context.Projects.Add(project);
                    context.SaveChanges();
                    result.Add(String.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
                }
                catch (Exception )
                {
                    result.Add(ErrorMessage);
                }
            }

            return string.Join(Environment.NewLine, result);
        }

        private static DateTime? GetDueDate(string DueDate, string v)
        {
            if (!String.IsNullOrWhiteSpace(DueDate))
            {
                DateTime dueDateDt;
                bool isDueDateValid = DateTime.TryParseExact(DueDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out dueDateDt);

                if (!isDueDateValid)
                {
                    throw new Exception();
                }

               return dueDateDt;
            }
            return null;
        }

        private static DateTime GetOpenDate(string openDate, string v)
        {
            DateTime _openDate;
            if (!DateTime.TryParseExact(openDate, "dd/MM/yyyy",
                  CultureInfo.InvariantCulture, DateTimeStyles.None, out _openDate))
            {
                throw new Exception();
            }

            return _openDate;
        }

        private static void GetTasks(List<string> result, ICollection<Task> tasks, ImportProjectTasksDto[] tasksDto)
        {


            foreach (var taskDto in tasksDto)
            {
                try
                {
                    if (!IsValid(taskDto))
                    {
                        throw new Exception();
                    }

                    DateTime openDate = GetOpenDate(taskDto.OpenDate, "dd/MM/yyyy");
                    DateTime? dueDate = GetDueDate(taskDto.DueDate, "dd/MM/yyyy");


                    Task task = new Task {
                        Name = taskDto.Name,
                        OpenDate =openDate,
                        DueDate =(DateTime) dueDate,
                        ExecutionType = (ExecutionType)taskDto.ExecutionType,
                        LabelType = (LabelType)taskDto.LabelType
                    };

                    tasks.Add(task);
                }
                catch (Exception)
                {

                    continue;
                }
                           }



        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            List<string> result = new List<string>();
            ImportEmployeeDto[] importEmployeeDtos = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);

            foreach (var employeeDto in importEmployeeDtos)
            {

                try
                {
                    if (!IsValid(employeeDto))
                    {
                        throw new Exception();
                    }

                    Employee e = new Employee()
                    {
                        UserName = employeeDto.Username,
                        Email = employeeDto.Email,
                        Phone = employeeDto.Phone
                    };

                    getTasksById(context,result, e.EmployeeTasks, employeeDto.Tasks.Distinct());


                    context.Employees.Add(e);
                    context.SaveChanges();
                    result.Add(String.Format(SuccessfullyImportedEmployee,e.UserName,e.EmployeeTasks.Count));
                }
                catch (Exception)
                {

                    result.Add(ErrorMessage);
                }
            }

            return string.Join(Environment.NewLine, result);
        }

        private static void getTasksById(TeisterMaskContext context, List<string> result, ICollection<EmployeeTasks> employeeTasks, IEnumerable<int> enumerable)
        {
            foreach (var id in enumerable)
            {
                try
                {
                Task _task = context.Tasks.First(t => t.Id == id);
                employeeTasks.Add(new EmployeeTasks() { Task= _task});
                }
                catch (Exception)
                {
                    continue;
                }

                
            }
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}