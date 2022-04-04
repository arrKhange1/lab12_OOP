using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab14
{
    public class IntersectionLINQ
    {
        public static int Intersect(Factory coll)
        {
            Console.WriteLine("Пересечение профессий из первого и последнего цехов:");

            var result = (from worker in (from ceh in coll.stack select ceh.CehElem).First() select worker.Value.positionName).Intersect(from worker in (from ceh in coll.stack select ceh.CehElem).Last() select worker.Value.positionName);

            Console.WriteLine("Результат IntersectionLINQ:\n");
            foreach (var elem in result)
                Console.WriteLine(elem);
            Console.WriteLine("\n------------\n");

            return result.Count();
        }
    }
}
