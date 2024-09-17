using AutoMapper;
using MuleWebAPIPhatPT19.Data.Models.DTOs;
using MuleWebAPIPhatPT19.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuleWebAPIPhatPT19.Business.MapperConfig
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {

            CreateMap<ProductDTO, Product>().ReverseMap();
            CreateMap<PurchaseOrderDTO, Purchaseorder>().ReverseMap();
            CreateMap<PurchaseOrderDetailDTO, Purchaseorderdetail>().ReverseMap();
            CreateMap<SalesOrderDTO, Salesorder>().ReverseMap();
            CreateMap<SalesOrderDetailDTO, Salesorderdetail>().ReverseMap();
        }
    }
}
