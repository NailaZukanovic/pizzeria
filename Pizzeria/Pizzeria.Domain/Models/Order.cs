using Pizzeria.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizzeria.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderCreatedOn { get; set; }
        public DateTime OrderCompletedOn { get; set; }
        public List<Pizza> Pizzas { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
