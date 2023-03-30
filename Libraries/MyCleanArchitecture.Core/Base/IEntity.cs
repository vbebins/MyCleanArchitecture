using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCleanArchitecture.Core.Base
{
    public interface IEntity
    {
        object Id { get; set; }
        DateTime CreatedDate { get; set; }
        string CreatedBy { get; set; }
        DateTime LastModifiedDate { get; set; }
        string LastModifiedBy { get; set; }
        bool? IsActive { get; set; }
    }
    public interface IEntity<T> : IEntity
    {
        new T Id { get; set; }
    }
}
