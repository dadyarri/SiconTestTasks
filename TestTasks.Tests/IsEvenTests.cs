using FluentAssertions;
using Xunit;

namespace TestTasks.Tests
{
    public class IsEvenTests
    {
        [Fact(DisplayName = "IsEven должен вернуть true, когда получил на вход чётное число")]
        public void When_EvenNumberGiven__Expect_True()
        {
            var ti = new TestImplementation();
            var result = ti.IsEven(2);

            result.Should().BeTrue();
        }
        
        [Fact(DisplayName = "IsEven должен вернуть false, когда получил на вход нечётное число")]
        public void When_OddNumberGiven__Expect_False()
        {
            var ti = new TestImplementation();
            var result = ti.IsEven(3);

            result.Should().BeFalse();
        }
    }
}