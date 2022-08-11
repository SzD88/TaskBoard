﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<IEnumerable<Project>> GetAllSortedAsync(string sortField, bool ascending); 
        Task<IEnumerable<SubTask>> CreateListOfMainTasks(Guid parentId);
        Task CreateExampleProjectsAsync();
    }
}
