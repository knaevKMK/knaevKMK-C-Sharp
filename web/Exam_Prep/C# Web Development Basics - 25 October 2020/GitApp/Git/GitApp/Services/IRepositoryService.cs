using GitApp.Models;
using GitApp.Repositories;
using GitApp.Views.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitApp.Services
{
    public interface IRepositoryService
    {

        ICollection<RepositoryListOutDto> GetAll();

        RepositoryCreateDto Add(RepositoryCreateDto repositoryDto);
        Repository GetByName(string name);
    }
}
