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
            var personMock = IPersonConstr.One().Build();

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
        [Test]
        public void CreateSuccess()
        {
            var personMock = IPersonConstr.One().Standard();
            var person = _person.Setup(o => o.Create(personMock)).ReturnsAsync(personMock);
            var result = _person.Object.Create(personMock);
            Assert.Multiple(() =>
            {
                Assert.That(result.Result, Is.EqualTo(personMock));
                Assert.That(result.Result.Id, Is.EqualTo(personMock.Id));
                Assert.That(result.Result.Name, Is.EqualTo(personMock.Name));

            });
        }
        [Test]
        public void DeleteSuccess()
        {
            var personMock = IPersonConstr.One().Standard();
            var person = _person.Setup(o => o.Delete(personMock.Id)).ReturnsAsync(true);
            var result = _person.Object.Delete(personMock.Id);
            Assert.Multiple(() =>
            {
              
                Assert.That(result.Result, Is.EqualTo(true));
               

            });
        }

        [TearDown]
        public void TearDown()
        {
            _person = null;

        }
    }
}