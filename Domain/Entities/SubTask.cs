﻿using Domain.ValueObjects;

namespace Domain.Entities
{
    public class SubTask : AuditibleEntity
    {
        public Id? Id { get; private set; }  
        private Content? _content;
        private Completed? _completed;
        private Id? _levelAboveId;
        private readonly LinkedList<Guid> _includedSubTasks = new(); 
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

        public Guid GetSubTaskId() =>
        Id;
        public string GetContent() =>
         _content.GetValue();
        public bool GetCompleted() =>
        _completed.GetValue();
        public Guid GetLevelAboveId() =>
         _levelAboveId.GetValue();

        public void AddMainTask(Guid mainTaskId)
        {
            var alreadyExists = _includedSubTasks.Any(i => i == mainTaskId);

            if (alreadyExists)
            {
                throw new Exception($"Object with id: {mainTaskId} alredy exists");
            }
            _includedSubTasks.AddLast(mainTaskId);
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
