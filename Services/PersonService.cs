using AutoMapper;
using Domain.Repositories;
using Services.DTOs;
using Services.Interfaces;

namespace Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            this.personRepository = personRepository;
            this.mapper = mapper;
        }

        public async Task<ICollection<PersonDTO>> FindAll()
        {
            var people =  await personRepository.FindAll();
            var peopleDTO = mapper.Map<ICollection<PersonDTO>>(people);
            return peopleDTO;
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
