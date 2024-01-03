using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TestTasks.Abstract;

namespace TestTasks
{
    public partial class TestImplementation: ITest3
    {
        private ConcurrentBag<Car> Test3Structure = new ConcurrentBag<Car>();

        /// <summary>
        /// Добавить информацию об автомобиле.
        /// Учесть, что вызов может быть осуществлен одновременно из нескольких параллельных потоков.
        /// </summary>
        /// <param name="car">Информация об автомобиле</param>
        public void RegisterCar(Car car)
        {
            Test3Structure.Add(car);
        }

        /// <summary>
        /// Вернуть информацию о количестве всех автомобилей указанного цвета.
        /// Метод должен работать максимально быстро.
        /// Учесть, что вызов возможен из отдельного потока параллельно RegisterCar()
        /// </summary>
        /// <param name="color">Требуемый цвет</param>
        /// <returns></returns>
        public int GetCountByColor(Color color)
        {
            return Test3Structure.Count(car => car.Color == color);
        }

        /// <summary>
        /// Вернуть массив всех автомобилей указанного цвета и указанной модели.
        /// Метод должен работать максимально быстро.
        /// Учесть, что вызов возможен из отдельного потока параллельно RegisterCar()
        /// </summary>
        /// <param name="color">Требуемый цвет</param>
        /// <param name="model">Требуемая модель</param>
        /// <returns></returns>
        public Car[] GetCarsByColorAndModel(Color color, string model)
        {
            return Test3Structure.Where(car => car.Color == color && car.Model == model).ToArray();
        }

        /// <summary>
        /// Перечислить все автомобили, выпущенные в указанный период (включительно)
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <returns></returns>
        public IEnumerable<Car> EnumAllReleasedBetween(DateTime dt1, DateTime dt2)
        {
            return Test3Structure.Where(car => car.ReleaseDt <= dt1 && car.ReleaseDt >= dt2);
        }


    }
}