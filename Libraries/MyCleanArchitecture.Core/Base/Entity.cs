using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCleanArchitecture.Core.Base
{
    public class Entity<T>: IEntity<T>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }

        object IEntity.Id { get => this.Id; set { this.Id = (T)Convert.ChangeType(value, typeof(T)); } }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public bool? IsActive { get; set; }
    }
}
