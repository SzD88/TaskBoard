using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class CreateSubTaskDto
    {
        public string? Content { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateSubTaskDto, SubTask>().ReverseMap();
            profile.CreateMap<CreateSubTaskDto, SubTaskDto>().ReverseMap();
        }
    }
   
}
