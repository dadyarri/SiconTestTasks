using System;
using System.Collections.Generic;
using System.Text;

namespace TestTasks
{
    /// <summary>
    /// Тест на умение работать с объектами, наследованием, сериализацией
    /// </summary>
    public interface ITest4
    {
        /// <summary>
        /// Создать случайную фигуру со случайными размерами
        /// </summary>
        /// <returns></returns>
        public CustomFigure CreateRandomFigure();

        /// <summary>
        /// Сохранить фигуру в массив байт
        /// </summary>
        /// <param name="figure"></param>
        /// <returns></returns>
        public byte[] SaveToBinary(CustomFigure figure);

        /// <summary>
        /// Восстановить фигуру из массива байт
        /// </summary>
        /// <param name="binaryArr"></param>
        /// <returns></returns>
        public CustomFigure TryLoadFromBinary(byte[] binaryArr);

        /// <summary>
        /// Восстановить фигуру из массива байт, альтернативный вариант.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="binary"></param>
        /// <returns></returns>
        public T TryLoadFromBinary<T>(byte[] binary);
    }

    /// <summary>
    /// Некая геометрическая фигура обобщенно.
    /// Необходимо унаследовать от нее 3 типа фигур - круг, квадрат, прямоугольник
    /// </summary>
    public abstract class CustomFigure
    {
        /// <summary>
        /// Реализовать вычисление площади фигуры
        /// </summary>
        /// <returns></returns>
        public abstract double CalculateSquare();

        /// <inheritdoc />
        public override string ToString()
        {
            return "Ожидаем, что метод будет переопределен и будет содержать исчерпывающее описание фигуры";
        }
    }
}
