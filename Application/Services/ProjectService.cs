using Application.Dto;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProjectService : IProjectService
    {
        public async Task<ProjectDto> AddProject(CreateSubTaskDto project)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task EditProject(ProjectDto project)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProjectDto>> GetAllNotes()
        {
            throw new NotImplementedException();
        }

        public async Task MarkAsCompleted(bool completed)
        {
            throw new NotImplementedException();
        }
    }
}
