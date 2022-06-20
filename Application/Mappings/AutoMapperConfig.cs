using Application.Dto;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AutoMappings
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration
            (
             cfg =>
             {
                 cfg.CreateMap<Note, NoteDto>().ReverseMap();
                 cfg.CreateMap<Note, CreateNoteDto>().ReverseMap();
                 cfg.CreateMap<NoteDto, CreateNoteDto>().ReverseMap();
             }
            ).CreateMapper();
    }
}
