using System.Collections.Generic;
using TestTasks.Abstract;

namespace TestTasks
{
    public partial class TestImplementation: ITest5
    {
        /// <summary>
        /// Вернуть "все человечество", рожденное, начиная с переданного в качестве аргумента предка (включительно)
        /// </summary>
        /// <param name="oldestHuman"></param>
        /// <returns></returns>
        public IEnumerable<HumanWithParent> EnumAllHuman(HumanWithChildren oldestHuman)
        {
            return EnumerateHumans(oldestHuman, null);
        }

        /// <summary>
        /// Вернуть "все человечество", рожденное, начиная с переданной группы предков (включительно).
        /// Учесть, что у некоторых родитетей есть общие дети и предпринять меры по исключению дублей в итоговой коллекции
        /// </summary>
        /// <param name="oldestHumanGroup"></param>
        /// <returns></returns>
        public IEnumerable<HumanWithParent> EnumAllHuman(IEnumerable<HumanWithChildren> oldestHumanGroup)
        {
            foreach (var oldestHuman in oldestHumanGroup)
            {
                var visitedHumans = new HashSet<string>();
                foreach (var humanWithParent in EnumerateHumans(oldestHuman, null, visitedHumans))
                {
                    yield return humanWithParent;
                }
            }
        }

        private static IEnumerable<HumanWithParent> EnumerateHumans(HumanWithChildren currentHuman,
            HumanWithChildren parent)
        {
            if (currentHuman == null) yield break;

            yield return new HumanWithParent { Name = currentHuman.Name, Parent = parent };

            if (currentHuman.Children == null) yield break;

            foreach (var child in currentHuman.Children)
            {
                foreach (var grandchild in EnumerateHumans(child, currentHuman))
                {
                    yield return grandchild;
                }
            }
        }

        private static IEnumerable<HumanWithParent> EnumerateHumans(HumanWithChildren currentHuman,
            HumanWithChildren parent, HashSet<string> visitedHumans)
        {
            if (currentHuman == null) yield break;

            if (!visitedHumans.Add(currentHuman.Name)) yield break;

            yield return new HumanWithParent { Name = currentHuman.Name, Parent = parent };

            if (currentHuman.Children == null) yield break;

            foreach (var child in currentHuman.Children)
            {
                foreach (var grandchild in EnumerateHumans(child, currentHuman, visitedHumans))
                {
                    yield return grandchild;
                }
            }
        }
    }
}