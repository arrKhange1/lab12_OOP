using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using lab11;

namespace lab14
{
    class GroupByWorkersExtension
    {
        public static void GroupBy(Factory coll)
        {
            var result = coll.stack.Select(ceh => ceh.CehElem).Select(dict => dict.GroupBy(worker => worker.Value.positionName));
            /*
             * выбираем из стэка с классами "Цех" словари цехов
             * далее выбираем каждый словарь и для него группируем его рабочих по профессии
            */

            Console.WriteLine("GroupBy Extension\n");

            int i = result.Count();
            foreach (var ceh in result)
            {

                Console.WriteLine($"Ceh{i}:");
                foreach (var group in ceh)
                {
                    Console.WriteLine(group.Key + ": (Group Start)");
                    foreach (var worker in group) Console.WriteLine(worker.Key);
                    Console.WriteLine("---- Group End ----");
                }
                Console.WriteLine($"\n==== Ceh{i--} End ====\n");
            }
        }
    }
}
