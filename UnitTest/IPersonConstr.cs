using AutoFixture;
using Domain.Entities;
using Domain.Repositories;
using Moq;
using System.Xml.Linq;

namespace Application.Test
{
    public class IPersonConstr
    {
        Mock<Person> _person;
        Fixture _fixture;
        protected IPersonConstr(Mock<Person> mUser, Fixture fixture)
        {
            _person = mUser;
            _fixture = fixture;
        }

        public static IPersonConstr One()
        {
            return new IPersonConstr(new Mock<Person>(), new Fixture());
        }
        public Person Build() { return _person.Object; }

        public Person Standard()
        {
            _person.Object.Id = _fixture.Create<int>();
            _person.Object.Name = _fixture.Create<string>();
            _person.Object.Email = _fixture.Create<string>();
            return _person.Object;
        }
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
