using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.interfaces
{
    public interface IProductService
    {
        void Add(Product product);
        string LoadFromJson(string filePath);
    }
}
