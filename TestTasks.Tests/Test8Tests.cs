using System.Globalization;
using System.Threading;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace TestTasks.Tests
{
    public class Test8Tests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public Test8Tests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void GetCurrentUser()
        {
            var ti = new TestImplementation();
            for (var i = 0; i < 20; i++)
            {
                var i1 = i;
                var thread = new Thread(() =>
                {
                    ti.PrepareEnvironment(i1.ToString(), CultureInfo.CurrentCulture);
                    _testOutputHelper.WriteLine(i1.ToString());
                    ti.GetCurrentUser().Should().Be(i1.ToString());
                });
                thread.Name = $"Test8 thread #{i1}";
                thread.Start();
            }
        }
    }
}