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
    }
}
