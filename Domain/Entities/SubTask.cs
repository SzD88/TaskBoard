using Domain.ValueObjects;

namespace Domain.Entities
{
    public class SubTask : AuditibleEntity
    {
        public Id Id { get; private set; }
        private Content _content;
        private Completed _completed;
        public DayDate _dayDate;
        public Id _levelAboveId { get; private set; }
        private readonly List<Guid> _includedSubTasks = new();
        public SubTask()
        {
        } 
        public SubTask(Guid id, string content, bool completed, DateTime dayDate,  Guid levelAboveId)
        {
            Id = id;
            _content = content;
            _completed = completed;
            _dayDate = dayDate;
            _levelAboveId = levelAboveId; 
            Created = DateTime.Now;
        }
        
        public Guid GetSubTaskId() =>
            Id;
        public string GetContent() => 
            _content.Value;
        public bool GetCompleted() => 
            _completed.Value;
        public DayDate GetDayDate() =>
           _dayDate.Value;
        public Guid GetLevelAboveId() =>
             _levelAboveId.Value;

        public void AddSubTask(Guid mainTaskId)
        {
            var alreadyExists = _includedSubTasks.Any(i => i == mainTaskId);

            if (alreadyExists)
            {
                throw new SubTaskAlredyExistsException($"Object with id: {mainTaskId} alredy exists");
            }
            _includedSubTasks.Append(mainTaskId);
        }
    }
}
