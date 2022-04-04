using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using lab11;

namespace lab14
{
    class MaxCehWorkersLINQ 
    {
        public static void Max(Factory coll)
        {
            int result = (from ceh in coll.stack select ceh.CehElem.Count).Max();

            Console.WriteLine($"Максимальное количество работников из всех цехов: {result}\n----------\n\n");
        }
    }
}
