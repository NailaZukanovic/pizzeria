using Pizzeria.API.Dto;

namespace Pizzeria.API.Services.AuthService
{
    public interface IAuthService
    {
        Task<ResponseDto<string>> Login(UserLoginDto user);
        Task<ResponseDto<bool>> Register(UserRegisterDto user);
    }
}
