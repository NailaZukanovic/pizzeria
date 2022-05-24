using Pizzeria.API.Dto;

namespace Pizzeria.API.Services.OrderService
{
    public interface IOrderService
    {
        Task<ResponseDto<List<OrderDto>>> GetOrders();
        Task<ResponseDto<OrderDto>> GetOrderById(int id);
        Task<ResponseDto<bool>> CreateOrder(OrderDto request);
        Task<ResponseDto<bool>> UpdateOrder(OrderDto request);
    }
}
