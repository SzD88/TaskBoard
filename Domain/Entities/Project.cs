using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Project : AuditibleEntity // #refactor
    {
        public Id? Id { get; private set; }
        private ProjectNumber? _projectNumber;
        private Title? _title;
        private Description? _description;
        private Completed? _completed;
        private readonly List<Guid> _mainTasksAsSubTasks; // = new();
        public Project()
        {
        }
        public Project(string projNumber, string title, string description)
        {
            Id = Guid.NewGuid();
            _projectNumber = projNumber;
            _title = title;
            _description = description;
            _completed = false;
            Created = DateTime.Now;
            _mainTasksAsSubTasks =  new List<Guid>();
        } 
        public void EditProjectNumber(string toUpdate) =>
         _projectNumber.Edit(toUpdate);
        public void EditTitle(string toUpdate) =>
         _title.Edit(toUpdate);
        public void EditDescription(string toUpdate) =>
         _description.GetValue();
        public void EditCompleted(bool toUpdate) =>
         _completed.GetValue();
        public Guid GetProjectId() =>
         Id;
        public string GetProjectNumber() =>
         _projectNumber.GetValue(); 
        public string GetTitle() =>
         _title.GetValue();
        public string GetDescription() =>
         _description.GetValue();
        public bool GetCompleted() =>
         _completed.GetValue();

        public void AddMainTask(Guid mainTaskId)
        {
            var alreadyExists = _mainTasksAsSubTasks.Any(i => i == mainTaskId);

            if (alreadyExists)
            {
                throw new Exception($"Object with id: {mainTaskId} alredy exists");
            }
            _mainTasksAsSubTasks.Append(mainTaskId);
        }
        public bool CheckExistance(Guid id) // method was Get SubTask, now i see no point in it
        {
            var task = _mainTasksAsSubTasks.FirstOrDefault(i => i == id);

            if (task == Guid.Empty)
            {
                throw new Exception($"Object with {id} does not exists");
            }
            return true;
        }
        public void RemoveMainTask(Guid item)
        {
            var alreadyExists = _mainTasksAsSubTasks.Any(i => i == item);

            if (!alreadyExists)
            {
                throw new Exception($"Object with id: {item} does not exists");
            }
            _mainTasksAsSubTasks.Remove(item);
        }

    }
}
