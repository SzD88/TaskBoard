using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class UpdateSubTaskDto
    {
        public Guid Id { get; set; }    
        public string? Content { get; set; } 
        public bool Completed { get; set; }
        public Guid LevelAboveIt { get; set; }

    }

}
