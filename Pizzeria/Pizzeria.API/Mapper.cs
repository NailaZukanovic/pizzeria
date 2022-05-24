using AutoMapper;
using Pizzeria.API.Dto;
using Pizzeria.Domain.Models;

namespace Pizzeria.API
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<User, UserRegisterDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Pizza, PizzaDto>().ReverseMap();
        }
    }
}
