using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISubTaskService : IService<SubTaskDto,CreateSubTaskDto, UpdateSubTaskDto>
    {
        
        //Task<NoteDto> CreateAsync(CreateNoteDto entity);
        //Task DeleteAsync(Guid id);
       // Task<IEnumerable<NoteDto>> GetAllAsync();
       // Task<NoteDto> GetByIDAsync(Guid id); 
//Task UpdateAsync(NoteDto entityToUpdate);
    }
}
