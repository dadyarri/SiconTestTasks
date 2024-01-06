using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using TestTasks.Abstract;

namespace TestTasks
{
    public partial class TestImplementation : ITest6
    {
        /// <summary>
        /// Калькулятор, выполняющий сложные вычисления.
        /// Присваивается извне, реализовывать его не нужно.
        /// </summary>
        public IExternalCalculator AssignedCalculator { get; set; }

        /// <summary>
        /// Очередь с данными для вычисления
        /// </summary>
        private readonly ConcurrentQueue<byte[]> _dataToCalculate = new ConcurrentQueue<byte[]>();

        /// <summary>
        /// Очередь с готовыми данными
        /// </summary>
        private readonly ConcurrentQueue<int> _calculatedHashes = new ConcurrentQueue<int>();

        /// <summary>
        /// Источник токена отмены
        /// </summary>
        private readonly CancellationTokenSource _ctSource = new CancellationTokenSource();

        private Task _processingTask;
        private readonly object _processingLock = new object();

        /// <summary>
        /// Метод, который запускает вычисление 
        /// </summary>
        private Task StartProcessing()
        {
            return Task.Factory.StartNew(async () =>
                {
                    var attemptsWithoutNewData = 0;

                    // Сколько попыток ожидания новых данных делать перед остановкой процесса (5 секунд)
                    const int maxAttemptsWithoutNewData = 50;

                    while (!_ctSource.IsCancellationRequested)
                    {
                        if (_dataToCalculate.TryDequeue(out var data))
                        {
                            var hash = AssignedCalculator.GetVeryHardCalculatedHash(data);
                            _calculatedHashes.Enqueue(hash);
                        }
                        else
                        {
                            await Task.Delay(100, _ctSource.Token);
                            attemptsWithoutNewData += 1;
                            if (attemptsWithoutNewData == maxAttemptsWithoutNewData)
                            {
                                _ctSource.Cancel();
                            }
                        }
                    }
                }, _ctSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default
            );
        }

        /// <summary>
        /// Зарегистировать новые данные для вычисления.
        /// Метод должен вернуть управление как можно скорее, не дожидаясь, пока вычисление будет выполнено.
        /// Предусмотреть вероятность одновременного вызова этого метода из нескольких потоков.
        /// Переданные данные должны попасть в AssignedCalculator.GetVeryHardCalculatedHash(), но не в вызывающем потоке,
        /// фактическое вычисление должен выполнять какой-то фоновый поток (его нужно будет реализовать).
        /// </summary>
        /// <param name="sourceData"></param>
        /// <returns></returns>
        public void RegisterDataToCalculate(byte[] sourceData)
        {
            _dataToCalculate.Enqueue(sourceData);
            lock (_processingLock)
            {
                if (_processingTask == null || _processingTask.IsCompleted)
                {
                    _processingTask = StartProcessing();
                }
            }
        }

        /// <summary>
        /// Забрать готовые результаты.
        /// Предусмотреть, что метод может вызываться многократо и одновременно с вызовом выше.
        /// Каждый результат вычисления должен возвращаться лишь однократно (повторные вызовы должны 
        /// возвращать новые результаты или пустой массив, если новых готовых вычислений еще нет).
        /// </summary>
        /// <returns></returns>
        public int[] GetCalculatedHashes()
        {
            var hashes = new int[_calculatedHashes.Count];
            _calculatedHashes.CopyTo(hashes, 0);
            return hashes;
        }
    }
}