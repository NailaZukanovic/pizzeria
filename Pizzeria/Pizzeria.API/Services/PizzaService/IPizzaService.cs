using Pizzeria.API.Dto;

namespace Pizzeria.API.Services.PizzaService
{
    public interface IPizzaService
    {
        Task<ResponseDto<List<PizzaDto>>> GetPizzas();
    }
}
