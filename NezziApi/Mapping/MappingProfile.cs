using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NezziApi.Mapping.Model;
using NezziApi.Mapping.Dtos;
using AutoMapper;

namespace NezziApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           CreateMap<User, UserDto>()
             .ForMember(ed => ed.Fullname, opt => opt.MapFrom((e => e.Name +" "+ e.Surname)));
        }
    }
}
