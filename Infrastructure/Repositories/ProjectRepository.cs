﻿using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Infrastructure.ExtensionMethods;
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
        public async Task<IEnumerable<Project>> GetAllSortedAsync(string sortField, bool ascending)
        {
            return await _context.Projects
                .OrderByPropertyName(sortField, ascending)
                .ToListAsync();
        }

        public async Task<Project> GetByIDAsync(object id)
        {
            var guid = (Guid)id;
            var toReturn = await _context.Projects.FirstOrDefaultAsync(x => x.Id == guid);
            //  if (toReturn == null) throw new Exception("Not found sd");
            return toReturn;
        }

        public async Task UpdateAsync(Project entityToUpdate)
        {
            //var projectToUpdate = await _context.Projects.FirstOrDefaultAsync(x => x.Id == entityToUpdate.Id);
            entityToUpdate.LastModified = DateTime.Now;
          //  entityToUpdate.Created = projectToUpdate.Created;
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
        public async Task CreateExampleProjectsAsync()
        {
            try
            {
                var ifCreated = await GetByIDAsync(new Guid("56950D32-F426-4B5C-96CB-FFA074A8A37B"));
                if (ifCreated == null)
                {
                    var exampleProject = new Project()
                    {
                        ProjectNumber = "133-22",
                        Id = new Guid("56950D32-F426-4B5C-96CB-FFA074A8A37B"),
                        Title = "Example Project Number 1",
                        Description = "Example Description of Project Number 1",
                        Completed = false,
                        Created = DateTime.Now,
                        LastModified = DateTime.Now

                    };
                    var exampleProject2 = new Project()
                    {
                        ProjectNumber = "144-22",
                        Id = new Guid("1d5672c8-7102-414e-b5cf-95352b172ada"),
                        Title = "Example Project Number 2",
                        Description = "Example Description of Project Number 2",
                        Completed = false,
                        Created = DateTime.Now,
                        LastModified = DateTime.Now
                    };

                    await _context.AddAsync(exampleProject);
                    await _context.AddAsync(exampleProject2);
                    await _context.SaveChangesAsync();

                }
            }
            catch (Exception)
            {

            }



        }
    }
}
