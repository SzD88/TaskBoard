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
        private readonly LinkedList<SubTask> _mainTasksAsSubTasks = new(); 
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
        } 
        public void EditProjectNumber(string toUpdate) =>
         _projectNumber.Edit(toUpdate); 
        public void EditTitle(string toUpdate) =>
         _title.Edit(toUpdate); 
        public void EditDescription(string toUpdate) =>
          _description.Edit(toUpdate); 
        public void EditCompleted(bool toUpdate) =>
         _completed.Edit(toUpdate); 
        public void AddMainTask(SubTask item)
        {
            var alreadyExists = _mainTasksAsSubTasks.Any(i => i.Id == item.Id);
            if (alreadyExists)
            {
                throw new Exception($"{item} alredy exists");
            }
            _mainTasksAsSubTasks.AddLast(item);
        }
        public SubTask GetMainTask(Id id)
        {
            var task = _mainTasksAsSubTasks.SingleOrDefault(i => i.Id == id);

            if (task is null)
            {
                throw new Exception($"Item with {id} does not exists");
            }
            return task;
        }
        public void RemoveMainTask(SubTask item)
        {
            var itemToRemove = GetMainTask(item.Id);
            _mainTasksAsSubTasks.Remove(itemToRemove);
        }
    }
}
