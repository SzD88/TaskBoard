using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Project : AuditibleEntity  
    {
        public Id Id { get; private set; }
        private ProjectNumber _projectNumber;
        private Title _title;
        private Description _description;
        private Completed _completed;
        public Project()
        {
        } 
        public Project(Guid id, ProjectNumber projNumber, Title title, Description description,
            Completed completed ) //DateTime created, DateTime lastmodified
        {
            Id = id;
            _projectNumber = projNumber;
            _title = title;
            _description = description;
            _completed = completed;
            //Created = created;
            //LastModified = lastmodified;
           //  _mainTasksAsSubTasks = new List<Guid>();
        } 
       
        public string GetProjectNumber() =>
         _projectNumber.Value;
        public string GetTitle() =>
         _title.Value;
        public string GetDescription() =>
         _description.Value;
        public bool GetCompleted() =>
         _completed.Value; 
    }
}
