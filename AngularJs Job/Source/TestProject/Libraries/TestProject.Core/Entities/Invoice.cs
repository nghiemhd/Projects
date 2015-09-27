using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Core.Infrastructure;

namespace TestProject.Core.Entities
{
    public class Invoice : BaseEntity
    {
        public DateTime InvoiceDate { get; set; }

        public decimal ShippingFee { get; set; }

        public decimal VAT { get; set; }

        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
