using System;

namespace HR.Models.QueryModels
{
    public interface  IQueryModel
    {
        string SortBy { get; set; }
        bool IsSortAscending { get; set; }
        int Page { get; set; }
        byte PageSize { get; set; }
    }
}