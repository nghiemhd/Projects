using AutoMapper;
using Client.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProject.Logging.Extensions;
using TestProject.Service.ServiceContracts;

namespace Client.Web.Controllers
{
    [Authorize]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            this.invoiceService = invoiceService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetInvoice()
        {
            try
            {
                var invoice = invoiceService.GetFirstInvoice();
                var model = Mapper.Map<InvoiceViewModel>(invoice);

                return Json(new { success = true, invoice = model }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = LogExtension.GetFinalInnerException(ex).Message }, JsonRequestBehavior.AllowGet);
            }            
        }
    }
}