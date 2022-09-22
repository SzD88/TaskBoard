using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Infrastructure.ExtensionMethods;
using Domain.ValueObjects;

namespace Infrastructure.Repositories
{
    internal class ProjectRepository : IProjectRepository
    {
        private readonly ProjectManagerContext _context;
        public ProjectRepository(ProjectManagerContext context)
        {
            _context = context;
        }
        public async Task<Project> CreateAsync(Project entity)
        { 
            await _context.Projects.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteAsync(Guid idToDelete)
        { 
            var projectToDelete = await GetByIDAsync(idToDelete);
            _context.Remove(projectToDelete); 
            await _context.SaveChangesAsync();
        }
        public async Task<IReadOnlyList<Project>> GetAllAsync()
        {
            return await _context.Projects.ToListAsync();
        }
        public async Task<IReadOnlyList<Project>> GetAllSortedAsync(string sortField, bool ascending)
        {
            return await _context.Projects
                .OrderByPropertyName(sortField, ascending)
                .ToListAsync();
        }

        public async Task<Project> GetByIDAsync(Guid id)
        {
            var guid =  (Id)id;
            var toReturn = await _context.Projects.FirstOrDefaultAsync(x => x.Id == guid);
            return toReturn;
        } 
        public async Task UpdateAsync(Project entityToUpdate)
        {
            entityToUpdate.LastModified = DateTime.Now;
            _context.Projects.Update(entityToUpdate);
            await _context.SaveChangesAsync();
        }
        //public async Task<IReadOnlyList<SubTask>> CreateListOfMainTasks(Guid parentId)
        //{
        //    var list = await _context.SubTasks
        //          .Where(x => x.GetLevelAboveId() == parentId)
        //          .ToListAsync();

        //    return list;
        //} 
    }
}

