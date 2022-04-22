using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using lab11;

namespace lab14
{
    public class MaxCehWorkersLINQ 
    {
        public static int Max(Factory coll)
        {
            int result = (from ceh in coll.stack select ceh.CehElem.Count).Max();

            Console.WriteLine($"Максимальное количество работников из всех цехов: {result}\n----------\n\n");

            return result;
        }
    }
}
