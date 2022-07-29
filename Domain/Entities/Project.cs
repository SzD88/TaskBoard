using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Projects")]

    public class Project : AuditibleEntity
    {
        [Key]
        public Guid Id { get; protected set; } // what type in sql server is guid ? answer: uniqueidentifier

        public string ProjectNumber { get;   set; }

        [Required] 
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

       // public string ProjectNumber { get; set; }
        public bool Completed { get; set; }
         
        [NotMapped]
        public List<SubTask> MainTasks { get; set;}
        public Project(string projNumber, string title, string description)
        {
            ProjectNumber = projNumber;
            Id = Guid.NewGuid();
            Title = title; 
            Description = description;
            Completed = false;
            Created = DateTime.Now;
        }
        public Project()
        {

        }
    }
}
