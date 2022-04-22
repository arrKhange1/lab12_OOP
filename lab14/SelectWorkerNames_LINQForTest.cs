using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lab11;

namespace lab14
{
    public class SelectWorkerNames_LINQForTest
    {
        public static int Select(Factory coll)
        {
            string ceh = "Ceh2";

            var result = from workerName in (from dep in coll.stack where dep.Name == ceh select dep).First().CehElem select workerName;

            Console.WriteLine("Результат LINQ:\n");
            foreach (var elem in result)
                Console.WriteLine(elem);
            Console.WriteLine("\n------------\n");

            return result.Count();
        }
    }
}
