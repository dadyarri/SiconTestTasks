using System.Collections.Generic;
using System.Linq;
using TestTasks.Abstract;

namespace TestTasks
{
    public partial class TestImplementation: ITest2
    {
        public Dictionary<string, bool> Case1Structure = new Dictionary<string, bool>();
        public Dictionary<string, bool> Case2Structure = new Dictionary<string, bool>();
        public List<User> Case3Structure = new List<User>();
        public Queue<int> Case4Structure = new Queue<int>();
        public Stack<string> Case5Structure = new Stack<string>();
        
        /// <summary>
        /// В систему добавили нового пользователя
        /// </summary>
        /// <param name="userName">Логин пользователя</param>
        public void Case1_NotifyUserRegistered(string userName)
        {
            Case1Structure.Add(userName, true);
        }

        /// <summary>
        /// Вернуть общее число зарегистрированных пользователей
        /// </summary>
        /// <returns></returns>
        public int Case1_GetRegisteredUsersCount()
        {
            return Case1Structure.Count;
        }

        /// <summary>
        /// Уведомить об обнаружении нового устройства 
        /// </summary>
        /// <param name="serialNumber">Серийный номер устройства</param>
        /// <returns></returns>
        public string Case2_NotifyMeter(string serialNumber)
        {
            Case2Structure.Add(serialNumber, true);
            return serialNumber;
        }

        /// <summary>
        /// Проверить, обнаружено ли указанное устройство
        /// </summary>
        /// <param name="serialNumber">Серийный номер устройства</param>
        /// <returns>true - устройство уже есть в коллекции</returns>
        public bool Case2_MeterAlreadyExists(string serialNumber)
        {
            return Case2Structure.ContainsKey(serialNumber);
        }

        /// <summary>
        /// Уведомить о событии входа или выхода пользователя из системы
        /// </summary>
        /// <param name="userName">Логин пользователя</param>
        /// <param name="userLoggedIn">true - пользователь вошел в систему, false - пользователь вышел</param>
        public void Case3_NotifyUserSecurityEvent(string userName, bool userLoggedIn)
        {
            Case3Structure.Add(new User { Username = userName, IsLoggedIn = userLoggedIn });
        }

        /// <summary>
        /// Вернуть количество выполненных входов в систему для указанного логина
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public int Case3_GetUserLoggedInCount(string userName)
        {
            return Case3Structure.Count(user => user.Username == userName && user.IsLoggedIn);
        }

        /// <summary>
        /// Уведомить о появлении новой команды для выполнения
        /// </summary>
        /// <param name="commandCode">Код команды</param>
        /// <returns></returns>
        public void Case4_NotifyCommand(int commandCode)
        {
            Case4Structure.Enqueue(commandCode);
        }

        /// <summary>
        /// Извлечь очередную команду из принятых по правилу FIFO 
        /// (более новые команды будут извлекаться последними).
        /// Извлеченная команда попутно удаляется из коллекции.
        /// </summary>
        /// <returns>Код команды или null, если команды закончились</returns>
        public int? Case4_TryExtractNextCommand()
        {
            var isSucceeded = Case4Structure.TryDequeue(out var commandCode);

            return isSucceeded ? commandCode : (int?)null;
        }

        /// <summary>
        /// Уведомить о смене текущего контекста 
        /// </summary>
        /// <param name="contextDescription">Новый описатель текущего контекста 
        /// (не важно, что это, какое-то строковое описание текущего окружения)</param>
        public void Case5_PushContext(string contextDescription)
        {
            Case5Structure.Push(contextDescription);
        }

        /// <summary>
        /// Извлечь контекст по правилу LIFO
        /// То есть должен вернуться самый "верхний" контекст, самый свежеполученный.
        /// Извлеченный контекст попутно удаляется из коллекции
        /// </summary>
        /// <returns>Последний принятый контекст или null, если извлекать больше нечего</returns>
        public string Case5_PopContext()
        {
            var isSucceeded = Case5Structure.TryPop(out var result);
            return isSucceeded ? result : null;
        }


    }
}