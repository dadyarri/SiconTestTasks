using System;
using TestTasks.Abstract;

namespace TestTasks
{
    /// <summary>
    /// Тест на навыки работы с состояниями (конечные автоматы)
    /// Предположим, есть модем, который умеет по команде дозваниваться до нужного номера, 
    /// в случае успешного дозвона позволяет обмениваться с удаленным устройством данными, 
    /// а также обрывает соединение по команде, когда соединение больше не требуется.
    ///
    /// Необходимо реализовать логику выдачи команд модему таким образом, чтобы "выполнился" успешный 
    /// опрос устройства. Успешным считаетя опрос, при котором:
    /// - модем был настроен;
    /// - модем набрал номер;
    /// - произошла серия обменов запрос-ответ с устройством (пусть это будет серия из 5 успешных пар запрос-ответ;
    /// - модем положил трубку по команде.
    /// 
    /// Следует учесть, что:
    /// - номер может не набраться;
    /// - установленное соединение может разорваться;
    /// - модем может зависнуть и не набирать номер, отвечая ошибкой, в этом случае поможет только перезагрузка модема 
    /// (на команду перезагрузки модем отреагирует всегда)
    /// 
    /// Перед самым первым вызовом модем бездействует, трубка положена.
    /// Все вызовы выполняются в одном потоке.
    /// </summary>
    public partial class TestImplementation : ITest9
    {
        private enum ModemState
        {
            Inactive,
            SettingUp,
            Calling,
            Connected,
            Error
        }

        private ModemState _currentState = ModemState.Inactive;
        private int _dialAttempts;
        private int _successfulRequests;

        /// <summary>
        /// Дать очередную команду модему
        /// </summary>
        /// <returns></returns>
        public ModemCommand GetModemCommand()
        {
            switch (_currentState)
            {
                case ModemState.Inactive:
                    return ModemCommand.Setup;
                case ModemState.SettingUp:
                    return ModemCommand.Call;
                case ModemState.Calling:
                    if (_dialAttempts >= 5)
                    {
                        _dialAttempts = 0;
                        return ModemCommand.Restart;
                    }
                    _dialAttempts++;
                    return ModemCommand.Call;
                case ModemState.Connected:
                    return _successfulRequests < 5 ? ModemCommand.SendRequest : ModemCommand.HangUp;

                case ModemState.Error:
                    return ModemCommand.Restart;
                default:
                    throw new InvalidOperationException("Некорректное состояние модема");
            }
        }

        /// <summary>
        /// Получить ответ со стороны модема
        /// </summary>
        /// <param name="answer"></param>
        public void NotifyModemAnswer(ModemAnswer answer)
        {
            switch (_currentState)
            {
                case ModemState.SettingUp:
                    _currentState = answer == ModemAnswer.Ok ? ModemState.Calling : ModemState.Error;
                    break;
                case ModemState.Calling:
                    switch (answer)
                    {
                        case ModemAnswer.Ok:
                            _currentState = ModemState.Connected;
                            _successfulRequests = 0;
                            break;
                        case ModemAnswer.Buzy:
                            break;
                        case ModemAnswer.Response:
                            break;
                        case ModemAnswer.Error:
                        default:
                            _currentState = ModemState.Error;
                            break;
                    }

                    break;
                case ModemState.Connected:
                    if (answer == ModemAnswer.Response)
                    {
                        _successfulRequests++;
                    }
                    else
                    {
                        _currentState = ModemState.Error;
                    }

                    break;
                case ModemState.Error:
                    if (answer == ModemAnswer.Ok)
                    {
                        _currentState = ModemState.Inactive;
                    }

                    break;
                case ModemState.Inactive:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(answer), "Некорректное состояние модема");
            }
        }
    }
}