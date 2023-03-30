using AutoFixture;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Moq;
using Services;

namespace Application.Test
{
    [TestFixture]
    public class PersonTest : BaseTest
    {
        Mock<IPersonRepository> _person;
        Mock<IMapper> _mapper;
        Fixture _fixture;
        PersonService _personService;
        
        [SetUp]
        public void Setup()
        {
            _person = new Mock<IPersonRepository>();
            _mapper = new Mock<IMapper>();
            _fixture = new Fixture();
            _personService = new PersonService(_person.Object,_mapper.Object);
        }
        //FindByIdSuccess 
        // var exemplo = _fixture.Create<string>();
        [Test]
        public void IdSuccess()
        {
            //montar
            //Person personMock = IPersonConstr.One().WithId(_fixture.Create<int>()).WithName(_fixture.Create<string>()).WithEmail(_fixture.Create<string>()).Build();
            Person personMock = IPersonConstr.One().Standard();
            
            // criar Moq da função findbyid
            var person = _person.Setup(o => o.FindById(It.IsAny<int>())).ReturnsAsync(personMock);

            //executa
            //criar o findbyid do user
              Task<Person> result = _person.Object.FindById(50); 
            
            //verifica
              Assert.AreEqual(personMock.Id, result.Result.Id);
              Assert.AreEqual(personMock.Name, result.Result.Name);

        }
        [Test]
        public void IdSpecificSuccess()
        {
            Person personMock = IPersonConstr.One().Standard();
            var person = _person.Setup(o => o.FindById(personMock.Id)).ReturnsAsync(personMock);
            Task<Person> result = _person.Object.FindById(personMock.Id);
            Assert.Multiple(() =>
            {
                Assert.That(result.Result.Id, Is.EqualTo(personMock.Id));
                Assert.That(result.Result.Name, Is.EqualTo(personMock.Name));
            });
        }

        //FindByIdFail
        [Test]
        public void FindByIdFail()
        {
            Person personMock = IPersonConstr.One().WithId(_fixture.Create<int>()).WithName(_fixture.Create<string>()).WithEmail(_fixture.Create<string>()).Build();

            // criar Moq da função findbyid
            var person = _person.Setup(o => o.FindById(personMock.Id)).ReturnsAsync(personMock);

            //executa
            //criar o findbyid do user
            Task<Person> result = _person.Object.FindById(50);


            //verifica
            Assert.AreEqual(null, result.Result);
            
        }

        [TearDown]
        public void TearDown()
        {
            _person = null;
            _mapper = null;
        }
    }
}