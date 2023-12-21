using AutoMapper;
using ProniaOnion.Application.DTOs.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.MappingProfiles
{
    public class TagProfile:Profile
    {
        public TagProfile()
        {
            CreateMap<TagProfile, TagItemDto>().ReverseMap();
            CreateMap<TagCreateDto,TagProfile>();
            CreateMap<TagUpdateDto, TagProfile>().ReverseMap();
        }
    }
}
