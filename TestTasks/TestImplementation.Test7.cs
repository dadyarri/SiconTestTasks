using System;
using System.Linq;
using System.Threading.Tasks;
using TestTasks.Abstract;

namespace TestTasks
{
    public partial class TestImplementation : ITest7
    {
        /// <summary>
        /// Синхронно вычислить сразу все хэши, задействовав при этом все возможные ресурсы CPU, 
        /// чтобы вернуть результат как можно скорее
        /// </summary>
        /// <param name="sourceArrays"></param>
        /// <returns></returns>
        public int[] CalculateHashes(byte[][] sourceArrays)
        {
            var hashes = new int[sourceArrays.Length];

            Parallel.ForEach(sourceArrays.AsParallel().WithDegreeOfParallelism(Environment.ProcessorCount),
                sourceData => hashes[Array.IndexOf(sourceArrays, sourceData)] =
                    AssignedCalculator.GetVeryHardCalculatedHash(sourceData));

            return hashes;
        }
    }
}