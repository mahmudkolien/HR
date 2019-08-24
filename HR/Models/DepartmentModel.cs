using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR.Models
{
    public class DepartmentModel
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedById { get; set; }
        public Guid? UpdatedById { get; set; }
         public string DepartmentName{ get;set;}
    }
     public class DepartmentSaveModel
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
         public string DepartmentName{ get;set;}
    }
}