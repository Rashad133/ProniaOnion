using AutoMapper;
using ProniaOnion.Application.DTOs.Tag;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Application.MappingProfiles
{
    internal class TagProfile:Profile
    {
        public TagProfile()
        {
            CreateMap<TagProfile, TagItemDto>().ReverseMap();
            CreateMap<TagCreateDto,Tag>().ReverseMap();
            CreateMap<TagUpdateDto, Tag>().ReverseMap();
            CreateMap<Tag,TagGetDto>().ReverseMap();
        }
    }
}
