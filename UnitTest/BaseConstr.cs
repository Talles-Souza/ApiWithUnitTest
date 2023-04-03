using Application.Test;
using AutoFixture;
using Moq;

namespace UnitTest
{
    public class BaseConstr<T> where T : class
    {
        protected readonly Fixture _fixture;
        protected readonly Mock<T> _mock;
        protected BaseConstr()
        {
            _fixture = new Fixture();
            _mock = new Mock<T>();
        }
        public T Build()
        {
            return _mock.Object;
        }
        public Mock<T> ToObtain()
        {
            return _mock;
        }

    }
}
