namespace Domain.Entities
{
    public class SubTask : AuditibleEntity
    { 
        public Guid Id { get;   set; } // #refactor protected need to be added 
        public string Content { get; set; } 
        public bool Completed { get; set; }
        public Guid LevelAboveId { get; set; }  
        public List<SubTask> IncludedTasks { get; set; }
        public SubTask(string content)
        {
            Id = Guid.NewGuid(); 
            Content = content;
            Completed = false;
            Created = DateTime.Now;
        }
        public SubTask()
        {

        }
    }
}
