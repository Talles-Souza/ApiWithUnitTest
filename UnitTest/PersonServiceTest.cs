using Application.Test;
using AutoMapper;
using Domain.Repositories;
using Moq;
using Services.DTOs;
using Services.Exceptions;
using Services.Interfaces;

namespace UnitTest
{
    [TestFixture]
    public class PersonServiceTest : BaseTest
    {
        Mock<IPersonRepository> _person;
        Mock<IPersonService> _personService;
        Mock<IMapper> _mapper;

        [SetUp]
        public void Setup()
        {
            _person = new Mock<IPersonRepository>();
            _mapper = new Mock<IMapper>();
            _personService = new Mock<IPersonService>();
        }

        [Test]
        public void IdSuccessService()
        {
     
            var personMock = IPersonConstr2.One().Standard();         
            var person = _personService.Setup(o => o.FindById(personMock.Data.Id)).ReturnsAsync(ResultService.Ok<PersonDTO>(200, personMock.Data));
            Task<ResultService<PersonDTO>> result = _personService.Object.FindById(personMock.Data.Id);
            Assert.Multiple(() =>
            {
                Assert.That(result.Result.Data.Id, Is.EqualTo(personMock.Data.Id));
                Assert.That(result.Result.Data.Name, Is.EqualTo(personMock.Data.Name));
                Assert.That(result.Result.Code, Is.EqualTo(200));
            });
        }

        [TearDown]
        public void TearDown()
        {
            _person = null;
            _mapper = null;
            _personService = null;

        }
    }
}
