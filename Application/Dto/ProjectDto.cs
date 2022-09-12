﻿using Domain.Entities;

namespace Application.Dto
{
    public class ProjectDto
    {
        public Guid Id { get; set; }  
        public string ProjectNumber { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public List<SubTaskDto> MainTasks { get; set; }

        
    }
}
