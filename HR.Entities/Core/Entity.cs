using System;
using System.ComponentModel.DataAnnotations;

namespace HR.Entities.Core
{
    public class Entity
    {
        [Key]
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }

        public Entity()
        {
            this.Id = Guid.NewGuid();
        }
    }
}