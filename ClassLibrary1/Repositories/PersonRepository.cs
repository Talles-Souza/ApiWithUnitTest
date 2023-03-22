using Data.Context;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Task<Person> Create(Person user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
