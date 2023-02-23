using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Day : AuditibleEntity  
    {
        public Id Id { get; private set; }
        private DayDate _dayDate;
        private Title _title;
        private Description _description;
        private Completed _completed;
        public Day()
        {
        } 
        public Day(Guid id, DayDate dayDate, Title title, Description description,
            Completed completed ) //DateTime created, DateTime lastmodified
        {
            Id = id;
            _dayDate = dayDate;
            _title = title;
            _description = description;
            _completed = completed;
            //Created = created;
            //LastModified = lastmodified;
           //  _mainTasksAsSubTasks = new List<Guid>();
        } 
       
        public DateTime GetDate() =>
         _dayDate.Value;
        public string GetTitle() =>
         _title.Value;
        public string GetDescription() =>
         _description.Value;
        public bool GetCompleted() =>
         _completed.Value; 
    }
}
