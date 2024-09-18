using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MuleWebAPIPhatPT19.Business.Services.Interfaces;
using MuleWebAPIPhatPT19.Data.Helpers;
using MuleWebAPIPhatPT19.Data.Models.DTOs;
using MuleWebAPIPhatPT19.Data.Models.Entities;

namespace MuleWebAPIPhatPT19.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseDTO> GetAllProducts()
        {
            ResponseDTO responseDTO = new();
            try
            {
                var products = await _context.Products.ToListAsync();

                var productDTOs = _mapper.Map<List<ProductDTO>>(products);

                if (productDTOs.Any())
                {
                    responseDTO.Success = true;
                    responseDTO.Message = "Products retrieved successfully.";
                    responseDTO.Data = productDTOs;
                }
                else
                {
                    responseDTO.Success = false;
                    responseDTO.Message = "No products found.";
                    responseDTO.Data = null;
                }
            }
            catch (Exception ex)
            {
                responseDTO.Success = false;
                responseDTO.Message = $"Error retrieving products: {ex.Message}";
                responseDTO.Data = null;
            }

            return responseDTO;
        }

        public async Task AddProductAsync(ProductDTO productDTO)
        {
            var productEntity = _mapper.Map<product>(productDTO);
            _context.Products.Add(productEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateProductById(ProductDTO productDTO)
        {
            var existingProduct = await _context.Products.FindAsync(productDTO.ProductCode);
            if (existingProduct == null)
            {
                return false;
            }

            _mapper.Map(productDTO, existingProduct);

            _context.Products.Update(existingProduct);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<ProductDTO> FindProductById(string productId, double unitPrice)
        {
            var productEntity = await _context.Products.FindAsync(productId, unitPrice);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<bool> UpdateProductUnitPrice(string productId)
        {
            try
            {
                var product = await _context.Products.FindAsync(productId);

                if (product == null)
                {
                    return false;
                }

                product.UnitPrice = (double)((product.QuantityInStock * product.UnitPrice + 5 * 201) / 2);

                _context.Products.Update(product);

                var result = await _context.SaveChangesAsync();

                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
