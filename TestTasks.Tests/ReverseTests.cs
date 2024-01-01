using FluentAssertions;
using Xunit;

namespace TestTasks.Tests
{
    public class ReverseTests
    {
        [Fact(DisplayName = "Reverse должен вернуть перевёрнутый массив байт")]
        public void When_ByteArrayGiven__ExpectSameReversedByteArray()
        {
            var ti = new TestImplementation();
            var result = ti.Reverse(new byte[] { 1, 2, 3 });

            result.Should().Equal(3, 2, 1);
        }
    }
}