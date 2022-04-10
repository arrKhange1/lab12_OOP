using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using lab11;


namespace lab14
{
    class GroupByWorkersLINQ
    {
       public static void GroupBy(Factory coll)
       {
           var result =  from dict in (from ceh in coll.stack select ceh.CehElem) select(from worker in dict group worker by worker.Value.positionName);

            Console.WriteLine("GroupBy LINQ\n");
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
