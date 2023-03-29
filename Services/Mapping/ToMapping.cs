using AutoMapper;
using Domain.Entities;
using Services.DTOs;

namespace Services.Mapping
{
    public class ToMappingDTO : Profile
    {
        public ToMappingDTO()
        {
            CreateMap<PersonDTO, Person>();
        }
    }
}
