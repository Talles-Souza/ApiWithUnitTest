using Domain.Entities;
using Domain.Repositories;
using Moq;

namespace Application.Test
{
    public class IPersonConstr
    {
        Mock<Person> _person;

        protected IPersonConstr(Mock<Person> mUser)
        {
            _person = mUser;
        }

        public static IPersonConstr One()
        {
            return new IPersonConstr(new Mock<Person>());
        }
        public Person Build() { return _person.Object; }   
        public IPersonConstr WithId(int id)
        {
            _person.Object.Id = id; 
            return this;
        }
        public IPersonConstr WithName(string name)
        {
            _person.Object.Name = name;
            return this;
        }
        public IPersonConstr WithEmail(string email)
        {
            _person.Object.Email = email;
            return this;
        }
    }
}
