using GitApp.Models;
using GitApp.Repositories;
using GitApp.Views.Commit.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitApp.Services
{
    public class CommitServce : ICommitService
    {

        private readonly CommitRepository commitRepository;
        private readonly IRepositoryService repositoryService;
        private readonly IUserService userService;

        public CommitServce(CommitRepository commitRepository, IUserService userService, IRepositoryService repositoryService)
        {
            this.commitRepository = commitRepository;
            this.userService = userService;
            this.repositoryService = repositoryService;
        }

        public CommitCreateDto Add(CommitCreateDto commitDto)
        {
            Commit commit = new Commit() {
                Description = commitDto.Description,
                CreateOn = DateTime.Now,
                Repository = repositoryService.GetByName(commitDto.Name)
  //           ,   Creator = userService.GetCurrentUser()
            };

            Commit commit1 = commitRepository.Add(commit);
            return commitDto;
        }

        public CommitCreateDto Delete(int id)
        {
            Models.Commit commit = commitRepository.Delete(id);
            return new CommitCreateDto() { Description= commit.Description, Id=commit.Id, Name= commit.Repository.Name};
        }

        public ICollection<CommitListOutDto> GetAll()
        {
            return commitRepository.All()
                //ToDo get user session
         //       .Where(c=>c.Creator.Id== ???)
                .Select(c=> new CommitListOutDto() { 
                Description= c.Description,
                Id=c.Id,
                CreateOn = c.CreateOn,
                Repository= c.Repository.Name,
                })
                .ToList();
        }

      
    }
}
