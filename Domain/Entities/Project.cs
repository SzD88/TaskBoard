using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Projects")]

    public class Project : AuditibleEntity
    {
        [Key]
        public Guid Id { get; protected set; } // what type in sql server is guid ? answer: uniqueidentifier
      
        public bool Completed { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        //create list of guids too - including all main tasks
        
        [NotMapped]
        public List<Guid> MainTasks { get; set;}
        public Project(string description)
        {
            Created = DateTime.Now;
            Id = Guid.NewGuid();
            Description = description;
            Completed = false;
          //  MasterTasks = new List<Guid>();
        }
    }
}
