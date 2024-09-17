using Microsoft.AspNetCore.Mvc;
using MuleWebAPIPhatPT19.Business.Services.Interfaces;
using MuleWebAPIPhatPT19.Data.Models.DTOs;

namespace MuleWebAPIPhatpt19.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly IPurchaseOrderService _purchaseOrderService;

        public PurchaseOrderController(IPurchaseOrderService purchaseOrderService)
        {
            _purchaseOrderService = purchaseOrderService;
        }
        [HttpPost]
        public async Task<IActionResult> CreatePurchaseOrder([FromBody] PurchaseOrderDTO purchaseOrderDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _purchaseOrderService.CreatePurchaseOrder(purchaseOrderDTO);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPurchaseOrders()
        {
            var response = await _purchaseOrderService.GetAllPurchaseOrder();

            if (!response.Success || response.Data == null)
            {
                return NoContent();
            }

            return Ok(response.Data);
        }
    }
}
