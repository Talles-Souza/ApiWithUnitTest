using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Services.DTOs;
using Services.Exceptions;
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

        public async Task<ResultService<ICollection<PersonDTO>>> FindAll()
        {
            var people = await personRepository.FindAll();
            return ResultService.Ok<ICollection<PersonDTO>>(200, mapper.Map<ICollection<PersonDTO>>(people));
        }

        public async Task<ResultService<PersonDTO>> FindById(int id)
        {  
            if(id <= 0) return ResultService.Fail<PersonDTO>(406, "Invalid informed value");
            var person = await personRepository.FindById(id);
            if (person == null) return ResultService.Fail<PersonDTO>(404,"User not Found");
            return ResultService.Ok<PersonDTO>(200,mapper.Map<PersonDTO>(person));
        }

        public async Task<ResultService<PersonDTO>> Create(PersonDTO personDTO)
        {
            if(personDTO == null) return ResultService.Fail<PersonDTO>(400, "User must be informed");
            var person = mapper.Map<Person>(personDTO);
            var data = await personRepository.Create(person);
            return ResultService.Ok<PersonDTO>(200, mapper.Map<PersonDTO>(data));
        }

        public async Task<ResultService> Delete(int id)
        {
           if (id <= 0) return ResultService.Fail<PersonDTO>(406, "Invalid informed value");
           var person = await personRepository.FindById(id);
           if (person == null) return ResultService.Fail<PersonDTO>(404, "User not Found");
           await personRepository.Delete(id);
           return ResultService.Ok(200, "Person with the id  " + id + " was successfully deleted");
        }
    }
}
