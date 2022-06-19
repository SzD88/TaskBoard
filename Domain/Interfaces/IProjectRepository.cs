using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllNotes();
        Task<Project> AddProject(Project project);
        Task EditProject(Project project);
        Task Delete(Guid id);
        Task MarkAsCompleted(bool completed);
    }
}
