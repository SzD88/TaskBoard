using Application.Dto;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMappings;

public static class AutoMapperConfig
  {
      public static IMapper Initialize()
          => new MapperConfiguration
          (
           cfg =>
           {
               //#refactor #needrefactor lastchanged == creationDate 
               cfg.CreateMap<SubTask, SubTaskDto>()
               .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => src.LastModified));// was .reversemap()
               cfg.CreateMap<SubTask, CreateSubTaskDto>().ReverseMap();
               cfg.CreateMap<SubTaskDto, CreateSubTaskDto>().ReverseMap();
               cfg.CreateMap<CreateSubTaskDto, SubTaskDto>();
               cfg.CreateMap<SubTaskDto, SubTask>(); // changed - possible problem
               cfg.CreateMap<UpdateSubTaskDto, SubTask>().ReverseMap();

               cfg.CreateMap<Project, ProjectDto>()
               .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => src.LastModified))// was .reversemap()
               .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.Created));// was .reversemap()

               cfg.CreateMap<Project, CreateProjectDto>().ReverseMap();
               cfg.CreateMap<ProjectDto, CreateProjectDto>().ReverseMap();
               cfg.CreateMap<CreateProjectDto, ProjectDto>();
               cfg.CreateMap<ProjectDto, Project>(); // changed - possible problem
               cfg.CreateMap<UpdateProjectDto, Project>();
                 
           }
          ).CreateMapper();
  }
