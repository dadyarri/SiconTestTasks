using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace TestTasks
{
    public class TestImplementation : ITestImplementation, ITest0, ITest1, ITest2, ITest4
    {
        public string AuthorName => "Голубев Даниил Олегович";
        public Dictionary<string, bool> Case1_Structure = new Dictionary<string, bool>();
        public Dictionary<string, bool> Case2_Structure = new Dictionary<string, bool>();
        public List<User> Case3_Structure = new List<User>();
        public Queue<int> Case4_Structure = new Queue<int>();
        public Stack<string> Case5_Structure = new Stack<string>();

        /// <summary>
        /// Проверить, является ли число четным
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Флаг, указывающий на чётность числа</returns>
        public bool IsEven(int value)
        {
            return value % 2 == 0;
        }

        /// <summary>
        /// Определить, сколько секунд между двумя моментами времени
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <returns>Количество секунд между двумя моментами времени</returns>
        public int GetSecondsBetweenDates(DateTime dt1, DateTime dt2)
        {
            return (int)Math.Abs((dt1 - dt2).TotalSeconds);
        }

        /// <summary>
        /// Есть строка полного имени человека в формате "Фамилия Имя Отчество"
        /// Требуется вернуть Имя
        /// </summary>
        /// <param name="fullName">ФИО</param>
        /// <returns>Имя человека</returns>
        public string ExtractFirstName(string fullName)
        {
            return fullName.Split(" ")[1];
        }

        /// <summary>
        /// Вернуть массив байт с элементами, расположенными в обратном порядке 
        /// </summary>
        /// <param name="value">Исходный массив байт</param>
        /// <returns>Перевёрнутый массив байт</returns>
        public byte[] Reverse(byte[] value)
        {
            return value.Reverse().ToArray();
        }

        /// <summary>
        /// Сохранить строку в файл
        /// </summary>
        /// <param name="textToSave">Текст, который нужно сохранить в файл</param>
        /// <param name="fileName">Путь до файла, в который текст должен быть сохранён</param>
        public void WriteText(string textToSave, string fileName)
        {
            File.WriteAllText(fileName, textToSave);
        }

        /// <summary>
        /// Прочитать содержимое текстового файла
        /// </summary>
        /// <param name="fileName">Путь до файла</param>
        /// <returns></returns>
        public string ReadText(string fileName)
        {
            return File.ReadAllText(fileName);
        }

        /// <summary>
        /// Проверить, является ли массив пустым
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool IsArrayEmpty(int[] value)
        {
            return value.Length == 0;
        }

        /// <summary>
        /// Вернуть коллекцию строк в виде одной строки с разделителем
        /// </summary>
        /// <param name="largeStringCollection">Коллекция строк. Учесть, что она может быть внушительной.</param>
        /// <param name="delimiter">Разделитель</param>
        /// <returns></returns>
        public string ToOneString(IEnumerable<string> largeStringCollection, string delimiter)
        {
            return string.Join(delimiter, largeStringCollection);
        }

        /// <summary>
        /// Вернуть массив чисел, исключив все дубли (повторяющиеся значения) из исходного массива
        /// </summary>
        /// <param name="intArr"></param>
        /// <returns></returns>
        public int[] RemoveDuplcates(int[] intArr)
        {
            return intArr.Distinct().ToArray();
        }

        /// <summary>
        /// Вернуть все дни (дата со значение времени 00:00:00) между переданными датами
        /// </summary>
        /// <param name="lowDt">Нижняя граница времени</param>
        /// <param name="highDt">Верхняя граница времени</param>
        /// <returns></returns>
        public IEnumerable<DateTime> EnumDaysBetween(DateTime lowDt, DateTime highDt)
        {
            var currentDt = lowDt;
            while (currentDt < highDt)
            {
                yield return currentDt;
                currentDt = currentDt.AddDays(1);
            }
        }

        /// <summary>
        /// Вернуть количество элементов массива со значением, превышающим указанное
        /// </summary>
        /// <param name="sourceArray">Коллекция чисел</param>
        /// <param name="value">Пороговое значение</param>
        /// <returns></returns>
        public int GetCountLargerThanValue(int[] sourceArray, int value)
        {
            return sourceArray.Count(e => e > value);
        }

        /// <summary>
        /// Вернуть сумму всех элементов
        /// </summary>
        /// <param name="sourceArray">Массив чисел, сумму которых требуется вычислить</param>
        /// <returns></returns>
        public int CalculateSumm(int[] sourceArray)
        {
            return sourceArray.Sum();
        }

        /// <summary>
        /// Получить массив элементов только нужного типа из исходной разнотипной коллекции
        /// </summary>
        /// <typeparam name="T">Тип интересующих элементов</typeparam>
        /// <param name="manyObjectsCollection">Коллекция элементов разных типов</param>
        /// <returns></returns>
        public T[] ExtractOnlyWantedType<T>(object[] manyObjectsCollection)
        {
            return manyObjectsCollection.OfType<T>().ToArray();
        }

        /// <summary>
        /// Получить число отфильтрованных внешним фильтром элементов
        /// </summary>
        /// <typeparam name="T">Тип элементов коллекции</typeparam>
        /// <param name="collection">Коллекция элементов</param>
        /// <param name="filter">Внешняя финкция-фильтр элементов, возвращает true, если элемент участвует в вычислении,
        /// false - элемент выкидывыется из анализа</param>
        /// <returns></returns>
        public int GetFilteredCount<T>(IEnumerable<T> collection, Func<T, bool> filter)
        {
            return collection.Count(filter);
        }

        /// <summary>
        /// Вернуть коллекцию всех чисел из диапазона ulong.MinValue до ulong.MaxValue
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ulong> EnumAllValues()
        {
            for (var i = ulong.MinValue; i < ulong.MaxValue; i++)
            {
                yield return i;
            }
        }

        /// <summary>
        /// В систему добавили нового пользователя
        /// </summary>
        /// <param name="userName">Логин пользователя</param>
        public void Case1_NotifyUserRegistered(string userName)
        {
            Case1_Structure.Add(userName, true);
        }

        /// <summary>
        /// Вернуть общее число зарегистрированных пользователей
        /// </summary>
        /// <returns></returns>
        public int Case1_GetRegisteredUsersCount()
        {
            return Case1_Structure.Count;
        }

        /// <summary>
        /// Уведомить об обнаружении нового устройства 
        /// </summary>
        /// <param name="serialNumber">Серийный номер устройства</param>
        /// <returns></returns>
        public string Case2_NotifyMeter(string serialNumber)
        {
            Case2_Structure.Add(serialNumber, true);
            return serialNumber;
        }

        /// <summary>
        /// Проверить, обнаружено ли указанное устройство
        /// </summary>
        /// <param name="serialNumber">Серийный номер устройства</param>
        /// <returns>true - устройство уже есть в коллекции</returns>
        public bool Case2_MeterAlreadyExists(string serialNumber)
        {
            return Case2_Structure.ContainsKey(serialNumber);
        }

        /// <summary>
        /// Уведомить о событии входа или выхода пользователя из системы
        /// </summary>
        /// <param name="userName">Логин пользователя</param>
        /// <param name="userLoggedIn">true - пользователь вошел в систему, false - пользователь вышел</param>
        public void Case3_NotifyUserSecurityEvent(string userName, bool userLoggedIn)
        {
            Case3_Structure.Add(new User { Username = userName, IsLoggedIn = userLoggedIn });
        }

        /// <summary>
        /// Вернуть количество выполненных входов в систему для указанного логина
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public int Case3_GetUserLoggedInCount(string userName)
        {
            return Case3_Structure.Count(user => user.Username == userName && user.IsLoggedIn);
        }

        /// <summary>
        /// Уведомить о появлении новой команды для выполнения
        /// </summary>
        /// <param name="commandCode">Код команды</param>
        /// <returns></returns>
        public void Case4_NotifyCommand(int commandCode)
        {
            Case4_Structure.Enqueue(commandCode);
        }

        /// <summary>
        /// Извлечь очередную команду из принятых по правилу FIFO 
        /// (более новые команды будут извлекаться последними).
        /// Извлеченная команда попутно удаляется из коллекции.
        /// </summary>
        /// <returns>Код команды или null, если команды закончились</returns>
        public int? Case4_TryExtractNextCommand()
        {
            var isSucceeded = Case4_Structure.TryDequeue(out var commandCode);

            return isSucceeded ? commandCode : (int?)null;
        }

        /// <summary>
        /// Уведомить о смене текущего контекста 
        /// </summary>
        /// <param name="contextDescription">Новый описатель текущего контекста 
        /// (не важно, что это, какое-то строковое описание текущего окружения)</param>
        public void Case5_PushContext(string contextDescription)
        {
            Case5_Structure.Push(contextDescription);
        }

        /// <summary>
        /// Извлечь контекст по правилу LIFO
        /// То есть должен вернуться самый "верхний" контекст, самый свежеполученный.
        /// Извлеченный контекст попутно удаляется из коллекции
        /// </summary>
        /// <returns>Последний принятый контекст или null, если извлекать больше нечего</returns>
        public string Case5_PopContext()
        {
            var isSucceeded = Case5_Structure.TryPop(out var result);
            return isSucceeded ? result : null;
        }

        /// <summary>
        /// Создать случайную фигуру со случайными размерами
        /// </summary>
        /// <returns></returns>
        public CustomFigure CreateRandomFigure()
        {
            var random = new Random();
            var randomValue = random.Next(0, 3);
            return randomValue switch
            {
                0 => new Circle { Radius = random.NextDouble() },
                1 => new Rectangle { SideALength = random.NextDouble(), SideBLength = random.NextDouble() },
                2 => new Square { SideALength = random.NextDouble() },
                _ => throw new ArgumentException("Неподдерживаемое значение")
            };
        }

        /// <summary>
        /// Сохранить фигуру в массив байт
        /// </summary>
        /// <param name="figure"></param>
        /// <returns></returns>
        public byte[] SaveToBinary(CustomFigure figure)
        {
            var bf = new BinaryFormatter();
            using var ms = new MemoryStream();
            bf.Serialize(ms, figure);
            return ms.ToArray();
        }

        /// <summary>
        /// Восстановить фигуру из массива байт
        /// </summary>
        /// <param name="binaryArr"></param>
        /// <returns></returns>
        public CustomFigure TryLoadFromBinary(byte[] binaryArr)
        {
            var bf = new BinaryFormatter();
            using var ms = new MemoryStream(binaryArr);
            return (CustomFigure)bf.Deserialize(ms);
        }

        /// <summary>
        /// Восстановить фигуру из массива байт, альтернативный вариант.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="binary"></param>
        /// <returns></returns>
        public T TryLoadFromBinary<T>(byte[] binary)
        {
            var bf = new BinaryFormatter();
            using var ms = new MemoryStream(binary);
            return (T)bf.Deserialize(ms);
        }
    }

    public class Square : Rectangle
    {
        public new double SideALength { get; set; }
        public new double SideBLength
        {
            get => SideALength;
            private set => SideALength = value;
        }

        public override string ToString()
        {
            return "Квадрат — прямоугольник, у которого все стороны равны";
        }
    }

    public class Rectangle : CustomFigure
    {
        public double SideALength { get; set; }
        public double SideBLength { get; set; }

        public override double CalculateSquare()
        {
            return SideALength * SideBLength;
        }

        public override string ToString()
        {
            return "Прямоугольник — четырёхугольник, у которого все углы прямые (равны 90 градусов)";
        }
    }

    public class Circle : CustomFigure
    {
        public double Radius { get; set; }

        public override double CalculateSquare()
        {
            return Math.PI * Radius * Radius;
        }

        public override string ToString()
        {
            return "Круг — часть плоскости, которая лежит внутри окружности";
        }
    }


    public struct User
    {
        public string Username { get; set; }
        public bool IsLoggedIn { get; set; }
    }
}