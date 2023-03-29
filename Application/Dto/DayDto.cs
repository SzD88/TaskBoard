namespace Application.Dto
{
    public class DayDto
    {
        public Guid Id { get; set; }  
        public DateTime DayDate { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public List<SubTaskDto> MainTasks { get; set; }
    }
}
