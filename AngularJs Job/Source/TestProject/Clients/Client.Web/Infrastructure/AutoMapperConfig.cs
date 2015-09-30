using AutoMapper;
using Client.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestProject.Core.Entities;

namespace Client.Web.Infrastructure
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<InvoiceDetail, InvoiceDetailViewModel>();
            Mapper.CreateMap<Invoice, InvoiceViewModel>();

            Mapper.CreateMap<InvoiceDetailViewModel, InvoiceDetail>();
        }
    }
}