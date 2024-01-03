using System;
using System.Collections.Generic;
using System.Linq;
using TestTasks.Abstract;

namespace TestTasks
{
    public partial class TestImplementation: ITest1
    {
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

    }
}