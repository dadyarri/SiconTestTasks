using System;
using FluentAssertions;
using Xunit;

namespace TestTasks.Tests
{
    public class IsArrayEmptyTests
    {
        [Fact(DisplayName = "IsArrayEmpty должен вернуть true, когда массив пуст")]
        public void When_ArrayIsEmpty__Expect_True()
        {
            var ti = new TestImplementation();
            var result = ti.IsArrayEmpty(Array.Empty<int>());

            result.Should().BeTrue();
        }

        [Fact(DisplayName = "IsArrayEmpty должен вернуть false, когда массив не пуст")]
        public void When_ArrayIsNotEmpty__Expect_False()
        {
            var ti = new TestImplementation();
            var result = ti.IsArrayEmpty(new[] { 1, 2, 3 });

            result.Should().BeFalse();
        }
    }
}