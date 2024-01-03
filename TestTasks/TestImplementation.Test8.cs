using System.Globalization;
using System.Threading;
using TestTasks.Abstract;

namespace TestTasks
{
    public partial class TestImplementation : ITest8
    {
        private readonly ThreadLocal<UserInfo> _threadState = new ThreadLocal<UserInfo>();

        public void PrepareEnvironment(string userName, CultureInfo userCulture)
        {
            _threadState.Value = new UserInfo
            {
                Username = userName,
                CultureInfo = userCulture
            };
        }

        public string GetCurrentUser()
        {
            return _threadState.Value.Username;
        }
    }

    public class UserInfo
    {
        public string Username { get; set; }
        public CultureInfo CultureInfo { get; set; }
    }
}