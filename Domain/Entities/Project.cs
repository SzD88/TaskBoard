using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Project : AuditibleEntity // #refactor
    {
        public Id Id { get; private set; }
        private ProjectNumber _projectNumber;
        private Title _title;
        private Description _description;
        private Completed _completed;
        private readonly List<Guid> _mainTasksAsSubTasks; // = new();
        public Project()
        {
        }
      
        public Project(Guid id, string projNumber, string title, string description, bool completed ) //DateTime created, DateTime lastmodified
        {
            Id = id;
            _projectNumber = projNumber;
            _title = title;
            _description = description;
            _completed = completed;
            //Created = created;
            //LastModified = lastmodified;
            _mainTasksAsSubTasks = new List<Guid>();
        } 
       
        public string GetProjectNumber() =>
         _projectNumber.Value;
        public string GetTitle() =>
         _title.Value;
        public string GetDescription() =>
         _description.Value;
        public bool GetCompleted() =>
         _completed.Value;

        //public void AddMainTask(Guid mainTaskId)
        //{
        //    var alreadyExists = _mainTasksAsSubTasks.Any(i => i == mainTaskId);

        //    if (alreadyExists)
        //    {
        //        throw new Exception($"Object with id: {mainTaskId} alredy exists");
        //    }
        //    _mainTasksAsSubTasks.Append(mainTaskId);
        //}
        //public bool CheckExistance(Guid id) 
        //{
        //    var task = _mainTasksAsSubTasks.FirstOrDefault(i => i == id);

        //    if (task == Guid.Empty)
        //    {
        //        throw new Exception($"Object with {id} does not exists");
        //    }
        //    return true;
        //}
        //public void RemoveMainTask(Guid item)
        //{
        //    var alreadyExists = _mainTasksAsSubTasks.Any(i => i == item);

        //    if (!alreadyExists)
        //    {
        //        throw new Exception($"Object with id: {item} does not exists");
        //    }
        //    _mainTasksAsSubTasks.Remove(item);
        //}

    }
}
