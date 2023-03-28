using Services.DTOs;
using Services.Exceptions;

namespace Services.Interfaces
{
    public interface IPersonService
    {
        Task<ResultService<ICollection<PersonDTO>>> FindAll();
        Task<ResultService<PersonDTO>> FindById(int id);
        Task<ResultService<PersonDTO>> Create(PersonDTO personDTO);
        Task<ResultService<bool>> Delete(int id);

    }
}
