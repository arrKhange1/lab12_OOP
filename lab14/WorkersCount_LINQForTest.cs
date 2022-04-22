using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab14
{
    public class WorkersCount_LINQForTest // кол-во рабочих заданной профессии
    {
        public static int Count(Factory coll)
        {
            string prof = "Worker5";

            int result = (from dict in (from ceh in coll.stack select ceh.CehElem) select (from worker in dict where worker.Value.positionName == prof select worker).Count()).Sum();

            /*
             * сначала получаем из коллекции цехов коллекцию словарей этих цехов
             * далее для каждого словаря селектуем выбираем кол-во работников заданной профессии, проходясь по этому словарю в селекте
             * на последнем этапе суммируем элементы итоговой коллекции с числами, получая итоговое кол-во работников со всех цехов заданной профессии
             */

            Console.WriteLine($"Результат WorkerCount_LINQ: {result}\n");
            Console.WriteLine("-----------\n");

            return result;
        }
    }
}
