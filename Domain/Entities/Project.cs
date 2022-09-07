using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Projects")]

    public class Project : AuditibleEntity // #refactor
    {

        [Key]
        public Guid Id { get;  set; } //#refactor : private(thismore) or  protected should be added to set!

        public string ProjectNumber { get;   set; }

        [Required] 
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

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
