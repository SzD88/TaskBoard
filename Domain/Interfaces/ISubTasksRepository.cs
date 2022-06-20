using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISubTasksRepository
    {
        Task<IEnumerable<SubTask>> GetAll();
        Task<SubTask> Create(SubTask project);
        Task Edit(SubTask project);
        Task Delete(Guid id);
        Task MarkAsCompleted(bool completed);
    }
}
