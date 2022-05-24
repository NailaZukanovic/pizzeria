using System.ComponentModel.DataAnnotations.Schema;

namespace Pizzeria.Domain.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Size { get; set; }
        [Column(TypeName = "decimal(3,2)")]
        public decimal PricePerUnit { get; set; }
        public string Additives { get; set; }
        public int OrderId { get; set; }
        public List<Order> Order { get; set; }
    }
}
