using AutoMapper;
using ProniaOnion.Application.DTOs.Users;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Application.MappingProfiles
{
    internal class AppUserProfile:Profile
    {
        public AppUserProfile()
        {
            CreateMap<RegisterDto,AppUser>();
        }
    }
}
