using MuleWebAPIPhatPT19.Data.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuleWebAPIPhatPT19.Business.Services.Interfaces
{
    public interface IPurchaseOrderService
    {
        Task<ResponseDTO> CreatePurchaseOrder(PurchaseOrderDTO purchaseOrderDTO);
        Task<ResponseDTO> UpdatePurchaseOrderById(PurchaseOrderDTO purchaseOrderDTO);
        Task<ResponseDTO> ReduceProductQuantity(string productId, double buyQuantity);
        Task<ResponseDTO> GetAllPurchaseOrder();
    }
}
