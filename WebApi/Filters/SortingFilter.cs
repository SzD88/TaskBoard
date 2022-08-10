using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Filters
{
    public class SortingFilter
    {
        public string SortField { get; set; }
        public bool Ascending { get; set; } = false; // #
        public SortingFilter()
        {
            SortField = "LastChanged";
        }
        public SortingFilter(string sortField, bool ascending)
        {
            var sortFields = 
        }
    }
}
    