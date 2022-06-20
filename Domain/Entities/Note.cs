using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Notes")]
    public class Note : AuditibleEntity
    {

        [Key]
        public Guid Id { get; protected set; } 
        [Required]
        [MaxLength(100)]
        public string Content { get; set; } 
        public bool Completed { get; set; }
        public Guid LevelAboveId { get; set; }


        public Note(string content)
        {
            Content = content;
            Completed = false;

        }
    }
}
