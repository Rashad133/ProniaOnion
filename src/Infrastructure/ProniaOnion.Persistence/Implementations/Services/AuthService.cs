using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.DTOs.Users;
using ProniaOnion.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProniaOnion.Persistence.Implementations.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _config;

        public AuthService(IMapper mapper,IConfiguration config,UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _config = config;
        }

        public async Task<TokenResponseDto> Login(LoginDto dto)
        {
            AppUser user = await _userManager.FindByNameAsync(dto.UserNameorEmail);
            if (user is null)
            {
                user = await _userManager.FindByEmailAsync(dto.UserNameorEmail);
                if (user is null) throw new Exception("Username,Email or Password incorrect");
            }
            if (!await _userManager.CheckPasswordAsync(user, dto.Password)) throw new Exception("Username,Email or Password incorrect");

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.NameIdentifier,user.Id)
            };

            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
                (_config["Jwt:SecurityKey"]));

            SigningCredentials signingCredentials = new(symmetricSecurityKey, SecurityAlgorithms.HmacSha512Signature);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
               issuer: _config["Jwt:issuer"],
               audience: _config["Jwt:audience"],
               claims: claims,
               notBefore: DateTime.UtcNow,
               expires: DateTime.UtcNow.AddHours(2)
                ) ;

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler() ;
            string token = tokenHandler.WriteToken(jwtSecurityToken) ;

            return new(token, jwtSecurityToken.ValidTo, user.UserName);
        }

        public async Task Register(RegisterDto dto)
        {

            AppUser user = await _userManager.Users.FirstOrDefaultAsync(u => u.Name == dto.Name || u.Email == dto.Email);
            if (user is not null) throw new Exception("Same Name or Email exist");
            user = _mapper.Map<AppUser>(dto);

           var result= await _userManager.CreateAsync(user,dto.Password);
            if (!result.Succeeded)
            {
                StringBuilder message= new StringBuilder();

                foreach (var error in result.Errors)
                {
                    message.AppendLine(error.Description);
                }
                throw new Exception(message.ToString());
            }
        }

        
    }
}
