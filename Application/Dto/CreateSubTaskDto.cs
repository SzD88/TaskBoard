namespace Application.Dto
{
    public class CreateSubTaskDto
    {
        public string Content { get; set; }
        public Guid LevelAboveId { get; set; } = Guid.NewGuid(); // #tutaj
        public DateTime DayDate { get; set; }

    }

}
