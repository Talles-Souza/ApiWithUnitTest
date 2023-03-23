using AutoMapper;
using Domain.Repositories;
using Services.DTOs;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Person : IPersonService
    {
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;

        public Person(IPersonRepository personRepository, IMapper mapper)
        {
            this.personRepository = personRepository;
            this.mapper = mapper;
        }

        public Task<ICollection<PersonDTO>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<PersonDTO> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PersonDTO> Create(PersonDTO personDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
