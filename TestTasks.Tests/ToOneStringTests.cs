using FluentAssertions;
using Xunit;

namespace TestTasks.Tests
{
    public class ToOneStringTests
    {
        [Fact(DisplayName = "ToOneString должен вернуть строку, склеееную из коллекции с разделителем")]
        public void When_CollectionOfStringsGiven__Expect_OneStringWithDelimeters()
        {
            var ti = new TestImplementation();
            var result = ti.ToOneString(new[] { "1", "2", "3" }, " ");

            result.Should().Be("1 2 3");
        }
    }
}