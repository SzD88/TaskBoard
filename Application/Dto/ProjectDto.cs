using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class ProjectDto  
    {
        public List<Domain.Entities.zzzSubTask> MasterTasks { get; set; }
        public bool Completed { get; set; }
        public string Description { get; set; }

    }
}
