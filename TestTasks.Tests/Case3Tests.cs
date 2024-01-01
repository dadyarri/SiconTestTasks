using FluentAssertions;
using Xunit;

namespace TestTasks.Tests
{
    public class Case3Tests: IClassFixture<TestImplementationFixture>
    {
        private readonly TestImplementationFixture _testImplementationFixture;

        public Case3Tests(TestImplementationFixture fixture)
        {
            _testImplementationFixture = fixture;
        }
        private static string UserName => "dadyarri";


        [Fact]
        public void Call1_InitData()
        {
            _testImplementationFixture.TestImplementation.Case3_NotifyUserSecurityEvent(UserName, true);
            _testImplementationFixture.TestImplementation.Case3_NotifyUserSecurityEvent(UserName, false);
            _testImplementationFixture.TestImplementation.Case3_NotifyUserSecurityEvent(UserName, true);
            _testImplementationFixture.TestImplementation.Case3_NotifyUserSecurityEvent(UserName, false);

            _testImplementationFixture.TestImplementation.Case3_Structure.Count.Should().Be(4);
        }

        [Fact]
        public void Call2_GetAmountOfLoginsOfTheUser()
        {
            var result = _testImplementationFixture.TestImplementation.Case3_GetUserLoggedInCount(UserName);

            result.Should().Be(2);
        }
    }
}