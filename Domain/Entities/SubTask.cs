using Domain.ValueObjects;

namespace Domain.Entities
{
    public class SubTask : AuditibleEntity
    {
        public Id Id { get; private set; }
        private Content _content;
        private Completed _completed;
        public Id _levelAboveId { get; private set; }
        private readonly List<Guid> _includedSubTasks = new();
        public SubTask()
        {
        } 
        public SubTask(Guid id, string content, bool completed, Guid levelAboveId)
        {
            Id = id;
            _content = content;
            _completed = completed; // null reference 
            _levelAboveId = levelAboveId; 
        }
        
        public Guid GetSubTaskId() =>
            Id;
        public string GetContent() => 
            _content.Value;
        public bool GetCompleted() => 
            _completed.Value; 
        public Guid GetLevelAboveId() =>
             _levelAboveId.Value;

        public void AddSubTask(Guid mainTaskId)
        {
            var alreadyExists = _includedSubTasks.Any(i => i == mainTaskId);

            if (alreadyExists)
            {
                throw new Exception($"Object with id: {mainTaskId} alredy exists");
            }
            _includedSubTasks.Append(mainTaskId);
        }
        public bool CheckExistance(Guid id) // method was Get SubTask, now i see no point in it
        {
            var task = _includedSubTasks.FirstOrDefault(i => i == id);

            if (task == Guid.Empty)
            {
                throw new Exception($"Object with {id} does not exists");
            }
            return true;
        }
        public void RemoveMainTask(Guid item)
        {
            var alreadyExists = _includedSubTasks.Any(i => i == item);

            if (!alreadyExists)
            {
                throw new Exception($"Object with id: {item} does not exists");
            }
            _includedSubTasks.Remove(item);
        }
    }
}
