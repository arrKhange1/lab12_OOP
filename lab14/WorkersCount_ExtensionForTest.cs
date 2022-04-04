using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using lab11;

namespace lab14
{
    public class WorkersCount_ExtensionForTest
    {
        public static int Count(Factory coll)
        {
            string prof = "Worker5";

            Func<KeyValuePair<Person, Worker>, bool> workerFilter = delegate (KeyValuePair<Person, Worker> worker) { return worker.Value.positionName == prof; };
            Func<Dictionary<Person, Worker>, int> workerSelector = delegate (Dictionary<Person, Worker> worker) { return worker.Where(workerFilter).Count(); };

            int result = coll.stack.Select((Ceh elem) => elem.CehElem).Select(workerSelector).Sum();

            Console.WriteLine($"Результат WorkerCount_Extension: {result}\n");
            Console.WriteLine("-----------\n");

            return result;
        }
    }
}
