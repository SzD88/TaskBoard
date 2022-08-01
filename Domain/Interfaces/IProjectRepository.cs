using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
          Task<IEnumerable<SubTask>> CreateListOfMainTasks(Guid parentId);
        //Task DeleteAllProjects( );
        Task CreateExampleProjectsAsync();
    }
}
