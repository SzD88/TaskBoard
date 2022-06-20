﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Projects")]

    public class Project : AuditibleEntity
    {
        [Key]
        public Guid Id { get; set; } // #check what type in sql server is guid ? answer: uniqueidentifier
      //  public List<Guid> MasterTasks { get; set; } // #check as well  as subtask 
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
          //  MasterTasks = new List<Guid>();
        }
    }
}
