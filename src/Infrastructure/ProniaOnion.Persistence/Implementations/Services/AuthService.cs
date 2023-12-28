using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Tokens;
using ProniaOnion.Application.DTOs.Users;
using ProniaOnion.Domain.Entities;
using System.Text;

namespace ProniaOnion.Persistence.Implementations.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenHandler _handler;

        public AuthService(IMapper mapper,ITokenHandler handler,UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _handler = handler;
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

            return _handler.CreateJwt(user,2);

            
            
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
