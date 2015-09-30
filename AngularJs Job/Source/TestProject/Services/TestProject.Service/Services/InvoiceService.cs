using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Core.Entities;
using TestProject.Core.Infrastructure;
using TestProject.Logging;
using TestProject.Service.ServiceContracts;

namespace TestProject.Service
{
    public class InvoiceService : HandleErrorService, IInvoiceService
    {
        private IUnitOfWork unitOfWork;
        private ILogger logger;
        private IRepository<Invoice> invoiceRepository;
        private IRepository<InvoiceDetail> invoiceDetailRepository;

        public InvoiceService(IUnitOfWork unitOfWork, ILogger logger)
            : base(logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
            this.invoiceRepository = this.unitOfWork.GetRepository<Invoice>();
            this.invoiceDetailRepository = this.unitOfWork.GetRepository<InvoiceDetail>();
        }

        public Invoice GetInvoiceBy(int id)
        {
            var invoice = invoiceRepository.Query().Where(x => x.Id == id).FirstOrDefault();
            return invoice;
        }

        public Invoice GetFirstInvoice()
        {
            return invoiceRepository.Query().FirstOrDefault();
        }

        public List<InvoiceDetail> GetInvoiceDetails(int invoiceId)
        {
            var details = invoiceDetailRepository.Query().Where(x => x.InvoiceId == invoiceId).ToList();
            return details;
        }

        private void DeleteInvoiceDetails(IList<int> invoiceDetailIds)
        {
            var invoiceDetails = invoiceDetailRepository.Query().Where(x => invoiceDetailIds.Contains(x.Id)).ToList();
            invoiceDetailRepository.RemoveRange(invoiceDetails);            
        }

        public void UpdateInvoiceDetails(IList<InvoiceDetail> invoiceDetails, IList<int> deleteIds)
        {
            Process(() =>
            {
                if (invoiceDetails != null && invoiceDetails.Count > 0)
                {
                    var ids = invoiceDetails.Select(x => x.Id);
                    var invoicesInDb = invoiceDetailRepository.Query().Where(x => ids.Contains(x.Id)).ToList();
                    var idsInDb = invoicesInDb.Select(x => x.Id);
                    foreach (var invoice in invoicesInDb)
                    {
                        var item = invoiceDetails.Where(x => x.Id == invoice.Id).First();
                        invoice.Description = item.Description;
                        invoice.Quantity = item.Quantity;
                        invoice.Price = item.Price;
                    }

                    var invoicesNotInDb = invoiceDetails.Where(x => !idsInDb.Contains(x.Id));
                    foreach (var invoice in invoicesNotInDb)
                    {
                        invoiceDetailRepository.Insert(invoice);
                    }
                }

                if (deleteIds != null && deleteIds.Count > 0)
                {
                    DeleteInvoiceDetails(deleteIds);
                }

                this.unitOfWork.Commit();
            });            
        }
    }
}
