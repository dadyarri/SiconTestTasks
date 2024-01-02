namespace TestTasks.Abstract
{
    /// <summary>
    /// Тест на навыки выбора оптимального формата хранения коллекции.
    /// Требуется реализовать парные вызовы с префиксами Case1_, Case2_ и т.д. (см. ниже).
    /// Каждая пара вызовов - это отдельная независимая от соседней пары история.
    /// Первый вызов (CaseNNotify...) присылает данные и заставляет складировать их в каком-то виде у себя в оперативной памяти 
    /// (что это будет, предстоит придумать самостоятельно, важно, чтобы это была какая-то стандартная .net коллекция, а не файл или БД).
    /// Второй вызов выполняет манипуляции с этой коллекцией.
    /// Коллекция, хранящая данные, должна по возможности быть подобрана таким образом, 
    /// чтобы наиболее оптимально отвечать требованиям второго вызова (того, который выполняет манипуляции над ней).
    /// Все вызовы осуществляются в одном потоке. 
    /// </summary>
    public interface ITest2
    {
        /// <summary>
        /// В систему добавили нового пользователя
        /// </summary>
        /// <param name="userName">Логин пользователя</param>
        void Case1_NotifyUserRegistered(string userName);

        /// <summary>
        /// Вернуть общее число зарегистрированных пользователей
        /// </summary>
        /// <returns></returns>
        int Case1_GetRegisteredUsersCount();

        /// <summary>
        /// Уведомить об обнаружении нового устройства 
        /// </summary>
        /// <param name="serialNumber">Серийный номер устройства</param>
        /// <returns></returns>
        string Case2_NotifyMeter(string serialNumber);

        /// <summary>
        /// Проверить, обнаружено ли указанное устройство
        /// </summary>
        /// <param name="serialNumber">Серийный номер устройства</param>
        /// <returns>true - устройство уже есть в коллекции</returns>
        bool Case2_MeterAlreadyExists(string serialNumber);

        /// <summary>
        /// Уведомить о событии входа или выхода пользователя из системы
        /// </summary>
        /// <param name="userName">Логин пользователя</param>
        /// <param name="userLoggedIn">true - пользователь вошел в систему, false - пользователь вышел</param>
        void Case3_NotifyUserSecurityEvent(string userName, bool userLoggedIn);

        /// <summary>
        /// Вернуть количество выполненных входов в систему для указанного логина
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        int Case3_GetUserLoggedInCount(string userName);

        /// <summary>
        /// Уведомить о появлении новой команды для выполнения
        /// </summary>
        /// <param name="commandCode">Код команды</param>
        /// <returns></returns>
        void Case4_NotifyCommand(int commandCode);

        /// <summary>
        /// Извлечь очередную команду из принятых по правилу FIFO 
        /// (более новые команды будут извлекаться последними).
        /// Извлеченная команда попутно удаляется из коллекции.
        /// </summary>
        /// <returns>Код команды или null, если команды закончились</returns>
        int? Case4_TryExtractNextCommand();

        /// <summary>
        /// Уведомить о смене текущего контекста 
        /// </summary>
        /// <param name="contextDescription">Новый описатель текущего контекста 
        /// (не важно, что это, какое-то строковое описание текущего окружения)</param>
        void Case5_PushContext(string contextDescription);

        /// <summary>
        /// Извлечь контекст по правилу LIFO
        /// То есть должен вернуться самый "верхний" контекст, самый свежеполученный.
        /// Извлеченный контекст попутно удаляется из коллекции
        /// </summary>
        /// <returns>Последний принятый контекст или null, если извлекать больше нечего</returns>
        string Case5_PopContext();
    }
}
