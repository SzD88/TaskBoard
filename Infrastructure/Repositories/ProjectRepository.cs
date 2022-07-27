using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ProjectManagerContext _context;
        public ProjectRepository(ProjectManagerContext context)
        {
            _context = context;
        }

        public async Task<Project> CreateAsync(Project entity)
        {
            entity.Completed = false;
            entity.Created = DateTime.Now;
            entity.LastModified = DateTime.Now;
            await _context.Projects.AddAsync(entity); 
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(object projectToDelete)
        {
            _context.Remove(projectToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> GetByIDAsync(object id)
        {
            var guid = (Guid)id;
            var toReturn = await _context.Projects.FirstOrDefaultAsync(x => x.Id == guid);
            if (toReturn == null) throw new Exception("Not found sd");
            return toReturn;
        }

        public async Task UpdateAsync(Project entityToUpdate)
        {
            _context.Projects.Update(entityToUpdate);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<SubTask>> CreateListOfMainTasks(Guid parentId)
        {
            var list = await _context.SubTasks
                  .Where(x => x.LevelAboveId == parentId)
                  .ToListAsync();
                  
            return list;
        }

        //public async Task DeleteAllProjects()
        //{
        //    foreach (var id in _context.Projects.Select(e => e.Id))
        //    {
        //        var entity = new Project { Id = id };
        //        _context.Projects.Attach(entity);
        //        _context.Projects.Remove(entity);
        //    }
        //  await  _context.SaveChangesAsync();
        //}
    }
}
