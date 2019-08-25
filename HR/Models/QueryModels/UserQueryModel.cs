using System;

namespace HR.Models.QueryModels
{
    public class UserQueryModel : IQueryModel
    {
        public string Name { get; set; }
        
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}