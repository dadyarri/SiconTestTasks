using System;

namespace TestTasks.Tests
{
    public class TestImplementationFixture : IDisposable
    {
        public TestImplementation TestImplementation { get; private set; } = new TestImplementation();

        public void Dispose()
        {
        }
    }
}