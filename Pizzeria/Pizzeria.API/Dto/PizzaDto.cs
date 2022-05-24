namespace Pizzeria.API.Dto
{
    public class PizzaDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Size { get; set; }
        public decimal PricePerUnit { get; set; }
        public string Additives { get; set; }
        public int OrderId { get; set; }
        public List<OrderDto> Order { get; set; }
    }
}
