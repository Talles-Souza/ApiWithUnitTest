using Domain.Repositories;
using Moq;

namespace Application.Test
{
    [TestFixture]
    public class PersonTest : BaseTest
    {
        Mock<IPersonRepository> _person;

        [SetUp]
        public void Setup()
        {
            _person = new Mock<IPersonRepository>();
        }
        //FindByIdSuccess 
        // var exemplo = _fixture.Create<string>();
        [Test]
        public void IdSuccess()
        {
            //montar
            //Person personMock = IPersonConstr.One().WithId(_fixture.Create<int>()).WithName(_fixture.Create<string>()).WithEmail(_fixture.Create<string>()).Build();
            var personMock = IPersonConstr.One().Standard();

            // criar Moq da função findbyid
            var person = _person.Setup(o => o.FindById(It.IsAny<int>())).ReturnsAsync(personMock);

            //executa
            //criar o findbyid do user
            var result = _person.Object.FindById(50);

            //verifica
            Assert.AreEqual(personMock.Id, result.Result.Id);
            Assert.AreEqual(personMock.Name, result.Result.Name);

        }
        [Test]
        public void IdSpecificSuccess()
        {
            var personMock = IPersonConstr.One().Standard();
            var person = _person.Setup(o => o.FindById(personMock.Id)).ReturnsAsync(personMock);
            var result = _person.Object.FindById(personMock.Id);
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
            var personMock = IPersonConstr.One().Standard();

            // criar Moq da função findbyid
            var person = _person.Setup(o => o.FindById(personMock.Id)).ReturnsAsync(personMock);

            //executa
            //criar o findbyid do user
            var result = _person.Object.FindById(50);


            //verifica
            Assert.AreEqual(null, result.Result);

        }

        [TearDown]
        public void TearDown()
        {
            _person = null;

        }
    }
}