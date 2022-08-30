using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SubTaskRepository : ISubTaskRepository
    {
        private readonly ProjectManagerContext _context;
        public SubTaskRepository(ProjectManagerContext context)
        {
            _context = context;
        }

        public async Task<SubTask> CreateAsync(SubTask entity)
        {
            entity.Completed = false;
            entity.Created = DateTime.Now;
            entity.LastModified = DateTime.Now;
            await _context.SubTasks.AddAsync(entity); //(SubTask)
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteAsync(object subTaskToDelete) // tu ma wejsc note
        {
            _context.Remove(subTaskToDelete);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<SubTask>> GetAllAsync()
        {
            return await _context.SubTasks.ToListAsync();
        }
        public async Task<SubTask> GetByIDAsync(object id)
        {
            var guid = (Guid)id;
            var toReturn = await _context.SubTasks.FirstOrDefaultAsync(x => x.Id == guid);
          //   if (toReturn == null) throw new Exception("Not found sd");
            return toReturn;
        }
        public async Task UpdateAsync(SubTask entityToUpdate)
        {
            _context.SubTasks.Update(entityToUpdate);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<SubTask>> CreateListOfTasks(Guid parentId)
        {
            var list = await _context.SubTasks
                .Where(x => x.LevelAboveId == parentId)
                .ToListAsync();

            foreach (var item in list)
            {
                var listBelow = await CreateListOfTasks(item.Id);


                item.IncludedTasks = listBelow.ToList();
            }
            return list;
        }

        public async Task CreateExampleSubTasksAsync()
        {// ("56950D32-F426-4B5C-96CB-FFA074A8A37B"),
         // ("11150Z32-Z336-3B5C-33ZZ-FFA034A8A36Z"),

            var ifCreated = await GetByIDAsync(new Guid("392D319D-BAAF-4F52-BCD7-55D8DFB9E0C4"));
            if (ifCreated == null)
            {
                var exampleSubTask1 = new SubTask()
                {
                    Id = new Guid("392D319D-BAAF-4F52-BCD7-55D8DFB9E0C4"),
                    Content = "SubTaks 1 of Project 1 Level 0",
                    LevelAboveId = Guid.Parse("56950D32-F426-4B5C-96CB-FFA074A8A37B"), //proj1
                    Completed = false,
                    Created = DateTime.Now
                };
                var exampleSubTask2 = new SubTask()
                {
                    Id = new Guid("e79a9e1d-0c64-4c4b-9bb8-fbb6aa471a32"),
                    Content = "SubTaks 1 of project 2 Level 0",
                    LevelAboveId = Guid.Parse("1d5672c8-7102-414e-b5cf-95352b172ada"),// proj2
                    Completed = false,
                    Created = DateTime.Now
                };
                var exampleSubTask3 = new SubTask()
                {
                    Id = new Guid("985e18e3-62d5-42f7-a616-0395aa72ac96"),
                    Content = "SubTaks 2 inside subtask 1 Level 1 Project 1",
                    LevelAboveId = Guid.Parse("392D319D-BAAF-4F52-BCD7-55D8DFB9E0C4"), //subtask1
                    Completed = false,
                    Created = DateTime.Now
                };
                var exampleSubTask4 = new SubTask()
                {
                    Id = new Guid("dd54de26-87aa-4a9b-90b5-6a0d667d31f5"),
                    Content = "SubTaks 3 inside subtask 2 Level 2 Project 1",
                    LevelAboveId = Guid.Parse("985e18e3-62d5-42f7-a616-0395aa72ac96"), //subtask3
                    Completed = false,
                    Created = DateTime.Now
                };
                var exampleSubTask5 = new SubTask()
                {
                    Id = new Guid("4d8b4b8e-70a7-4adf-a0d6-8579be2c9883"),
                    Content = "SubTaks 4 inside subtask 3 Level 3 Project 1",
                    LevelAboveId = Guid.Parse("dd54de26-87aa-4a9b-90b5-6a0d667d31f5"), //subtask4
                    Completed = false,
                    Created = DateTime.Now
                };
                try
                {
                    await _context.AddAsync(exampleSubTask1);
                    await _context.AddAsync(exampleSubTask2);
                    await _context.AddAsync(exampleSubTask3);
                    await _context.AddAsync(exampleSubTask4);
                    await _context.AddAsync(exampleSubTask5);

                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {

                }
            }

        }
    }
}
