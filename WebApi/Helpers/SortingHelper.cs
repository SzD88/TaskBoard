using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Helpers
{
    public class SortingHelper
    {
        public static KeyValuePair<string, string>[] GetSortFields()
        {
            return new[] { SortFields.Title, SortFields.CreationDate };
        }
    }
    public class SortFields
    {
        public static KeyValuePair<string, string> Title { get; } = new KeyValuePair<string, string>("title", "Title");
        public static KeyValuePair<string, string> CreationDate { get; } = new KeyValuePair<string, string>("creationdate", "Created");
        public static KeyValuePair<string, string> LastModifiedDate { get; } = new KeyValuePair<string, string>("lastmodifieddate", "LastModifiedDate");
        public static KeyValuePair<string, string> Id { get; } = new KeyValuePair<string, string>("id", "Id");
        public static KeyValuePair<string, string> ProjectNumber { get; } = new KeyValuePair<string, string>("projectnumber", "ProjectNumber");
        public static KeyValuePair<string, string> Description { get; } = new KeyValuePair<string, string>("description", "Description");
        public static KeyValuePair<string, string> Completed { get; } = new KeyValuePair<string, string>("completed", "Completed");


        //public Guid Id { get; protected set; } // what type in sql server is guid ? answer: uniqueidentifier
        //public string ProjectNumber { get; set; }
        //public string Title { get; set; }
        //public string Description { get; set; }
        //public bool Completed { get; set; }
        //public DateTime CreationDate { get; set; }
        //public DateTime LastModifiedDate { get; set; }
        //public List<SubTaskDto> MainTasks { get; set; } // by count? 
    }
}
