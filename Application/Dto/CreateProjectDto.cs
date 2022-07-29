using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class CreateProjectDto
    {
        //   public Guid Id { get; set; } 
        public string ProjectNumber { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
