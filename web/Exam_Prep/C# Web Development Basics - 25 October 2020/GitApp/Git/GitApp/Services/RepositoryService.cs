using GitApp.Models;
using GitApp.Repositories;
using GitApp.Views.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitApp.Services
{
    public class RepositoryService : IRepositoryService
    {
        private readonly RepositoryRepository repositoryRepository;

        public RepositoryService(RepositoryRepository repository)
        {
            this.repositoryRepository = repository;
        }

        public RepositoryCreateDto Add(RepositoryCreateDto repositoryDto)
        {
            Repository repository = new Repository()
            {
                Name = repositoryDto.Name,
                CreateOn = DateTime.Now,
                IsPublc= repositoryDto.Type.Equals("Publc")
            };

            // TODo may valdate for Repo with same name and Date
            repositoryRepository.Add(repository);

            return repositoryDto;

        }

        public ICollection<RepositoryListOutDto> GetAll()
        {
            return repositoryRepository.All()
                 .Select(r => new RepositoryListOutDto() {
                     Name = r.Name,
                     Owner = r.Owner.Username,
                     CreateOn = r.CreateOn,
                     CommitCount = r.Commits.Count()
                 })
                 .ToList();
        }

        public Repository GetByName(string name)
        {
            return repositoryRepository.GetByName(name);
        }
    }
}
