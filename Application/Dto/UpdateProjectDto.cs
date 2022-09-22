namespace Application.Dto
{
    public class UpdateProjectDto 
    {
        public Guid Id { get; set; }
        public string ProjectNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }

    }
}
