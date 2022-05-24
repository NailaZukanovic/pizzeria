using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pizzeria.API.Data;
using Pizzeria.API.Dto;

namespace Pizzeria.API.Services.PizzaService
{
    public class PizzaService : IPizzaService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public PizzaService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<PizzaDto>>> GetPizzas()
        {
            ResponseDto<List<PizzaDto>> response = new();
            var pizzas = await _dataContext.Pizzas.ToListAsync();

            response.Success = true;
            response.Data = _mapper.Map<List<PizzaDto>>(pizzas);

            return response;
        }
    }
}
