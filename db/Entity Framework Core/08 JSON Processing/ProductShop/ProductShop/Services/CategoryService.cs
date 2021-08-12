using AutoMapper;
using Data;
using Models;
using Models.DtoImport;
using Services.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService : ICategoryService
    {

        private static IMapper Mapper = new MapperConfiguration(c => {
            c.CreateMap<CategoryImportDto, Category>();
        }).CreateMapper();
        private static ApplicationDbContext db = new ApplicationDbContext();
        public void Add(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public string LoadFromJson(string filePath)
        {
            if (db.Categories.Count<Category>() != 0)
            {
                return "Category DB is not Empty";
            }
            var report = new List<string>();
           

            IEnumerable<CategoryImportDto> categoriesDto = JsonSerializer.Deserialize<IEnumerable<CategoryImportDto>>(File.ReadAllText(filePath));
            foreach (var categoryDto in categoriesDto)
            {
                try { 
                Category category = Mapper.Map<Category>(categoryDto);
                    if (category==null)
                    {
                        throw new Exception();
                    }
                    this.Add(category);
                    report.Add("Success add Category - " + category.Name);
                }catch(Exception e){
                    report.Add("Invalid Category");
                }
            }

            Console.WriteLine();
            return string.Join(Environment.NewLine, report);
        }
    }
}
