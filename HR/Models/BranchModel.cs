using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR.Models
{
    public class BranchModel
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedById { get; set; }
        public Guid? UpdatedById { get; set; }
        public CompanyModel Company{get;set;}
        public string BranchName { get; set; }
        public string Address { get; set; }
        public string PhoneNo{get;set;}
        public string Email{get;set;}
    }
     public class BranchSaveModel
    {
        public Guid Id { get; set; }
        public Guid CompanyId{ get;set; }
        public string BranchName { get; set; }
        public string Address { get; set; }
        public string PhoneNo{get;set;}
        public string Email{get;set;}
    }
}