﻿namespace Application.Dto
{
    public class ProjectDto
    {
        public Guid Id { get; protected set; } // what type in sql server is guid ? answer: uniqueidentifier
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public List<Guid> MainTasks { get; set; }
    }
}
