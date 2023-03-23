using AutoMapper;
using Domain.Entities;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapping
{
    public class ToMapping : Profile
    {
        public ToMapping()
        {
            CreateMap<Person,PersonDTO>();
            CreateMap<PersonDTO, Person>();
        }
    }
}
