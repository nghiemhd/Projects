using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Client.Web.Models
{
    public class UpdateInvoiceViewModel
    {
        public List<InvoiceDetailViewModel> UpdatedInvoiceDetails { get; set; }

        public List<int> DeletedInvoiceDetails { get; set; }
    }
}