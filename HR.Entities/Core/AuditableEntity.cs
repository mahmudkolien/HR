using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR.Entities.Core
{
    public class AuditableEntity : Entity
    {
        [Display(Name = "Created At")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedAt { get; set; }

        [Display(Name = "Updated At")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime? UpdatedAt { get; set; }

        public Guid? CreatedById { get; set; }
        //[ForeignKey("CreatedById")]
        //public virtual User CreatedBy { get; set; }
        public Guid? UpdatedById { get; set; }
        //[ForeignKey("UpdatedById")]
        //public virtual User UpdatedBy { get; set; }

        public AuditableEntity()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }
    }
}