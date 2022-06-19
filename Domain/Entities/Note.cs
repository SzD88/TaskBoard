using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Notes")]
    public class Note : AuditibleEntity
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Content { get; set; }

        
        public bool Completed { get; set; }

        public Note()
        {

        }
        public Note(  string content)
        {
            
            Content = content;
            Completed = false;

        }
    }
}
