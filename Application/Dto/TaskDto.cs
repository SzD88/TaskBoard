using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class TaskDto
    {
      //  public List<Guid>? Tasks { get; set; } // #check should be list of  Guid of subtask ID
        public string Description { get; set; }
        public string?  Note { get; set; }
        public bool Completed { get; set; } 

     // public Guid LevelAboveId { get; set; }
    }
}
