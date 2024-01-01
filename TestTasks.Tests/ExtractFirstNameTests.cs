using FluentAssertions;
using Xunit;

namespace TestTasks.Tests
{
    public class ExtractFirstNameTests
    {
        [Fact(DisplayName = "ExtractFirstName должен вернуть имя человека")]
        public void When_FullNameGiven__Expect_FirstName()
        {
            var ti = new TestImplementation();
            var result = ti.ExtractFirstName(ti.AuthorName);

            result.Should().Be("Даниил");
        }
    }
}