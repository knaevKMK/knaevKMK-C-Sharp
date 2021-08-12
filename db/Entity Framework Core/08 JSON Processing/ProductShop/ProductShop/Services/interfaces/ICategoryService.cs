using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.interfaces
{
    public interface ICategoryService
    {

        void Add(Category category);

        string LoadFromJson(string filePath);
    }
}
