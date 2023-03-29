namespace Application.Dto
{
    public class UpdateSubTaskDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public bool Completed { get; set; }
        public DateTime DayDate { get; set; }
        public Guid LevelAboveId { get; set; }
    }
}
