using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class SubTaskDto
    {
        public Guid Id { get; set; }
        public string? Content { get; set; }
        public bool Completed { get; set; }
        public SubTaskDto(Guid id, string content, bool completed)
        {
            Id = id;
            Content = content;  
            Completed = completed;

        }
    }
}
