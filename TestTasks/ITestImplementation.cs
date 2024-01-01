using System;

namespace TestTasks
{
    /// <summary>
    /// Экспортируемый средствами MEF интерфейс.
    /// Он же должен реализовывать интерфейсы ITest* (все или часть, которую осилил соискатель).
    /// Если возникла сложность реализации каких-то отдельных методов интерфейсов ITest*, 
    /// эти методы должны порождать исключение NotImplementedException
    /// </summary>
    public interface ITestImplementation
    {
        /// <summary>
        /// ФИО соискателя, выполнившего тестовое задание
        /// </summary>
        string AuthorName { get; }
    }
}
