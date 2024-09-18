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

            CreateMap<ProductDTO, product>().ReverseMap();
            CreateMap<PurchaseOrderDTO, purchaseorder>().ReverseMap();
            CreateMap<PurchaseOrderDetailDTO, purchaseorderdetail>().ReverseMap();
            CreateMap<SalesOrderDTO, salesorder>().ReverseMap();
            CreateMap<SalesOrderDetailDTO, salesorderdetail>().ReverseMap();
        }
    }
}
