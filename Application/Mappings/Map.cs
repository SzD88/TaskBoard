using Application.Dto;
using Domain.Entities;

namespace Application.Mappings
{
    public static class Map
    {
        public static ProjectDto ProjectToProjectDto(Project projectType)
        {
            return new ProjectDto
            {
                Id = projectType.GetProjectId(),
                ProjectNumber = projectType.GetProjectNumber(),
                Title = projectType.GetTitle(),
                Description = projectType.GetDescription(),
                Completed = projectType.GetCompleted(),
                CreationDate = projectType.Created,
                LastModifiedDate = projectType.LastModified,
                MainTasks = new List<SubTaskDto>()
            }; 
        }
        
    }

}
