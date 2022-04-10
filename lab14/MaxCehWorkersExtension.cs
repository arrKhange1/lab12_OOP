using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using lab11;

namespace lab14
{
    public class MaxCehWorkersExtension
    {
        public static int Max(Factory coll)
        {
            int result = coll.stack.Select(ceh => ceh.CehElem.Count).Aggregate((a,b) => Math.Max(a,b));

            Console.WriteLine($"Максимальное количество работников из всех цехов: {result}\n----------\n\n");

            return result;
        }
    }
}
