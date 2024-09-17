using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MuleWebAPIPhatPT19.Business.Services.Interfaces;
using MuleWebAPIPhatPT19.Data.Helpers;
using MuleWebAPIPhatPT19.Data.Models.DTOs;
using MuleWebAPIPhatPT19.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuleWebAPIPhatPT19.Business.Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPurchaseOrderDetailService _purchaseOrderDetailService;
        private readonly IProductService _productService;
        public PurchaseOrderService(ApplicationDbContext context, 
                                    IMapper mapper, 
                                    IPurchaseOrderDetailService purchaseOrderDetailService, 
                                    IProductService productService)
        {
            _context = context;
            _mapper = mapper;
            _purchaseOrderDetailService = purchaseOrderDetailService;
            _productService = productService;
        }
        public async Task<ResponseDTO> CreatePurchaseOrder(PurchaseOrderDTO purchaseOrderDTO)
        {
            var responseDTO = new ResponseDTO();

            try
            {
                // Map the PurchaseOrderDTO to the PurchaseOrder entity
                var orderEntity = _mapper.Map<Purchaseorder>(purchaseOrderDTO);

                // Add the PurchaseOrder to the context
                await _context.PurchaseOrders.AddAsync(orderEntity);

                // Save the changes to the database
                var result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    // Success case
                    responseDTO.Success = true;
                    responseDTO.Message = "Purchase order created successfully.";
                    responseDTO.Data = orderEntity;

                    // Create order details if available
                    if (purchaseOrderDTO.Detail != null)
                    {
                        var detailResult = await _purchaseOrderDetailService.CreateOrderDetail(purchaseOrderDTO.Detail);

                        if (!detailResult.Success)
                        {
                            // If detail creation fails, update the response with detail error
                            responseDTO.Success = false;
                            responseDTO.Message = $"Purchase order created, but failed to create order details: {detailResult.Message}";
                        } else
                        {
                            var isQuantityReduced = await ReduceProductQuantity(purchaseOrderDTO.Detail.ProductCode, purchaseOrderDTO.Detail.Quantity);
                            if (isQuantityReduced.Success)
                            {
                                Console.WriteLine("Product quantity reduced successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Failed to reduce product quantity.");
                            }
                            bool isUpdated = await _productService.UpdateProductUnitPrice(purchaseOrderDTO.Detail.ProductCode);
                            if (isUpdated)
                            {
                                Console.WriteLine("Product UnitPrice updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Failed to update Product UnitPrice.");
                            }
                        }
                    }
                }
                else
                {
                    // If saving the order fails
                    responseDTO.Success = false;
                    responseDTO.Message = "Failed to create purchase order.";
                }
            }
            catch (Exception ex)
            {
                // Handle unexpected exceptions and log the error
                responseDTO.Success = false;
                responseDTO.Message = $"An error occurred while creating the purchase order: {ex.Message}";
                // Optionally log the exception here for debugging purposes
            }

            return responseDTO;
        }

        public async Task<ResponseDTO> UpdatePurchaseOrderById(PurchaseOrderDTO purchaseOrderDTO)
        {
            var responseDTO = new ResponseDTO();

            var existingOrder = await _context.PurchaseOrders.FindAsync(purchaseOrderDTO.OrderNo);
            if (existingOrder == null)
            {
                responseDTO.Success = false;
                responseDTO.Message = "Purchase order not found.";
                return responseDTO;
            }

            _mapper.Map(purchaseOrderDTO, existingOrder);
            _context.PurchaseOrders.Update(existingOrder);

            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                responseDTO.Success = true;
                responseDTO.Message = "Purchase order updated successfully.";
                responseDTO.Data = existingOrder;
            }
            else
            {
                responseDTO.Success = false;
                responseDTO.Message = "Failed to update purchase order.";
            }

            return responseDTO;
        }

        public async Task<ResponseDTO> ReduceProductQuantity(string productId, double buyQuantity)
        {
            var responseDTO = new ResponseDTO();

            var product = await _context.Products.FindAsync(productId);

            if (product == null)
            {
                responseDTO.Success = false;
                responseDTO.Message = $"Product with ID {productId} not found.";
                return responseDTO;
            }

            // Check if there is enough stock
            if (product.QuantityInStock < buyQuantity)
            {
                responseDTO.Success = false;
                responseDTO.Message = $"Insufficient stock for product {product.ProductName}. Available: {product.QuantityInStock}, Requested: {buyQuantity}.";
                return responseDTO;
            }

            // Reduce the product quantity
            product.QuantityInStock -= buyQuantity;

            // Update the product in the context
            _context.Products.Update(product);


            // Save changes to the database
            var result = await _context.SaveChangesAsync();

            // Check if the update was successful
            if (result > 0)
            {
                responseDTO.Success = true;
                responseDTO.Message = "Product quantities updated successfully.";
            }
            else
            {
                responseDTO.Success = false;
                responseDTO.Message = "Failed to update product quantities.";
            }

            return responseDTO;
        }

        public async Task<ResponseDTO> GetAllPurchaseOrder()
        {
            ResponseDTO response = new ResponseDTO();

            try
            {
                // Fetch all purchase orders from the database
                var purchaseOrders = await _context.PurchaseOrders.ToListAsync();

                if (purchaseOrders != null && purchaseOrders.Any())
                {
                    // Success case
                    response.Success = true;
                    response.Message = "Purchase orders retrieved successfully.";
                    response.Data = purchaseOrders;
                }
                else
                {
                    // No purchase orders found
                    response.Success = false;
                    response.Message = "No purchase orders found.";
                    response.Data = null;
                }
            }
            catch (Exception ex)
            {
                // In case of an error
                response.Success = false;
                response.Message = $"An error occurred while retrieving purchase orders: {ex.Message}";
                response.Data = null;
            }

            return response;
        }
    }
}
