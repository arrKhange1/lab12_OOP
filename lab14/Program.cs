using System;
using System.Collections.Generic;
using lab11;

namespace lab14
{
    class Program
    {
        static void Main(string[] args)
        {
            SelectLab12Collection.Select();
            CountLab12Collection.Count();
            AggregateLab12Collection.Aggregate();

            Factory collection = new Factory();
            
            Filler.Fill(collection, 5);

            Printer.Print(collection);

            SelectWorkerNames_LINQ.Select(collection);
            SelectWorkerNames_Extension.Select(collection);

            WorkersCount_LINQ.Count(collection);
            WorkersCount_Extension.Count(collection);

            IntersectionLINQ.Intersect(collection);
            IntersectionExtension.Intersect(collection);

            ConcatLINQ.Concat(collection);
            ConcatExtension.Concat(collection);

            MaxCehWorkersLINQ.Max(collection);
            MaxCehWorkersExtension.Max(collection);

            GroupByWorkersLINQ.GroupBy(collection);
            GroupByWorkersExtension.GroupBy(collection);

        }
    }
}
