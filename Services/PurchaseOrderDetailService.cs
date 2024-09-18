using AutoMapper;
using MuleWebAPIPhatPT19.Business.Services.Interfaces;
using MuleWebAPIPhatPT19.Data.Helpers;
using MuleWebAPIPhatPT19.Data.Models.DTOs;
using MuleWebAPIPhatPT19.Data.Models.Entities;

namespace MuleWebAPIPhatPT19.Business.Services
{
    public class PurchaseOrderDetailService : IPurchaseOrderDetailService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public PurchaseOrderDetailService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseDTO> CreateOrderDetail(PurchaseOrderDetailDTO purchaseOrderDetailDTO)
        {
            var responseDTO = new ResponseDTO();

            // Map DTO to entity
            var orderDetailEntity = _mapper.Map<purchaseorderdetail>(purchaseOrderDetailDTO);

            // Add the order detail entity to the context
            _context.PurchaseOrderDetails.Add(orderDetailEntity);

            var result = await _context.SaveChangesAsync();  // Save changes to the database

            // Check if insertion was successful
            if (result > 0)
            {
                responseDTO.Success = true;
                responseDTO.Message = "Purchase order detail created successfully.";
                responseDTO.Data = orderDetailEntity;  // Optionally return the created entity or specific data
            }
            else
            {
                responseDTO.Success = false;
                responseDTO.Message = "Failed to create purchase order detail.";
            }

            return responseDTO;
        }

        public async Task<ResponseDTO> UpdateOrderDetailById(PurchaseOrderDetailDTO purchaseOrderDetailDTO)
        {
            var responseDTO = new ResponseDTO();

            var existingOrderDetail = await _context.PurchaseOrderDetails.FindAsync(purchaseOrderDetailDTO.OrderNo);

            if (existingOrderDetail == null)
            {
                responseDTO.Success = false;
                responseDTO.Message = "Order detail not found.";
                return responseDTO;
            }

            _mapper.Map(purchaseOrderDetailDTO, existingOrderDetail);

            _context.PurchaseOrderDetails.Update(existingOrderDetail);

            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                responseDTO.Success = true;
                responseDTO.Message = "Order detail updated successfully.";
                responseDTO.Data = existingOrderDetail;
            }
            else
            {
                responseDTO.Success = false;
                responseDTO.Message = "Failed to update order detail.";
            }

            return responseDTO;
        }

    }
}
