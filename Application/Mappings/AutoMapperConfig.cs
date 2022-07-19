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
                 //#refactor #needrefactor
                 cfg.CreateMap<SubTask, SubTaskDto>().ReverseMap();
                 cfg.CreateMap<SubTask, CreateSubTaskDto>().ReverseMap();
                 cfg.CreateMap<SubTaskDto, CreateSubTaskDto>().ReverseMap();
                 cfg.CreateMap<CreateSubTaskDto, SubTaskDto>() ;
                 cfg.CreateMap<UpdateSubTaskDto, SubTask>().ReverseMap();

                 cfg.CreateMap<Project, ProjectDto>().ReverseMap();
                 cfg.CreateMap<Project, CreateProjectDto>().ReverseMap();
                 cfg.CreateMap<ProjectDto, CreateProjectDto>().ReverseMap();
                 cfg.CreateMap<CreateProjectDto, ProjectDto>();
                 cfg.CreateMap<UpdateProjectDto, Project>().ReverseMap();
             }
            ).CreateMapper();
    }
}
