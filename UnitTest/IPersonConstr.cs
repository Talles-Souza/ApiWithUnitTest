using AutoFixture;
using Domain.Entities;
using UnitTest;

namespace Application.Test
{
   
    public class IPersonConstr : BaseConstr<Person>
    {
        public IPersonConstr() : base() { }

        public static IPersonConstr One()
        {
            return new IPersonConstr();
        }
        public Person Standard()
        {
            _mock.Object.Id = _fixture.Create<int>();
            _mock.Object.Name = _fixture.Create<string>();
            _mock.Object.Email = _fixture.Create<string>();
            return _mock.Object;
        }
    
    }
}
