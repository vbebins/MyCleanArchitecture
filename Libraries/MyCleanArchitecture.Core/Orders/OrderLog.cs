using MyCleanArchitecture.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCleanArchitecture.Core.Orders
{
    public class OrderLog : Entity<long>
    {
        public long OrderId { get; set; }

        public string OrderName { get; set; }   
    }
}
