using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using lab11;


namespace lab14
{
    public class SelectWorkerNames_ExtensionForTest
    {
        public static int Select(Factory coll)
        {
            string ceh = "Ceh2";

            Func<Ceh, bool> searchFilter = delegate (Ceh cehh) { return cehh.Name == ceh; };
            Func<KeyValuePair<Person, Worker>, KeyValuePair<Person, Worker>> workerPrinter = delegate (KeyValuePair<Person, Worker> worker) { return worker; };

            var result = coll.stack.Where(searchFilter).First().CehElem.Select(workerPrinter);

            Console.WriteLine("Результат Extensions:\n");
            foreach (var elem in result)
                Console.WriteLine(elem.Key + ", " + elem.Value);
            Console.WriteLine("\n------------\n");

            return result.Count();
        }
    }
}
