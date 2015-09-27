using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Core.Infrastructure;

namespace TestProject.Core.Entities
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }

        public int OrderStatus { get; set; }
    }
}
