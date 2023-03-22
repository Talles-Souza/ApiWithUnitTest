using Domain.Entities;

namespace Domain.Repositories
{
    public interface IPersonRepository
    {
        Task<Person> FindById(int id);
        Task<ICollection<Person>> FindAll();
        Task<Person> Create(Person user);
        Task<bool> Delete(int id);
    }
}
