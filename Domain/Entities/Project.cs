using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Projects")]

    public class Project : AuditibleEntity
    {
        [Key]
        public Guid Id { get; set; }
        public List<SubTask> MasterTasks { get; set; }
        public bool Completed { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        public Project(string description)
        {
            Created = DateTime.Now;
            Id = Guid.NewGuid();
            Description = description;
            Completed = false;
            MasterTasks = new List<SubTask>();
        }
    }
}
