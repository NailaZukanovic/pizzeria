using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Pizzeria.API.Data;
using Pizzeria.API.Dto;
using Pizzeria.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Pizzeria.API.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthService(DataContext dataContext, IMapper mapper, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<ResponseDto<string>> Login(UserLoginDto request)
        {
            ResponseDto<string> response = new ResponseDto<string>();

            var user = _dataContext.Users.FirstOrDefault(x => x.Username.ToLower() == request.Username.ToLower());
            
            if (user == null)
            {
                response.Message = "User not found.";
                return response;
            }

            if (!VerifyPassword(request.Password))
            {
                response.Message = "Wrong password.";
                return response;
            }

            string token = CreateToken(user);
            if(!string.IsNullOrEmpty(token))
            {
                response.Success = true;
                response.Data = token;
                return response;
            }

            response.Message = "Something went wrong, please login again.";
            return response;
        }

        public async Task<ResponseDto<bool>> Register(UserRegisterDto request)
        {
            ResponseDto<bool> response = new ResponseDto<bool>();
            User userModel = _mapper.Map<User>(request);
            User userExists = _dataContext.Users.FirstOrDefault(x => x.Username.ToLower() == request.Username.ToLower());
            if (userExists == null)
            {
                _dataContext.Users.Add(userModel);
                await _dataContext.SaveChangesAsync();
                response.Success = true;
                return response;
            }
            return response;
        }

        private string CreateToken(User user)
        {
            var role = _dataContext.Roles.Single(x => x.Id == user.RoleId);
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, role.Name)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private bool VerifyPassword(string password)
        {
            return _dataContext.Users.Select(x => x.Password == password).First();
        }
    }
}
