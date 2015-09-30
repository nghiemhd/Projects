using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Core.Infrastructure;

namespace TestProject.Core.Entities
{
    public class InvoiceDetail : BaseEntity
    {
        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public int InvoiceId { get; set; }

        [ForeignKey("InvoiceId")]
        public virtual Invoice Invoice { get; set; }
    }
}
