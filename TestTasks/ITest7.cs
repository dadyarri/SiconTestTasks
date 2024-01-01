using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestTasks
{
    /// <summary>
    /// Альтернативная реализация задачи предыдущего теста.
    /// Ставка на максимальную производительность.
    /// </summary>
    public interface ITest7
    {
        /// <summary>
        /// Калькулятор, выполняющий сложные вычисления.
        /// Присваивается извне, реализовывать его не нужно.
        /// </summary>
        IExternalCalculator AssignedCalculator { get; set; }

        /// <summary>
        /// Синхронно вычислить сразу все хэши, задействовав при этом все возможные ресурсы CPU, 
        /// чтобы вернуть результат как можно скорее
        /// </summary>
        /// <param name="sourceArrays"></param>
        /// <returns></returns>
        int[] CalculateHashes(byte[][] sourceArrays);
    }
}
