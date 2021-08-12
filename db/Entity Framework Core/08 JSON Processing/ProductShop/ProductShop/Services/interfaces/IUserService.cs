using Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.interfaces
{
    public interface IUserService
    {
        string ImportFromFile(string filePath);
        void Add(User    user);
       User FindUserById(int id);
    }
}
