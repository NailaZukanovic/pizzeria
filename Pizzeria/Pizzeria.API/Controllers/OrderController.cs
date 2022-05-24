using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.API.Dto;
using Pizzeria.API.Services.OrderService;

namespace Pizzeria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Authorize(Roles = "Baker, Delivery")]
        public async Task<IActionResult> Get()
        {
            var response = await _orderService.GetOrders();
            return Ok(response);
        }

        [HttpGet("id")]
        [Authorize(Roles = "Baker, Delivery")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _orderService.GetOrderById(id);
            if(!string.IsNullOrEmpty(response.Message))
                return BadRequest(response.Message);
            return Ok(response.Data);
        }

        [HttpPost]
        [Authorize(Roles = "Customer, Baker, Delivery")]
        public async Task<IActionResult> Create(OrderDto request)
        {
            var response = await _orderService.CreateOrder(request);
            if(!response.Success)
                return BadRequest();
            return Ok(response.Success);
        }

        [HttpPut]
        [Authorize(Roles = "Baker, Delivery")]
        public async Task<IActionResult> Update(OrderDto request)
        {
            var response = await _orderService.UpdateOrder(request);
            if (!response.Success)
                return BadRequest();
            return Ok(response.Success);
        }
    }
}
