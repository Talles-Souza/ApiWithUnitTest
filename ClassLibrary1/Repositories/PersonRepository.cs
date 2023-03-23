using Data.Context;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ContextDb db;

        public PersonRepository(ContextDb db)
        {
            this.db = db;
        }

        public async Task<ICollection<Person>> FindAll()
        {
            List<Person> person = await db.People.ToListAsync();
            return person;
        }

        public async Task<Person> FindById(int id)
        {
            Person person = await db.People.SingleOrDefaultAsync(x => x.Id == id);
            return person;
        }

        public async Task<Person> Create(Person person)
        {
            db.People.Add(person);
            db.SaveChanges();
            return person;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {

                Person person = await db.People.SingleOrDefaultAsync(x => x.Id == id);
                if (person == null) return false;
                db.People.Remove(person);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
             return false;
            }
        }

    }
}
