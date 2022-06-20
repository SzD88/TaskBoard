using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class CreateNoteDto
    {
        public string? Content { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateNoteDto, Note>().ReverseMap();
            profile.CreateMap<CreateNoteDto, NoteDto>().ReverseMap();
        }
    }
   
}
