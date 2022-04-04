using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lab11;

namespace lab14
{
    class ConcatLINQ
    {
        public static void Concat(Factory coll)
        {
            Console.WriteLine("Объединение профессий из первого и последнего цехов:");
           
            var result = (from worker in (from ceh in coll.stack select ceh.CehElem).First() select worker.Value.positionName).Concat(from worker in (from ceh in coll.stack select ceh.CehElem).Last() select worker.Value.positionName);

            Console.WriteLine("Результат ConcatLINQ:\n");
            foreach (var elem in result)
                Console.WriteLine(elem);
            Console.WriteLine("\n------------\n");
        }
    }
}

