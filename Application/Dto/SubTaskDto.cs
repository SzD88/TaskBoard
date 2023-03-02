namespace Application.Dto
{
    public class SubTaskDto
    {
        public Guid Id { get; set; }  
        public string Content { get; set; }
        public bool Completed { get; set; }
        public DateTime DayDate { get; set; }
        public Guid LevelAboveId { get; set; }

        public List<SubTaskDto> IncludedTasks { get; set; } = new List<SubTaskDto>();
        public DateTime Created { get; set; } 
        public DateTime LastModifiedDate { get; set; }

        public SubTaskDto(Guid id, string content, bool completed, DateTime dayDate)
        {
            Id = id;
            Content = content;  
            Completed = completed;
            DayDate = dayDate;
        }
        public SubTaskDto()
        {

        }
    }
}
