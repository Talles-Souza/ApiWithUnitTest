using AutoMapper;
using Domain.Entities;
using Services.DTOs;

namespace Services.Mapping
{
    public class ToMappingDomain : Profile
    {
        public ToMappingDomain()
        {
            CreateMap<Person, PersonDTO>();
        }

       
    }
}
