using Domain.ValueObjects;

namespace Domain.Entities
{
    public class SubTask : AuditibleEntity
    {
        public Id? Id { get; private set; }  
        private Content? _content;
        private Completed? _completed;
        private Id? _levelAboveId;
        private readonly LinkedList<SubTask> _includedSubTasks = new(); 
        public SubTask()
        {
        }
        public SubTask(string content)
        {
            Id = Guid.NewGuid();
            _content = content;
            _completed = false;
            Created = DateTime.Now; 
        } 
        public void EditContent(string toUpdate) =>
         _content.Edit(toUpdate);
        public void EditCompleted(bool toUpdate) =>
         _completed.Edit(toUpdate);
        public void EditLevelAboveId(Guid toUpdate) =>
         _levelAboveId.Edit(toUpdate);   
        public void AddMainTask(SubTask item)
        {
            var alreadyExists = _includedSubTasks.Any(i => i.Id == item.Id);
            if (alreadyExists)
            {
                throw new Exception($"{item} alredy exists");
            }
            _includedSubTasks.AddLast(item);
        }
        public SubTask GetMainTask(Id id)
        {
            var task = _includedSubTasks.SingleOrDefault(i => i.Id == id);

            if (task is null)
            {
                throw new Exception($"Item with {id} does not exists");
            }
            return task;
        }
        public void RemoveMainTask(SubTask item)
        {
            var itemToRemove = GetMainTask(item.Id);
            _includedSubTasks.Remove(itemToRemove);
        }
    }
}
