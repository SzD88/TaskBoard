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
        public static Project ProjectDtoToProject(ProjectDto enter)
        {
            var projectType = new Project();
            projectType.EditProjectNumber(enter.ProjectNumber);
            projectType.EditCompleted(enter.Completed);
            projectType.EditDescription(enter.Description);
            projectType.EditTitle(enter.Title);
            projectType.Id.Edit(enter.Id);
            projectType.Created = enter.CreationDate;
            projectType.LastModified = enter.LastModifiedDate;

            return projectType; 
        }
        public static Project CreateProjectDtoToProject(CreateProjectDto enter)
        {
            var projectType = new Project();
            projectType.EditProjectNumber(enter.ProjectNumber);
            projectType.EditCompleted(false);
            projectType.EditDescription(enter.Description);
            projectType.EditTitle(enter.Title);
            projectType.Id.Edit(new Guid());
            projectType.Created = DateTime.UtcNow;
            projectType.LastModified = DateTime.UtcNow;

            return projectType;
        }
        public static Project UpdateProjectDtoToProject(UpdateProjectDto enter)
        {
            var projectType = new Project();
            projectType.EditProjectNumber(enter.ProjectNumber);
            projectType.EditCompleted(false);
            projectType.EditDescription(enter.Description);
            projectType.EditTitle(enter.Title);
            projectType.Id.Edit(enter.Id);
            //projectType.Created = ??; #refactor
            projectType.LastModified = DateTime.UtcNow;

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
            var subTaskType = new SubTask();
            subTaskType.EditCompleted(enter.Completed);
            subTaskType.EditContent(enter.Content);
            subTaskType.EditLevelAboveId(enter.LevelAboveId);
            subTaskType.Id.Edit(enter.Id);

            return subTaskType;
        } 
        public static SubTask CreateSubTaskDtoToSubTask(CreateSubTaskDto enter)
        {
            var subTaskType = new SubTask();
            subTaskType.EditCompleted(false);
            subTaskType.EditContent(enter.Content);
            subTaskType.EditLevelAboveId(enter.LevelAboveId);
            subTaskType.Id.Edit(new Guid());

            return subTaskType;
        } 
        public static SubTask UpdateSubTaskDtoToSubTask(UpdateSubTaskDto enter)
        {
            var subTaskType = new SubTask();
            subTaskType.EditCompleted(false);
            subTaskType.EditContent(enter.Content);
            subTaskType.EditLevelAboveId(enter.LevelAboveId);
            subTaskType.Id.Edit(enter.Id); 
            //projectType.Created = ??; #refactor
            subTaskType.LastModified = DateTime.UtcNow;
            return subTaskType;
        }
    }

}
