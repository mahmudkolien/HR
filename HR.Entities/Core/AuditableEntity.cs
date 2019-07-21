using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR.Entities.Core
{
    public class AuditableEntity : Entity
    {
        [DataType(DataType.Date)]
        public DateTime? CreatedOn { get; set; }

        [DataType(DataType.Date)]
        public DateTime? UpdatedOn { get; set; }

        public Guid? CreatedById { get; set; }
        //[ForeignKey("CreatedById")]
        //public virtual User CreatedBy { get; set; }
        public Guid? UpdatedById { get; set; }
        //[ForeignKey("UpdatedById")]
        //public virtual User UpdatedBy { get; set; }

        public AuditableEntity()
        {
            this.CreatedOn = DateTime.Now;
            this.UpdatedOn = DateTime.Now;
        }
    }
}