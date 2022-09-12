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
        // na bieząco dodam jak bede naprawial serwisy ok ? ok.
        //public static Project ProjectDtoToProject(ProjectDto projectDtoType)
        //{
        //    var project = new Project();

        //    project.EditProjectNumber(projectDtoType.ProjectNumber);
        //    project.EditDescription(projectDtoType.Description);
        //    project.EditTitle(projectDtoType.Title);
        //    project.EditCompleted(projectDtoType.Completed);
        //    project.ed
                //dto
        //        public Guid Id { get; set; }
        //public string ProjectNumber { get; set; }
        //public string Title { get; set; }
        //public string Description { get; set; }
        //public bool Completed { get; set; }
        //public DateTime CreationDate { get; set; }
        //public DateTime LastModifiedDate { get; set; }
        //public List<SubTaskDto> MainTasks { get; set; }
    };
        }
    }

}
