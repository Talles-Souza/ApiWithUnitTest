using Services.DTOs;

namespace Services.Interfaces
{
    public interface IPersonService
    {
        Task<ICollection<PersonDTO>> FindAll();
        Task<PersonDTO> FindById(int id);
        Task<PersonDTO> Create(PersonDTO personDTO);
        Task<bool> Delete(int id);

    }
}
