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
            return new[] { SortFields.Title, SortFields.CreationDate, SortFields.LastModified,  
            SortFields.ProjectNumber, SortFields.Description};
        }
    }
    public class SortFields
    {
        public static KeyValuePair<string, string> Title { get; } = new KeyValuePair<string, string>("title", "Title");
        public static KeyValuePair<string, string> CreationDate { get; } = new KeyValuePair<string, string>("creation date", "Created");
        public static KeyValuePair<string, string> LastModified { get; } = new KeyValuePair<string, string>("last modified date", "LastModified");
        public static KeyValuePair<string, string> ProjectNumber { get; } = new KeyValuePair<string, string>("project number", "ProjectNumber");
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
