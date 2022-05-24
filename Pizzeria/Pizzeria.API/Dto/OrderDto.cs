using Pizzeria.Domain.Enums;

namespace Pizzeria.API.Dto
{
    public class OrderDto
    {
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderCreatedOn { get; set; }
        public DateTime OrderCompletedOn { get; set; }
        public List<PizzaDto> Pizzas { get; set; }
        public int? VehicleId { get; set; }
    }
}
