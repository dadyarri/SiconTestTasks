using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TestTasks
{
    /// <summary>
    /// Работа с окружением потока в условиях многопоточности 
    /// </summary>
    public interface ITest8
    {
        /// <summary>
        /// Подготовить информацию об окружениии текущего потока
        /// Метод может вызываться одновременно из нескольких потоков.
        /// </summary>
        /// <param name="userName">Логин пользователя</param>
        /// <param name="userCulture">Настройки локализации текущего пользователя</param>
        void PrepareEnvironment(string userName, CultureInfo userCulture);

        /// <summary>
        /// Вернуть логин текущего пользователя. Должен вернуться userName, 
        /// переданный в предварительном вызове PrepareEnvironment() текущего потока.
        /// </summary>
        /// <returns></returns>
        string GetCurrentUser();
    }
}
