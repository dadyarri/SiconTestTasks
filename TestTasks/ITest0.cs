using System;

namespace TestTasks
{
    /// <summary>
    /// Тест на базовые знания C#
    /// Этот интерфейс обязателен к реализации!
    /// </summary>
    public interface ITest0
    {
        /// <summary>
        /// Проверить, является ли число четным
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool IsEven(int value);

        /// <summary>
        /// Определить, сколько секунд между двумя моментами времени
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <returns></returns>
        int GetSecondsBetweenDates(DateTime dt1, DateTime dt2);

        /// <summary>
        /// Есть строка полного имени человека в формате "Фамилия Имя Отчество"
        /// Требуется вернуть Имя
        /// </summary>
        /// <param name="fullName">ФИО</param>
        /// <returns></returns>
        string ExtractFirstName(string fullName);

        /// <summary>
        /// Вернуть массив байт с элементами, расположенными в обратном порядке 
        /// </summary>
        /// <param name="value">Исходный массив байт</param>
        /// <returns></returns>
        byte[] Reverse(byte[] value);

        /// <summary>
        /// Сохранить строку в файл
        /// </summary>
        /// <param name="textToSave"></param>
        /// <param name="fileName"></param>
        void WriteText(string textToSave, string fileName);

        /// <summary>
        /// Прочитать содержимое текстового файла
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        string ReadText(string fileName);

        /// <summary>
        /// Проверить, является ли массив пустым
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool IsArrayEmpty(int[] value);
    }

}
