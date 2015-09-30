using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Client.Web.Models
{
    public class InvoiceDetailViewModel
    {
        public int Id { get; set; }

        public int InvoiceId { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }        
    }
}