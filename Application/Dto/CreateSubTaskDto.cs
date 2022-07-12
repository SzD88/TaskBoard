﻿using AutoMapper;
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
        public Guid LevelAboveId { get; set; }
    }
   
}
