using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TestTasks
{
    /// <summary>
    /// Тест на умение работать в многопоточной среде,
    /// а также на навыки выбора оптимального формата из стандартных классов-коллекций.
    /// Требуется реализовать какое-то собственное хранилище 
    /// (в любом формате в оперативной памяти без привлечения файлов/СУБД/проч.),
    /// которое будет принимать информацию об автомобилях и позволять анализировать итоговое наполнение.
    /// </summary>
    public interface ITest3
    {
        /// <summary>
        /// Добавить информацию об автомобиле.
        /// Учесть, что вызов может быть осуществлен одновременно из нескольких параллельных потоков.
        /// </summary>
        /// <param name="car">Информация об автомобиле</param>
        void RegisterCar(Car car);

        /// <summary>
        /// Вернуть информацию о количестве всех автомобилей указанного цвета.
        /// Метод должен работать максимально быстро.
        /// Учесть, что вызов возможен из отдельного потока параллельно RegisterCar()
        /// </summary>
        /// <param name="color">Требуемый цвет</param>
        /// <returns></returns>
        int GetCountByColor(Color color);

        /// <summary>
        /// Вернуть массив всех автомобилей указанного цвета и указанной модели.
        /// Метод должен работать максимально быстро.
        /// Учесть, что вызов возможен из отдельного потока параллельно RegisterCar()
        /// </summary>
        /// <param name="color">Требуемый цвет</param>
        /// <param name="model">Требуемая модель</param>
        /// <returns></returns>
        Car[] GetCarsByColorAndModel(Color color, string model);

        /// <summary>
        /// Перечислить все автомобили, выпущенные в указанный период (включительно)
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <returns></returns>
        IEnumerable<Car> EnumAllReleasedBetween(DateTime dt1, DateTime dt2);
    }

    /// <summary>
    /// Описание автомобиля
    /// </summary>
    public class Car
    {
        /// <summary>
        /// Описание модели
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Цвет автомобиля
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Дата выпуска
        /// </summary>
        public DateTime ReleaseDt { get; set; }
    }
}
