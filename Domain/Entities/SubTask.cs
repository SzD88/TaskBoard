using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("SubTasks")]
    public class SubTask : AuditibleEntity
    {

        [Key]
        public Guid Id { get; protected set; } 
        [Required]
        [MaxLength(100)]
        public string Content { get; set; } 
        public bool Completed { get; set; }
        public Guid LevelAboveId { get; set; }


        public SubTask(string content)
        {
            Content = content;
            Completed = false;

        }
    }
}
