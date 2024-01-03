using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TestTasks.Abstract;

namespace TestTasks
{
    public partial class TestImplementation : ITest4
    {
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
}