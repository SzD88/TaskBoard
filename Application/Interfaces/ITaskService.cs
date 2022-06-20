using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDto>> GetAll();
        Task<TaskDto> Create(CreateTaskDto project);
        Task Edit(TaskDto project);
        Task Delete(Guid id);
        Task MarkAsCompleted(bool completed);
    }
}
