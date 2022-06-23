using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDto>> GetAllNotes();
        Task<ProjectDto> AddProject(CreateSubTaskDto project);
        Task EditProject(ProjectDto project);
        Task Delete(Guid id);
        Task MarkAsCompleted(bool completed);
    }
}
