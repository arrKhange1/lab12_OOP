using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lab11;

namespace lab14
{
    public class IntersectionExtension
    {
        public static int Intersect(Factory coll)
        {
            Console.WriteLine("Пересечение профессий из первого и последнего цехов:");


            Func<KeyValuePair<Person, Worker>, string> profSelector = delegate (KeyValuePair<Person, Worker> worker) { return worker.Value.positionName; };

            var result = coll.stack.Select((Ceh ceh) => ceh.CehElem).First().Select(profSelector);
            result = result.Intersect(coll.stack.Select((Ceh ceh) => ceh.CehElem).Last().Select(profSelector));

            Console.WriteLine("Результат IntersectionExtension:\n");
            foreach (var elem in result)
                Console.WriteLine(elem);
            Console.WriteLine("\n------------\n");

            return result.Count();
        }
    }
}
