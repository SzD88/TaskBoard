using Application.Commands;
using Application.Dto;
using Domain.Entities;

namespace Application.Mappings
{
    public static class Map
    {
        public static DayDto DayToDayDto(Day dayType)
        {
            return new DayDto
            {
                Id = dayType.Id,
                DayDate = dayType.GetDate(),
                Title = dayType.GetTitle(),
                Description = dayType.GetDescription(),
                Completed = dayType.GetCompleted(),
                MainTasks = new List<SubTaskDto>()
            };
        }
        public static Day DayDtoToDay(DayDto enter)
        {
            var dayType = new Day(
            enter.Id,
            enter.DayDate,
            enter.Title,
            enter.Description,
            enter.Completed);
            return dayType;
        }
        public static Day CreateDayDtoToDay(CreateDayDto enter)
        {
            var dayType = new Day(
                Guid.NewGuid(),
                enter.DayDate,
                enter.Title,
                enter.Description,
                false);

            return dayType;
        }
        public static Day UpdateDayDtoToDay(UpdateDayDto enter)
        {
            var dayType = new Day(
            enter.Id,
            enter.DayDate,
            enter.Title,
            enter.Description,
            enter.Completed);
            return dayType;
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
                false, 
                enter.DayDate.Date,
                Guid.NewGuid() 
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
                toReturn.Add(Map.DayToDayDto(item));
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
