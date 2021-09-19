using Common.Attributes;
using Common.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Abstraction
{
    public abstract class BaseEntity : IEntity
    {
        [Key]
        public long ID { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public object GetKeyProperty()
        {
            return this.PropertyFindValueByAttribute(typeof(KeyAttribute));
        }

        public object GetParentKeyProperty()
        {
            return this.PropertyFindValueByAttribute(typeof(ParentKeyAttribute));
        }
    }
}