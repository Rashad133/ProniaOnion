using ProniaOnion.Application.DTOs.Users;

namespace ProniaOnion.Application.Abstractions.Repositories
{
    public interface IAuthService
    {
        Task Register(RegisterDto dto);
        Task<TokenResponseDto> Login(LoginDto dto);
    }
}
