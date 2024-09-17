using MuleWebAPIPhatPT19.Data.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuleWebAPIPhatPT19.Business.Services.Interfaces
{
    public interface IPurchaseOrderDetailService
    {
        Task<ResponseDTO> CreateOrderDetail(PurchaseOrderDetailDTO purchaseOrderDetailDTO);
        Task<ResponseDTO> UpdateOrderDetailById(PurchaseOrderDetailDTO purchaseOrderDetailDTO);
    }
}
