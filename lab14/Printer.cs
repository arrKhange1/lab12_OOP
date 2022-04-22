using System;
using System.Collections.Generic;
using System.Text;
using lab11;

namespace lab14
{
    class Printer
    {
        public static void Print(Factory coll)
        {
            int i = 0;
            foreach(var dict in coll.stack)
            {
                Console.WriteLine($"{i+1} dictName = {dict.Name}:\n");
                foreach (KeyValuePair<Person, Worker> elem in dict.CehElem) Console.WriteLine($"Key: {elem.Key.FirstName}; Value: {elem.Value.FirstName}, {elem.Value.factoryName}, {elem.Value.positionName}");
                ++i;
                Console.WriteLine();
            }
        }
    }
}
