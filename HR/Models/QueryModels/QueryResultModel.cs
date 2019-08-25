using System.Collections.Generic;

namespace HR.Models.QueryModels
{
    public class QueryResultModel<T>
    {
        public int TotalItems { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}