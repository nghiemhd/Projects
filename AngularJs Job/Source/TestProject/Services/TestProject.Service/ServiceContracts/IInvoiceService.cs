using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Core.Entities;

namespace TestProject.Service.ServiceContracts
{
    public interface IInvoiceService
    {
        Invoice GetInvoiceBy(int id);

        Invoice GetFirstInvoice();

        List<InvoiceDetail> GetInvoiceDetails(int invoiceId);

        //void DeleteInvoiceDetails(IList<int> invoiceDetailIds);

        void UpdateInvoiceDetails(IList<InvoiceDetail> invoiceDetails, IList<int> deleteIds);
    }
}
