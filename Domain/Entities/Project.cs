namespace Domain.Entities
{
    public class Project : AuditibleEntity // #refactor
    { 
        public Guid Id { get;  set; } //#refactor : private(thismore) or  protected should be added to set! 
        public string ProjectNumber { get;   set; } 
        public string Title { get; set; } 
        public string Description { get; set; } 
        public bool Completed { get; set; } 
        public List<SubTask> MainTasks { get; set;}
        public Project(string projNumber, string title, string description)
        {
            ProjectNumber = projNumber;
            Id = Guid.NewGuid();
            Title = title; 
            Description = description;
            Completed = false;
            Created = DateTime.Now;
        }
        public Project()
        {

        }
    }
}
