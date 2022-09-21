﻿using Domain.Entities;
using Domain.Interfaces;
using Domain.ValueObjects;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class SubTaskRepository : ISubTaskRepository
    {
        private readonly ProjectManagerContext _context;
        public SubTaskRepository(ProjectManagerContext context)
        {
            _context = context;
        }

        public async Task<SubTask> CreateAsync(SubTask entity)
        { 
            await _context.SubTasks.AddAsync(entity); //(SubTask)
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteAsync(Guid idToDelete) // tu ma wejsc note
        {
            var subTaskToDelete = await GetByIDAsync(idToDelete);
            _context.Remove(subTaskToDelete);
            await _context.SaveChangesAsync();
        }
        public async Task<IReadOnlyList<SubTask>> GetAllAsync()
        {
            return await _context.SubTasks.ToListAsync();
        }
        public async Task<SubTask> GetByIDAsync(Guid id)
        {
            var guid = (Id)id;
            var toReturn = await _context.SubTasks.FirstOrDefaultAsync(x => x.Id == guid);
            return toReturn;
        }
        public async Task UpdateAsync(SubTask entityToUpdate)
        {
            entityToUpdate.LastModified = DateTime.Now; 
            _context.SubTasks.Update(entityToUpdate);
            await _context.SaveChangesAsync();
        }
        public async Task<IReadOnlyList<SubTask>> CreateListOfTasks(Guid parentId)
        {
            var cos = (Id)parentId;
            var list = await _context.SubTasks
                .Where(x => x.Id == cos) // #problem // nie mozesz tak zrobic przeciez
                //#sorthere
                .ToListAsync(); 
             
            foreach (var subtask in list)
            {
                var listBelow = await CreateListOfTasks(subtask.Id);

                foreach (var itemBelow in listBelow)
                {
                    subtask.AddSubTask(itemBelow.GetSubTaskId());
                }
            }
            return list;
        } 
    }
}
