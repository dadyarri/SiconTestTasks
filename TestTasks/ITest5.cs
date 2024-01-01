using System;
using System.Collections.Generic;
using System.Text;

namespace TestTasks
{
    /// <summary>
    /// Тест на работу с рекурсией и преобразованием коллекций
    /// </summary>
    public interface ITest5
    {
        /// <summary>
        /// Вернуть "все человечество", рожденное, начиная с переданного в качестве аргумента предка (включительно)
        /// </summary>
        /// <param name="oldestHuman"></param>
        /// <returns></returns>
        IEnumerable<HumanWithParent> EnumAllHuman(HumanWithChildren oldestHuman);

        /// <summary>
        /// Вернуть "все человечество", рожденное, начиная с переданной группы предков (включительно).
        /// Учесть, что у некоторых родитетей есть общие дети и предпринять меры по исключению дублей в итоговой коллекции
        /// </summary>
        /// <param name="oldestHumanGroup"></param>
        /// <returns></returns>
        IEnumerable<HumanWithParent> EnumAllHuman(IEnumerable<HumanWithChildren> oldestHumanGroup);
    }

    /// <summary>
    /// Класс, описывающий человека и его детей
    /// </summary>
    public class HumanWithChildren
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name;

        /// <summary>
        /// Дети человека (а у них тоже есть дети, да)
        /// </summary>
        public HumanWithChildren[] Children;
    }

    /// <summary>
    /// Класс, описывающий человека и его родителя
    /// </summary>
    public class HumanWithParent
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name;

        /// <summary>
        /// Родитель
        /// </summary>
        public HumanWithChildren Parent;
    }
}
