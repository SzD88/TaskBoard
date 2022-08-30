using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Helpers;

namespace WebApi.Filters
{
    public class SortingFilter
    {
        public string SortField { get; set; }
        public bool Ascending { get; set; } = true; // #
        public SortingFilter()
        {
            SortField = "Id"; // LastModifiedDate
        }
        public SortingFilter(string sortField, bool ascending)
        {
            var sortFields = SortingHelper.GetSortFields();
            sortField = sortField.ToLower();

            if (sortFields.Select(x => x.Key).Contains(sortField.ToLower()))
            {
                //KeyValuePair<string, string>
                sortField = sortFields.Where(x => x.Key == sortField).Select(x => x.Value).SingleOrDefault();
            }
            else
            {
                sortField = "Id";
            }

            SortField = sortField;
            Ascending = ascending;
        }

    }
}
