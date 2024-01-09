using ProniaOnion.Application.DTOs.Tokens;
using ProniaOnion.Application.DTOs.Users;

namespace ProniaOnion.Application.Abstractions.Repositories
{
    public interface IAuthService
    {
        Task Register(RegisterDto dto);
        Task<TokenResponseDto> Login(LoginDto dto);
        Task<TokenResponseDto> LoginByRefreshToken(string refresh);
    }
}
