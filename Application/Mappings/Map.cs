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
                Id = projectType.Id,
                ProjectNumber = projectType.GetProjectNumber(),
                Title = projectType.GetTitle(),
                Description = projectType.GetDescription(),
                Completed = projectType.GetCompleted(),
                CreationDate = projectType.Created,
                LastModifiedDate = projectType.LastModified,
                MainTasks = new List<SubTaskDto>()
            };
        }
        public static Project ProjectDtoToProject(ProjectDto enter)
        {
            var projectType = new Project(
            enter.Id,
            enter.ProjectNumber,
            enter.Title,
            enter.Description,
            enter.Completed);
            return projectType;
        }
        public static Project CreateProjectDtoToProject(CreateProjectDto enter)
        {
            var projectType = new Project(
                Guid.NewGuid(),
                enter.ProjectNumber,
                enter.Title,
                enter.Description,
                false);

            return projectType;
        }
        public static Project UpdateProjectDtoToProject(UpdateProjectDto enter)
        {
            var projectType = new Project(
            enter.Id,
            enter.ProjectNumber,
            enter.Title,
            enter.Description,
            enter.Completed);
            return projectType;
        }

        public static SubTaskDto SubTaskToSubTaskDto(SubTask subTaskType)
        {
            return new SubTaskDto
            {
                Id = subTaskType.GetSubTaskId(),
                Completed = subTaskType.GetCompleted(),
                Content = subTaskType.GetContent(),
                LevelAboveId = subTaskType.GetLevelAboveId()
            };
        }
        public static SubTask SubTaskDtoToSubTask(SubTaskDto enter)
        {
            var subTaskType = new SubTask(
                Guid.NewGuid(),
                enter.Content,
                enter.Completed,
                enter.LevelAboveId
                );
            return subTaskType;
        }
        public static SubTask CreateSubTaskDtoToSubTask(CreateSubTaskDto enter)
        {
            var subTaskType = new SubTask(
                Guid.NewGuid(),
                enter.Content,
                false,  // completed
                enter.LevelAboveId
                );
            return subTaskType;
        }
        public static SubTask UpdateSubTaskDtoToSubTask(UpdateSubTaskDto enter)
        {
            var subTaskType = new SubTask(
                enter.Id,
                enter.Content,
                enter.Completed,
                enter.LevelAboveId
                );
            return subTaskType;
        }
        public static List<ProjectDto> ListConvert(IReadOnlyList<Project> enter)
        {
            var toReturn = new List<ProjectDto>();
            foreach (var item in enter)
            {
                toReturn.Add(Map.ProjectToProjectDto(item));
            }
            return toReturn;
        }
        public static List<SubTaskDto> ListConvert(IReadOnlyList<SubTask> enter)
        {
            var toReturn = new List<SubTaskDto>();
            foreach (var item in enter)
            {
                toReturn.Add(Map.SubTaskToSubTaskDto(item));
            }
            return toReturn;
        }
    }
}
