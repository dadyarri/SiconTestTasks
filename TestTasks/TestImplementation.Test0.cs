using System;
using System.IO;
using System.Linq;
using TestTasks.Abstract;

namespace TestTasks
{
    public partial class TestImplementation: ITest0
    {
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
    }
}