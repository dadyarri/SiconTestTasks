using System;
using FluentAssertions;
using Xunit;

namespace TestTasks.Tests
{
    public class GetSecondsBetweenDatesTests
    {
        [Fact(DisplayName = "GetSecondsBetweenDates должен вернуть количество секунд между двумя отметками времени, не отличающимися более чем на одну минуту")]
        public void When_DatesAreDiffersNotMoreThanOneMinute__Expect_AmountOfSecondsLessThanOneMinute()
        {
            var ti = new TestImplementation();
            var result = ti.GetSecondsBetweenDates(
                new DateTime(2023, 12, 28, 12, 00, 00),
                new DateTime(2023, 12, 28, 12, 00, 30)
            );

            result.Should().Be(30);
        }
        [Fact(DisplayName = "GetSecondsBetweenDates должен вернуть количество секунд между двумя отметками времени, отличающимися более чем на одну минуту")]
        public void When_DatesAreDiffersMoreThanOneMinute__Expect_AmountOfSecondsMoreThanOneMinute()
        {
            var ti = new TestImplementation();
            var result = ti.GetSecondsBetweenDates(
                new DateTime(2023, 12, 28, 12, 00, 00),
                new DateTime(2023, 12, 28, 13, 00, 30)
            );

            result.Should().Be(3630);
        }
    }
}