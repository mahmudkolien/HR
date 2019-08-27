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
        [ForeignKey("CreatedById")]
        public User CreatedBy { get; set; }
        public Guid? UpdatedById { get; set; }
        [ForeignKey("UpdatedById")]
        public User UpdatedBy { get; set; }
        public bool IsActive { get; set; }

        public AuditableEntity()
        {
            this.CreatedOn = DateTime.Now;
            this.UpdatedOn = DateTime.Now;
            this.IsActive = true;
        }
    }
}