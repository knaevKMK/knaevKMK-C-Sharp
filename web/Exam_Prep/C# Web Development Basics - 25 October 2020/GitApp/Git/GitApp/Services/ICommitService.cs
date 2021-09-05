using GitApp.Repositories;
using GitApp.Views.Commit.Dto;
using System.Collections.Generic;

namespace GitApp.Services
{
    public interface ICommitService
    {

        ICollection<CommitListOutDto> GetAll();

       CommitCreateDto Add(CommitCreateDto commitDto);
        CommitCreateDto Delete(int id);
    }
}