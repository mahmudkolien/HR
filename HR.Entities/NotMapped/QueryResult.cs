using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR.Entities.NotMapped
{
    [NotMapped]
    public class QueryResult<T>
    {
        public int TotalItems { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}