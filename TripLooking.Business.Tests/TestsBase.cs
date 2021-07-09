using System;
using Moq;

namespace TripLooking.Business.Tests
{
    public abstract class TestsBase<TSut> : IDisposable
    {
        protected TSut SUT { get; set; }

        protected MockRepository MockRepository { get; private set; }

        protected TestsBase()
        {
            MockRepository = new MockRepository(MockBehavior.Strict);
            CreateMocks();
            SUT = CreateSUT();
        }

        protected abstract void CreateMocks();

        protected abstract TSut CreateSUT();

        public void Dispose()
        {
            MockRepository.VerifyAll();
        }
    }
}
