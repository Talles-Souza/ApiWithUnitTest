using AutoFixture;
using Domain.Entities;
using Services;
using Services.DTOs;
using Services.Exceptions;
using UnitTest;

namespace Application.Test
{

    public class IPersonConstr2 : BaseConstr<ResultService<PersonDTO>>
    {
        public IPersonConstr2() : base() { }

        public static IPersonConstr2 One()
        {
            return new IPersonConstr2();
        }
        public ResultService<PersonDTO> Standard()
        {
            _mock.Object.Data = new PersonDTO
                (_fixture.Create<int>(), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>());
            return _mock.Object;
        }

    }
}