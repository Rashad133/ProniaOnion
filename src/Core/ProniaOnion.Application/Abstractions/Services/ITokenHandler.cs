using ProniaOnion.Application.DTOs.Tokens;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Application.Abstractions.Services
{
    public interface ITokenHandler
    {
        TokenResponseDto CreateJwt(AppUser user, int hours);
    }
}
