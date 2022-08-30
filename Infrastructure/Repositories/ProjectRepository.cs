using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
          //  if (toReturn == null) throw new Exception("Not found sd");
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
                        Title = "Title of Example Project 1",
                        Description = "Description of Example Project Number 1",
                        Completed = false,
                        Created = DateTime.Now

                    };
                    var exampleProject2 = new Project()
                    {
                        ProjectNumber = "144-22",
                        Id = new Guid("1d5672c8-7102-414e-b5cf-95352b172ada"),
                        Title = "Title of Example Project 2",
                        Description = "Description of Example Project Number 2",
                        Completed = false,
                        Created = DateTime.Now
                    };

                    await _context.AddAsync(exampleProject);
                    await _context.AddAsync(exampleProject2);
                    await _context.SaveChangesAsync();

                }
            } 
            catch ( Exception)
            {
                
            }



        }
    }
}
