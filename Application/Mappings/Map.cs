using Application.Commands;
using Application.Dto;
using Domain.Entities;

namespace Application.Mappings
{
    public static class Map
    {
        public static DayDto ProjectToProjectDto(Day projectType)
        {
            return new DayDto
            {
                Id = projectType.Id,
                DayDate = projectType.GetDate(),
                Title = projectType.GetTitle(),
                Description = projectType.GetDescription(),
                Completed = projectType.GetCompleted(),
              //  CreationDate = projectType.Created,
               // LastModifiedDate = projectType.LastModified,
                MainTasks = new List<SubTaskDto>()
            };
        }
        public static Day ProjectDtoToProject(DayDto enter)
        {
            var projectType = new Day(
            enter.Id,
            enter.DayDate,
            enter.Title,
            enter.Description,
            enter.Completed);
            return projectType;
        }
        public static Day CreateProjectDtoToProject(CreateDay enter)
        {
            var projectType = new Day(
                Guid.NewGuid(),
                enter.DayDate,
                enter.Title,
                enter.Description,
                false);

            return projectType;
        }
        public static Day UpdateProjectDtoToProject(UpdateDayDto enter)
        {
            var projectType = new Day(
            enter.Id,
            enter.DayDate,
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
                LevelAboveId = subTaskType.GetLevelAboveId(),
                DayDate = subTaskType.GetDayDate(),
                Created = subTaskType.Created
            };
        }
        public static SubTask SubTaskDtoToSubTask(SubTaskDto enter)
        {
            var subTaskType = new SubTask(
                Guid.NewGuid(),
                enter.Content,
                enter.Completed,
                enter.DayDate,
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
                enter.DayDate.Date,
                Guid.NewGuid() //#tutaj
               // enter.LevelAboveId
                );
             subTaskType.LastModified = DateTime.UtcNow;
            return subTaskType;
        }
        public static SubTask UpdateSubTaskDtoToSubTask(UpdateSubTaskDto enter)
        {
            var subTaskType = new SubTask(
                enter.Id,
                enter.Content,
                enter.Completed,
                enter.DayDate,

                enter.LevelAboveId
                );
            return subTaskType;
        }
        public static List<DayDto> ListConvert(IReadOnlyList<Day> enter)
        {
            var toReturn = new List<DayDto>();
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
