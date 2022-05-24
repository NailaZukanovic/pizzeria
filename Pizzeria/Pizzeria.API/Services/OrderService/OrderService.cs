using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pizzeria.API.Data;
using Pizzeria.API.Dto;
using Pizzeria.Domain.Models;

namespace Pizzeria.API.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public OrderService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<ResponseDto<bool>> CreateOrder(OrderDto request)
        {
            ResponseDto<bool> response = new();
            Order order = _mapper.Map<Order>(request);
            if(!_dataContext.Orders.Any(x => x.Id == order.Id))
            {
                response.Success = true;
                _dataContext.Orders.Add(order);
                await _dataContext.SaveChangesAsync();
                return response;
            }

            return response;
        }

        public async Task<ResponseDto<OrderDto>> GetOrderById(int id)
        {
            ResponseDto<OrderDto> response = new();
            Order order = await _dataContext.Orders.FirstAsync(x => x.Id == id);
            if (order == null)
            {
                response.Message = "Order not found.";
            }
            response.Success = true;
            response.Data = _mapper.Map<OrderDto>(order);
            return response;
        }

        public async Task<ResponseDto<List<OrderDto>>> GetOrders()
        {
            ResponseDto<List<OrderDto>> response = new();
            List<Order> orders = await _dataContext.Orders.ToListAsync();
            response.Success = true;
            response.Data = _mapper.Map<List<OrderDto>>(orders);
            return response;
        }

        public async Task<ResponseDto<bool>> UpdateOrder(OrderDto request)
        {
            ResponseDto<bool> response = new();
            var order = _mapper.Map<Order>(request);
            if (order != null)
            {
                response.Success = true;
                _dataContext.Orders.Update(order);
                await _dataContext.SaveChangesAsync();
                return response;
            }
            return response;
        }
    }
}
