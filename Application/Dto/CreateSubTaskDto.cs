namespace Application.Dto
{
    public class CreateSubTaskDto
    {
        public string Content { get; set; }
        public Guid LevelAboveId { get; set; } = Guid.NewGuid();  
        public DateTime DayDate { get; set; }

    }

}
