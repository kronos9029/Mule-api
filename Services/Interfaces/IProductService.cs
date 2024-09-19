using MuleWebAPIPhatPT19.Data.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuleWebAPIPhatPT19.Business.Services.Interfaces
{
    public interface IProductService
    {
        Task<ResponseDTO> GetAllProducts();
        Task<ResponseDTO> AddProductAsync(ProductDTO productDTO);
        Task<bool> UpdateProductById(ProductDTO productDTO);
        Task<ProductDTO> FindProductById(string productId, double unitPrice);
        Task<bool> UpdateProductUnitPrice(string productId);
    }
}
