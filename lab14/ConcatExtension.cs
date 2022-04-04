using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lab11;

namespace lab14
{
    class ConcatExtension
    {
        public static void Concat(Factory coll)
        {
            Console.WriteLine("Объединение профессий первого и последнего цехов:");

            Func<KeyValuePair<Person, Worker>, string> profSelector = delegate (KeyValuePair<Person, Worker> worker) { return worker.Value.positionName; };

            var result = coll.stack.Select((Ceh ceh) => ceh.CehElem).First().Select(profSelector);
            result = result.Concat(coll.stack.Select((Ceh ceh) => ceh.CehElem).Last().Select(profSelector));

            Console.WriteLine("Результат ConcatExtension:\n");
            foreach (var elem in result)
                Console.WriteLine(elem);
            Console.WriteLine("\n------------\n");
        }
    }
}
