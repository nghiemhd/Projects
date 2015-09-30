using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Client.Web.Models
{
    public class InvoiceViewModel
    {
        public int Id { get; set; }

        public string InvoiceNo { get; set; }

        public DateTime InvoiceDate { get; set; }

        public decimal ShippingFee { get; set; }

        public decimal VAT { get; set; }

        public List<InvoiceDetailViewModel> InvoiceDetails { get; set; }
    }
}