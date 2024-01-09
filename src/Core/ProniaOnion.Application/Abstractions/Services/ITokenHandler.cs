using ProniaOnion.Application.DTOs.Tokens;
using ProniaOnion.Domain.Entities;
using System.Security.Claims;

namespace ProniaOnion.Application.Abstractions.Services
{
    public interface ITokenHandler
    {
        TokenResponseDto CreateJwt(AppUser user, IEnumerable<Claim> claims,int hours);
    }
}
