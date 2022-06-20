using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("SubTasks")]

    public class SubTask : AuditibleEntity
    {
        [Key]
        public Guid Id { get; protected set; }
        public List<Guid>? Tasks { get; set; }
        [Required]
        [MaxLength(100)]
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
