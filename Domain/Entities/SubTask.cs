using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SubTask : AuditibleEntity
    {
        public Guid Id { get; protected set; }
        public List<SubTask>? Tasks { get; set; } 
        public string Description { get; set; }
        public Note? Note { get; set; }
        public bool Completed { get; set; }

        public Guid LevelAboveId { get; set; }


        public SubTask(string description)
        {
            Created = DateTime.Now;
            Id = Guid.NewGuid();
            Description = description;
            Completed = false;
        }
    }
}
